using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace CalibreTools
{
    public partial class CalibreTools : Form
    {
        private SQLiteConnection m_dbConnection = null;
        private String m_strCalibreRoot = "";        

        public CalibreTools()
        {
            InitializeComponent();
        }

        private void CalibreTools_FormClosing(object sender, FormClosingEventArgs e)
        {
            buttonClose_Click(sender, e);
        }

        #region 库目录
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogLib.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxPath.Text = openFileDialogLib.FileName;
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (m_dbConnection != null)
            {
                m_dbConnection.Close();
                m_dbConnection = null;
            }

            m_dbConnection = new SQLiteConnection(String.Format("Data Source={0}",textBoxPath.Text));
            m_dbConnection.Open();

            try
            {
                string sql = "DROP TRIGGER books_update_trg;";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                buttonRefresh.Enabled = true;
                buttonMove.Enabled = true;
                buttonAddCatalog.Enabled = true;
                buttonEditCatalog.Enabled = true;
                buttonRefreshCatalog.Enabled = true;
                buttonImportCatalog.Enabled = true;
            }
            catch (Exception)
            {
            }

            m_strCalibreRoot = Path.GetDirectoryName(textBoxPath.Text);

            MessageBox.Show(this,"打开操作成功，操作前请先关闭Calibre应用");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (m_dbConnection != null)
            {
                try
                {
                    string sql =
                    "CREATE TRIGGER books_update_trg AFTER UPDATE ON books " +
                    "BEGIN " +
                        "UPDATE books SET sort=title_sort(NEW.title) WHERE id=NEW.id AND OLD.title <> NEW.title;" +
                    "END";
                    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();

                    buttonRefresh.Enabled = false;
                    buttonMove.Enabled = false;
                    buttonAddCatalog.Enabled = false;
                    buttonEditCatalog.Enabled = false;
                    buttonRefreshCatalog.Enabled = false;
                    buttonImportCatalog.Enabled = false;
                }
                catch (Exception)
                {
                }

                m_dbConnection.Close();
                m_dbConnection = null;

                MessageBox.Show(this,"关闭操作成功");
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            listViewBooks.Items.Clear();

            string sql = "select id,title,path from books";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(
                    new string[]
                    {
                        reader["title"] as string,
                        reader["path"] as string
                    });
                item.Tag = reader["id"];
                listViewBooks.Items.Add(item);
            }
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            string strMoveFolder = "";
            if (listViewBooks.SelectedItems.Count > 0)
            {
                folderBrowserDialogLib.SelectedPath = m_strCalibreRoot;
                DialogResult result = folderBrowserDialogLib.ShowDialog();
                if (result == DialogResult.OK)
                {
                    strMoveFolder = folderBrowserDialogLib.SelectedPath;
                }
            }

            if (string.IsNullOrEmpty(strMoveFolder))
            {
                return;
            }

            if (!strMoveFolder.StartsWith(m_strCalibreRoot))
            {
                return;
            }

            string newPathValue = strMoveFolder.Remove(0, m_strCalibreRoot.Length+1);
            newPathValue = newPathValue.Replace('\\', '/');

            foreach (ListViewItem item in listViewBooks.SelectedItems)
            {
                string sourceFolder = Path.Combine(m_strCalibreRoot,item.SubItems[1].Text);
                if (Directory.Exists(sourceFolder))
                {
                    try
                    {
                        string sql = "update books set path='{0}' where id={1}";
                        // 使用中文名代替拼音
                        string title = item.SubItems[0].Text;
                        string parentFolder = "/" + title;
                        string newPath = newPathValue + parentFolder;
                        if (Directory.Exists(strMoveFolder + parentFolder))
                        {
                            MessageBox.Show("目标目录\"" + strMoveFolder + parentFolder + "\"已经存在，请换一个目录");
                            continue;
                        }

                        SQLiteCommand command = new SQLiteCommand(string.Format(sql, newPath, item.Tag), m_dbConnection);
                        if (command.ExecuteNonQuery() > 0)
                        {
                            Directory.Move(sourceFolder, strMoveFolder + parentFolder);
                            item.SubItems[1].Text = newPath;

                            // 判断父目录是否为空
                            sourceFolder = sourceFolder.Substring(0, sourceFolder.LastIndexOf('/'));
                            if (Directory.Exists(sourceFolder) &&
                                (Directory.GetDirectories(sourceFolder).Count() == 0))
                            {
                                Directory.Delete(sourceFolder);
                            }

                            // 更改文件名
                            object dataIdx = 0;
                            string dataFormat = null;
                            string dataName = null;
                            string dataSql = "select id,format,name from data where book={0}";
                            SQLiteCommand dataCmd = new SQLiteCommand(string.Format(dataSql, item.Tag), m_dbConnection);
                            SQLiteDataReader reader = dataCmd.ExecuteReader();
                            if (reader.Read())
                            {
                                dataIdx = reader["id"];
                                dataFormat = reader["format"] as string;
                                dataName = reader["name"] as string;
                            }

                            if (string.IsNullOrEmpty(dataFormat) || string.IsNullOrEmpty(dataName))
                            {
                                continue;
                            }

                            if (string.Compare(dataName, title, true) != 0)
                            {
                                string sourceFile = strMoveFolder + parentFolder + "/" + dataName + "." + dataFormat;
                                string destFile = strMoveFolder + parentFolder + "/" + title + "." + dataFormat;
                                new FileInfo(sourceFile).MoveTo(destFile);

                                dataSql = "update data set name='{0}' where id = {1}";
                                dataCmd = new SQLiteCommand(string.Format(dataSql, title, dataIdx), m_dbConnection);
                                dataCmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this,"发生异常，" + ex.Message);
                    }
                }
            }
        }
        #endregion

        #region 用户目录
        private void buttonRefreshCatalog_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select val from preferences where key='user_categories'";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string value = reader["val"] as string;
                    JObject jo = JObject.Parse(value);
                    if (jo.Count > 0)
                    {
                        UserCatalog userCatalog = new UserCatalog();
                        foreach (var child in jo)
                        {
                            List<CatalogItem> items = new List<CatalogItem>();
                            JArray childObjs = JArray.Parse(child.Value.ToString());
                            if (childObjs.Count > 0)
                            {
                                foreach(var item in childObjs)
                                {
                                    items.Add(new CatalogItem
                                    {
                                        name = item[0].ToString(),
                                        value = item[1].ToString(),
                                        index = Convert.ToInt32(item[2].ToString())
                                    }
                                    );
                                }
                            }

                            userCatalog.catalogs.Add(child.Key, items);
                        }

                        // 显示树
                        treeViewCatalog.Nodes.Clear();
                        foreach (var node in userCatalog.catalogs)
                        {
                            TreeNode CurrentNode = null;
                            TreeNodeCollection CurrentNodes = treeViewCatalog.Nodes;
                            string[] nodeName = node.Key.Split('.');                            
                            foreach (string name in nodeName)
                            {                                
                                if (!CurrentNodes.ContainsKey(name))
                                {
                                    CurrentNode = CurrentNodes.Add(name, name);                                    
                                }
                                else
                                {
                                    CurrentNode = CurrentNodes[name];
                                }

                                CurrentNodes = CurrentNode.Nodes;
                            }

                            if (CurrentNode != null)
                            {
                                foreach (CatalogItem leaf in node.Value)
                                {
                                    CurrentNode.Nodes.Add(leaf.name + ":" + leaf.value + ":" + leaf.index);
                                }
                            }                            
                        }
                    }
                }
            }
            catch(Exception ex)
            {
            }
        }

        private void buttonAddCatalog_Click(object sender, EventArgs e)
        {           
            TreeNode SelectedNode = treeViewCatalog.SelectedNode;
            if (SelectedNode != null)
            {
                if (SelectedNode.Text.Contains(':'))
                {
                    MessageBox.Show(this, "带过滤条件的节点不能再添加子节点");
                    return;
                }

                AddUserCatalog dlg = new AddUserCatalog();
                DialogResult result = dlg.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    string nodeText = dlg.name;
                    if (!string.IsNullOrEmpty(dlg.filter))
                    {
                        nodeText = dlg.name + ":" + dlg.filter + ":" + dlg.index;
                        SelectedNode.Nodes.Add(nodeText);
                    }
                    else
                    {
                        SelectedNode.Nodes.Add(dlg.name, nodeText);
                    }                    
                }
            }
        }

        private void buttonEditCatalog_Click(object sender, EventArgs e)
        {
            TreeNode SelectedNode = treeViewCatalog.SelectedNode;
            if (SelectedNode != null)
            {
                AddUserCatalog dlg = new AddUserCatalog();
                dlg.filterEnable = (SelectedNode.Nodes.Count == 0);

                string[] values = SelectedNode.Text.Split(':');
                dlg.name = values[0];
                if (values.Length == 3)
                {                    
                    dlg.filter = values[1];
                    dlg.index = Convert.ToInt32(values[2]);
                }

                DialogResult result = dlg.ShowDialog(this);
                if ((result == DialogResult.OK) && !string.IsNullOrEmpty(dlg.name))
                {
                    string nodeText = dlg.name;
                    if (!string.IsNullOrEmpty(dlg.filter))
                    {
                        nodeText = dlg.name + ":" + dlg.filter + ":" + dlg.index;                        
                    }

                    SelectedNode.Text = nodeText;
                }
            }
        }

        private void buttonImportCatalog_Click(object sender, EventArgs e)
        {
            // 把内容写入到数据库
            if (treeViewCatalog.Nodes.Count == 0)
            {
                return;
            }

            try
            {
                UserCatalog config = new UserCatalog();
                Queue<TreeNode> nodesList = new Queue<TreeNode>();
                nodesList.Enqueue(treeViewCatalog.Nodes[0]);

                while (nodesList.Count > 0)
                {
                    TreeNode currentNode = nodesList.Dequeue();
                    currentNode.Tag = currentNode.Text;
                    if (currentNode.Parent != null)
                    {
                        currentNode.Tag = currentNode.Parent.Tag as string + "." + currentNode.Text;
                    }

                    string[] nodeValue = currentNode.Text.Split(':');
                    if (nodeValue.Length == 3)
                    {
                        string strKeyValue = currentNode.Parent.Tag as string;
                        if (!config.catalogs.ContainsKey(strKeyValue))
                        {
                            config.catalogs[strKeyValue] = new List<CatalogItem>();
                        }

                        config.catalogs[strKeyValue].Add(
                            new CatalogItem
                            {
                                name = nodeValue[0],
                                value = nodeValue[1],
                                index = Convert.ToInt32(nodeValue[2])
                            });
                    }
                    else
                    {
                        config.catalogs.Add(currentNode.Tag as string, new List<CatalogItem>());
                    }

                    foreach (TreeNode v in currentNode.Nodes)
                    {
                        nodesList.Enqueue(v);
                    }
                }
                
                StringWriter sw = new StringWriter();
                JsonWriter writer = new JsonTextWriter(sw);
                writer.WriteStartObject();

                foreach (var item in config.catalogs)
                {
                    writer.WritePropertyName(StringToUnicode(item.Key));
                    writer.WriteStartArray();
                    if (item.Value.Count != 0)
                    {
                        foreach (var childItem in item.Value)
                        {
                            writer.WriteStartArray();
                            writer.WriteValue(StringToUnicode(childItem.name));
                            writer.WriteValue(childItem.value);
                            writer.WriteValue(childItem.index);
                            writer.WriteEndArray();
                        }
                    }
                    writer.WriteEndArray();
                }
                writer.WriteEndObject();
                writer.Flush();

                string strJson = sw.ToString();
                if (!string.IsNullOrEmpty(strJson))
                {
                    strJson = strJson.Replace("\\\\","\\");
                    string sql = "update preferences set val='{0}' where key='user_categories'";
                    SQLiteCommand command = new SQLiteCommand(string.Format(sql, strJson), m_dbConnection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
            }
        }

        #endregion


        #region 辅助函数
        /// <summary>    
        /// 字符串转为UniCode码字符串    
        /// </summary>    
        /// <param name="s"></param>    
        /// <returns></returns>    
        private static string StringToUnicode(string s)
        {
            char[] charbuffers = s.ToCharArray();
            byte[] buffer;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < charbuffers.Length; i++)
            {
                buffer = System.Text.Encoding.Unicode.GetBytes(charbuffers[i].ToString());
                sb.Append(String.Format("\\u{0:X2}{1:X2}", buffer[1], buffer[0]));
            }
            return sb.ToString();
        }
        /// <summary>    
        /// Unicode字符串转为正常字符串    
        /// </summary>    
        /// <param name="srcText"></param>    
        /// <returns></returns>    
        private static string UnicodeToString(string srcText)
        {
            string dst = "";
            string src = srcText;
            int len = srcText.Length / 6;
            for (int i = 0; i <= len - 1; i++)
            {
                string str = "";
                str = src.Substring(0, 6).Substring(2);
                src = src.Substring(6);
                byte[] bytes = new byte[2];
                bytes[1] = byte.Parse(int.Parse(str.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                bytes[0] = byte.Parse(int.Parse(str.Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                dst += Encoding.Unicode.GetString(bytes);
            }
            return dst;
        }

        #endregion
    }
}

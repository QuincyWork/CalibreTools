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
using System.Net;
using HtmlAgilityPack;
using System.Threading;
using System.Configuration;
using System.Text.RegularExpressions;

namespace CalibreTools
{
    public delegate bool DownloadarticleDelegate(bool val);
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

        private void CalibreTools_Load(object sender, EventArgs e)
        {
            // 加载Download配置
            textBoxBase.Text = Properties.Settings.Default.baseURL;
            textBoxChapter.Text = Properties.Settings.Default.catalogRelativeURL;
            textBoxTocXPath.Text = Properties.Settings.Default.catalogXPath;
            textBoxChapterXPath.Text = Properties.Settings.Default.articleXPath;
            textBoxSavePath.Text = Properties.Settings.Default.saveFilePath;
            string encodeValue = Properties.Settings.Default.articleEncode;
            if (!string.IsNullOrEmpty(encodeValue))
            {
                comboBoxCodec.SelectedText = encodeValue;
            }
            else
            {
                comboBoxCodec.SelectedIndex = 0;
            }
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "发生异常: " + ex.Message);
            }

            buttonRefresh.Enabled = true;
            buttonMove.Enabled = true;
            buttonSetCatalog.Enabled = true;
            buttonAddCatalog.Enabled = true;
            buttonEditCatalog.Enabled = true;
            buttonRefreshCatalog.Enabled = true;
            buttonImportCatalog.Enabled = true;

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
                }
                catch (Exception)
                {
                }

                m_dbConnection.Close();
                m_dbConnection = null;

                buttonRefresh.Enabled = false;
                buttonMove.Enabled = false;
                buttonSetCatalog.Enabled = false;
                buttonAddCatalog.Enabled = false;
                buttonEditCatalog.Enabled = false;
                buttonRefreshCatalog.Enabled = false;
                buttonImportCatalog.Enabled = false;

                MessageBox.Show(this,"关闭操作成功");
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            listViewBooks.Items.Clear();

            // 获取目录分类
            int catelogId = 0;
            Dictionary<int, string> catalogName = new Dictionary<int, string>();
            catalogName.Add(-1, "");

            string customSQL = "select id from custom_columns where label='catalog'";
            SQLiteCommand customCmd = new SQLiteCommand(customSQL, m_dbConnection);
            SQLiteDataReader customReader = customCmd.ExecuteReader();
            if (customReader.Read())
            {
                catelogId = Convert.ToInt32(customReader["id"]);
            }

            customSQL = "select id,value from custom_column_{0}";
            customCmd = new SQLiteCommand(string.Format(customSQL, catelogId), m_dbConnection);
            customReader = customCmd.ExecuteReader();
            while (customReader.Read())
            {
                catalogName.Add(Convert.ToInt32(customReader["id"]), customReader["value"] as string);
            }

            // 获取图书
            string sql = "select id,title,path from books";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int bookId = Convert.ToInt32(reader["id"]);
                int bookCatalogId = -1;
                string catalogSQL = "select value from books_custom_column_{0}_link where book={1}";
                SQLiteCommand catalogCMD = new SQLiteCommand(string.Format(catalogSQL, catelogId, bookId), m_dbConnection);
                SQLiteDataReader catalogReader = catalogCMD.ExecuteReader();
                if (catalogReader.Read())
                {
                    bookCatalogId = Convert.ToInt32(catalogReader["value"]);
                }

                ListViewItem item = new ListViewItem(
                    new string[]
                    {
                        reader["title"] as string,                        
                        reader["path"] as string,
                        catalogName[bookCatalogId]
                    });
                item.Tag = bookId;
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
                        // 替换不能创建目录的特殊字符
                        title = title.TrimStart('.');
                        title = Regex.Replace(title, "[\\/:*?*<>|]", string.Empty, RegexOptions.Compiled);                        

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

                            // 更新名称
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

        private void buttonSetCatalog_Click(object sender, EventArgs e)
        {
            try
            {
                string strCatalogValue = "";
                if (listViewBooks.SelectedItems.Count > 0)
                {
                    SetFileCatalog dlg = new SetFileCatalog();
                    dlg.SetCatalogTree(treeViewCatalog.Nodes);
                    DialogResult result = dlg.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        strCatalogValue = dlg.SelectedCatalog;
                    }
                }

                // 设置catalog目录
                if (!string.IsNullOrEmpty(strCatalogValue))
                {
                    // 判断是否有catalog自定义值
                    int customId = 0;
                    string customSQL = "select id from custom_columns where label='catalog'";
                    SQLiteCommand customCmd = new SQLiteCommand(customSQL, m_dbConnection);
                    SQLiteDataReader customReader = customCmd.ExecuteReader();
                    if (customReader.Read())
                    {
                        customId = Convert.ToInt32(customReader["id"]);
                    }
                    else
                    {
                        MessageBox.Show(this, "请先在Calibre中添加自定义栏目'catalog'");
                        return;
                    }

                    if (customId != 0)
                    {
                        int catalogId = 0;
                        customSQL = "select id from custom_column_{0} where value='{1}'";
                        customCmd = new SQLiteCommand(string.Format(customSQL, customId, strCatalogValue), m_dbConnection);
                        customReader = customCmd.ExecuteReader();
                        if (customReader.Read())
                        {
                            catalogId = Convert.ToInt32(customReader["id"]);
                        }
                        else
                        {
                            string customInsertSQL = "insert into custom_column_{0} (value) values ('{1}')";
                            SQLiteCommand customInsertCmd = new SQLiteCommand(string.Format(customInsertSQL, customId, strCatalogValue), m_dbConnection);
                            customInsertCmd.ExecuteNonQuery();
                            customCmd.Reset();
                            customReader = customCmd.ExecuteReader();
                            if (customReader.Read())
                            {
                                catalogId = Convert.ToInt32(customReader["id"]);
                            }
                        }

                        // 更新图书的catalog标记
                        if (catalogId != 0)
                        {
                            foreach (ListViewItem item in listViewBooks.SelectedItems)
                            {
                                if (string.IsNullOrEmpty(item.SubItems[2].Text))
                                {
                                    string linkInsertSQL = "insert into books_custom_column_{0}_link (book,value) values ({1},{2})";
                                    SQLiteCommand linkInsertCmd = new SQLiteCommand(
                                        string.Format(linkInsertSQL, customId, item.Tag, catalogId), m_dbConnection);
                                    linkInsertCmd.ExecuteNonQuery();
                                }
                                else
                                {                                    
                                    string linkUpdateSQL = "update books_custom_column_{0}_link set value={2} where book ={1}";
                                    SQLiteCommand linkUpdateCmd = new SQLiteCommand(
                                        string.Format(linkUpdateSQL, customId, item.Tag, catalogId), m_dbConnection);
                                    linkUpdateCmd.ExecuteNonQuery();
                                }

                                item.SubItems[2].Text = strCatalogValue;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "发生异常，" + ex.Message);
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

        #region 下载文章

        private bool DownloadArticle(bool review)
        {
            bool result = false;
            textBoxReview.Text = "";
            
            string strCodec = comboBoxCodec.Text;
            string strSavePath = textBoxSavePath.Text;
            string strBoxTocXPath = textBoxTocXPath.Text;
            string strBoxChapterXPath = textBoxChapterXPath.Text;

            Thread thread = new Thread(new ThreadStart(() =>
            {
                FileStream fileSteam = null;
                StreamWriter sw = null;
                Encoding encode = Encoding.GetEncoding(strCodec);
                fileSteam = new FileStream(strSavePath, FileMode.Append);
                sw = new StreamWriter(fileSteam, encode);
                
                try
                {                    
                    string urlBase = textBoxBase.Text;
                    string urlChapter = urlBase + textBoxChapter.Text;
                    string webIndex = GetHttpWebRequest(urlChapter, encode);
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(webIndex);

                    HtmlNodeCollection ElementCollection = doc.DocumentNode.SelectNodes(strBoxTocXPath);
                    if (ElementCollection != null)
                    {
                        foreach (HtmlNode item in ElementCollection)
                        {
                            if (!review)
                            {
                                sw.WriteLine(item.InnerText);
                                textBoxReview.Invoke(new Action(delegate
                                {
                                    textBoxReview.Text = "正在下载 " + item.InnerText + "...";
                                }));                                
                            }
                            else
                            {
                                textBoxReview.Invoke(new Action(delegate
                                {
                                    textBoxReview.Text = textBoxReview.Text + item.InnerText + "\r\n";
                                }));                                
                            }

                            string chapterRef = item.Attributes["href"].Value;
                            if (string.IsNullOrEmpty(chapterRef))
                            {
                                continue;
                            }

                            int downloaCount = 5;
                            string chapterContext = "";
                            do
                            {
                                try
                                {
                                    Thread.Sleep(200);
                                    chapterContext = GetHttpWebRequest(urlBase + chapterRef, encode);
                                    HtmlAgilityPack.HtmlDocument chapterDoc = new HtmlAgilityPack.HtmlDocument();
                                    chapterDoc.LoadHtml(chapterContext);

                                    HtmlNode ChapElement = chapterDoc.DocumentNode.SelectSingleNode(strBoxChapterXPath);
                                    if (ChapElement != null)
                                    {
                                        string chapData = ChapElement.InnerText.Replace("&nbsp;", "");
                                        if (!review)
                                        {
                                            sw.WriteLine(chapData);
                                            sw.WriteLine();
                                        }
                                        else
                                        {
                                            textBoxReview.Invoke(new Action(delegate
                                            {
                                                textBoxReview.Text = textBoxReview.Text + chapData + "\r\n\r\n";
                                            })); 
                                            
                                        }
                                    }

                                    break;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(this, "发生异常：" + ex.Message);
                                }
                            } while (downloaCount-- > 0);

                            if (review)
                            {
                                break;
                            }
                        }
                    }

                    result = true;
                }
                catch (Exception ex)
                {
                    textBoxReview.Invoke(new Action(delegate
                    {
                        textBoxReview.Text = "发生异常：" + ex.Message;
                    }));                     
                }

                if (sw != null)
                {
                    sw.Close();
                }

                if (fileSteam != null)
                {
                    fileSteam.Close();
                }

                if (!review && result)
                {
                    textBoxReview.Invoke(new Action(delegate
                    {
                        textBoxReview.Text = "下载完成";
                    }));
                    
                    Properties.Settings.Default.baseURL = textBoxBase.Text;
                    Properties.Settings.Default.catalogRelativeURL = textBoxChapter.Text;
                    Properties.Settings.Default.catalogXPath = strBoxTocXPath;
                    Properties.Settings.Default.articleXPath = strBoxChapterXPath;
                    Properties.Settings.Default.saveFilePath = strSavePath;
                    Properties.Settings.Default.articleEncode = strCodec;
                    Properties.Settings.Default.Save();
                }
            }));

            thread.Start();

            return result;
        }
        
        private void buttonReview_Click(object sender, EventArgs e)
        {
            DownloadArticle(true);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DownloadArticle(false);            
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        private string GetHttpWebRequest(string url, Encoding encoding)
        {
            Uri uri = new Uri(url);
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(uri);
            myReq.UserAgent = "User-Agent:Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705";
            myReq.Accept = "*/*";
            myReq.KeepAlive = true;
            myReq.Headers.Add("Accept-Language", "zh-cn,en-us;q=0.5");
            HttpWebResponse result = (HttpWebResponse)myReq.GetResponse();
            Stream receviceStream = result.GetResponseStream();
            StreamReader readerOfStream = new StreamReader(receviceStream, encoding);
            string strHTML = readerOfStream.ReadToEnd();
            readerOfStream.Close();
            receviceStream.Close();
            result.Close();
            return strHTML;
        }

        #endregion

    }
}

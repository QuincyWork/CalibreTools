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
            catch (Exception)
            {
            }

            m_strCalibreRoot = Path.GetDirectoryName(textBoxPath.Text);

            MessageBox.Show("打开操作成功，操作前请先关闭Calibre应用");
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

                MessageBox.Show("关闭操作成功");
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
                        MessageBox.Show("发生异常，" + ex.Message);
                    }
                }
            }
        }

        private void CalibreTools_FormClosing(object sender, FormClosingEventArgs e)
        {
            buttonClose_Click(sender, e);
        }
    }
}

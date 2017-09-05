namespace CalibreTools
{
    partial class CalibreTools
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonMove = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.listViewBooks = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonImportCatalog = new System.Windows.Forms.Button();
            this.buttonRefreshCatalog = new System.Windows.Forms.Button();
            this.buttonEditCatalog = new System.Windows.Forms.Button();
            this.buttonAddCatalog = new System.Windows.Forms.Button();
            this.treeViewCatalog = new System.Windows.Forms.TreeView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.openFileDialogLib = new System.Windows.Forms.OpenFileDialog();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.folderBrowserDialogLib = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxBase = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTocXPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxChapterXPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSavePath = new System.Windows.Forms.TextBox();
            this.textBoxReview = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonReview = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxCodec = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxChapter = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1292, 764);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonMove);
            this.tabPage1.Controls.Add(this.buttonRefresh);
            this.tabPage1.Controls.Add(this.listViewBooks);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage1.Size = new System.Drawing.Size(1276, 717);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "库文件";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonMove
            // 
            this.buttonMove.Enabled = false;
            this.buttonMove.Location = new System.Drawing.Point(1110, 94);
            this.buttonMove.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(150, 46);
            this.buttonMove.TabIndex = 1;
            this.buttonMove.Text = "移动";
            this.buttonMove.UseVisualStyleBackColor = true;
            this.buttonMove.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Enabled = false;
            this.buttonRefresh.Location = new System.Drawing.Point(1110, 36);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(150, 46);
            this.buttonRefresh.TabIndex = 1;
            this.buttonRefresh.Text = "刷新";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // listViewBooks
            // 
            this.listViewBooks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewBooks.Dock = System.Windows.Forms.DockStyle.Left;
            this.listViewBooks.FullRowSelect = true;
            this.listViewBooks.Location = new System.Drawing.Point(6, 6);
            this.listViewBooks.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.listViewBooks.Name = "listViewBooks";
            this.listViewBooks.Size = new System.Drawing.Size(1058, 705);
            this.listViewBooks.TabIndex = 0;
            this.listViewBooks.UseCompatibleStateImageBehavior = false;
            this.listViewBooks.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "标题";
            this.columnHeader1.Width = 167;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "路径";
            this.columnHeader2.Width = 359;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonImportCatalog);
            this.tabPage2.Controls.Add(this.buttonRefreshCatalog);
            this.tabPage2.Controls.Add(this.buttonEditCatalog);
            this.tabPage2.Controls.Add(this.buttonAddCatalog);
            this.tabPage2.Controls.Add(this.treeViewCatalog);
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage2.Size = new System.Drawing.Size(1276, 717);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "用户目录";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonImportCatalog
            // 
            this.buttonImportCatalog.Enabled = false;
            this.buttonImportCatalog.Location = new System.Drawing.Point(1110, 212);
            this.buttonImportCatalog.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonImportCatalog.Name = "buttonImportCatalog";
            this.buttonImportCatalog.Size = new System.Drawing.Size(150, 46);
            this.buttonImportCatalog.TabIndex = 1;
            this.buttonImportCatalog.Text = "导入";
            this.buttonImportCatalog.UseVisualStyleBackColor = true;
            this.buttonImportCatalog.Click += new System.EventHandler(this.buttonImportCatalog_Click);
            // 
            // buttonRefreshCatalog
            // 
            this.buttonRefreshCatalog.Enabled = false;
            this.buttonRefreshCatalog.Location = new System.Drawing.Point(1110, 38);
            this.buttonRefreshCatalog.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonRefreshCatalog.Name = "buttonRefreshCatalog";
            this.buttonRefreshCatalog.Size = new System.Drawing.Size(150, 46);
            this.buttonRefreshCatalog.TabIndex = 1;
            this.buttonRefreshCatalog.Text = "刷新";
            this.buttonRefreshCatalog.UseVisualStyleBackColor = true;
            this.buttonRefreshCatalog.Click += new System.EventHandler(this.buttonRefreshCatalog_Click);
            // 
            // buttonEditCatalog
            // 
            this.buttonEditCatalog.Enabled = false;
            this.buttonEditCatalog.Location = new System.Drawing.Point(1110, 154);
            this.buttonEditCatalog.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonEditCatalog.Name = "buttonEditCatalog";
            this.buttonEditCatalog.Size = new System.Drawing.Size(150, 46);
            this.buttonEditCatalog.TabIndex = 1;
            this.buttonEditCatalog.Text = "修改分类";
            this.buttonEditCatalog.UseVisualStyleBackColor = true;
            this.buttonEditCatalog.Click += new System.EventHandler(this.buttonEditCatalog_Click);
            // 
            // buttonAddCatalog
            // 
            this.buttonAddCatalog.Enabled = false;
            this.buttonAddCatalog.Location = new System.Drawing.Point(1110, 96);
            this.buttonAddCatalog.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonAddCatalog.Name = "buttonAddCatalog";
            this.buttonAddCatalog.Size = new System.Drawing.Size(150, 46);
            this.buttonAddCatalog.TabIndex = 1;
            this.buttonAddCatalog.Text = "添加子分类";
            this.buttonAddCatalog.UseVisualStyleBackColor = true;
            this.buttonAddCatalog.Click += new System.EventHandler(this.buttonAddCatalog_Click);
            // 
            // treeViewCatalog
            // 
            this.treeViewCatalog.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeViewCatalog.Location = new System.Drawing.Point(6, 6);
            this.treeViewCatalog.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.treeViewCatalog.Name = "treeViewCatalog";
            this.treeViewCatalog.Size = new System.Drawing.Size(1060, 705);
            this.treeViewCatalog.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.comboBoxCodec);
            this.tabPage3.Controls.Add(this.buttonSave);
            this.tabPage3.Controls.Add(this.buttonReview);
            this.tabPage3.Controls.Add(this.textBoxReview);
            this.tabPage3.Controls.Add(this.textBoxSavePath);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.textBoxChapterXPath);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.textBoxTocXPath);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.textBoxChapter);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.textBoxBase);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Location = new System.Drawing.Point(8, 39);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage3.Size = new System.Drawing.Size(1276, 717);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "下载";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 778);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "库路径:";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(120, 772);
            this.textBoxPath.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(894, 35);
            this.textBoxPath.TabIndex = 2;
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(1118, 772);
            this.buttonOpen.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(150, 46);
            this.buttonOpen.TabIndex = 3;
            this.buttonOpen.Text = "打开";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(1118, 824);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(150, 46);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "关闭";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // openFileDialogLib
            // 
            this.openFileDialogLib.FileName = "*.db";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(1018, 770);
            this.buttonBrowse.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(60, 46);
            this.buttonBrowse.TabIndex = 4;
            this.buttonBrowse.Text = "...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "网站基地址";
            // 
            // textBoxBase
            // 
            this.textBoxBase.Location = new System.Drawing.Point(173, 17);
            this.textBoxBase.Name = "textBoxBase";
            this.textBoxBase.Size = new System.Drawing.Size(897, 35);
            this.textBoxBase.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "目录XPath";
            // 
            // textBoxTocXPath
            // 
            this.textBoxTocXPath.Location = new System.Drawing.Point(173, 121);
            this.textBoxTocXPath.Name = "textBoxTocXPath";
            this.textBoxTocXPath.Size = new System.Drawing.Size(897, 35);
            this.textBoxTocXPath.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "文章XPath";
            // 
            // textBoxChapterXPath
            // 
            this.textBoxChapterXPath.Location = new System.Drawing.Point(173, 172);
            this.textBoxChapterXPath.Name = "textBoxChapterXPath";
            this.textBoxChapterXPath.Size = new System.Drawing.Size(897, 35);
            this.textBoxChapterXPath.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "保存路径";
            // 
            // textBoxSavePath
            // 
            this.textBoxSavePath.Location = new System.Drawing.Point(173, 274);
            this.textBoxSavePath.Name = "textBoxSavePath";
            this.textBoxSavePath.Size = new System.Drawing.Size(897, 35);
            this.textBoxSavePath.TabIndex = 1;
            // 
            // textBoxReview
            // 
            this.textBoxReview.Location = new System.Drawing.Point(29, 377);
            this.textBoxReview.Multiline = true;
            this.textBoxReview.Name = "textBoxReview";
            this.textBoxReview.Size = new System.Drawing.Size(1041, 317);
            this.textBoxReview.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 350);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "预览结果";
            // 
            // buttonReview
            // 
            this.buttonReview.Location = new System.Drawing.Point(1110, 37);
            this.buttonReview.Name = "buttonReview";
            this.buttonReview.Size = new System.Drawing.Size(150, 46);
            this.buttonReview.TabIndex = 3;
            this.buttonReview.Text = "预览";
            this.buttonReview.UseVisualStyleBackColor = true;
            this.buttonReview.Click += new System.EventHandler(this.buttonReview_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(1110, 99);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(150, 46);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBoxCodec
            // 
            this.comboBoxCodec.FormattingEnabled = true;
            this.comboBoxCodec.Items.AddRange(new object[] {
            "utf-8",
            "GB18030"});
            this.comboBoxCodec.Location = new System.Drawing.Point(173, 225);
            this.comboBoxCodec.Name = "comboBoxCodec";
            this.comboBoxCodec.Size = new System.Drawing.Size(226, 32);
            this.comboBoxCodec.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "文章编码";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 24);
            this.label8.TabIndex = 0;
            this.label8.Text = "文章路径";
            // 
            // textBoxChapter
            // 
            this.textBoxChapter.Location = new System.Drawing.Point(173, 70);
            this.textBoxChapter.Name = "textBoxChapter";
            this.textBoxChapter.Size = new System.Drawing.Size(897, 35);
            this.textBoxChapter.TabIndex = 1;
            // 
            // CalibreTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 876);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "CalibreTools";
            this.Text = "Calibre工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CalibreTools_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ListView listViewBooks;
        private System.Windows.Forms.Button buttonMove;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.OpenFileDialog openFileDialogLib;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogLib;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TreeView treeViewCatalog;
        private System.Windows.Forms.Button buttonImportCatalog;
        private System.Windows.Forms.Button buttonAddCatalog;
        private System.Windows.Forms.Button buttonRefreshCatalog;
        private System.Windows.Forms.Button buttonEditCatalog;
        private System.Windows.Forms.TextBox textBoxBase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxChapterXPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTocXPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSavePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxReview;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxCodec;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonReview;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxChapter;
        private System.Windows.Forms.Label label8;
    }
}


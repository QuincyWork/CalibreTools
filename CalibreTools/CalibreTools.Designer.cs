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
            this.buttonEditCatalog = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(646, 382);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonMove);
            this.tabPage1.Controls.Add(this.buttonRefresh);
            this.tabPage1.Controls.Add(this.listViewBooks);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(638, 356);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "库文件";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonMove
            // 
            this.buttonMove.Location = new System.Drawing.Point(555, 47);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(75, 23);
            this.buttonMove.TabIndex = 1;
            this.buttonMove.Text = "移动";
            this.buttonMove.UseVisualStyleBackColor = true;
            this.buttonMove.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(555, 18);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
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
            this.listViewBooks.Location = new System.Drawing.Point(3, 3);
            this.listViewBooks.Name = "listViewBooks";
            this.listViewBooks.Size = new System.Drawing.Size(531, 350);
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
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(638, 356);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "用户目录";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonImportCatalog
            // 
            this.buttonImportCatalog.Location = new System.Drawing.Point(555, 106);
            this.buttonImportCatalog.Name = "buttonImportCatalog";
            this.buttonImportCatalog.Size = new System.Drawing.Size(75, 23);
            this.buttonImportCatalog.TabIndex = 1;
            this.buttonImportCatalog.Text = "导入";
            this.buttonImportCatalog.UseVisualStyleBackColor = true;
            this.buttonImportCatalog.Click += new System.EventHandler(this.buttonImportCatalog_Click);
            // 
            // buttonRefreshCatalog
            // 
            this.buttonRefreshCatalog.Location = new System.Drawing.Point(555, 19);
            this.buttonRefreshCatalog.Name = "buttonRefreshCatalog";
            this.buttonRefreshCatalog.Size = new System.Drawing.Size(75, 23);
            this.buttonRefreshCatalog.TabIndex = 1;
            this.buttonRefreshCatalog.Text = "刷新";
            this.buttonRefreshCatalog.UseVisualStyleBackColor = true;
            this.buttonRefreshCatalog.Click += new System.EventHandler(this.buttonRefreshCatalog_Click);
            // 
            // buttonAddCatalog
            // 
            this.buttonAddCatalog.Location = new System.Drawing.Point(555, 48);
            this.buttonAddCatalog.Name = "buttonAddCatalog";
            this.buttonAddCatalog.Size = new System.Drawing.Size(75, 23);
            this.buttonAddCatalog.TabIndex = 1;
            this.buttonAddCatalog.Text = "添加子分类";
            this.buttonAddCatalog.UseVisualStyleBackColor = true;
            this.buttonAddCatalog.Click += new System.EventHandler(this.buttonAddCatalog_Click);
            // 
            // treeViewCatalog
            // 
            this.treeViewCatalog.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeViewCatalog.Location = new System.Drawing.Point(3, 3);
            this.treeViewCatalog.Name = "treeViewCatalog";
            this.treeViewCatalog.Size = new System.Drawing.Size(532, 350);
            this.treeViewCatalog.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(638, 356);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "下载";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 389);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "库路径:";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(60, 386);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(449, 21);
            this.textBoxPath.TabIndex = 2;
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(559, 386);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 3;
            this.buttonOpen.Text = "打开";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(559, 412);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
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
            this.buttonBrowse.Location = new System.Drawing.Point(509, 385);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(30, 23);
            this.buttonBrowse.TabIndex = 4;
            this.buttonBrowse.Text = "...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonEditCatalog
            // 
            this.buttonEditCatalog.Location = new System.Drawing.Point(555, 77);
            this.buttonEditCatalog.Name = "buttonEditCatalog";
            this.buttonEditCatalog.Size = new System.Drawing.Size(75, 23);
            this.buttonEditCatalog.TabIndex = 1;
            this.buttonEditCatalog.Text = "修改分类";
            this.buttonEditCatalog.UseVisualStyleBackColor = true;
            this.buttonEditCatalog.Click += new System.EventHandler(this.buttonEditCatalog_Click);
            // 
            // CalibreTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 438);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CalibreTools";
            this.Text = "Calibre工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CalibreTools_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
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
    }
}


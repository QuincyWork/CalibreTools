namespace CalibreTools
{
    partial class AddUserCatalog
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
            this.label1 = new System.Windows.Forms.Label();
            this.DlgCatalogName = new System.Windows.Forms.TextBox();
            this.DlgCatalogOK = new System.Windows.Forms.Button();
            this.DlgCatalogCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DlgCatalogFilter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DlgCatalogIndex = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "分类";
            // 
            // DlgCatalogName
            // 
            this.DlgCatalogName.Location = new System.Drawing.Point(70, 12);
            this.DlgCatalogName.Name = "DlgCatalogName";
            this.DlgCatalogName.Size = new System.Drawing.Size(202, 21);
            this.DlgCatalogName.TabIndex = 1;
            // 
            // DlgCatalogOK
            // 
            this.DlgCatalogOK.Location = new System.Drawing.Point(117, 98);
            this.DlgCatalogOK.Name = "DlgCatalogOK";
            this.DlgCatalogOK.Size = new System.Drawing.Size(75, 23);
            this.DlgCatalogOK.TabIndex = 2;
            this.DlgCatalogOK.Text = "确定";
            this.DlgCatalogOK.UseVisualStyleBackColor = true;
            this.DlgCatalogOK.Click += new System.EventHandler(this.DlgCatalogOK_Click);
            // 
            // DlgCatalogCancel
            // 
            this.DlgCatalogCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DlgCatalogCancel.Location = new System.Drawing.Point(198, 98);
            this.DlgCatalogCancel.Name = "DlgCatalogCancel";
            this.DlgCatalogCancel.Size = new System.Drawing.Size(75, 23);
            this.DlgCatalogCancel.TabIndex = 2;
            this.DlgCatalogCancel.Text = "取消";
            this.DlgCatalogCancel.UseVisualStyleBackColor = true;
            this.DlgCatalogCancel.Click += new System.EventHandler(this.DlgCatalogCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "过滤器";
            // 
            // DlgCatalogFilter
            // 
            this.DlgCatalogFilter.Location = new System.Drawing.Point(70, 39);
            this.DlgCatalogFilter.Name = "DlgCatalogFilter";
            this.DlgCatalogFilter.Size = new System.Drawing.Size(202, 21);
            this.DlgCatalogFilter.TabIndex = 1;
            this.DlgCatalogFilter.Text = "#catalog";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "索引值";
            // 
            // DlgCatalogIndex
            // 
            this.DlgCatalogIndex.Location = new System.Drawing.Point(70, 66);
            this.DlgCatalogIndex.Name = "DlgCatalogIndex";
            this.DlgCatalogIndex.Size = new System.Drawing.Size(202, 21);
            this.DlgCatalogIndex.TabIndex = 1;
            // 
            // AddUserCatalog
            // 
            this.AcceptButton = this.DlgCatalogOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.DlgCatalogCancel;
            this.ClientSize = new System.Drawing.Size(284, 131);
            this.Controls.Add(this.DlgCatalogCancel);
            this.Controls.Add(this.DlgCatalogOK);
            this.Controls.Add(this.DlgCatalogIndex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DlgCatalogFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DlgCatalogName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddUserCatalog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加用户目录";
            this.Load += new System.EventHandler(this.AddUserCatalog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DlgCatalogName;
        private System.Windows.Forms.Button DlgCatalogOK;
        private System.Windows.Forms.Button DlgCatalogCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DlgCatalogFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DlgCatalogIndex;
    }
}
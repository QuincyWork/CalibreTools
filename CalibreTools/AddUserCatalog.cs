using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalibreTools
{
    public partial class AddUserCatalog : Form
    {
        public string name;
        public string filter;
        public int    index;

        public AddUserCatalog()
        {
            InitializeComponent();            
        }

        private void DlgCatalogCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void DlgCatalogOK_Click(object sender, EventArgs e)
        {
            name = DlgCatalogName.Text;
            filter = DlgCatalogFilter.Text;            
            index = 0;
            if (DlgCatalogIndex.Text.Length > 0)
            {
                index = Convert.ToInt32(DlgCatalogIndex.Text);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void AddUserCatalog_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(name))
            {
                DlgCatalogName.Text = name;
            }

            if (!string.IsNullOrEmpty(filter))
            {
                DlgCatalogFilter.Text = filter;
                DlgCatalogIndex.Text = index.ToString();
            }
        }
    }
}

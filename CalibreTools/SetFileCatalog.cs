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
    public partial class SetFileCatalog : Form
    {
        public string SelectedCatalog = "";

        public SetFileCatalog()
        {
            InitializeComponent();
        }

        public void SetCatalogTree(TreeNodeCollection tree)
        {
            Queue<TreeNode> nodesList = new Queue<TreeNode>();
            nodesList.Enqueue(tree[0]);

            while (nodesList.Count > 0)
            {
                TreeNode currentNode = nodesList.Dequeue();                
                string[] nodeValue = currentNode.Text.Split(':');
                if (nodeValue.Length == 3)
                {
                    comboBoxSetCatalog.Items.Add(nodeValue[0]);
                }
                else
                {
                    foreach (TreeNode v in currentNode.Nodes)
                    {
                        nodesList.Enqueue(v);
                    }
                }
            }

            comboBoxSetCatalog.SelectedIndex = 0;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SelectedCatalog = comboBoxSetCatalog.SelectedItem.ToString();
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

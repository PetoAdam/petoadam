using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HelloWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            tbHelloTextBox.Text = "Hello World!";
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TreeNode node = treeView1.Nodes.Add("Local Disk (C:)");
            node.Tag = new DirectoryInfo("C:\\");
            node.Nodes.Add("");
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;
            DirectoryInfo parentDi = (DirectoryInfo)node.Tag;
            node.Nodes.Clear();

            try
            {


                foreach (DirectoryInfo di in parentDi.GetDirectories())
                {
                    TreeNode subnode = new TreeNode(di.Name);
                    subnode.Tag = di;
                    subnode.Nodes.Add("");
                    node.Nodes.Add(subnode);
                }
            }
            catch { }
        }
    }
}

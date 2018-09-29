using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreeViewControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TreeNode tNode;
            try
            {
                tNode = treeView1.Nodes.Add("1");

                treeView1.Nodes[0].Nodes.Add("2");
                treeView1.Nodes[0].Nodes.Add("3");

                treeView1.Nodes[0].Nodes[0].Nodes.Add("4");
                //-------------
                tNode = treeView1.Nodes.Add("One");

                treeView1.Nodes[1].Nodes.Add("Two");
                treeView1.Nodes[1].Nodes.Add("Three");

                treeView1.Nodes[1].Nodes[0].Nodes.Add("Four");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            MessageBox.Show(treeView1.SelectedNode.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Indent = Convert.ToInt32(txtIndent.Text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            treeView1.CheckBoxes = checkBox1.Checked;
            
        }
    }
}

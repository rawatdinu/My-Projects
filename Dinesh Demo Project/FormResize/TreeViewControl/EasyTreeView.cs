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
    public partial class EasyTreeView : Form
    {
        public EasyTreeView()
        {
            InitializeComponent();

            TreeNode mainNode = new TreeNode();
            mainNode.Name = "mainNode";
            mainNode.Text = "MainNode";
            this.treeView1.Nodes.Add(mainNode);
        }

        private void addNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Node newNode = new Node();
            TreeNode node;

            newNode.Text = "Add Node";
           if( DialogResult.Cancel!=newNode.ShowDialog())
            {
                node = new TreeNode();
                node.Name = newNode.NodeName;
                node.Text = newNode.NodeText;
                node.Tag = newNode.NodeTag;
                treeView1.SelectedNode.Nodes.Add(node);
                treeView1.SelectedNode.ExpandAll();
            }
           newNode.Close();
           newNode = null;
        }

        private void editNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;

            Node currentNode = new Node();
            currentNode.Text ="Edit Node";
            currentNode.NodeName = node.Name;
            currentNode.NodeText = node.Text;
            currentNode.NodeTag = Convert.ToString(node.Tag);

            if (DialogResult.Cancel != currentNode.ShowDialog())
            {

                node.Name = currentNode.NodeName;
                node.Text = currentNode.NodeText;
                node.Tag = currentNode.NodeTag;               
                treeView1.SelectedNode.ExpandAll();
            }
            currentNode.Close();
            currentNode = null;

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Remove();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                txtName.Text = "";
                txtParent.Text = "";
                txtText.Text = "";
                txtTag.Text = "";
                

                txtName.Text = treeView1.SelectedNode.Name;
                if (treeView1.SelectedNode.Parent != null)
                {
                    txtParent.Text = Convert.ToString(treeView1.SelectedNode.Parent.Text);
                }                
                txtText.Text = treeView1.SelectedNode.Text;
                txtTag.Text = Convert.ToString(treeView1.SelectedNode.Tag);               
                


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void treeView1_Click(object sender, EventArgs e)
        {

        }

    

     
        #region Find By Name
        private void cmdFindByName_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Remove BackColor
        private void ClearBackColor()
        {
            TreeNodeCollection nodes = treeView1.Nodes;
            foreach (TreeNode n in nodes)
            {
                
            }
       
        }

        private void ClearRecursive(TreeNode node)
        { 
        
        }
        #endregion




    }
}

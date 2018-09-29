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
    public partial class Node : Form
    {
        public string NodeName
        {
            get
            { 
                return txtName.Text; 
            }
            set
            {
                txtName.Text = value;
            }
        }

        public string NodeText
        {
            get
            {
                return txtText.Text;
            }
            set
            {
                txtText.Text = value;
            }
        }

        public string NodeTag
        {
            get
            {
                return txtTag.Text;
            }
            set
            {
                txtTag.Text = value;
            }
        }

        public Node()
        {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

      
    }
}

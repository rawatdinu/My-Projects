using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShowFormAsDialog
{
    public partial class Form1 : Form
    {
        private Form2 frmInterface;
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            ProcessInterface();
        }
        private void ProcessInterface()
        {
            LoadInterface();

            ShowForm();

            UnloadInterface();

        }
        private void LoadInterface()
        {
            frmInterface = new Form2();
            frmInterface.Name = textBox1.Text;
            frmInterface.Age = textBox2.Text;
            frmInterface.Phone = textBox3.Text;
        }

        private void UnloadInterface()
        {
            frmInterface.Close();
            frmInterface = null;
        }

        private void ShowForm()
        {
            DialogResult result;
            result=frmInterface.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox4.Text = frmInterface.Result;
            }
            else
            {
                textBox4.Text = "";
            }        
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DemoProject;
using System.IO;


namespace DemoProject
{
    
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = button1;
            SetDefaultInterface();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool result = GlobalFunction.IsValidUser(txtUserName.Text, txtPassword.Text);
            if (result)
            {
                this.DialogResult = DialogResult.OK;
                GlobalFunction.GetUserTypes();
            }
            else
            {
                lblMsg.Visible=true;
                lblMsg.Text = "Incorrect User Id or Password";
            return;
            }           

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (GlobalFunction.IsValidLicence())
            {
                txtUserName.Text = string.Empty;
                txtPassword.Text = string.Empty;
                lblMsg.Text = string.Empty;
                lblMsg.Visible = false;
                txtUserName.Focus();
            }
            else
            {
                this.Close();
            }
        }

       
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void SetDefaultInterface()
        { 
            string imageFile = Application.StartupPath+ @"\Images\64X64\login1.jpg";
            string iconFile = Application.StartupPath+ @"\Icon\16X16\log.ico";
            

            if (File.Exists(imageFile))
            {
                pictureBox1.Image = Image.FromFile(imageFile);
            }
            if (File.Exists(iconFile))
            {                
                System.Drawing.Icon ico = new System.Drawing.Icon(iconFile);
                this.Icon = ico;
            }
        
        }
    }
}

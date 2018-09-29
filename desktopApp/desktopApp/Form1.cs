using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using desktopApp.Common;
using desktopApp.DAL;

namespace desktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            LoginControl l = new LoginControl();
            l.Show();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbUser u = new tbUser();
            //dataGridView1.DataSource = u.GetUserDetail();
        }

    }
}

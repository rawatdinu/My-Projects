using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tab_Order
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
           
            textBox6.Focus();
        }

        private void button3_Leave(object sender, EventArgs e)
        {
            textBox7.Focus();
        }

        private void button9_Leave(object sender, EventArgs e)
        {
            textBox4.Focus();
        }
    }
}

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
    public partial class Form2 : Form
    {
        private string _name;
        private string _age;
        private string _phone;
        private string _result;

        public string Name
        {
            get
            { 
            return _name;
            }
            set
            {
                _name = value;
                label1.Text = _name;
            }
        }

        public string Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                label2.Text = _age;
            }
        }

        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
                label3.Text = _phone;
            }
        }

        public string Result
        {
            get
            {
                return _result;
            }
            
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            _result = textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

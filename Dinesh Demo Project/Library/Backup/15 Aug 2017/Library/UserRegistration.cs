using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.BLL;

namespace Library
{
    public partial class frmUserRegistration : Form
    {
        public frmUserRegistration()
        {
            InitializeComponent();
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            Account ac = new Account();
            ac.AccountHolderName = txtName.Text;
            ac.ID = txtID.Text;
            ac.DateOfBirth = GlobalFunction.GetDateTimeWithoutMiliSecond(dtpDOB.Value);

            AccountHandler acHanlder = new AccountHandler();
            Boolean result = acHanlder.AddNewAccount(ac);
            if (result == true)
            {
                MessageBox.Show("New Account created");
            }
            else
            {
                MessageBox.Show("Errror Occurs!");
            }            
        }

        private void frmUserRegistration_Load(object sender, EventArgs e)
        {
            txtID.Text = GlobalFunction.GetUniqueCode("AccountMaster1");
            txtName.Text = "";
            txtName.Focus();
        }

        private void txtNew_Click(object sender, EventArgs e)
        {
            txtID.Text = GlobalFunction.GetUniqueCode("AccountMaster1");
            txtName.Text = "";
            txtName.Focus();
        }

     
    }
}

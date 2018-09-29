using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DemoStoredProcCSharp
{
    public partial class Form1 : Form
    {
        int ID;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Display(1);
        }

        public void Display(int id)
        {

            try
            {
                //string str = "EXEC spSelectEmpId "+id+"";
                string str = "EXEC spSelectEmpId " + id + "";
                //string[] para= new string[]{"@Id"};
                //object[] value= new object[]{id};
                DataTable dt= DBService.GetDataTable(str);
                ID=(int)dt.Rows[0]["id"];
                txtName.Text = Convert.ToString(dt.Rows[0]["name"]);
                txtAge.Text = Convert.ToString(dt.Rows[0]["age"]);
                dtpDate.Value = Convert.ToDateTime(dt.Rows[0]["dob"]);
                txtAddress.Text = Convert.ToString(dt.Rows[0]["address"]);
                txtCity.Text = Convert.ToString(dt.Rows[0]["city"]);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {

                string str = "EXEC [spInsertEmp] @city,@age,@dob,@address,@name";
                string[] para = new string[] { "@city", "@age", "@dob", "@address","@name" };
                object[] value = new object[] { txtCity.Text,txtAge.Text,dtpDate.Value,txtAddress.Text,txtName.Text};
                DBService.ExecuteNonQuery(str,para,value);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtAge.Text = "";
            txtAddress.Text = "";
            txtCity.Text="";
            dtpDate.Value = DateTime.Now;
        
        }




    }
}

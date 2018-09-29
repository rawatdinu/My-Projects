using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VillageMeeting.AppCode;

namespace VillageMeeting
{
    public partial class frmCapitalLoanSetting : Form
    {
         int ID;
        bool blnUpdate=false;
        string msg_Validation;
        int SpclLoanScheme;
        

        public frmCapitalLoanSetting()
        {
            InitializeComponent();
        }

        private void frmCapitalLoanSetting_Load(object sender, EventArgs e)
        {
            string str = "SELECT Max( ID) as Num FROM CapitalLoanSetting";
            ID = Convert.ToInt32(DBService.ExecuteScalar(str));
            DispayData();
        }
        private void ControlStatus(bool status)
        {
            txtCapital.ReadOnly = status;
            txtMinEMI.ReadOnly = status;
            txtInterest.ReadOnly = status;
            txtSplInterest.ReadOnly = status;
            txtLoanLimit.ReadOnly = status;
            txtPenality.ReadOnly = status;
            chkSpclLoanScheme.Enabled = !status;

        }

        private void DispayData()
        {
            DataTable dt = new DataTable();
            string str;
            int RecNo;
            try
            {
                str = "SELECT ID, Capital, MinEMI, Interest, SpcInterest, LoanLimit, Penalty,SpclLoanScheme FROM CapitalLoanSetting Where ID=" + ID + "";
                dt = DBService.GetDataTable(str);
                RecNo = dt.Rows.Count;

                if (RecNo > 0)
                {

                    ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                    txtCapital.Text = Convert.ToString(dt.Rows[0]["Capital"]);
                    txtMinEMI.Text = Convert.ToString(dt.Rows[0]["MinEMI"]);
                    txtInterest.Text = Convert.ToString(dt.Rows[0]["Interest"]);
                    txtSplInterest.Text = Convert.ToString(dt.Rows[0]["SpcInterest"]);
                    txtLoanLimit.Text = Convert.ToString(dt.Rows[0]["LoanLimit"]);
                    txtPenality.Text = Convert.ToString(dt.Rows[0]["Penalty"]);


                    SpclLoanScheme = Convert.ToInt32(Convert.IsDBNull(dt.Rows[0]["SpclLoanScheme"]) ? "0" : dt.Rows[0]["SpclLoanScheme"]);
                    if (SpclLoanScheme == 1)
                    {
                        chkSpclLoanScheme.Checked = true;
                    }
                    else
                    {
                        chkSpclLoanScheme.Checked = false;
                    }
                }

                ControlStatus(true);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            blnUpdate = true;
            ControlStatus(false);
            txtCapital.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputData())
            {
                Save();
            }
        }

        private void Save()
        {
            string[] para = new string[] { };
            object[] values = new object[] { };
            string str1;            
            object result;

            try
            {
                if (blnUpdate)
                {
                    DialogResult dr = MessageBox.Show("Do You Want to Save Data?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (dr == DialogResult.OK)
                    {
                        int TempID;


                        str1 = "SELECT  Max(ID) as tempID FROM CapitalLoanSetting";
                        TempID = Convert.ToInt32(DBService.ExecuteScalar(str1));
                        if (TempID == 0)
                        {
                            TempID = 1;
                        }
                        else
                        {
                            TempID = TempID + 1;
                        }


                        str1 = "INSERT INTO CapitalLoanSetting(ID, Capital, MinEMI, Interest, SpcInterest, LoanLimit, Penalty,SpclLoanScheme,UpdatedOn) VALUES (@ID,@Capital, @MinEMI, @Interest, @SpcInterest, @LoanLimit, @Penalty,@SpclLoanScheme,@UpdatedOn)";

                        para = new string[] { "@ID", "@Capital", "@MinEMI", "@Interest", "@SpcInterest", "@LoanLimit", "@Penalty", "@SpclLoanScheme", "@UpdatedOn" };
                        values = new object[] { TempID, Convert.ToInt32(txtCapital.Text.Trim()), Convert.ToInt32(txtMinEMI.Text.Trim()), Convert.ToInt32(txtInterest.Text.Trim()), Convert.ToInt32(txtSplInterest.Text.Trim()), Convert.ToInt32(txtLoanLimit.Text.Trim()), Convert.ToInt32(txtPenality.Text.Trim()), SpclLoanScheme, DateTime.Now.Date };

                       
                        result = DBService.ExecuteNonQuerry(str1, para, values);
                        if (result != null)
                        {
                            blnUpdate = false;
                            ID = TempID;
                            MessageBox.Show("Data is Updated succesfully");
                            ControlStatus(true);
                            Meeting.SetMeetingAmount();
                            DispayData();

                        }
                        else
                        {
                            MessageBox.Show("Error Occurs", "ERROR");
                        }
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        bool ValidateInputData()
        {
            bool result = true;
            msg_Validation = "";

            // Special Loan Validation
            if (chkSpclLoanScheme.Checked == false)
            {
                txtSplInterest.Text = "0";
                SpclLoanScheme = 0;
            }
            else if (chkSpclLoanScheme.Checked == true)
            {
                SpclLoanScheme = 1;
            }

            //Capital

            if (!GlobalFunction.IsInteger(txtCapital.Text.Trim()))
            {
                result = false;
                msg_Validation = "Capital amount is not correct";
                MessageBox.Show(msg_Validation);
            }
            //Min EMI
            else if (!GlobalFunction.IsInteger(txtMinEMI.Text.Trim()))
            {
                result = false;
                msg_Validation = "Min. EMI is not correct";
                MessageBox.Show(msg_Validation);
            }
            //Interest
            else if (!GlobalFunction.IsInteger(txtInterest.Text.Trim()))
            {
                result = false;
                msg_Validation = "Insterest amount is not correct";
                MessageBox.Show(msg_Validation);
            }
            //Spl Interest
            else if (!GlobalFunction.IsInteger(txtSplInterest.Text.Trim()) && (chkSpclLoanScheme.Checked == true))
            {
                result = false;
                msg_Validation = "Spcial Interest amount is not correct";
                MessageBox.Show(msg_Validation);
            }
            //LOan Limit
            else if (!GlobalFunction.IsInteger(txtLoanLimit.Text.Trim()))
            {
                result = false;
                msg_Validation = "Loan limit amount is not correct";
                MessageBox.Show(msg_Validation);
            }
            // Penalty
            else if (!GlobalFunction.IsInteger(txtPenality.Text.Trim()))
            {
                result = false;
                msg_Validation = "Penalty is not correct";
                MessageBox.Show(msg_Validation);
            }

            return result;

        }
     

        private void chkSpclLoanScheme_Click(object sender, EventArgs e)
        {
            if (chkSpclLoanScheme.Checked == false)
            {
                txtSplInterest.Text = "0";
                txtSplInterest.ReadOnly = true;
                SpclLoanScheme = 0;
            }
            else if (chkSpclLoanScheme.Checked == true)
            {
                SpclLoanScheme = 1;
                txtSplInterest.ReadOnly = false;
            }
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            blnUpdate = false;
            string str = "SELECT Max( ID) as Num FROM CapitalLoanSetting";
            ID = Convert.ToInt32(DBService.ExecuteScalar(str));
            DispayData();
        }

      
     
        
    }
}

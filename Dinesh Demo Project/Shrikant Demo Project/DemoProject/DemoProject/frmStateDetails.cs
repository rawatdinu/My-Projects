using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoProject.AppCode;

namespace DemoProject
{
    public partial class frmStateDetails : Form
    {

        public string StateCode { get; set; }
        public string StateName { get; set; }
        

        public bool IsAdd = false;
        public bool IsEdit = false;


        private void SetProperty()
        {

            StateCode = txtStateCode.Text;
            StateName = txtStateName.Text;
            
        }

        private void GetProperty()
        {

            txtStateCode.Text=StateCode;
            txtStateName.Text= StateName;
        }

        public frmStateDetails()
        {
            InitializeComponent();
        }

        private void Save()
        {

            string[] para;
            object[] values;
            string str1;

            List<Transaction> transList = new List<Transaction>();

            object obj;

            try
            {
                if (IsAdd)
                {
                    DialogResult dr = MessageBox.Show("Do You Want to Save Data ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (dr == DialogResult.OK)
                    {
                        

                        StateCode = GlobalFunction.GetUniqueCode("StateMaster");


                        /*Master Table**/
                        //str1 = "INSERT INTO ShareMaster(ShareHolderName,Address,PhoneNo,IsActive,CreatedOn) VALUES (@ShareHolderName,@Address,@PhoneNo,@IsActive,@CreatedOn)";
                        str1 = "INSERT INTO StateMaster(StateCode, StateName, CreatedOn) VALUES (@StateCode, @StateName, @CreatedOn)";

                        para = new string[] { "@StateCode", "@StateName", "@CreatedOn" };
                        values = new object[] { StateCode, StateName, GlobalFunction.GetDateTimeWithoutMiliSecond(System.DateTime.Now) };

                        transList.Add(new Transaction(str1, para, values));


                        // UPdate counter
                        str1 = "Update UniqueCodeMaster set CurrentNo=CurrentNo + IncrementBy where TableName='StateMaster'";
                        para = new string[] { };
                        values = new object[] { };

                        transList.Add(new Transaction(str1, para, values));

                        obj = DBService.ExecuteTransaction(transList);
                        if (obj != null)
                        {
                            IsEdit = false;
                            //MessageBox.Show("Record saved succesfully");
                        }
                        else
                        {
                            MessageBox.Show("Error Occurs", "ERROR");
                        }

                    }
                }
                /******************************EDIT*****************************************/
                else if (IsEdit)
                {
                    DialogResult dr = MessageBox.Show("Do You Want to Update '" + txtStateCode.Text + "'", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (dr == DialogResult.OK)
                    {
                        str1 = "Update StateMaster set StateName=@StateName,LastModify=@LastModify  Where StateCode = @StateCode";
                        para = new string[] { "@StateName", "@LastModify", "@StateCode" };
                        values = new object[] { StateName, GlobalFunction.GetDateTimeWithoutMiliSecond(DateTime.Now), StateCode };

                        //oleParam = new OleDbParameter[]
                        // {

                        //    new OleDbParameter("@ShareHolderName",GetProperName(txtName.Text)),
                        //     new  OleDbParameter("@Address",txtAddress.Text.Trim()),
                        //     new  OleDbParameter("@PhoneNo",txtPhone.Text.Trim()),
                        //     new  OleDbParameter("@IsActive", 1),
                        //     new  OleDbParameter("@UpdatedOn",DateTime.Now.Date),
                        //     new OleDbParameter("@ID",ID)
                        // };

                        obj = DBService.ExecuteNonQuerry(str1, para, values);
                        if (obj != null)
                        {
                            IsEdit = false;
                            //MessageBox.Show("Share Hoder is Updated succesfully");
                            //ControlStatus(true);
                            //DispayData();
                            //DispayData2();
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

      
        private void cmdOK_Click(object sender, EventArgs e)
        {
            SetProperty();
            Save();
            this.DialogResult = DialogResult.OK;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmStateDetails_Load(object sender, EventArgs e)
        {
            this.Text = "State " + StateCode;
            
            GetProperty();
            
        }

    }
}

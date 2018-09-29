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
    public partial class frmIndustryTypeDetails : Form
    {
        public string IndustryCode { get; set; }
        public string IndustryName { get; set; }

        public bool IsAdd = false;
        public bool IsEdit = false;

        public frmIndustryTypeDetails()
        {
            InitializeComponent();
        }

        private void frmIndustryTypeDetails_Load(object sender, EventArgs e)
        {
            this.Text = "Industry Type " + IndustryCode;

            GetProperty();
        }

        private void SetProperty()
        {

            IndustryCode = txtIndustryCode.Text;
            IndustryName = txtIndustryName.Text;

        }

        private void GetProperty()
        {

            txtIndustryCode.Text = IndustryCode;
            txtIndustryName.Text = IndustryName;
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


                        IndustryCode = GlobalFunction.GetUniqueCode("IndustryTypeMaster");


                        /*Master Table**/
                        //str1 = "INSERT INTO ShareMaster(ShareHolderName,Address,PhoneNo,IsActive,CreatedOn) VALUES (@ShareHolderName,@Address,@PhoneNo,@IsActive,@CreatedOn)";
                        str1 = "INSERT INTO IndustryTypeMaster(IndustryCode, IndustryName, CreatedOn) VALUES (@IndustryCode, @IndustryName, @CreatedOn)";

                        para = new string[] { "@IndustryCode", "@IndustryName", "@CreatedOn" };
                        values = new object[] { IndustryCode, IndustryName, GlobalFunction.GetDateTimeWithoutMiliSecond(System.DateTime.Now) };

                        transList.Add(new Transaction(str1, para, values));


                        // UPdate counter
                        str1 = "Update UniqueCodeMaster set CurrentNo=CurrentNo + IncrementBy where TableName='IndustryTypeMaster'";
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
                    DialogResult dr = MessageBox.Show("Do You Want to Update '" + txtIndustryCode.Text + "'", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (dr == DialogResult.OK)
                    {
                        str1 = "Update IndustryTypeMaster set IndustryName=@IndustryName,LastModify=@LastModify  Where IndustryCode = @IndustryCode";
                        para = new string[] { "@IndustryName", "@LastModify", "@IndustryCode" };
                        values = new object[] { IndustryName, GlobalFunction.GetDateTimeWithoutMiliSecond(DateTime.Now), IndustryCode };

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
    }
}

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
    public partial class frmCityDetail : Form
    {
        public string CityCode { get; set; }
        public string CityName { get; set; }

        private string _statecode = "";
        private string _statename = "";

        

        


        public bool IsAdd = false;
        public bool IsEdit = false;

        public frmCityDetail()
        {
            InitializeComponent();
        }


        private void cmdOK_Click(object sender, EventArgs e)
        {
            SetProperty();
            Save();
            this.DialogResult = DialogResult.OK;
        }

        private void frmCityDetail_Load(object sender, EventArgs e)
        {
            this.Text = "City " + CityCode;
            GetProperty();
            if (IsEdit)
            {
                Display(CityCode);
            }
        }

        private void SetProperty()
        {

            CityCode = txtCityCode.Text;
            CityName = txtCityName.Text;
            _statename = txtStateName.Text;

        }

        private void GetProperty()
        {
            txtCityCode.Text=CityCode  ;
            txtCityName.Text=CityName;
            txtStateName.Text = _statename;
        }

        private void ClearControls()
        {
            txtCityCode.Text = "";
            txtCityName.Text = "";
            txtStateName.Text = "";
        
        }

        public void Display(string cityCode)
        {
            DataTable dt = new DataTable();
            string str;
            int RecNo;


            try
            {
                str = "SELECT CityMaster.CityCode, CityMaster.CityName, CityMaster.StateCode, StateMaster.StateName FROM CityMaster INNER JOIN StateMaster ON CityMaster.StateCode = StateMaster.StateCode Where CityMaster.CityCode ='"+ cityCode +"'";
                dt = DBService.GetDataTable(str);
                RecNo = dt.Rows.Count;

                if (RecNo > 0)
                {
                    txtCityCode.Text = Convert.ToString(dt.Rows[0]["CityCode"]);
                    txtCityName.Text = Convert.ToString(dt.Rows[0]["CityName"]);
                    _statecode = Convert.ToString(dt.Rows[0]["StateCode"]);
                    txtStateName.Text = Convert.ToString(dt.Rows[0]["StateName"]);

                    txtCityName.Focus();                 
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
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


                        CityCode = GlobalFunction.GetUniqueCode("CityMaster");


                        /*Master Table**/
                        //str1 = "INSERT INTO ShareMaster(ShareHolderName,Address,PhoneNo,IsActive,CreatedOn) VALUES (@ShareHolderName,@Address,@PhoneNo,@IsActive,@CreatedOn)";
                        str1 = "INSERT INTO CityMaster(CityCode, CityName, StateCode,CreatedOn) VALUES (@CityCode, @CityName,@StateCode,  @CreatedOn)";

                        para = new string[] { "@CityCode", "@CityName", "@StateCode", "@CreatedOn" };
                        values = new object[] { CityCode, CityName, _statecode, GlobalFunction.GetDateTimeWithoutMiliSecond(System.DateTime.Now) };

                        transList.Add(new Transaction(str1, para, values));


                        // UPdate counter
                        str1 = "Update UniqueCodeMaster set CurrentNo=CurrentNo + IncrementBy where TableName='CityMaster'";
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
                    DialogResult dr = MessageBox.Show("Do You Want to Update '" + txtCityCode.Text + "'", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (dr == DialogResult.OK)
                    {
                        str1 = "Update CityMaster set CityName=@CityName, StateCode=@StateCode, LastModify=@LastModify  Where CityCode = @CityCode";
                        para = new string[] { "@CityName", "@StateCode", "@LastModify", "@CityCode" };
                        values = new object[] { CityName, _statecode, GlobalFunction.GetDateTimeWithoutMiliSecond(DateTime.Now), CityCode };

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

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


        private frmStateMaster frmStateMaster;

        private void cmdSearch_Click(object sender, EventArgs e)
        {

            ProcessStateMasterInterface();  
            
           
        }

        private void ProcessStateMasterInterface()
        {
            LoadStateMasterInterface();

            ShowStateMasterForm();

            UnloadStateMasterInterface();

        }

        private void LoadStateMasterInterface()
        {
            if (frmStateMaster == null)
                frmStateMaster = new frmStateMaster();          
        }

        private void UnloadStateMasterInterface()
        {
            frmStateMaster.Close();
            frmStateMaster = null;
        }

        private void ShowStateMasterForm()
        {
            DialogResult result;
            frmStateMaster.IsLookup = 1;
            result = frmStateMaster.ShowDialog();
            if (result == DialogResult.OK)
            {
                _statecode = frmStateMaster.StateCode;
                txtStateName.Text = frmStateMaster.StateName;
            }
            else
            {
                //textBox4.Text = "";
            }
        }

    }
}

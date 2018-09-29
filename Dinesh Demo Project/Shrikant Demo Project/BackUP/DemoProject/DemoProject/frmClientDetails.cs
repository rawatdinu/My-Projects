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
    


    public partial class frmClientDetails : Form
    {
        public string ClientCode { get; set; }        
        public string ClientName { get; set; }
        public string ContactNo { get; set; }
        public string Remarks { get; set; }
        public string State { get; set; }
        public string IndustryType { get; set; }
        public int IsActive{ get; set; }
        public string AddService{ get; set; }


        public bool AddCleint = false;
        public bool EditClient = false;

        public frmClientDetails()
        {
            InitializeComponent();
        }

        private void frmClientDetails_Load(object sender, EventArgs e)
        {
            this.Text = "Client Details" + ClientCode;
            cboState.SelectedIndex = 0;
            cboIndustryType.SelectedIndex = 0;
            cboService.SelectedIndex = 0;

            if (EditClient)
            {
                GetProperty();
            }
        }

        private void SetProperty()
        { 
                
        ClientName = txtClientName.Text;
        ContactNo = txtContactNo.Text;
        Remarks = txtRemarks.Text;
        State =  cboState.SelectedItem.ToString();
        IndustryType = cboIndustryType.SelectedItem.ToString();
            if(chkIsActive.Checked == true)
            {
                IsActive = 1;
            }
            else
            {
                IsActive = 0;
            }

            AddService = cboService.SelectedItem.ToString();
        }

        private void GetProperty()
        {

           txtClientName.Text = ClientName ;
           txtContactNo.Text = ContactNo;
           txtRemarks.Text = Remarks ;
           cboState.SelectedItem = State;
           cboIndustryType.SelectedItem = IndustryType;
            if (IsActive == 1)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }

            cboService.SelectedItem = AddService;
        }

      
        private void Save()
        {

            string[] para;
            object[] values;
            string str1;

            object obj;

            try
            {
                if (AddCleint)
                {
                    DialogResult dr = MessageBox.Show("Do You Want to Save Data ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (dr == DialogResult.OK)
                    {
                        ClientCode = GlobalFunction.GetUniqueNo("ClientMaster", "CL", 5);


                       
                        /*Master Table**/
                        //str1 = "INSERT INTO ShareMaster(ShareHolderName,Address,PhoneNo,IsActive,CreatedOn) VALUES (@ShareHolderName,@Address,@PhoneNo,@IsActive,@CreatedOn)";
                        str1 = "INSERT INTO ClientMaster(ClientCode, ClientName, ContactNo, Remarks, State, IndustryType, IsActive, AddService) VALUES (@ClientCode, @ClientName, @ContactNo, @Remarks, @State, @IndustryType, @IsActive, @AddService)";

                        para = new string[] { "@ClientCode", "@ClientName", "@ContactNo", "@Remarks", "@State", "@IndustryType", "@IsActive", "@AddService" };
                        values = new object[] { ClientCode, ClientName, ContactNo, Remarks, State, IndustryType, Convert.ToBoolean(IsActive), AddService };




                        //oleParam = new OleDbParameter[]
                        // {
                        //      new OleDbParameter("@ID",TempID),
                        //    new OleDbParameter("@ShareHolderName",GetProperName(txtName.Text)),
                        //     new  OleDbParameter("@Address",txtAddress.Text.Trim()),
                        //     new  OleDbParameter("@PhoneNo",txtPhone.Text.Trim()),
                        //     new  OleDbParameter("@IsActive", 1),
                        //     new  OleDbParameter("@CreatedOn",DateTime.Now.Date)
                        // };
                        obj = DBService.ExecuteNonQuerry(str1, para, values);
                        if (obj != null)
                        {
                            AddCleint = false;
                            //ID = TempID;
                            //MessageBox.Show("Share Holder is Added succesfully");

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
                /******************************EDIT*****************************************/
                else if (EditClient)
                {
                    DialogResult dr = MessageBox.Show("Do You Want to Update '" + txtClientName.Text + "'", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (dr == DialogResult.OK)
                    {
                        str1 = "Update ClientMaster set ClientName=@ClientName,ContactNo=@ContactNo,Remarks=@Remarks,State=@State,IndustryType=@IndustryType, IsActive =@IsActive, AddService = @AddService  Where ClientCode = @ClientCode";
                        para = new string[] { "@ClientName", "@ContactNo", "@Remarks", "@State", "@IndustryType", "@IsActive", "@AddService", "@ClientCode" };
                        values = new object[] { ClientName, ContactNo, Remarks, State, IndustryType, Convert.ToBoolean(IsActive), AddService, ClientCode };

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
                            EditClient = false;
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

        private void Display()
        {
            DataTable dt = new DataTable();
            string str;
            int RecNo;            
            

            try
            {
                str = "SELECT ClientCode, ClientName, ContactNo, Remarks, State, IndustryType, IsActive, AddService FROM ClientMaster ORDER BY ClientCode";
                dt = DBService.GetDataTable(str);
                RecNo = dt.Rows.Count;
                
                if (RecNo > 0)
                {

                   

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


    }
}

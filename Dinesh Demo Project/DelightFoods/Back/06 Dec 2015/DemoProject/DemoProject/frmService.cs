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
    public partial class frmService : Form
    {

        private bool IsEdit = false;
        private bool IsAdd = false;
        private string _validationMessege = "";
        private int _hostID;

        public string ClientCode = "";
        public string ClientName = "";

        private frmClientMaster frmClientMaster;


        //Constant
        private const int SNo = 0;
        private const int ServiceID = 1;
        private const int ServiceName = 2;
        private const int Description = 3;
        private const int BillableValue = 4;
        private const int VAT = 5;
        private const int FeesPerc = 6;
        private const int FeesInValue = 7;
        private const int ST = 8;

        //private const int BalanceLoan = 9;
        //private const int Interest = 10;
        //private const int NewLoan = 11;
        //private const int NewInterest = 12;
        //private const int Penalty = 13;
        //private const int TotalLoan = 14;
        //private const int Deposit = 15;
        //private const int ShareRemarks = 16;

        //column width
        private const int SNoWidth = 40;
        private const int ServiceIDWidth = 40;
        private const int ServiceNameWidth = 40;
        private const int DescriptionWidth = 140;
        private const int BillableValueWidth = 100;
        private const int VATWidth = 60;
        private const int FeesPercWidth = 100;        
        private const int FeesInValueWidth = 80;
        private const int STWidth = 100;

        //private const int InterestWidth = 60;
        //private const int NewLoanWidth = 100;
        //private const int NewInterestWidth = 60;
        //private const int PenaltyWidth = 80;
        //private const int TotalLoanWidth = 100;
        //private const int DepositWidth = 100;
        //private const int ShareRemarksWidth = 200;

        public frmService()
        {
            InitializeComponent();
        }

        private void frmService_Load(object sender, EventArgs e)
        {
            DesignMainGrid();
            ClearControl();
            ControlStatus(true);
            
            DisplayData();


        }

        private void ControlStatus(bool status)
        {
            cmdNew.Enabled = status;
            cmdEdit.Enabled = status;
            cmSave.Enabled = !(status);
            cmdCancel.Enabled = !(status);

            txtServiceId.ReadOnly = true;
            txtClientName.ReadOnly = status;
            txtRemarks.ReadOnly = status;
            dtpServiceDate.Enabled = !(status);
            txtTotalAmount.ReadOnly = status;

            cmdAddService.Enabled = !(status);
            cmdRemoveService.Enabled = !(status);
     
           
        
        }
        private void ClearControl()
        {
            txtServiceId.Text = "";
            dtpServiceDate.Value = DateTime.Now;
            txtClientName.Text = "";
            ClientName = "";
            ClientCode = "";
            txtRemarks.Text = "";
            txtTotalAmount.Text = "";
            dgvMain.RowCount = 0;
        }


        private void DesignMainGrid()
        {
            dgvMain.RowCount = 1;
            dgvMain.ColumnCount = 9;

            dgvMain.Columns[0].Name = "S.No";
            dgvMain.Columns[0].Width = SNoWidth;
            dgvMain.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Share Name
            dgvMain.Columns[1].Name = "ServiceID";
            dgvMain.Columns[1].Width = ServiceIDWidth;

            dgvMain.Columns[2].Name = "ServiceName";
            dgvMain.Columns[2].Width = ServiceNameWidth;

            dgvMain.Columns[3].Name = "Description";
            dgvMain.Columns[3].Width = DescriptionWidth;

            dgvMain.Columns[4].Name = "Billable Value";
            dgvMain.Columns[4].Width = BillableValueWidth;      //323
            dgvMain.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            
            dgvMain.Columns[5].Name = "VAT";
            dgvMain.Columns[5].Width = VATWidth;
            

            dgvMain.Columns[6].Name = "Fees(%)";
            dgvMain.Columns[6].Width = FeesPercWidth;
            dgvMain.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMain.Columns[7].Name = "Fees In Value";
            dgvMain.Columns[7].Width = FeesInValueWidth;      //323
            dgvMain.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

           
            dgvMain.Columns[8].Name = "ST";
            dgvMain.Columns[8].Width = STWidth;
            


            dgvMain.RowHeadersVisible = false;
            dgvMain.AllowUserToDeleteRows = false;
            dgvMain.AllowUserToAddRows = false;
            dgvMain.AllowUserToResizeRows = false;
            dgvMain.AllowUserToResizeColumns = true;
            dgvMain.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvMain.ScrollBars = ScrollBars.Both;
            dgvMain.SelectionMode = DataGridViewSelectionMode.CellSelect;


            //GlobalFunction.SetGridStyle(dgvMain);

            //if (GlobalFunction.glbUserType == GlobalFunction.SuperUser)
            //{
            //    dgvMain.Columns[1].Visible = true;   //ID
            //    dgvMain.Columns[2].Visible = true;
            //}
            //else
            //{
            //    dgvMain.Columns[1].Visible = false;
            //    dgvMain.Columns[2].Visible = false;
            //}


            //if (Meeting.SpecialLoanScheme == 1)
            //{
            //    dgvMain.Columns[11].Visible = true;   
            //    dgvMain.Columns[12].Visible = true;
            //    dgvMain.Columns[13].Visible = true;
            //    dgvMain.Columns[14].Visible = true;
            //    dgvMain.Columns[17].Visible = true;
            //    dgvMain.Columns[18].Visible = true;
            //}
            //else
            //{
            //    dgvMain.Columns[11].Visible = false;
            //    dgvMain.Columns[12].Visible = false;
            //    dgvMain.Columns[13].Visible = false;
            //    dgvMain.Columns[14].Visible = false;
            //    dgvMain.Columns[17].Visible = false;
            //    dgvMain.Columns[18].Visible = false;
            //}


        }

        public void DisplayData(string meetingID = "-1")
        {
            DataTable dt = new DataTable();
            string str;
            int rowCount;
            try
            {
                ClearControl();
                if (meetingID == "-1")// show last record by default
                {

                    str = "SELECT ShareDetails.SHID, ShareDetails.SID, ShareDetails.ShareName, M.MeetingFileMaster.MeetingID as MeetingID, M.MeetingDate, M.HostID, M.Place, M.MeetingFileMaster.Remarks as Remarks, M.Previous_Capital, M.Fee, M.New_Capital, M.Previous_Loan, M.Loan_Return, M.Balance_Loan, M.Interest,  M.New_Loan, M.New_Interest,  M.Penalty, M.Deposit,M.Loan, M.MeetingFileDetails.Remarks as ShareRemarks FROM ShareDetails LEFT JOIN (SELECT  * FROM MeetingFileMaster INNER JOIN MeetingFileDetails ON MeetingFileMaster.MeetingID = MeetingFileDetails.MeetingID)  AS M ON ShareDetails.SID = M.SID Where (M.MeetingFileMaster.MeetingID =(SELECT MAX  (MeetingFileMaster.MeetingID)  FROM MeetingFileMaster) and ShareDetails.IsActiveShare = 1 ) Order by ShareDetails.SHID, ShareDetails.SID";
                }
                else // show data according to meetingID
                {
                    str = "SELECT ShareDetails.SHID, ShareDetails.SID, ShareDetails.ShareName, M.MeetingFileMaster.MeetingID as MeetingID, M.MeetingDate, M.HostID, M.Place, M.MeetingFileMaster.Remarks as Remarks, M.Previous_Capital, M.Fee, M.New_Capital, M.Previous_Loan, M.Loan_Return, M.Balance_Loan, M.Interest,  M.New_Loan, M.New_Interest,  M.Penalty, M.Deposit,M.Loan, M.MeetingFileDetails.Remarks as ShareRemarks FROM ShareDetails LEFT JOIN (SELECT  * FROM MeetingFileMaster INNER JOIN MeetingFileDetails ON MeetingFileMaster.MeetingID = MeetingFileDetails.MeetingID)  AS M ON ShareDetails.SID = M.SID Where (M.MeetingFileMaster.MeetingID ='" + meetingID + "' and ShareDetails.IsActiveShare = 1 ) Order by ShareDetails.SHID, ShareDetails.SID";
                }

                dt = DBService.GetDataTable(str);
                rowCount = dt.Rows.Count;
                if (rowCount > 0)
                {

                    txtServiceId.Text = Convert.ToString(dt.Rows[0]["MeetingID"]);
                    dtpServiceDate.Value = Convert.IsDBNull(dt.Rows[0]["MeetingDate"]) ? DateTime.Now.Date : ((System.DateTime)(dt.Rows[0][4])).Date;

                    ClientCode = "";
                    ClientName = "";
                    txtClientName.Text = ClientName;
                    txtRemarks.Text = Convert.ToString(dt.Rows[0]["Remarks"]);
                    txtTotalAmount.Text = Convert.ToString(dt.Rows[0]["Remarks"]);


                    for (int i = 0; i < rowCount; i++)
                    {

        //                 private const int ServiceID = 1;
        //private const int ServiceName = 2;
        //private const int Description = 3;
        //private const int BillableValue = 4;
        //private const int VAT = 5;
        //private const int FeesPerc = 6;
        //private const int FeesInValue = 7;
        //private const int ST = 8;
                        //share details                        
                        //dgvMain.RowCount += 1;
                        dgvMain.RowCount = i + 1;
                        dgvMain.Rows[i].Cells[SNo].Value = i + 1;
                        dgvMain.Rows[i].Cells[ServiceID].Value = Convert.ToString(dt.Rows[i]["SHID"]);
                        dgvMain.Rows[i].Cells[ServiceName].Value = Convert.ToString(dt.Rows[i]["SID"]);
                        dgvMain.Rows[i].Cells[Description].Value = Convert.ToString(dt.Rows[i]["ShareName"]);

                        //Meeting details
                        dgvMain.Rows[i].Cells[BillableValue].Value = Convert.IsDBNull(dt.Rows[i]["Previous_Capital"]) ? 0 : dt.Rows[i]["Previous_Capital"];
                        dgvMain.Rows[i].Cells[VAT].Value = Convert.IsDBNull(dt.Rows[i]["Fee"]) ? 0 : dt.Rows[i]["Fee"];
                        dgvMain.Rows[i].Cells[FeesPerc].Value = Convert.IsDBNull(dt.Rows[i]["New_Capital"]) ? 0 : dt.Rows[i]["New_Capital"];

                        dgvMain.Rows[i].Cells[FeesInValue].Value = Convert.IsDBNull(dt.Rows[i]["Previous_Loan"]) ? 0 : dt.Rows[i]["Previous_Loan"];
                        dgvMain.Rows[i].Cells[ST].Value = Convert.IsDBNull(dt.Rows[i]["Loan_Return"]) ? 0 : dt.Rows[i]["Loan_Return"];
                     
                    }

                }
                else
                {
                    dgvMain.RowCount = 0;
                }
                

                ControlStatus(true);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Save()
        {
            string querry = "";
            string[] para;
            object[] values;
            List<Transaction> transList = new List<Transaction>();

            string str1;
            object obj;
            int rowCount;

          

            try
            {
                if (IsAdd)
                {
                    DialogResult dr = MessageBox.Show("Do you want to save?", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (dr == DialogResult.OK)
                    {


                        str1 = "Insert Into ServiceMaster (ServiceID, ClientCode, ServiceDate, Remarks, Amount, CreatedOn) values (@ServiceID, @ClientCode, @ServiceDate, @Remarks, @Remarks,@Amount,  @CreatedOn)";
                        para = new string[] { "@ServiceID", "@ClientCode", "@ServiceDate", "@Remarks", "@Remarks", "@Amount", "@CreatedOn" };
                        values = new object[] { txtServiceId.Text.Trim(), ClientCode, dtpServiceDate.Value,  txtRemarks.Text, txtTotalAmount.Text, GlobalFunction.GetDateTimeWithoutMiliSecond(DateTime.Now) };
                        transList.Add(new Transaction(str1, para, values));

                        //Save details
                        rowCount = dgvMain.RowCount;
                        for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                        {
                            str1 = "Insert into ServiceDetails (ServiceID, ServiceName, Description, BillableValue, VAT, FeesPerc, FeesInValue, ST) values (@ServiceID, @ServiceName, @Description, @BillableValue, @VAT, @FeesPerc, @FeesInValue, @ST)";
                            para = new string[] { "@ServiceID", "@ServiceName", "@Description", "@BillableValue", "@VAT", "@FeesPerc", "@FeesInValue", "@ST" };

                            values = new object[] { txtServiceId.Text.Trim(), Convert.ToString(dgvMain.Rows[rowIndex].Cells[ServiceName].Value), Convert.ToString(dgvMain.Rows[rowIndex].Cells[Description].Value), Convert.ToDecimal(dgvMain.Rows[rowIndex].Cells[BillableValue].Value), Convert.ToString(dgvMain.Rows[rowIndex].Cells[VAT].Value), Convert.ToDecimal(dgvMain.Rows[rowIndex].Cells[FeesPerc].Value), Convert.ToDecimal(dgvMain.Rows[rowIndex].Cells[FeesInValue].Value), Convert.ToString(dgvMain.Rows[rowIndex].Cells[ST].Value) };

                            transList.Add(new Transaction(str1, para, values));
                        }


                        obj = DBService.ExecuteTransaction(transList);
                        if (obj != null)
                        {
                            IsAdd = false;
                            MessageBox.Show("Meeting File is saved succesfully");
                            ControlStatus(true);
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
                    DialogResult dr = MessageBox.Show("Do you want to update?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (dr == DialogResult.OK)
                    {


                        str1 = "Update  ServiceMaster set ClientCode=@ClientCode, ServiceDate=@ServiceDate, Remarks=@Remarks, Amount=@Amount, LastModify=@LastModify Where ServiceID=@ServiceID";

                        para = new string[] { "@ClientCode", "@ServiceDate", "@Remarks", "@Remarks", "@Amount", "@LastModify", "@ServiceID" };

                        values = new object[] { ClientCode, dtpServiceDate.Value, txtRemarks.Text, txtTotalAmount.Text, GlobalFunction.GetDateTimeWithoutMiliSecond(DateTime.Now), txtServiceId.Text.Trim() };

                        transList.Add(new Transaction(str1, para, values));

                        //Delete old detials
                        str1 = "Delete * From  ServiceMaster Where ServiceID=@ServiceID";
                        para = new string[] { "@ServiceID" };
                        values = new object[] {  txtServiceId.Text.Trim() };


                        //Insert New  details
                        rowCount = dgvMain.RowCount;
                        for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                        {
                            str1 = "Insert into ServiceDetails (ServiceID, ServiceName, Description, BillableValue, VAT, FeesPerc, FeesInValue, ST) values (@ServiceID, @ServiceName, @Description, @BillableValue, @VAT, @FeesPerc, @FeesInValue, @ST)";
                            para = new string[] { "@ServiceID", "@ServiceName", "@Description", "@BillableValue", "@VAT", "@FeesPerc", "@FeesInValue", "@ST" };

                            values = new object[] { txtServiceId.Text.Trim(), Convert.ToString(dgvMain.Rows[rowIndex].Cells[ServiceName].Value), Convert.ToString(dgvMain.Rows[rowIndex].Cells[Description].Value), Convert.ToDecimal(dgvMain.Rows[rowIndex].Cells[BillableValue].Value), Convert.ToString(dgvMain.Rows[rowIndex].Cells[VAT].Value), Convert.ToDecimal(dgvMain.Rows[rowIndex].Cells[FeesPerc].Value), Convert.ToDecimal(dgvMain.Rows[rowIndex].Cells[FeesInValue].Value), Convert.ToString(dgvMain.Rows[rowIndex].Cells[ST].Value) };

                            transList.Add(new Transaction(str1, para, values));
                        }

                        obj = DBService.ExecuteTransaction(transList);
                        if (obj != null)
                        {
                            IsEdit = false;
                            ControlStatus(true);
                            MessageBox.Show("Meeting File is updated succesfully");

                        }
                        else
                        {
                            MessageBox.Show("Error Occurs", "ERROR");
                        }

                    }

                }
                else
                {
                    ControlStatus(true);
                    IsAdd = false;
                    IsEdit = false;
                }

                DisplayData(txtServiceId.Text.Trim());

            }
            catch (Exception ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
            }

        }

        private void cmdSearchClient_Click(object sender, EventArgs e)
        {
            ProcessClientMasterInterface();
        }

        private void ProcessClientMasterInterface()
        {
            LoadClientMasterInterface();

            ShowClientMasterForm();

            UnloadClientMasterInterface();

        }

        private void LoadClientMasterInterface()
        {
            if (frmClientMaster == null)
                frmClientMaster = new frmClientMaster();
        }

        private void UnloadClientMasterInterface()
        {
            frmClientMaster.Close();
            frmClientMaster = null;
        }

        private void ShowClientMasterForm()
        {
            DialogResult result;
            //frmClientMaster.IsLookup = 1;
            result = frmClientMaster.ShowDialog();
            if (result == DialogResult.OK)
            {
                ClientCode = "";
                ClientName = "";
                txtClientName.Text = "";
            }
            else
            {
                //textBox4.Text = "";
            }
        }


        private void cmdNew_Click(object sender, EventArgs e)
        {
            string meeintNo = GlobalFunction.GetUniqueCode("ServiceMaster"); 
            if (meeintNo != "-1")
            {
                IsAdd = true;
                IsEdit = false;
                ClearControl();
                ControlStatus(false);
                txtServiceId.Text = meeintNo;
                dtpServiceDate.Value = DateTime.Now.Date;
                
            }
            else
            {
                MessageBox.Show("Invalid Service ID. " + meeintNo);
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            IsAdd = false;
            IsEdit = true;

        }

        private void cmSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        
    }
}

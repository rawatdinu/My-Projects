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
    public partial class frmMeetingFile : Form
    {
        private bool IsEdit = false;
        private bool IsAdd = false;
        private string _validationMessege = "";
        private int _hostID;

        //Constant
        private const int SNo = 0;
        private const int SHID = 1;
        private const int SID = 2;
        private const int ShareName = 3;
        private const int PrevCapital = 4;
        private const int CapitalFee = 5;
        private const int TotalCapital = 6;
        private const int PrevLoan = 7;
        private const int LoanReturn = 8;
        private const int BalanceLoan = 9;
        private const int Interest = 10;
        private const int NewLoan = 11;
        private const int NewInterest = 12;
        private const int Penalty = 13;
        private const int TotalLoan = 14;
        private const int Deposit = 15;
        private const int ShareRemarks = 16;

        //column width
        private const int SNoWidth = 40;
        private const int SHIDWidth = 40;
        private const int SIDWidth = 40;
        private const int ShareNameWidth = 140;
        private const int PrevCapitalWidth = 100;
        private const int CapitalFeeWidth = 60;
        private const int TotalCapitalWidth = 100;
        private const int PrevLoanWidthWidth = 100;
        private const int LoanReturnWidth = 80;
        private const int BalanceLoanWidth = 100;
        private const int InterestWidth = 60;
        private const int NewLoanWidth = 100;
        private const int NewInterestWidth = 60;
        private const int PenaltyWidth = 80;
        private const int TotalLoanWidth = 100;
        private const int DepositWidth = 100;
        private const int ShareRemarksWidth = 200;

                  
        public frmMeetingFile()
        {
            InitializeComponent();
            
        }

        private void frmMeetingFile_Load(object sender, EventArgs e)
        {
            DesignMainGrid();
            DesignSumGrid();
            Clear();
            ControlStatus(true);
            FillHostName();
            DisplayData();

        }

        private void FillHostName()
        {
            DataTable dt = new DataTable();
            string str;
            int RecNo;
            try
            {
                str = "SELECT  ID, ShareHolderName FROM ShareMaster WHERE (IsActive=1) ORDER BY ID";
                dt = DBService.GetDataTable(str);
                RecNo = dt.Rows.Count;
                
                if (RecNo > 0)
                {
                    cboHostName.DataSource = dt;
                    cboHostName.DisplayMember = "ShareHolderName";
                    cboHostName.ValueMember = "ID";
                    cboHostName.SelectedIndex = 0;
                }               
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ControlStatus(bool status)
        {
            btnAdd.Enabled = status;
            btnEdit.Enabled = status;
            btnSave.Enabled = !(status); 
            btnCancel.Enabled = !(status);

            txtMeetingNo.ReadOnly = true;
            txtPlace.ReadOnly = status;
            txtRemarks.ReadOnly = status;
            dtpDate.Enabled = !(status);
          

        }
        private void Clear()
        {
            txtMeetingNo.Text = "";
            dtpDate.Value = DateTime.Now;
            cboHostName.SelectedIndex = -1;
            txtPlace.Text = "";
            txtRemarks.Text = "";
            dgvMain.RowCount = 0;
            dgvMain.RowCount = 0;

        }

        private void DesignMainGrid()
        {
            dgvMain.RowCount = 1;
            dgvMain.ColumnCount = 17;

            dgvMain.Columns[0].Name = "S.No";
            dgvMain.Columns[0].Width = SNoWidth;
            dgvMain.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            //Share Name
            dgvMain.Columns[1].Name = "SHID";
            dgvMain.Columns[1].Width = SHIDWidth;
            dgvMain.Columns[2].Name = "SID";
            dgvMain.Columns[2].Width = SIDWidth;
            dgvMain.Columns[3].Name = "Share Name";
            dgvMain.Columns[3].Width = ShareNameWidth;      //323
            
            //Capital
            dgvMain.Columns[4].Name = "PrevCapital";
            dgvMain.Columns[4].Width = PrevCapitalWidth;
            dgvMain.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMain.Columns[5].Name = "Fee";
            dgvMain.Columns[5].Width = CapitalFeeWidth;
            dgvMain.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMain.Columns[6].Name = "Total Cap.";
            dgvMain.Columns[6].Width = TotalCapitalWidth;      //323
            dgvMain.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Loan
            dgvMain.Columns[7].Name = "PrevLoan";
            dgvMain.Columns[7].Width = PrevLoanWidthWidth;
            dgvMain.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMain.Columns[8].Name = "LoanReturn";
            dgvMain.Columns[8].Width = LoanReturnWidth;
            dgvMain.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMain.Columns[9].Name = "BalLoan";
            dgvMain.Columns[9].Width = BalanceLoanWidth;
            dgvMain.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMain.Columns[10].Name = "Interest";
            dgvMain.Columns[10].Width = InterestWidth;
            dgvMain.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            //Spcl. Loan
            //dgvMain.Columns[11].Name = "SpclPrevLoan";
            //dgvMain.Columns[11].Width = 100;
            //dgvMain.Columns[12].Name = "SpclLoanReturn";
            //dgvMain.Columns[12].Width = 100;
            //dgvMain.Columns[13].Name = "SpclBalLoan";
            //dgvMain.Columns[13].Width = 100;
            //dgvMain.Columns[14].Name = "SplInterest";
            //dgvMain.Columns[14].Width = 80;

            //New Loan
            dgvMain.Columns[11].Name = "NewLoan";
            dgvMain.Columns[11].Width = NewLoanWidth;
            dgvMain.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMain.Columns[12].Name = "NewInt";
            dgvMain.Columns[12].Width = NewInterestWidth;
            dgvMain.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // New Spcl.Loan
            //dgvMain.Columns[17].Name = "SpclNewLoan";
            //dgvMain.Columns[17].Width = 100;
            //dgvMain.Columns[18].Name = "SpclNewInt";
            //dgvMain.Columns[18].Width = 80;


            dgvMain.Columns[13].Name = "Penalty";
            dgvMain.Columns[13].Width = PenaltyWidth;
            dgvMain.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMain.Columns[14].Name = "Total_Loan";
            dgvMain.Columns[14].Width = TotalLoanWidth;
            dgvMain.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
           
            dgvMain.Columns[15].Name = "Deposit";
            dgvMain.Columns[15].Width = DepositWidth;
            dgvMain.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMain.Columns[16].Name = "Remarks";
            dgvMain.Columns[16].Width = ShareRemarksWidth;      //323
            

            
            dgvMain.RowHeadersVisible = false;
            dgvMain.AllowUserToDeleteRows = false;
            dgvMain.AllowUserToAddRows = false;
            dgvMain.AllowUserToResizeRows = false;
            dgvMain.AllowUserToResizeColumns = true;
            dgvMain.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvMain.ScrollBars = ScrollBars.Both;
            dgvMain.SelectionMode = DataGridViewSelectionMode.CellSelect;
            

            GlobalFunction.SetGridStyle(dgvMain);

            if (GlobalFunction.glbUserType == GlobalFunction.SuperUser)
            {
                dgvMain.Columns[1].Visible = true;   //ID
                dgvMain.Columns[2].Visible = true;
            }
            else
            {
                dgvMain.Columns[1].Visible = false;
                dgvMain.Columns[2].Visible = false;
            }


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

        private void DesignSumGrid()
        {
            dgvTotal.RowCount = 1;                        
            dgvTotal.ColumnCount = 17;            
            

            dgvTotal.Columns[0].Name = "S.No";
            dgvTotal.Columns[0].Width = SNoWidth;
            dgvTotal.Columns[0].Visible = false;
                       
            //Share Name
            dgvTotal.Columns[1].Name = "SHID";
            dgvTotal.Columns[1].Width = SHIDWidth;
            dgvTotal.Columns[2].Name = "SID";
            dgvTotal.Columns[2].Width = SIDWidth;
            dgvTotal.Columns[3].Name = "Share Name";
            dgvTotal.Columns[3].Width = ShareNameWidth + SNoWidth;      //323
            dgvTotal.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //Capital
            dgvTotal.Columns[4].Name = "PrevCapital";
            dgvTotal.Columns[4].Width = PrevCapitalWidth;
            dgvTotal.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            

            dgvTotal.Columns[5].Name = "Fee";
            dgvTotal.Columns[5].Width = CapitalFeeWidth;
            dgvTotal.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTotal.Columns[6].Name = "Total Cap.";
            dgvTotal.Columns[6].Width = TotalCapitalWidth;      //323
            dgvTotal.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Loan
            dgvTotal.Columns[7].Name = "PrevLoan";
            dgvTotal.Columns[7].Width = PrevLoanWidthWidth;
            dgvTotal.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTotal.Columns[8].Name = "LoanReturn";
            dgvTotal.Columns[8].Width = LoanReturnWidth;
            dgvTotal.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTotal.Columns[9].Name = "BalLoan";
            dgvTotal.Columns[9].Width = BalanceLoanWidth;
            dgvTotal.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTotal.Columns[10].Name = "Interest";
            dgvTotal.Columns[10].Width = InterestWidth;
            dgvTotal.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Spcl. Loan
            //dgvTotal.Columns[11].Name = "SpclPrevLoan";
            //dgvTotal.Columns[11].Width = 100;
            //dgvTotal.Columns[12].Name = "SpclLoanReturn";
            //dgvTotal.Columns[12].Width = 100;
            //dgvTotal.Columns[13].Name = "SpclBalLoan";
            //dgvTotal.Columns[13].Width = 100;
            //dgvTotal.Columns[14].Name = "SplInterest";
            //dgvTotal.Columns[14].Width = 80;

            //New Loan
            dgvTotal.Columns[11].Name = "NewLoan";
            dgvTotal.Columns[11].Width = NewLoanWidth;
            dgvTotal.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTotal.Columns[12].Name = "NewInt";
            dgvTotal.Columns[12].Width = NewInterestWidth;
            dgvTotal.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // New Spcl.Loan
            //dgvTotal.Columns[17].Name = "SpclNewLoan";
            //dgvTotal.Columns[17].Width = 100;
            //dgvTotal.Columns[18].Name = "SpclNewInt";
            //dgvTotal.Columns[18].Width = 80;


            dgvTotal.Columns[13].Name = "Penalty";
            dgvTotal.Columns[13].Width = PenaltyWidth;
            dgvTotal.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTotal.Columns[14].Name = "Total_Loan";
            dgvTotal.Columns[14].Width = TotalLoanWidth;
            dgvTotal.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTotal.Columns[15].Name = "Deposit";
            dgvTotal.Columns[15].Width = DepositWidth;
            dgvTotal.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTotal.Columns[16].Name = "Remarks";
            dgvTotal.Columns[16].Width = ShareRemarksWidth;      //323
            dgvTotal.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            dgvTotal.RowHeadersVisible = false;
            dgvTotal.ColumnHeadersVisible = false;
            dgvTotal.AllowUserToDeleteRows = false;
            dgvTotal.AllowUserToAddRows = false;
            dgvTotal.AllowUserToResizeRows = false;
            dgvTotal.AllowUserToResizeColumns = true;
            dgvTotal.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvTotal.ScrollBars = ScrollBars.Both;
            dgvTotal.SelectionMode = DataGridViewSelectionMode.CellSelect;            
            dgvTotal.DefaultCellStyle.Font = new Font(dgvTotal.Font.FontFamily, 9.0F, FontStyle.Bold);
            dgvTotal.RowTemplate.Height = 27;

            GlobalFunction.SetGridStyle(dgvTotal);

            if (GlobalFunction.glbUserType == GlobalFunction.SuperUser)
            {
                dgvTotal.Columns[1].Visible = true;   //ID
                dgvTotal.Columns[2].Visible = true;
            }
            else
            {
                dgvTotal.Columns[1].Visible = false;
                dgvTotal.Columns[2].Visible = false;
            }


            //if (Meeting.SpecialLoanScheme == 1)
            //{
            //    dgvTotal.Columns[11].Visible = true;   
            //    dgvTotal.Columns[12].Visible = true;
            //    dgvTotal.Columns[13].Visible = true;
            //    dgvTotal.Columns[14].Visible = true;
            //    dgvTotal.Columns[17].Visible = true;
            //    dgvTotal.Columns[18].Visible = true;
            //}
            //else
            //{
            //    dgvTotal.Columns[11].Visible = false;
            //    dgvTotal.Columns[12].Visible = false;
            //    dgvTotal.Columns[13].Visible = false;
            //    dgvTotal.Columns[14].Visible = false;
            //    dgvTotal.Columns[17].Visible = false;
            //    dgvTotal.Columns[18].Visible = false;
            //}

            
            dgvTotal.RowCount = 1;
            dgvTotal.Rows[0].Cells[ShareName].Value = "Total";
        }

        private bool _IsFirstMeeting = true;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string meeintNo=GetNewMeetingNo();
            if (meeintNo != "-1")
            {
                IsAdd = true;
                IsEdit = false;
                Clear();
                ControlStatus(false);
                txtMeetingNo.Text = meeintNo;
                dtpDate.Value = DateTime.Now.Date;
                GetLastMeetingData();
               
            }
            else
            {                
                MessageBox.Show("Invalid meeting No. " + meeintNo);
            }
            
        }
        
        private string GetNewMeetingNo()
        {
            string str1;
            int TempID;
            string meetingNo = "";

            try
            {
                str1 = "SELECT  count(*) as tempID FROM MeetingFileMaster";
                TempID = Convert.ToInt32(DBService.ExecuteScalar(str1));

                if (TempID == 0)
                {
                    _IsFirstMeeting = true;
                }
                else
                {
                    _IsFirstMeeting = false;
                }

                TempID = TempID + 1;

                meetingNo = "ME" + Convert.ToString(TempID).PadLeft(5, '0');
                return meetingNo;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                meetingNo = "-1";
                return meetingNo;
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            IsEdit = true;
            IsAdd = false;
            ControlStatus(false);
        }

        bool ValidateData()
        {                    
            _validationMessege = "";
            bool result = true;
            if (cboHostName.SelectedIndex == -1)
            {
                _validationMessege = "Select Host Name";
                MessageBox.Show(_validationMessege);
                result = false;
            }

            else if(txtPlace.Text.Trim()=="")
            {
                _validationMessege = "Enter Place Name";
                MessageBox.Show(_validationMessege);
                result = false;
            }

            return result;
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

            int total_PrevCapital = Convert.ToInt32(dgvTotal.Rows[0].Cells[PrevCapital].Value);
            int total_Fee = Convert.ToInt32(dgvTotal.Rows[0].Cells[CapitalFee].Value);
            int total_NewCapital = Convert.ToInt32(dgvTotal.Rows[0].Cells[TotalCapital].Value);
            int total_PrevLoan = Convert.ToInt32(dgvTotal.Rows[0].Cells[PrevLoan].Value);
            int total_LoanReturn = Convert.ToInt32(dgvTotal.Rows[0].Cells[LoanReturn].Value);
            int total_BalanceLoan = Convert.ToInt32(dgvTotal.Rows[0].Cells[BalanceLoan].Value);
            int total_Interest = Convert.ToInt32(dgvTotal.Rows[0].Cells[Interest].Value);
            int total_NewLoan = Convert.ToInt32(dgvTotal.Rows[0].Cells[NewLoan].Value);
            int total_NewInterest = Convert.ToInt32(dgvTotal.Rows[0].Cells[NewInterest].Value);
            int total_Penalty = Convert.ToInt32(dgvTotal.Rows[0].Cells[Penalty].Value);
            int total_Loan = Convert.ToInt32(dgvTotal.Rows[0].Cells[TotalLoan].Value);
            int total_Deposit = Convert.ToInt32(dgvTotal.Rows[0].Cells[Deposit].Value);


            try
            {
                if (IsAdd)
                {
                    DialogResult dr = MessageBox.Show("Do you want to save?", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (dr == DialogResult.OK)
                    {
                        SortGridBySNo();

                        str1 = "Insert into MeetingFileMaster (MeetingID, MeetingDate, HostID, Place, Remarks,Total_PrevCapital, Total_Fee, Total_NewCapital, Total_PrevLoan, Total_LoanReturn, Total_BalanceLoan, Total_Interest, Total_NewLoan, Total_NewInterest, Total_Penalty, Total_Loan, Total_Deposit,CreatedOn) values (@ID, @MeetingDate, @HostID, @Place, @Remarks,@Total_PrevCapital, @Total_Fee, @Total_NewCapital, @Total_PrevLoan, @Total_LoanReturn, @Total_BalanceLoan, @Total_Interest, @Total_NewLoan, @Total_NewInterest, @Total_Penalty, @Total_Loan, @Total_Deposit, @CreatedOn)";
                        para = new string[] { "@ID", "@MeetingDate", "@HostID", "@Place", "@Remarks","@Total_PrevCapital", "@Total_Fee", "@Total_NewCapital", "@Total_PrevLoan", "@Total_LoanReturn","@Total_BalanceLoan", "@Total_Interest", "@Total_NewLoan", "@Total_NewInterest", "@Total_Penalty", "@Total_Loan", "@Total_Deposit", "@CreatedOn" };
                        values = new object[] { txtMeetingNo.Text.Trim(), dtpDate.Value, _hostID, txtPlace.Text.Trim(),txtRemarks.Text,total_PrevCapital, total_Fee, total_NewCapital, total_PrevLoan, total_LoanReturn, total_BalanceLoan, total_Interest, total_NewLoan, total_NewInterest, total_Penalty, total_Loan, total_Deposit, DateTime.Now.Date };
                        transList.Add(new Transaction( str1, para, values));

                        //Save details
                        rowCount = dgvMain.RowCount;
                        for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                        {
                            str1 = "Insert into MeetingFileDetails (MeetingID, SHID, SID, Previous_Capital, Fee, New_Capital, Previous_Loan, Loan_Return, Balance_Loan, Interest, New_Loan, New_Interest, Total_Loan, Penalty, Deposit, Remarks) values (@MeetingID, @SHID, @SID, @Previous_Capital, @Fee, @New_Capital, @Previous_Loan, @Loan_Return, @Balance_Loan, @Interest, @New_Loan, @New_Interest, @Loan, @Penalty, @Deposit, @Remarks)";
                            para = new string[] { "@MeetingID", "@SHID", "@SID", "@Capital", "@Fee", "@Total_Capital", "@Previous_Loan", "@Loan_Return", "@Balance_Loan", "@Interest", "@New_Loan", "@New_Interest", "@Loan", "@Penalty", "@Deposit", "@Remarks" };
                            values = new object[] { txtMeetingNo.Text.Trim(), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[SHID].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[SID].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[PrevCapital].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[CapitalFee].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[TotalCapital].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[PrevLoan].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[LoanReturn].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[BalanceLoan].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[Interest].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[NewLoan].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[NewInterest].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[TotalLoan].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[Penalty].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[Deposit].Value), Convert.ToString(dgvMain.Rows[rowIndex].Cells[ShareRemarks].Value) };

                            transList.Add(new Transaction(str1, para, values));
                        }


                        obj = DBService.ExecuteTransaction(transList);
                        if (obj != null)
                        {
                            IsAdd= false;                            
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
                        SortGridBySNo();

                        str1 = "Update  MeetingFileMaster set MeetingDate=@MeetingDate, HostID=@HostID, Place=@Place, Remarks=@Remarks,Total_PrevCapital=@Total_PrevCapital, Total_Fee=@Total_Fee, Total_NewCapital=@Total_NewCapital, Total_PrevLoan=@Total_PrevLoan, Total_LoanReturn=@Total_LoanReturn, Total_BalanceLoan=@Total_BalanceLoan, Total_Interest=@Total_Interest, Total_NewLoan=@Total_NewLoan, Total_NewInterest=@Total_NewInterest, Total_Penalty=@Total_Penalty, Total_Loan=@Total_Loan, Total_Deposit=@Total_Deposit,UpdatedOn=@UpdatedOn Where ID=@ID";

                        para = new string[] { "@MeetingDate", "@HostID", "@Place", "@Remarks", "@Total_PrevCapital", "@Total_Fee", "@Total_NewCapital", "@Total_PrevLoan", "@Total_LoanReturn", "@Total_BalanceLoan", "@Total_Interest", "@Total_NewLoan", "@Total_NewInterest", "@Total_Penalty", "@Total_Loan", "@Total_Deposit", "@UpdatedOn", "@SID" };
                        values = new object[] { dtpDate.Value, _hostID, txtPlace.Text, txtRemarks.Text,total_PrevCapital, total_Fee, total_NewCapital, total_PrevLoan, total_LoanReturn, total_BalanceLoan, total_Interest, total_NewLoan, total_NewInterest, total_Penalty, total_Loan, total_Deposit, DateTime.Now.Date, txtMeetingNo.Text.Trim() };

                        transList.Add(new Transaction(str1, para, values));

                        //Save details
                        rowCount = dgvMain.RowCount;
                        for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                        {
                            str1 = "Update MeetingFileDetails set  Previous_Capital=@Previous_Capital, Fee=@Fee, New_Capital=@New_Capital, Previous_Loan=@Previous_Loan, Loan_Return=@Loan_Return, Balance_Loan=@Balance_Loan, Interest=@Interest, New_Loan=@New_Loan, New_Interest=@New_Interest, Loan=@Loan, Penalty=@Penalty, Deposit=@Deposit, Remarks=@Remarks where MeetingID=@MeetingID AND SHID=@SHID AND SID=@SID";
                            para = new string[] { "@Previous_Capital", "@Fee", "@New_Capital", "@Previous_Loan", "@Loan_Return", "@Balance_Loan", "@Interest", "@New_Loan", "@New_Interest", "@Loan", "@Penalty", "@Deposit", "@Remarks", "@MeetingID", "@SHID", "@SID" };
                            values = new object[] { Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[PrevCapital].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[CapitalFee].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[TotalCapital].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[PrevLoan].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[LoanReturn].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[BalanceLoan].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[Interest].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[NewLoan].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[NewInterest].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[TotalLoan].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[Penalty].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[Deposit].Value), Convert.ToString(dgvMain.Rows[rowIndex].Cells[ShareRemarks].Value), txtMeetingNo.Text.Trim(), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[SHID].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[SID].Value) };

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

                DisplayData(txtMeetingNo.Text.Trim());

            }
            catch (Exception ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
            }

        }

        public void DisplayData(string meetingID = "-1")
        {
            DataTable dt = new DataTable();
            string str;
            int rowCount;
            try
            {
                Clear();
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

                    txtMeetingNo.Text = Convert.ToString(dt.Rows[0]["MeetingID"]);
                    dtpDate.Value = Convert.IsDBNull(dt.Rows[0]["MeetingDate"]) ? DateTime.Now.Date : ((System.DateTime)(dt.Rows[0][4])).Date;
                    cboHostName.SelectedValue = Convert.IsDBNull(dt.Rows[0]["HostID"]) ? -1 : Convert.ToInt32(dt.Rows[0]["HostID"]);
                    txtPlace.Text = Convert.ToString(dt.Rows[0]["Place"]);
                    txtRemarks.Text = Convert.ToString(dt.Rows[0]["Remarks"]);

                    for (int i = 0; i < rowCount; i++)
                    {
                       
                        //share details                        
                        //dgvMain.RowCount += 1;
                        dgvMain.RowCount = i+1;
                        dgvMain.Rows[i].Cells[SNo].Value = i + 1;
                        dgvMain.Rows[i].Cells[SHID].Value = Convert.ToString(dt.Rows[i]["SHID"]);
                        dgvMain.Rows[i].Cells[SID].Value = Convert.ToString(dt.Rows[i]["SID"]);
                        dgvMain.Rows[i].Cells[ShareName].Value = Convert.ToString(dt.Rows[i]["ShareName"]);

                        //Meeting details
                        dgvMain.Rows[i].Cells[PrevCapital].Value = Convert.IsDBNull(dt.Rows[i]["Previous_Capital"]) ? 0 : dt.Rows[i]["Previous_Capital"];
                        dgvMain.Rows[i].Cells[CapitalFee].Value = Convert.IsDBNull(dt.Rows[i]["Fee"]) ? 0 : dt.Rows[i]["Fee"];
                        dgvMain.Rows[i].Cells[TotalCapital].Value = Convert.IsDBNull(dt.Rows[i]["New_Capital"]) ? 0 : dt.Rows[i]["New_Capital"];

                        dgvMain.Rows[i].Cells[PrevLoan].Value = Convert.IsDBNull(dt.Rows[i]["Previous_Loan"]) ? 0 : dt.Rows[i]["Previous_Loan"];
                        dgvMain.Rows[i].Cells[LoanReturn].Value = Convert.IsDBNull(dt.Rows[i]["Loan_Return"]) ? 0 : dt.Rows[i]["Loan_Return"];
                        dgvMain.Rows[i].Cells[BalanceLoan].Value = Convert.IsDBNull(dt.Rows[i]["Balance_Loan"]) ? 0 : dt.Rows[i]["Balance_Loan"];
                        dgvMain.Rows[i].Cells[Interest].Value = Convert.IsDBNull(dt.Rows[i]["Interest"]) ? 0 : dt.Rows[i]["Interest"];

                        dgvMain.Rows[i].Cells[NewLoan].Value = Convert.IsDBNull(dt.Rows[i]["New_Loan"]) ? 0 : dt.Rows[i]["New_Loan"];
                        dgvMain.Rows[i].Cells[NewInterest].Value = Convert.IsDBNull(dt.Rows[i]["New_Interest"]) ? 0 : dt.Rows[i]["New_Interest"];

                        dgvMain.Rows[i].Cells[Penalty].Value = Convert.IsDBNull(dt.Rows[i]["Penalty"]) ? 0 : dt.Rows[i]["Penalty"];

                        dgvMain.Rows[i].Cells[TotalLoan].Value = Convert.IsDBNull(dt.Rows[i]["Loan"]) ? 0 : dt.Rows[i]["Loan"];
                        dgvMain.Rows[i].Cells[Deposit].Value = Convert.IsDBNull(dt.Rows[i]["Deposit"]) ? 0 : dt.Rows[i]["Deposit"];
                        dgvMain.Rows[i].Cells[ShareRemarks].Value = Convert.IsDBNull(dt.Rows[i]["ShareRemarks"]) ? "" : Convert.ToString(dt.Rows[i]["ShareRemarks"]);                                               
                    }                    
                    
                }
                else
                {
                    dgvMain.RowCount = 0;
                }

                //display summary total
                if (meetingID == "-1")// show last record by default
                {
                    str = "SELECT Total_PrevCapital, Total_Fee, Total_NewCapital, Total_PrevLoan, Total_LoanReturn, Total_BalanceLoan, Total_Interest, Total_NewLoan, Total_NewInterest, Total_Penalty, Total_Loan, Total_Deposit FROM MeetingFileMaster where MeetingID =(SELECT MAX  (MeetingID)  FROM MeetingFileMaster)";
                }
                else
                {
                    str = "SELECT Total_PrevCapital, Total_Fee, Total_NewCapital, Total_PrevLoan, Total_LoanReturn, Total_BalanceLoan, Total_Interest, Total_NewLoan, Total_NewInterest, Total_Penalty, Total_Loan, Total_Deposit FROM MeetingFileMaster where MeetingID ='" + meetingID + "'";
                }
                dt = DBService.GetDataTable(str);
                rowCount = dt.Rows.Count;
                if (rowCount > 0)
                {
                    dgvTotal.Rows[0].Cells[PrevCapital].Value = Convert.IsDBNull(dt.Rows[0]["Total_PrevCapital"]) ? "" : dt.Rows[0]["Total_PrevCapital"];
                    dgvTotal.Rows[0].Cells[CapitalFee].Value = Convert.IsDBNull(dt.Rows[0]["Total_Fee"]) ? "" : dt.Rows[0]["Total_Fee"];
                    dgvTotal.Rows[0].Cells[TotalCapital].Value = Convert.IsDBNull(dt.Rows[0]["Total_NewCapital"]) ? "" : dt.Rows[0]["Total_NewCapital"];
                    dgvTotal.Rows[0].Cells[PrevLoan].Value = Convert.IsDBNull(dt.Rows[0]["Total_PrevLoan"]) ? 0 : dt.Rows[0]["Total_PrevLoan"];
                    dgvTotal.Rows[0].Cells[LoanReturn].Value = Convert.IsDBNull(dt.Rows[0]["Total_LoanReturn"]) ? "" : dt.Rows[0]["Total_LoanReturn"];
                    dgvTotal.Rows[0].Cells[BalanceLoan].Value = Convert.IsDBNull(dt.Rows[0]["Total_BalanceLoan"]) ? "" : dt.Rows[0]["Total_BalanceLoan"];
                    dgvTotal.Rows[0].Cells[Interest].Value = Convert.IsDBNull(dt.Rows[0]["Total_Interest"]) ? "" : dt.Rows[0]["Total_Interest"];
                    dgvTotal.Rows[0].Cells[NewLoan].Value = Convert.IsDBNull(dt.Rows[0]["Total_NewLoan"]) ? "" : dt.Rows[0]["Total_NewLoan"];
                    dgvTotal.Rows[0].Cells[NewInterest].Value = Convert.IsDBNull(dt.Rows[0]["Total_NewInterest"]) ? "" : dt.Rows[0]["Total_NewInterest"];
                    dgvTotal.Rows[0].Cells[Penalty].Value = Convert.IsDBNull(dt.Rows[0]["Total_Penalty"]) ? "" : dt.Rows[0]["Total_Penalty"];
                    dgvTotal.Rows[0].Cells[TotalLoan].Value = Convert.IsDBNull(dt.Rows[0]["Total_Loan"]) ? "" : dt.Rows[0]["Total_Loan"];
                    dgvTotal.Rows[0].Cells[Deposit].Value = Convert.IsDBNull(dt.Rows[0]["Total_Deposit"]) ? "" : dt.Rows[0]["Total_Deposit"];             
                }

                ControlStatus(true);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
        private void GetLastMeetingData()
        {

            DataTable dt = new DataTable();
            string str;
            int rowCount;
            try
            {

                if (_IsFirstMeeting) // if this is first meeting
                {
                    str = "SELECT ShareDetails.SHID, ShareDetails.SID, ShareDetails.ShareName, M.MeetingFileMaster.MeetingID as MeetingID, M.MeetingDate, M.HostID, M.Place, M.MeetingFileMaster.Remarks, M.Capital, M.Fee, M.Total_Capital, M.Previous_Loan, M.Loan_Return, M.Balance_Loan, M.Interest,  M.New_Loan, M.New_Interest, M.Penalty, M.Total_Loan,M.Deposit, M.MeetingFileDetails.Remarks as Share_Remarks FROM ShareDetails LEFT JOIN (SELECT  * FROM MeetingFileMaster INNER JOIN MeetingFileDetails ON MeetingFileMaster.MeetingID = MeetingFileDetails.MeetingID)  AS M ON ShareDetails.SID = M.SID Where ( ShareDetails.IsActiveShare = 1 ) Order by ShareDetails.SHID, ShareDetails.SID";
                }
                else // put where condtion for Max(MeetingID)
                {
                    str = "SELECT ShareDetails.SHID, ShareDetails.SID, ShareDetails.ShareName, M.MeetingFileMaster.MeetingID as MeetingID, M.MeetingDate, M.HostID, M.Place, M.MeetingFileMaster.Remarks, M.Capital, M.Fee, M.Total_Capital, M.Previous_Loan, M.Loan_Return, M.Balance_Loan, M.Interest, M.New_Loan, M.New_Interest,  M.Penalty,M.Total_Loan, M.Deposit, M.MeetingFileDetails.Remarks as Share_Remarks FROM ShareDetails LEFT JOIN (SELECT  * FROM MeetingFileMaster INNER JOIN MeetingFileDetails ON MeetingFileMaster.MeetingID = MeetingFileDetails.MeetingID)  AS M ON ShareDetails.SID = M.SID Where (M.MeetingFileMaster.MeetingID =(SELECT MAX( MeetingFileMaster.MeetingID)  FROM MeetingFileMaster) and ShareDetails.IsActiveShare = 1 ) Order by ShareDetails.SHID, ShareDetails.SID";                
                }

                dt = DBService.GetDataTable(str);
                rowCount = dt.Rows.Count;                
                if (rowCount > 0)
                {
                    for (int i = 0; i < rowCount; i++)
                    {
                        //share details
                        dgvMain.RowCount = i+1;
                        dgvMain.Rows[i].Cells[SNo].Value = i + 1;
                        dgvMain.Rows[i].Cells[SHID].Value = Convert.ToString(dt.Rows[i]["SHID"]);
                        dgvMain.Rows[i].Cells[SID].Value = Convert.ToString(dt.Rows[i]["SID"]);
                        dgvMain.Rows[i].Cells[ShareName].Value = Convert.ToString(dt.Rows[i]["ShareName"]);
                       
                        //Meeting details
                        dgvMain.Rows[i].Cells[PrevCapital].Value = Convert.IsDBNull(dt.Rows[i]["Total_Capital"]) ? "0" : Convert.ToString(dt.Rows[i]["Total_Capital"]);
                        //Prev Loan
                        dgvMain.Rows[i].Cells[PrevLoan].Value = Convert.IsDBNull(dt.Rows[i]["Total_Loan"]) ? "0" : Convert.ToString(dt.Rows[i]["Total_Loan"]);
                    }                    
                }

                else
                {
                    dgvMain.RowCount = 0;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
            }
        
        }


        
        private void cboHostName_SelectedIndexChanged(object sender, EventArgs e)
        {
            object obj = cboHostName.SelectedItem;
            if (obj != null)
            {
                DataRowView dr = (DataRowView)obj;
                _hostID = Convert.ToInt32(dr.Row.ItemArray[0]);
            }
            
        }

        private void cboHostName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboHostName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtPlace.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                Save();
            }
            
        }

        private void chkAutoFill_CheckedChanged(object sender, EventArgs e)
        {
            int rowCount;
            if ((IsAdd || IsEdit) & chkAutoFill.Checked)
            {
                rowCount = dgvMain.Rows.Count;
                for (int i = 0; i < rowCount; i++)
                {
                    //Fee
                    dgvMain.Rows[i].Cells[CapitalFee].Value = Meeting.CapitalFee;
                    //Loan Retusnn
                    dgvMain.Rows[i].Cells[LoanReturn].Value = Math.Min(Convert.ToInt32(dgvMain.Rows[i].Cells[PrevLoan].Value), Meeting.MinEMI);

                    RowWiseCalculation(i, CapitalFee);
                }
            }
        }

        private void dgvMain_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;
            if ((IsAdd || IsEdit))
            {
                RowWiseCalculation(rowIndex, colIndex);
            }
        }

        private void RowWiseCalculation(int rowIndex, int colIndex)
        {
            

            if (colIndex == CapitalFee || colIndex == LoanReturn || colIndex == NewLoan || colIndex == Penalty)
            {
                dgvMain.Rows[rowIndex].Cells[TotalCapital].Value = Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[PrevCapital].Value) + Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[CapitalFee].Value);


                dgvMain.Rows[rowIndex].Cells[BalanceLoan].Value = Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[PrevLoan].Value) - Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[LoanReturn].Value);
                dgvMain.Rows[rowIndex].Cells[Interest].Value = ((Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[BalanceLoan].Value)) * (Meeting.Interest)) / 100;


                dgvMain.Rows[rowIndex].Cells[TotalLoan].Value = Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[BalanceLoan].Value) + Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[NewLoan].Value);
                dgvMain.Rows[rowIndex].Cells[NewInterest].Value = ((Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[NewLoan].Value)) * (Meeting.Interest)) / 100;
                
            }

            dgvMain.Rows[rowIndex].Cells[Deposit].Value = Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[CapitalFee].Value) + Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[LoanReturn].Value) + Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[Interest].Value) + Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[NewInterest].Value) + Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[Penalty].Value);

            //Do total after it
            RunnigTotalField();
        }

        private void RunnigTotalField()
        { 
         int totalPrevCapital = 0;
         int totalCapitalFee = 0;
         int totalCapital = 0;
         int totalPrevLoan = 0;
         int totalLoanReturn = 0;
         int totalBalanceLoan = 0;
         int totalInterest = 0;
         int totalNewLoan = 0;
         int totalNewInterest = 0;
         int totalPenalty = 0;
         int totalLoan = 0;
        int totalDeposit = 0;

            int rowCount= dgvMain.RowCount;

            if (rowCount > 0)
            {
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    totalPrevCapital += Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[PrevCapital].Value);
                    totalCapitalFee += Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[CapitalFee].Value);
                    totalCapital += Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[TotalCapital].Value);
                    totalPrevLoan += Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[PrevLoan].Value);
                    totalLoanReturn += Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[LoanReturn].Value);
                    totalBalanceLoan += Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[BalanceLoan].Value);
                    totalInterest += Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[Interest].Value);
                    totalNewLoan += Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[NewLoan].Value);
                    totalNewInterest += Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[NewInterest].Value);
                    totalPenalty += Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[Penalty].Value);
                    totalLoan += Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[TotalLoan].Value);
                    totalDeposit += Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[Deposit].Value);
                }
            }
            dgvTotal.Rows[0].Cells[PrevCapital].Value = totalPrevCapital;
            dgvTotal.Rows[0].Cells[CapitalFee].Value = totalCapitalFee;
            dgvTotal.Rows[0].Cells[TotalCapital].Value = totalCapital;
            dgvTotal.Rows[0].Cells[PrevLoan].Value = totalPrevLoan;
            dgvTotal.Rows[0].Cells[LoanReturn].Value = totalLoanReturn;
            dgvTotal.Rows[0].Cells[BalanceLoan].Value = totalBalanceLoan;
            dgvTotal.Rows[0].Cells[Interest].Value = totalInterest;
            dgvTotal.Rows[0].Cells[NewLoan].Value = totalNewLoan;
            dgvTotal.Rows[0].Cells[NewInterest].Value = totalNewInterest;
            dgvTotal.Rows[0].Cells[Penalty].Value = totalPenalty;
            dgvTotal.Rows[0].Cells[TotalLoan].Value = totalLoan;
            dgvTotal.Rows[0].Cells[Deposit].Value = totalDeposit;
        
        }

        private void dgvMain_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;
            if ((IsAdd || IsEdit))
            {
                // Fee, LoanRetuns,Interest,
                if (colIndex == CapitalFee || colIndex == LoanReturn || colIndex == Interest || colIndex == NewLoan || colIndex == NewInterest || colIndex == Penalty || colIndex == ShareRemarks)
                {
                    dgvMain.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                }
                else
                {
                    dgvMain.EditMode = DataGridViewEditMode.EditProgrammatically;
                }
                
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SortGridBySNo()
        {
            foreach (DataGridViewColumn col in dgvMain.Columns)
            {
                if (col.Name == "S.No")
                {
                    dgvMain.Sort(col, ListSortDirection.Ascending);
                    break;
                }
            }        
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (IsEdit)
            {
                DisplayData(txtMeetingNo.Text.Trim());
            }
            else if(IsAdd)
            {
            DisplayData();
            }
            IsEdit = false;
            IsAdd = false;
            ControlStatus(true);
        }

        
    }
}

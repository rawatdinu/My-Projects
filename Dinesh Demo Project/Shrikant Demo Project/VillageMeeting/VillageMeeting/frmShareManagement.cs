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
    public partial class frmShareManagement : Form
    {

        #region ShareHolders
        int ID;
        bool blnADD = false;
        bool blnEDIT = false;
        string msg_Validation;

        public frmShareManagement()
        {
            InitializeComponent();
        }
        private void DesignDataGridViewDetails()
        {
            dgvDetails.RowCount = 1;
            dgvDetails.ColumnCount = 3;
            dgvDetails.Columns[0].Name = "S.No";
            dgvDetails.Columns[0].Width = 60;
            dgvDetails.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
            dgvDetails.Columns[1].Name = "ID";
            dgvDetails.Columns[1].Width = 60;
            dgvDetails.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;
            if (GlobalFunction.glbUserType == GlobalFunction.SuperUser)
            {
                dgvDetails.Columns[1].Visible = true;   //ID

            }
            else
            {
                dgvDetails.Columns[1].Visible = false;

            }
            dgvDetails.Columns[2].Name = "Share Holders Name";
            dgvDetails.Columns[2].Width = 190;      //323
            dgvDetails.Columns[2].SortMode = DataGridViewColumnSortMode.Automatic;

            DataGridViewCheckBoxColumn chkCol = new DataGridViewCheckBoxColumn();
            chkCol.HeaderText = "Active";
            chkCol.Width = 70;
            chkCol.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvDetails.Columns.Add(chkCol);


            dgvDetails.RowHeadersVisible = false;
            dgvDetails.AllowUserToDeleteRows = false;
            dgvDetails.AllowUserToAddRows = false;
            dgvDetails.AllowUserToResizeRows = false;
            dgvDetails.AllowUserToResizeColumns = true;
            dgvDetails.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvDetails.ScrollBars = ScrollBars.Vertical;
            dgvDetails.SelectionMode = DataGridViewSelectionMode.CellSelect;

            dgvDetails.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            GlobalFunction.SetGridStyle(dgvDetails);
        }

        private void ControlStatus(bool status)
        {
            txtName.ReadOnly = status;
            txtAddress.ReadOnly = status;
            txtPhone.ReadOnly = status;

        }
        private void Clear()
        {
            txtName.Text = String.Empty;
            txtAddress.Text = String.Empty;
            txtPhone.Text = String.Empty;

        }
        

        private void frmShareManagement_Load(object sender, EventArgs e)
        {
            /****************************************************/
            DesignDataGridViewDetails();
            FillComboShareType(cboShareHolderList);            
            ControlStatus(true);            
            DispayData();
            /****************************************************/
            DesignShareDetails();
            FillComboShareType(cboShareDetails);            
            ControlStatus2(true);            
            DispayData2();
            /****************************************************/
            DesignShareList();
            DisplayShareList();
        }

        private void DispayData()
        {
            DataTable dt = new DataTable();
            string str;
            int RecNo;
            bool isActive;
            try
            {
                if (cboShareHolderList.SelectedIndex == 0)
                {
                    str = "SELECT  ID, ShareHolderName,  Address, IsActive,PhoneNo FROM ShareMaster ORDER BY ID";
                }

                else if (cboShareHolderList.SelectedIndex == 1)
                {
                    str = "SELECT  ID, ShareHolderName,  Address, IsActive,PhoneNo FROM ShareMaster WHERE (IsActive=1) ORDER BY ID";
                }
                else
                {
                    str = "SELECT  ID, ShareHolderName,  Address, IsActive,PhoneNo FROM ShareMaster WHERE (IsActive=0) ORDER BY ID";
                }                    
                dt = DBService.GetDataTable(str);
                RecNo = dt.Rows.Count;
                dgvDetails.RowCount = 1;
                if (RecNo > 0)
                {


                    for (int i = 0; i < RecNo; i++)
                    {
                        dgvDetails.RowCount += 1;
                        dgvDetails.Rows[i].Cells[0].Value = i + 1;
                        dgvDetails.Rows[i].Cells[1].Value = Convert.ToString(dt.Rows[i]["ID"]);
                        dgvDetails.Rows[i].Cells[2].Value = Convert.ToString(dt.Rows[i]["ShareHolderName"]);

                        if (Convert.ToInt32(dt.Rows[i]["IsActive"]) == 0)
                        {
                            isActive = false;
                        }
                        else
                        {
                            isActive = true;
                        }
                        dgvDetails.Rows[i].Cells[3].Value = isActive;
                        
                    }
                    Clear();
                    dgvDetails.RowCount -= 1;

                }

                else
                {
                    dgvDetails.RowCount = 0;
                }

                ControlStatus(true);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void DisplayRecord1(int tempID)
        {
            int RecNo;
            DataTable dt;
            string str = "SELECT ID, ShareHolderName, Address, PhoneNo FROM ShareMaster WHERE (ID =" + tempID + ")";
            dt = DBService.GetDataTable(str);
            RecNo = dt.Rows.Count;
            if (RecNo > 0)
            {
                txtName.Text = Convert.ToString(dt.Rows[0]["ShareHolderName"]);
                txtAddress.Text = Convert.ToString(dt.Rows[0]["Address"]);
                txtPhone.Text = Convert.ToString(dt.Rows[0]["PhoneNo"]);

            }

            ControlStatus(true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ControlStatus(false);
            Clear();
            blnADD = true;
            blnEDIT = false;
            txtName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Select Share Holder Name");
                return;

            }
            if (!blnADD)
            {
                ControlStatus(false);
                blnEDIT = true;
                blnADD = false;

            }
            else
            {
                ControlStatus(true);
                blnEDIT = false;
                blnADD = false;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (blnADD || blnEDIT)
            {
                if (ValidateData())
                {
                    Save();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!(blnADD) && !(blnEDIT))
            {
                if (!(HasShares(ID)))
                {
                    Delete();
                }
                else
                {
                    MessageBox.Show("Cannot delete record Share holder has shares");
                }
                
            }
        }
        private bool HasShares(int shareHolderID)
        {
            bool result = true;
            string querry = "SELECT count(*)  FROM ShareDetails where SHID ="+ shareHolderID;
            object obj = DBService.ExecuteScalar(querry);
            if (! (obj == null))
            {
                if (Convert.ToInt32(obj) > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }
        private void Delete()
        {
            string[] para;
            object[] values;
            string str1;
            object obj;

            try
            {

                if (txtName.Text.Trim() == "")
                {
                    MessageBox.Show("Select Share Holder Name");
                    return;

                }
                else
                {
                    DialogResult dr = MessageBox.Show("Do You Want to Delete '" + txtName.Text + "'", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (dr == DialogResult.OK)
                    {
                        
                        str1 = "DELETE  * FROM ShareMaster Where ID = @ID";
                        para = new string[] { "@ID" };
                        values = new object[] {  ID };

                        //oleParam = new OleDbParameter[]
                        // {                           
                        //     new  OleDbParameter("@IsActive",Convert.ToInt32("0")),
                        //     new  OleDbParameter("@DeletedOn",DateTime.Now.Date),
                        //     new OleDbParameter("@ID",ID)
                        // };
                        //result = DBService.Update(str1, oleParam);
                        obj = DBService.ExecuteNonQuerry(str1, para, values);

                        if (obj != null)
                        {
                            blnEDIT = false;
                            MessageBox.Show("Share Hoder is Deleted succesfully");
                            ControlStatus(true);
                            DispayData();
                            DispayData2();
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

        private void SetShareHolderState(int shareHolderId, bool isActive)
        { 
        
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DispayData();
        }

        bool ValidateData()
        {

            string str = "";
            string finalName = GetProperName(txtName.Text);
            msg_Validation = "";
            if (finalName == "")
            {
                msg_Validation = "Share Holder Name cannot be empty";
                MessageBox.Show(msg_Validation);
                return false;
            }
            else
            {
                if (blnADD)
                {
                    str = "SELECT  count(*) as Num FROM ShareMaster where ShareHolderName ='" + finalName + "' and IsActive=1";

                }
                else if (blnEDIT)
                {
                    str = "SELECT  count(*) as Num FROM ShareMaster where ShareHolderName ='" + finalName + "' and IsActive=1 and ID <>" + ID + " ";
                }

                if (Convert.ToInt32(DBService.ExecuteScalar(str)) > 0)
                {
                    msg_Validation = "Same Share Holder Name Exit choose different name";
                    MessageBox.Show(msg_Validation);
                    return false;
                }

            }

            return true;

        }
        private string GetProperName(string str)
        {
            str = str.Trim();
            string retName = "";
            if (str != "")
            {
                string[] arr = str.Split(' ');
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == "")
                        continue;
                    retName += arr[i].Trim() + " ";

                }
                retName = retName.Trim();
            }

            return retName;
        }

        private void Save()
        {

            string[] para;
            object[] values;
            string str1;
            
            object obj;

            try
            {
                if (blnADD)
                {
                    DialogResult dr = MessageBox.Show("Do You Want to Save Data ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (dr == DialogResult.OK)
                    {
                        int TempID;


                        str1 = "SELECT  Max(ID) as tempID FROM ShareMaster";
                        TempID = Convert.ToInt32(DBService.ExecuteScalar(str1));
                        if (TempID == 0)
                        {
                            TempID = 1;
                        }
                        else
                        {
                            TempID = TempID + 1;
                        }

                        /*Master Table**/
                        //str1 = "INSERT INTO ShareMaster(ShareHolderName,Address,PhoneNo,IsActive,CreatedOn) VALUES (@ShareHolderName,@Address,@PhoneNo,@IsActive,@CreatedOn)";
                        str1 = "INSERT INTO ShareMaster(ID,ShareHolderName,Address,PhoneNo,IsActive,CreatedOn) VALUES (@ID,@ShareHolderName,@Address,@PhoneNo,@IsActive,@CreatedOn)";

                        para = new string[] { "@ID", "@ShareHolderName", "@Address", "@PhoneNo", "@IsActive", "@CreatedOn" };
                        values = new object[] { TempID, GetProperName(txtName.Text), txtAddress.Text.Trim(), txtPhone.Text.Trim(), 1, DateTime.Now.Date };




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
                            blnADD = false;
                            ID = TempID;
                            MessageBox.Show("Share Holder is Added succesfully");

                            ControlStatus(true);
                            DispayData();
                            DispayData2();
                        }
                        else
                        {
                            MessageBox.Show("Error Occurs", "ERROR");
                        }
                    }
                }
                /******************************EDIT*****************************************/
                else if (blnEDIT)
                {
                    DialogResult dr = MessageBox.Show("Do You Want to Update '" + txtName.Text + "'", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (dr == DialogResult.OK)
                    {
                        str1 = "Update ShareMaster set ShareHolderName=@ShareHolderName,Address=@Address,PhoneNo=@PhoneNo,IsActive=@IsActive,UpdatedOn=@UpdatedOn Where ID = @ID";
                        para = new string[] { "@ShareHolderName", "@Address", "@PhoneNo", "@IsActive", "@UpdatedOn", "@ID" };
                        values = new object[] { GetProperName(txtName.Text), txtAddress.Text.Trim(), txtPhone.Text.Trim(), 1, DateTime.Now.Date, ID };

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
                            blnEDIT = false;
                            MessageBox.Show("Share Hoder is Updated succesfully");
                            ControlStatus(true);
                            DispayData();
                            DispayData2();
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


        private bool _IsShareHoldersActive = true;
        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewCheckBoxCell chk = new DataGridViewCheckBoxCell();
            try
            {
                ID = Convert.ToInt32(dgvDetails.Rows[dgvDetails.CurrentRow.Index].Cells[1].Value);
                if (e.ColumnIndex == 3)
                {
                    if (rowIndex != -1) // check/uncheck perticuler record
                    {
                        chk = (DataGridViewCheckBoxCell)dgvDetails.CurrentCell;
                        if (Convert.ToBoolean(chk.Value))
                        {
                            chk.Value = false;
                        }
                        else
                        {
                            chk.Value = true;
                        }
                    }
                    else //check/uncheck all records header click
                    {
                        if (_IsShareHoldersActive)
                        {
                            SetActiveAll(dgvDetails, 3, false);
                            _IsShareHoldersActive = false;
                        }
                        else
                        {
                            SetActiveAll(dgvDetails, 3, true);
                            _IsShareHoldersActive = true;
                        }
                    }
                }

                DisplayRecord1(ID);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

            
        }

        private void SetActiveAll(DataGridView dgv, int chkColumnIndex, bool isActive)
        {

            int rowcount = dgv.RowCount;
            DataGridViewCheckBoxCell chk = new DataGridViewCheckBoxCell();
            try
            {
                for (int i = 0; i < rowcount; i++)
                {
                    chk = (DataGridViewCheckBoxCell)dgv.Rows[i].Cells[chkColumnIndex];
                    chk.Value = isActive;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                   
        }


        private void dgvDetails_KeyDown(object sender, KeyEventArgs e)
        {
            ID = Convert.ToInt32(dgvDetails.Rows[dgvDetails.CurrentRow.Index].Cells[1].Value);
            DisplayRecord1(ID);
        }

        private void dgvDetails_KeyUp(object sender, KeyEventArgs e)
        {
            ID = Convert.ToInt32(dgvDetails.Rows[dgvDetails.CurrentRow.Index].Cells[1].Value);
            DisplayRecord1(ID);
        }

        #endregion
        /****************************************************************/
        #region Share Details
        int SHID;    //Shareholder ID
        int SID;    // share ID
        bool blnAdd2 = false;
        bool blnEdit2 = false;

        private void DesignShareDetails()
        {
            dgvShareDetails.RowCount = 1;
            dgvShareDetails.ColumnCount = 3;
            dgvShareDetails.Columns[0].Name = "S.No";
            dgvShareDetails.Columns[0].Width = 60;
            dgvShareDetails.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvShareDetails.Columns[1].Name = "SID";
            dgvShareDetails.Columns[1].Width = 60;
            dgvShareDetails.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            if (GlobalFunction.glbUserType == GlobalFunction.SuperUser)
            {
                dgvShareDetails.Columns[1].Visible = true;
            }
            else
            {
                dgvShareDetails.Columns[1].Visible = false;
            }

            dgvShareDetails.Columns[2].Name = "Share Name";
            dgvShareDetails.Columns[2].Width = 200;      //316
            dgvShareDetails.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewCheckBoxColumn chkCol = new DataGridViewCheckBoxColumn();
            chkCol.HeaderText = "Active";
            chkCol.Width = 60;
            chkCol.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvShareDetails.Columns.Add(chkCol);

            dgvShareDetails.RowHeadersVisible = false;
            dgvShareDetails.AllowUserToDeleteRows = false;
            dgvShareDetails.AllowUserToAddRows = false;
            dgvShareDetails.AllowUserToResizeRows = false;
            dgvShareDetails.AllowUserToResizeColumns = true;
            dgvShareDetails.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvShareDetails.ScrollBars = ScrollBars.Vertical;
            dgvShareDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvShareDetails.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvShareDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            
            GlobalFunction.SetGridStyle(dgvShareDetails);
        }

        private void DesignShareList()
        {
            dgvShareList.RowCount = 1;
            dgvShareList.ColumnCount = 4;
            dgvShareList.Columns[0].Name = "S.No";
            dgvShareList.Columns[0].Width = 40;
            dgvShareList.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvShareList.Columns[1].Name = "SHID";
            dgvShareList.Columns[1].Width = 50;
            dgvShareList.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvShareList.Columns[2].Name = "SID";
            dgvShareList.Columns[2].Width = 50;
            dgvShareList.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            if (GlobalFunction.glbUserType == GlobalFunction.SuperUser)
            {
                dgvShareList.Columns[1].Visible = true;
                dgvShareList.Columns[2].Visible = true;
            }
            else
            {
                dgvShareList.Columns[1].Visible = false;
                dgvShareList.Columns[2].Visible = false;
            }


            dgvShareList.Columns[3].Name = "Share Name";
            dgvShareList.Columns[3].Width = 200;      //257
            dgvShareList.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvShareList.RowHeadersVisible = false;
            dgvShareList.AllowUserToDeleteRows = false;
            dgvShareList.AllowUserToAddRows = false;
            dgvShareList.AllowUserToResizeRows = false;
            dgvShareList.AllowUserToResizeColumns = true;
            dgvShareList.RowTemplate.Height = 18;
            dgvShareList.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvShareList.ScrollBars = ScrollBars.Both;
            dgvShareList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            GlobalFunction.SetGridStyle(dgvShareList);
        }

        private void ControlStatus2(bool status)
        {
            // txtSHName.ReadOnly = true;
            txtShareName.ReadOnly = status;
            

        }
        private void Clear2()
        {

            txtShareName.Text = String.Empty;


        }

        private void DispayData2()
        {
            DataTable dt = new DataTable();
            string str;
            int RecNo;
            try
            {
                str = "SELECT  ID, ShareHolderName,  Address, PhoneNo FROM ShareMaster WHERE (IsActive=1) ORDER BY ID";
                dt = DBService.GetDataTable(str);
                RecNo = dt.Rows.Count;
                dgvShareDetails.RowCount = 1;
                if (RecNo > 0)
                {
                    cboSHName.DataSource = dt;
                    cboSHName.DisplayMember = "ShareHolderName";
                    cboSHName.ValueMember = "ID";
                    cboSHName.SelectedIndex = 0;                    
                }

                else
                {
                    dgvShareDetails.RowCount = 0;
                }

                ControlStatus2(true);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnNew2_Click(object sender, EventArgs e)
        {
            blnAdd2 = true;
            blnEdit2 = false;
            Clear2();
            ControlStatus2(false);
            txtShareName.Focus();
        }

        private void btnEdit2_Click(object sender, EventArgs e)
        {
            if (txtShareName.Text.Trim() == "")
            {
                MessageBox.Show("Select Share Name");
                return;

            }
            if (!blnAdd2)
            {
                blnEdit2 = true;
                blnAdd2 = false;
                ControlStatus2(false);
            }
            else
            {
                blnEdit2 = false;
                blnAdd2 = false;
                ControlStatus2(true);
            }
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            if (blnAdd2 || blnEdit2)
            {
                if (ValidateData2())
                {
                    Save2();

                }
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (!(blnAdd2) && !(blnEdit2))
            {
                Delete2();
            }
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            blnAdd2 = false;
            blnEdit2 = false;
            object obj = new object();

            cboSHName_SelectedIndexChanged(obj, e);
        }

        bool ValidateData2()
        {
            string str = "";
            string finalName = GetProperName(txtShareName.Text);
            msg_Validation = "";
            if (finalName == "")
            {
                msg_Validation = "Share Name cannot be empty";
                MessageBox.Show(msg_Validation);
                return false;
            }
            else
            {
                if (blnAdd2)
                {
                    str = "SELECT  count(*) as Num FROM ShareDetails where  (SHID=" + SHID + "  and IsActiveShare=1) and ShareName ='" + finalName + "'";
                }

                else if (blnEdit2)
                {
                    str = "SELECT  count(*) as Num FROM ShareDetails where  (SHID =" + SHID + "  and  SID <>" + SID + " and IsActiveShare=1 ) and ShareName ='" + finalName + "'";
                }

                if (Convert.ToInt32(DBService.ExecuteScalar(str)) > 0)
                {
                    msg_Validation = "Same Share Name Exit choose different name";
                    MessageBox.Show(msg_Validation);
                    return false;
                }

            }

            return true;

        }

        private void Save2()
        {
            string[] para;
            object[] values;

            string str1;            
            object obj;

            try
            {
                if (blnAdd2)
                {
                    DialogResult dr = MessageBox.Show("Do You Want to Save Data?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (dr == DialogResult.OK)
                    {
                        int TempID;


                        str1 = "SELECT  Max(SID) as tempID FROM ShareDetails";
                        TempID = Convert.ToInt32(DBService.ExecuteScalar(str1));
                        if (TempID == 0)
                        {
                            TempID = 1;
                        }
                        else
                        {
                            TempID = TempID + 1;
                        }


                        str1 = "Insert into ShareDetails (SHID, SID, ShareName, IsActiveShare, CreatedOn) values (@SHID, @SID, @ShareName, @IsActiveShare, @CreatedOn)";
                        para = new string[] { "@SHID", "@SID", "@ShareName", "@IsActiveShare", "@CreatedOn" };
                        values = new object[] { SHID, TempID, GetProperName(txtShareName.Text), 1, DateTime.Now.Date };

                        //oleParam = new OleDbParameter[]
                        //{
                        //     new OleDbParameter("@SHID",SHID),
                        //     new OleDbParameter("@SID",TempID),
                        //   new OleDbParameter("@ShareName",GetProperName(txtShareName.Text)),                 
                        //    new  OleDbParameter("@IsActiveShare", 1),
                        //    new  OleDbParameter("@CreatedOn",DateTime.Now.Date)
                        //};
                        //result = DBService.Insert(str1, oleParam);
                        obj = DBService.ExecuteNonQuerry(str1, para, values);
                        if (obj != null)
                        {
                            blnAdd2 = false;
                            SID = TempID;
                            MessageBox.Show("Share Name is Added succesfully");
                            ControlStatus2(true);
                            object tempObj = new object();
                            EventArgs e = new EventArgs();
                            cboSHName_SelectedIndexChanged(tempObj, e);
                            DisplayShareList();
                        }
                        else
                        {
                            MessageBox.Show("Error Occurs", "ERROR");
                        }
                    }
                }
                /******************************EDIT*****************************************/
                else if (blnEdit2)
                {
                    DialogResult dr = MessageBox.Show("Do You Want to Update '" + txtShareName.Text + "'", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (dr == DialogResult.OK)
                    {
                        str1 = "Update  ShareDetails set SHID=@SHID, ShareName=@ShareName, IsActiveShare=@IsActiveShare, UpdatedOn=@UpdatedOn Where SID=@SID";

                        para = new string[] { "@SHID", "@ShareName", "@IsActiveShare", "@UpdatedOn", "@SID" };
                        values = new object[] { SHID, GetProperName(txtShareName.Text), 1, DateTime.Now.Date, SID };

                        //oleParam = new OleDbParameter[]
                        // {
                        //      new OleDbParameter("@SHID",SHID),
                        //    new OleDbParameter("@ShareName",GetProperName(txtShareName.Text)),
                        //     new  OleDbParameter("@IsActiveShare", 1),
                        //     new  OleDbParameter("@UpdatedOn",DateTime.Now.Date),
                        //     new OleDbParameter("@SID",SID)
                        // };
                        //result = DBService.Update(str1, oleParam);
                        obj = DBService.ExecuteNonQuerry(str1, para, values);
                        if (obj != null)
                        {
                            blnEdit2 = false;
                            MessageBox.Show("Share Name is Updated succesfully");
                            ControlStatus2(true);
                            object tempObj = new object();
                            EventArgs e = new EventArgs();
                            cboSHName_SelectedIndexChanged(tempObj, e);
                            DisplayShareList();
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

        private void Delete2()
        {
            string[] para;
            object[] values;
            string str1;
            object obj;
            
            try
            {

                if (txtShareName.Text.Trim() == "")
                {
                    MessageBox.Show("Select Share Name");
                    return;

                }
                else
                {
                    DialogResult dr = MessageBox.Show("Do You Want to Delete '" + txtShareName.Text + "'", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (dr == DialogResult.OK)
                    {
                        str1 = "Update  ShareDetails set IsActiveShare=@IsActiveShare, DeletedOn=@DeletedOn Where SID=@SID";
                        para = new string[] { "@IsActiveShare", "@DeletedOn", "@SID" };
                        values = new object[] { 0, DateTime.Now.Date, SID };

                        //oleParam = new OleDbParameter[]
                        // {

                        //     new  OleDbParameter("@IsActiveShare", Convert.ToInt32("0")),
                        //     new  OleDbParameter("@DeletedOn",DateTime.Now.Date),
                        //     new OleDbParameter("@SID",SID)
                        // };
                        //result = DBService.Update(str1, oleParam);
                        obj = DBService.ExecuteNonQuerry(str1, para, values);
                        if (obj != null)
                        {
                            MessageBox.Show("Share Name is Deleted succesfully");
                            ControlStatus2(true);
                            object tempObj = new object();
                            EventArgs e = new EventArgs();
                            cboSHName_SelectedIndexChanged(tempObj, e);
                            DisplayShareList();
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

        private bool _IsShareActive = true;
        private void dgvShareDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

            int rowIndex = e.RowIndex;
            DataGridViewCheckBoxCell chk = new DataGridViewCheckBoxCell();
            try
            {
                SID = Convert.ToInt32(dgvShareDetails.Rows[dgvShareDetails.CurrentRow.Index].Cells[1].Value);
                txtShareName.Text = Convert.ToString(dgvShareDetails.Rows[dgvShareDetails.CurrentRow.Index].Cells[2].Value);
                if (e.ColumnIndex == 3)
                {
                    if (rowIndex != -1) // check/uncheck perticuler record
                    {
                        chk = (DataGridViewCheckBoxCell)dgvShareDetails.CurrentCell;
                        if (Convert.ToBoolean(chk.Value))
                        {
                            chk.Value = false;
                        }
                        else
                        {
                            chk.Value = true;
                        }
                    }
                    else //check/uncheck all records header click
                    {
                        if (_IsShareActive)
                        {
                            SetActiveAll(dgvShareDetails, 3, false);
                            _IsShareActive = false;
                        }
                        else
                        {
                            SetActiveAll(dgvShareDetails, 3, true);
                            _IsShareActive = true;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvShareDetails_KeyUp(object sender, KeyEventArgs e)
        {
            SID = Convert.ToInt32(dgvShareDetails.Rows[dgvShareDetails.CurrentRow.Index].Cells[1].Value);
            txtShareName.Text = Convert.ToString(dgvShareDetails.Rows[dgvShareDetails.CurrentRow.Index].Cells[2].Value);
        }

        private void dgvShareDetails_KeyDown(object sender, KeyEventArgs e)
        {
            SID = Convert.ToInt32(dgvShareDetails.Rows[dgvShareDetails.CurrentRow.Index].Cells[1].Value);
            txtShareName.Text = Convert.ToString(dgvShareDetails.Rows[dgvShareDetails.CurrentRow.Index].Cells[2].Value);
        }
      
        private void cboSHName_SelectedIndexChanged(object sender, EventArgs e)
        {
            object obj;
            DataRowView dr;
            string shareholerName = "";
            DataTable dt;
            string str;
            int RecNo;
            bool isActive = false;

            try
            {
                if (cboSHName.SelectedIndex != -1)
                {
                    obj = cboSHName.SelectedItem;                    
                    dr = (DataRowView)obj;
                    SHID = Convert.ToInt32(dr.Row.ItemArray[0]);

                    shareholerName = Convert.ToString(dr.Row.ItemArray[1]);

                    dt = new DataTable();
                    if (cboShareDetails.SelectedIndex == 0)// all shares
                    {
                        str = "SELECT ShareDetails.SHID, ShareDetails.SID,ShareMaster.ShareHolderName,  ShareDetails.ShareName, ShareDetails.IsActiveShare FROM ShareMaster INNER JOIN ShareDetails ON ShareMaster.ID = ShareDetails.SHID WHERE (ShareDetails.SHID= " + SHID + ")  ORDER BY ShareDetails.SID";
                    }
                    else if (cboShareDetails.SelectedIndex == 1)//all active shares
                    {
                        str = "SELECT ShareDetails.SHID, ShareDetails.SID,ShareMaster.ShareHolderName,  ShareDetails.ShareName, ShareDetails.IsActiveShare FROM ShareMaster INNER JOIN ShareDetails ON ShareMaster.ID = ShareDetails.SHID WHERE ((ShareDetails.SHID= " + SHID + ") AND (ShareDetails.IsActiveShare=1)) ORDER BY ShareDetails.SID";
                    }
                    else// all Non- Active shares
                    {
                        str = "SELECT ShareDetails.SHID, ShareDetails.SID,ShareMaster.ShareHolderName,  ShareDetails.ShareName, ShareDetails.IsActiveShare FROM ShareMaster INNER JOIN ShareDetails ON ShareMaster.ID = ShareDetails.SHID WHERE ((ShareDetails.SHID= " + SHID + ") AND (ShareDetails.IsActiveShare=0)) ORDER BY ShareDetails.SID";
                    }
                  
                    dt = DBService.GetDataTable(str);
                    RecNo = dt.Rows.Count;
                    dgvShareDetails.RowCount = 1;
                    if (RecNo > 0)
                    {


                        for (int i = 0; i < RecNo; i++)
                        {
                            dgvShareDetails.RowCount += 1;
                            dgvShareDetails.Rows[i].Cells[0].Value = i + 1;
                            dgvShareDetails.Rows[i].Cells[1].Value = Convert.ToString(dt.Rows[i]["SID"]);
                            dgvShareDetails.Rows[i].Cells[2].Value = Convert.ToString(dt.Rows[i]["ShareName"]);

                            if (Convert.ToInt32(dt.Rows[i]["IsActiveShare"]) == 0)
                            {
                                isActive = false;
                            }
                            else
                            {
                                isActive = true;
                            }
                            dgvShareDetails.Rows[i].Cells[3].Value = isActive;
                        }
                        dgvShareDetails.RowCount -= 1;
                    }
                    else
                    {
                        dgvShareDetails.RowCount = 0;
                    }
                    ControlStatus2(true);
                    Clear2();
                }

            }                       

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void DisplayShareList()
        {
            DataTable dt = new DataTable();
            string str;
            int RecNo;
            Color color = Color.Bisque;
            int prevID = -1;
            int currID = -1;


            try
            {
                str = "SELECT SHID, SID, ShareName FROM ShareDetails WHERE (IsActiveShare=1) ORDER BY SHID, SID";
                dt = DBService.GetDataTable(str);
                RecNo = dt.Rows.Count;
                dgvShareList.RowCount = 1;
                if (RecNo > 0)
                {

                    for (int i = 0; i < RecNo; i++)
                    {

                        currID = Convert.ToInt32(dt.Rows[i]["SHID"]);
                        if (currID != prevID)
                        {
                            color = ChangeColor(color);
                        }
                        dgvShareList.RowCount += 1;
                        dgvShareList.Rows[i].Cells[0].Value = i + 1;
                        dgvShareList.Rows[i].Cells[1].Value = Convert.ToString(dt.Rows[i]["SHID"]);

                        dgvShareList.Rows[i].Cells[2].Value = Convert.ToString(dt.Rows[i]["SID"]);
                        dgvShareList.Rows[i].Cells[3].Value = Convert.ToString(dt.Rows[i]["ShareName"]);

                        dgvShareList.Rows[i].DefaultCellStyle.BackColor = color;

                        prevID = currID;

                    }
                    dgvShareList.RowCount -= 1;

                }

                else
                {
                    dgvShareList.RowCount = 0;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private Color ChangeColor(Color clr)
        {
            if (clr == Color.Beige)
            {
                return Color.Bisque;
            }
            else
            {
                return Color.Beige;
            }

        }
        
       
        private void cboSHName_KeyPress(object sender, KeyPressEventArgs e) 
        {
            e.Handled = true;
        }
        
        private void cboSHName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgvShareDetails.Focus();
        }

        private void FillComboShareType( ComboBox cboTemp)
        {
            cboTemp.DataSource = null;
            cboTemp.Items.Clear();
            cboTemp.Items.Insert(0,"All");
            cboTemp.Items.Insert(1,"Active");
            cboTemp.Items.Insert(2,"Non-Active");
            cboTemp.SelectedIndex = 1;
            
        }

        private void cboShareHolderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboShareHolderList.SelectedIndex !=-1)
            {
                DispayData();
            }
        }

        private void cboShareDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboShareDetails.SelectedIndex != -1)
            {
                DispayData2();
            }
        }

        private void btnUpdateSH_Click(object sender, EventArgs e)
        {
            string querry = "";
            string[] para;
            object[] values;
            List<Transaction> transList = new List<Transaction>();
            object obj;
            
            int rowCount;
            int shareholderID;
            byte setvalue;



            try
            {                                                
                    DialogResult dr = MessageBox.Show("Do you want to update?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        rowCount = dgvDetails.RowCount;
                
                        
                        for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                        {
                            shareholderID = Convert.ToInt32(dgvDetails.Rows[rowIndex].Cells[1].Value);
                            if (Convert.ToBoolean(dgvDetails.Rows[rowIndex].Cells[3].Value))
                            {
                                setvalue = 1;
                                querry = "UPDATE ShareMaster set IsActive=@IsActive, UpdatedOn=@UpdatedOn where ID=@ID";
                                para = new string[] { "@IsActiveShare", "@UpdatedOn",  "@ID" };
                                values = new object[] { setvalue, DateTime.Now.Date, shareholderID };
                                transList.Add(new Transaction(querry, para, values));
                                
                            }
                            else
                            {
                                setvalue = 0;
                                //deactivate in sharedetails
                                querry = "UPDATE ShareDetails set IsActiveShare=@IsActiveShare,UpdatedOn=@UpdatedOn,DeletedOn=@DeletedOn where SHID=@SHID";
                                para = new string[] { "@IsActiveShare", "@UpdatedOn", "@DeletedOn", "@SHID" };
                                values = new object[] { setvalue, DateTime.Now.Date, DateTime.Now.Date, shareholderID };
                                transList.Add(new Transaction(querry, para, values));

                                //Delete from share master
                                querry = "UPDATE ShareMaster set IsActive=@IsActive, UpdatedOn=@UpdatedOn,DeletedOn=@DeletedOn where ID=@ID";
                                para = new string[] { "@IsActiveShare", "@UpdatedOn", "@DeletedOn", "@ID" };
                                values = new object[] { setvalue, DateTime.Now.Date, DateTime.Now.Date, shareholderID };
                                transList.Add(new Transaction(querry, para, values));
                            }
                           
                           
                        }

                        obj = DBService.ExecuteTransaction(transList);
                        if (obj != null)
                        {                           
                            MessageBox.Show("Updated succesfully");
                        }
                        
                    }

                }
                                           
            catch (Exception ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
            }
        }

        private void btnUpdateShare_Click(object sender, EventArgs e)
        {

        }        
      
    }
}

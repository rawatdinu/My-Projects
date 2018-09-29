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
    public partial class frmClientMaster : Form
    {
        private frmClientDetails frmInterface;

        private string clientcode;
        private string clientname;
        private string contactno;
        private string remarks;
        private string state;
        private string industrytype;
        private int isactive;
        private string addservice;

        private bool IsAdd=false;
        private bool IsEdit = false;

        public frmClientMaster()
        {
            InitializeComponent();
        }

        private void frmClientMaster_Load(object sender, EventArgs e)
        {
            DisplayClientList();

            if (dataGridView1.Rows.Count > 0)
            {                
                dataGridView1.Rows[0].Selected = true;
                SetCleintProperty(0);
            }
            
        }

        private void DisplayClientList()
        {
            DataTable dt = new DataTable();
            string str;
            int RecNo;
            
            
            try
            {
                str = "SELECT ClientCode, ClientName, ContactNo, Remarks, State, IndustryType, IsActive, AddService FROM ClientMaster ORDER BY ClientCode";
                dt = DBService.GetDataTable(str);
                RecNo = dt.Rows.Count;
                
                dataGridView1.DataSource = null;
                if (RecNo > 0)
                {
                    for (int i = 0; i < RecNo; i++)
                    {
                        //dt.Rows[i][6] = null;
                        //dt.Rows[i][6] = Convert.ToBoolean(dt.Rows[i][6]);
                    }
                }
                dataGridView1.DataSource = dt;

                dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToResizeRows = false;
                dataGridView1.AllowUserToResizeColumns = true;
            }
                         
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void ProcessInterface()
        {
            LoadInterface();

            ShowForm();

            UnloadInterface();

        }

        private void LoadInterface()
        {
            if (frmInterface == null)
                frmInterface = new frmClientDetails();

            if (IsEdit)
            {
                frmInterface.EditClient = true;
                frmInterface.ClientCode = clientcode;
                frmInterface.ClientName = clientname;
                frmInterface.ContactNo = contactno;
                frmInterface.Remarks = remarks;
                frmInterface.State = state;
                frmInterface.IndustryType = industrytype;
                frmInterface.IsActive = isactive;
                frmInterface.AddService = addservice;
            }
            else
            {
                frmInterface.AddCleint = true;
                frmInterface.ClientCode = "";
            }            
        }

        private void UnloadInterface()
        {
            frmInterface.Close();
            frmInterface = null;
        }

        private void ShowForm()
        {
            DialogResult result;
            result = frmInterface.ShowDialog();
            if (result == DialogResult.OK)
            {
                DisplayClientList();
            }
            else
            {
                //textBox4.Text = "";
            }
        }

        private void btnNew2_Click(object sender, EventArgs e)
        {
            IsAdd = true;
            IsEdit = false;
           
                ProcessInterface();                          
           
        }

        private void btnEdit2_Click(object sender, EventArgs e)
        {
            IsEdit = true;
            IsAdd = false;

            if (dataGridView1.RowCount > 0)
            {

                ProcessInterface();               
            }
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewCheckBoxCell chk = new DataGridViewCheckBoxCell();
            try
            {
               
                    SetCleintProperty(dataGridView1.CurrentRow.Index);
               
                //ID = Convert.ToInt32(dgvDetails.Rows[dgvDetails.CurrentRow.Index].Cells[1].Value);
                //if (e.ColumnIndex == 3)
                //{
                //    if (rowIndex != -1) // check/uncheck perticuler record
                //    {
                //        chk = (DataGridViewCheckBoxCell)dgvDetails.CurrentCell;
                //        if (Convert.ToBoolean(chk.Value))
                //        {
                //            chk.Value = false;
                //        }
                //        else
                //        {
                //            chk.Value = true;
                //        }
                //    }
                //    else //check/uncheck all records header click
                //    {
                //        if (_IsShareHoldersActive)
                //        {
                //            SetActiveAll(dgvDetails, 3, false);
                //            _IsShareHoldersActive = false;
                //        }
                //        else
                //        {
                //            SetActiveAll(dgvDetails, 3, true);
                //            _IsShareHoldersActive = true;
                //        }
                //    }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
                        
                SetCleintProperty(dataGridView1.CurrentRow.Index);            
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            SetCleintProperty(dataGridView1.CurrentRow.Index);
        }

        private void SetCleintProperty(int index)
        {
            clientcode = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
            clientname = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value);
            contactno = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value);
            remarks = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value);
            state = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value);
            industrytype = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value);

            if (Convert.ToBoolean(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value) == true)
            {
                isactive = 1;
            }
            else
            {
                isactive = 0;
            }

           // isactive = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);

            addservice = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value);
        
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            string[] para;
            object[] values;
            string str1;

            object obj;

            if (dataGridView1.Rows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Do You Want to Delete '" + clientcode+"  "+ clientname + "'", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (dr == DialogResult.OK)
                {
                    str1 = "Delete * From ClientMaster where ClientCode = @ClientCode";
                    para = new string[] {  "@ClientCode" };
                    values = new object[] { clientcode };

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
                        DisplayClientList();
                    }
                    else
                    {
                        MessageBox.Show("Error Occurs", "ERROR");
                    }

                }

            }

        }

    }
}

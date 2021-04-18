using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ColdStorage.BLL;

namespace ColdStorage
{
    public partial class frmPartyMaster : Form
    {
        private bool AddMode = false;
        private bool EditMode = false;
        frmPartyDetails frmPartyDetails;

        private string _itemID;
        public bool IsLookUpMode = false;
        
        public string PartyID
        {
            get
            {
                return _itemID;
            }
        }

        public PartyMaster PartyMasterSelected;


        private const int SNoWidth = 60;
        private const int PartyIDWidth = 60;
        private const int PartyNameWidth = 250;
        private const int PersonNameWidth = 150;
        private const int AddressWidth = 400;

        private const int EditColumIndex = 0;
        private const int ViewColumIndex = 1;
        private const int DeleteColumIndex = 2;

        private const int SNoIndex = 3;
        private const int PartyIDIndex = 4;
        private const int PartyNameIndex = 5;
        private const int PersonNameIndex = 6;
        private const int AddressIndex = 7;
        private const int ContactNoIndex = 8;
        private const int MobileIndex = 9;
        private const int EmailIndex = 10;
        private const int RemarksIndex = 11;

    

        //Flags
        private const int AddItem = 0;
        private const int UpdateItem = 1;
        private const int ViewItem = 2;



        public frmPartyMaster()
        {
            InitializeComponent();
            if (IsLookUpMode)
            { 
            GlobalFunction.SetLookupFormStyle(this);
            }
            pnlLookupControl.Visible = IsLookUpMode;
        }

        private void frmPartyMaster_Load(object sender, EventArgs e)
        {
            DesignMainGrid();
            FillMainGrid();

        }

        private void DesignMainGrid()
        {
            dgvMain.RowCount = 1;
            dgvMain.ColumnCount = 5;

            dgvMain.Columns[0].Name = "S.No";
            dgvMain.Columns[0].Width = SNoWidth;
            dgvMain.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;

            dgvMain.Columns[1].Name = "Party ID";
            dgvMain.Columns[1].Width = PartyIDWidth;

            dgvMain.Columns[2].Name = "Party Name";
            dgvMain.Columns[2].Width = PartyNameWidth;

            dgvMain.Columns[3].Name = "Person Name";
            dgvMain.Columns[3].Width = PersonNameWidth;

            dgvMain.Columns[4].Name = "Address";
            dgvMain.Columns[4].Width = AddressWidth;






            dgvMain.RowHeadersVisible = false;
            dgvMain.AllowUserToDeleteRows = false;
            dgvMain.AllowUserToAddRows = false;
            dgvMain.AllowUserToResizeRows = false;
            dgvMain.AllowUserToResizeColumns = true;
            dgvMain.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvMain.ScrollBars = ScrollBars.Both;
            dgvMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //GlobalFunction.SetGridStyle(dgvMain);
           
            GlobalFunction.AddActionButtonToGrid(dgvMain);
            //
            if (IsLookUpMode)
            {
                GlobalFunction.HideActionButtonFromGrid(dgvMain);                

            }
            

            GlobalFunction.ApplyMasterGrid(dgvMain);
            //


            //}
        }

        
        private void cmdNew_Click(object sender, EventArgs e)
        {
            AddUpdateViewItem("", AddItem);
        }

        private void ClearControl()
        {

            dgvMain.RowCount = 0;
        }

        private void FillMainGrid()
        {
            try
            {

                //
                ClearControl();
                //Master Data
                PartyMaster objMaster = new PartyMaster();

                List<PartyMaster> list = objMaster.GetPartyMasterList();

                if ((list != null))
                {
                    if (list.Count > 0)
                    {

                        int i;

                        foreach (PartyMaster obj in list)
                        {
                            i = dgvMain.RowCount;

                            dgvMain.RowCount = i + 1;
                            dgvMain.Rows[i].Cells[SNoIndex].Value = i + 1;

                            dgvMain.Rows[i].Cells[PartyIDIndex].Value = obj.PartyID;
                            dgvMain.Rows[i].Cells[PartyNameIndex].Value = obj.PartyName;
                            dgvMain.Rows[i].Cells[PersonNameIndex].Value = obj.PersonName;
                            dgvMain.Rows[i].Cells[AddressIndex].Value = obj.Address;

                           

    }

                    }
                }



            }

            catch (Exception ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
            }


        }


        private void AddUpdateViewItem(string itemID, int action)
        {
            //pnlMaster.BringToFront();
            //ClickAdd();

            frmPartyDetails = new frmPartyDetails();

            if (action == AddItem)
            {
                frmPartyDetails.AddMode = true;
            }
            else if (action == UpdateItem)
            {
                frmPartyDetails.EditMode = true;
                frmPartyDetails.ItemId = itemID;
            }

            else if (action == ViewItem)
            {
                frmPartyDetails.ViewMode = true;
                frmPartyDetails.ItemId = itemID;
            }

            DialogResult result;
            result = frmPartyDetails.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    //retun party master ojnect
            //    PartyMaster partyMaster = new PartyMaster();
            //    obj = partyMaster.GetPartyMasterDetails(objLookup.PartyID);
            //}
            //else
            //{
            //    //retun null
            //    obj = null;
            //}
            frmPartyDetails = null;

            if (action == AddItem || action == UpdateItem)
            {
                FillMainGrid();
            }


        }



        //private void cmdOK_Click(object sender, EventArgs e)
        //{
        //    if (IsLookUpMode)
        //    {
        //        foreach (ListViewItem item in listView1.SelectedItems)
        //        {
        //            _itemID = item.SubItems[0].Text;
        //        }
        //        this.DialogResult = DialogResult.OK;
        //    }
        //}


        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;

            string itemId = "";


            if (rowIndex >= 0)
            {

                if (colIndex == EditColumIndex)
                {
                    itemId = Convert.ToString(dgvMain.Rows[rowIndex].Cells[PartyIDIndex].Value);
                    AddUpdateViewItem(itemId, UpdateItem);
                }
                else if (colIndex == ViewColumIndex)
                {
                    itemId = Convert.ToString(dgvMain.Rows[rowIndex].Cells[PartyIDIndex].Value);
                    AddUpdateViewItem(itemId, ViewItem);
                }
                else if (colIndex == DeleteColumIndex)
                {
                    //delete operation
                }

            }


        }

        private void cmdOKLookup_Click(object sender, EventArgs e)
        {
            ProcessLookUpOK();
           
        }

        private  void ProcessLookUpOK()
        {
            PartyMasterSelected = new PartyMaster();
            int selectedIndex = dgvMain.SelectedRows[0].Index;

            if (selectedIndex != -1)
            {

                PartyMasterSelected.PartyID = Convert.ToString(dgvMain.Rows[selectedIndex].Cells[PartyIDIndex].Value);
                PartyMasterSelected.PartyName = Convert.ToString(dgvMain.Rows[selectedIndex].Cells[PartyNameIndex].Value);
                PartyMasterSelected.PersonName = Convert.ToString(dgvMain.Rows[selectedIndex].Cells[PersonNameIndex].Value);
                PartyMasterSelected.Address = Convert.ToString(dgvMain.Rows[selectedIndex].Cells[AddressIndex].Value);


            }
            else
            {
                PartyMasterSelected = null;
            }

            this.DialogResult = DialogResult.OK;

        }

        private void cmdCancelLookup_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        

        private void dgvMain_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsLookUpMode)
            {
                ProcessLookUpOK();
            }
        }
    }
    
}

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
    public partial class frmItemMaster : Form
    {
        private bool AddMode = false;
        private bool EditMode = false;
        frmItemMasterDetails frmItemMasterDetails;

        private string _itemID;
        public bool IsLookUpMode = false;

        public string ItemID
        {
            get
            {
                return _itemID;
            }
        }


        private const int SNoWidth = 60;
        private const int ItemIDWidth = 120;
        private const int ItemNameWidth = 300;
        private const int RemarksWidth = 300;

        private const int EditColumIndex=0;
        private const int ViewColumIndex = 1;
        private const int DeleteColumIndex = 2;

        private const int SNoIndex = 3;
        private const int ItemIDIndex = 4;

        private const int ItemNameIndex = 5;
        private const int RemarksIndex = 6;

        //
        private const int AddItem=0;
        private const int UpdateItem = 1;
        private const int ViewItem = 2;



        public frmItemMaster()
        {
            InitializeComponent();
        }

        private void frmItemMaster_Load(object sender, EventArgs e)
        {
            DesignMainGrid();
            FillMainGrid();
            
        }

        private void DesignMainGrid()
        {
            dgvMain.RowCount = 1;
            dgvMain.ColumnCount = 4;

            dgvMain.Columns[0].Name = "S.No";
            dgvMain.Columns[0].Width = SNoWidth;
            dgvMain.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;

            dgvMain.Columns[1].Name = "Item ID";
            dgvMain.Columns[1].Width = ItemIDWidth;

            dgvMain.Columns[2].Name = "Item Name";
            dgvMain.Columns[2].Width = ItemNameWidth;


            dgvMain.Columns[3].Name = "Remarks";
            dgvMain.Columns[3].Width = RemarksWidth;      //323





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
                ItemMaster objMaster = new ItemMaster();

                List<ItemMaster> list = objMaster.GetItemMasterList();

                if ((list != null))
                {
                    if (list.Count > 0)
                    {

                        int i;

                        foreach (ItemMaster obj in list)
                        {
                            i = dgvMain.RowCount;

                            dgvMain.RowCount = i + 1;
                            dgvMain.Rows[i].Cells[SNoIndex].Value = i + 1;

                            dgvMain.Rows[i].Cells[ItemIDIndex].Value = obj.ItemID;
                            dgvMain.Rows[i].Cells[ItemNameIndex].Value = obj.ItemName;
                            dgvMain.Rows[i].Cells[RemarksIndex].Value = obj.Remarks;

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

            frmItemMasterDetails = new frmItemMasterDetails();

            if (action == AddItem)
            {
                frmItemMasterDetails.AddMode = true;
            }
            else if (action == UpdateItem)
            {
                frmItemMasterDetails.EditMode = true;
                frmItemMasterDetails.ItemId = itemID;
            }

            else if (action == ViewItem)
            {
                frmItemMasterDetails.ViewMode = true;
                frmItemMasterDetails.ItemId = itemID;
            }

            DialogResult result;
            result = frmItemMasterDetails.ShowDialog();
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
            frmItemMasterDetails = null;

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
                    itemId = Convert.ToString(dgvMain.Rows[rowIndex].Cells[ItemIDIndex].Value);
                    AddUpdateViewItem(itemId, UpdateItem);
                }
                else if (colIndex == ViewColumIndex)
                {
                    itemId = Convert.ToString(dgvMain.Rows[rowIndex].Cells[ItemIDIndex].Value);
                    AddUpdateViewItem(itemId, ViewItem);
                }
                else if (colIndex == DeleteColumIndex)
                {
                    //delete operation
                }

            }
            


        }


       


    }
}

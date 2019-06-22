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


        private const int SNoWidth = 40;
        private const int ItemIDWidth = 80;
        private const int ItemNameWidth = 250;
        private const int RemarksWidth = 350;


        public frmItemMaster()
        {
            InitializeComponent();
        }

        private void frmItemMaster_Load(object sender, EventArgs e)
        {
            DesignMainGrid();
            FillMainGrid();
            DesignListView();
            FillListView();
            ClearControl();
            ControlStatus(true);
            pnlList.BringToFront();
        }

        private void DesignMainGrid()
        {
            dgvMain.RowCount = 1;
            dgvMain.ColumnCount = 4;

            dgvMain.Columns[0].Name = "S.No";
            dgvMain.Columns[0].Width = SNoWidth;
            dgvMain.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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

            GlobalFunction.SetGridStyle(dgvMain);

            //}
        }

        private void DesignListView()
        {
            listView1.Columns.Add("Item ID", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("ItemName", 200);
            listView1.Columns.Add("Remarks", 150);



            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.MultiSelect = false;
            listView1.View = View.Details;

            //listView1.StateImageList = _mediumImageList;


        }


        private void cmdNew_Click(object sender, EventArgs e)
        {
            ClickAdd();
        }
        private void ClickAdd()
        {
            //get new id for book
            AddMode = true;
            EditMode = false;
            ClearControl();
            ControlStatus(false);
            txtItemId.Text = GlobalFunction.GetUniqueCode("ItemMaster");

        }
        private void ClearControl()
        {

            txtItemId.Text = "";
            txtItemName.Text = "";
            txtRemarks.Text = "";
            //dgvMain.RowCount = 0;
        }

        private void ControlStatus(bool status)
        {

            cmdNew.Enabled = status;
            cmdGoToList.Enabled = status;
            cmdEdit.Enabled = status;


            cmdSave.Enabled = !(status);
            cmdCancel.Enabled = !(status);


            txtItemId.ReadOnly = true;

            txtRemarks.ReadOnly = status;

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            bool result = false;
            ItemMaster item = GetItem();


            ItemMaster handler = new ItemMaster();
            if (AddMode)
            {
                result = handler.AddNewItemMaster(item);
                if (result)
                {
                    result = GlobalFunction.UpdateUniqueCode("ItemMaster");
                }
            }
            else if (EditMode)
            {
                result = handler.UpdateItemMaster(item);
            }

            if (result == true)
            {
                if (AddMode)
                {
                    MessageBox.Show("New Record added successfully");
                }
                else
                {
                    MessageBox.Show("Record updated successfully");
                }

                ControlStatus(true);
            }
            else
            {
                MessageBox.Show("Errror Occurs!");
            }
        }

        public void DisplayData(string itemID = "-1")
        {


            try
            {


                //Master Data
                ItemMaster objHandler = new ItemMaster();
                ItemMaster obj = objHandler.GetItemMasterDetails(itemID);
                if (obj != null)
                {
                    ClearControl();
                    SetItem(obj);
                    ControlStatus(true);
                }
                else
                {
                    MessageBox.Show("No record exist");
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
            }
        }

        private ItemMaster GetItem()
        {
            ItemMaster obj = new ItemMaster();
            obj.ItemID = txtItemId.Text;
            obj.ItemName = txtItemName.Text;
            obj.Remarks = txtRemarks.Text;

            return obj;
        }

        private void SetItem(ItemMaster obj)
        {
            txtItemId.Text = obj.ItemID;
            txtItemName.Text = obj.ItemName;
            txtRemarks.Text = obj.Remarks;
        }


        private void FillListView()
        {
            List<ItemMaster> list = new List<ItemMaster>();
            ItemMaster handler = new ItemMaster();
            list = handler.GetItemMasterList();
            ListViewItem lvi = new ListViewItem();

            if (list != null)
            {
                if (list.Count > 0)
                {
                    foreach (ItemMaster obj in list)
                    {
                        lvi = new ListViewItem(obj.ItemID);
                        lvi.SubItems.Add(obj.ItemName);
                        lvi.SubItems.Add(obj.Remarks);

                        listView1.Items.Add(lvi);
                    }

                }
            }


        }

        private void FillMainGrid()
        {
            try
            {


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
                            dgvMain.Rows[i].Cells[0].Value = i + 1;

                            dgvMain.Rows[i].Cells[1].Value = obj.ItemID;
                            dgvMain.Rows[i].Cells[2].Value = obj.ItemName;
                            dgvMain.Rows[i].Cells[3].Value = obj.Remarks;

                        }

                    }
                }



            }

            catch (Exception ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
            }


        }

        private void cmdAddNewInList_Click(object sender, EventArgs e)
        {
            //pnlMaster.BringToFront();
            //ClickAdd();

            frmItemMasterDetails = new frmItemMasterDetails();

            frmItemMasterDetails.AddMode = true;


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

        }

        private void cmdGoToList_Click(object sender, EventArgs e)
        {
            pnlList.BringToFront();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (IsLookUpMode)
            {
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    _itemID = item.SubItems[0].Text;
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void cmdCancelSelection_Click(object sender, EventArgs e)
        {
            if (IsLookUpMode)
            {
                this.DialogResult = DialogResult.Cancel;
            }

        }

        private void cmdViewDetail_Click(object sender, EventArgs e)
        {
            string itemID = "";
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                itemID = item.SubItems[0].Text;
            }
            if (itemID != "")
            {
                frmItemMasterDetails = new frmItemMasterDetails();

                frmItemMasterDetails.AddMode = false;
                frmItemMasterDetails.EditMode = true;
                frmItemMasterDetails.ItemId = itemID;

                DialogResult result;

                result = frmItemMasterDetails.ShowDialog();
            }
            //pnlMaster.BringToFront();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            AddMode = false;
            EditMode = true;
            ControlStatus(false);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void Cancel()
        {
            if (AddMode)
            {
                pnlList.BringToFront();
            }
            else if (EditMode)
            {
                DisplayData(txtItemId.Text.Trim());
            }
            else
            {
                AddMode = false;
                EditMode = false;
                ControlStatus(true);
            }

        }


    }
}

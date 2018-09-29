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

        private string _itemID;
        public bool IsLookUpMode = false;

        public string ItemID
        {
            get
            {
                return _itemID;
            }
        }

        public frmItemMaster()
        {
            InitializeComponent();
        }

        private void frmItemMaster_Load(object sender, EventArgs e)
        {
            DesignListView();
            FillListView();
            ClearControl();
            ControlStatus(true);
            pnlList.BringToFront();
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

            if (list!=null)
            {
            if (list.Count > 0 )
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

        private void cmdAddNewInList_Click(object sender, EventArgs e)
        {
            pnlMaster.BringToFront();
            ClickAdd();
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
                DisplayData(itemID);
            }
            pnlMaster.BringToFront();
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

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

        private string _itemID;
        public bool IsLookUpMode = false;

        public string PartyID
        {
            get
            {
                return _partyID;
            }
        }

        public frmPartyMaster()
        {
            InitializeComponent();
        }

        private void frmPartyMaster_Load(object sender, EventArgs e)
        {
            DesignListView();
            FillListView();
            ClearControl();
            ControlStatus(true);
            pnlList.BringToFront();
        }

        private void DesignListView()
        {
            listView1.Columns.Add("Party ID", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Party Name", 100);
            listView1.Columns.Add("Person Name", 100);
            listView1.Columns.Add("Address", 100);
            listView1.Columns.Add("Contact No", 100);
            listView1.Columns.Add("Mobile", 100);
            listView1.Columns.Add("Email", 150);
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
            txtPartyID.Text = GlobalFunction.GetUniqueCode("PartyMaster");

        }
        private void ClearControl()
        {

            txtPartyID.Text = "";
            txtPartyName.Text = "";
            txtPersonName.Text = "";
            txtAddress.Text = "";
            txtContactNo.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
            txtRemarks.Text = "";
            //dgvMain.RowCount = 0;
        }

        private void ControlStatus(bool status)
        {
            //buttons
            cmdNew.Enabled = status;
            cmdGoToList.Enabled = status;
            cmdEdit.Enabled = status;


            cmdSave.Enabled = !(status);
            cmdCancel.Enabled = !(status);

            //texxt box
            txtPartyID.ReadOnly = true;

            txtPartyName.ReadOnly = status;
            txtPersonName.ReadOnly = status;
            txtAddress.ReadOnly = status;
            txtContactNo.ReadOnly = status;
            txtMobile.ReadOnly = status;
            txtEmail.ReadOnly = status;
            txtRemarks.ReadOnly = status;

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            bool result = false;
            PartyMaster item = GetItem();


            PartyMaster handler = new PartyMaster();
            if (AddMode)
            {
                result = handler.AddNewPartyMaster(item);
                if (result)
                {
                    result = GlobalFunction.UpdateUniqueCode("PartyMaster");
                }
            }
            else if (EditMode)
            {
                result = handler.UpdatePartyMaster(item);
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
                PartyMaster objHandler = new PartyMaster();
                PartyMaster obj = objHandler.GetPartyMasterDetails(itemID);
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

        private PartyMaster GetItem()
        {
            PartyMaster obj = new PartyMaster();
            
            obj.Remarks = txtRemarks.Text;
            obj.PartyID = txtPartyID.Text;
            obj.PartyName = txtPartyName.Text;
            obj.PersonName = txtPersonName.Text;
            obj.Address = txtAddress.Text;
            obj.ContactNo = txtContactNo.Text;
            obj.Mobile = txtMobile.Text;
            obj.EamilAddress = txtEmail.Text;
            obj.Remarks = txtRemarks.Text;

            return obj;
        }

        private void SetItem(PartyMaster obj)
        {
            txtRemarks.Text = obj.Remarks;
            txtPartyID.Text = obj.PartyID;
            txtPartyName.Text = obj.PartyName;
            txtPersonName.Text = obj.PersonName;
            txtAddress.Text = obj.Address;
            txtContactNo.Text = obj.ContactNo;
            txtMobile.Text = obj.Mobile;
            txtEmail.Text = obj.EamilAddress;
            txtRemarks.Text = obj.Remarks;
        }


        private void FillListView()
        {
            List<PartyMaster> list = new List<PartyMaster>();
            PartyMaster handler = new PartyMaster();
            list = handler.GetPartyMasterList();
            ListViewItem lvi = new ListViewItem();

            if (list != null)
            {
                if (list.Count > 0)
                {
                    foreach (PartyMaster obj in list)
                    {
                        lvi = new ListViewItem(obj.PartyID);
                        lvi.SubItems.Add(obj.PartyName);
                        lvi.SubItems.Add(obj.PersonName);
                        lvi.SubItems.Add(obj.Address);
                        lvi.SubItems.Add(obj.ContactNo);
                        lvi.SubItems.Add(obj.Mobile); 
                        lvi.SubItems.Add(obj.EamilAddress);                         
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
                DisplayData(txtPartyID.Text.Trim());
            }
            else
            {
                AddMode = false;
                EditMode = false;
                ControlStatus(true);
            }

        }



        public string _partyID { get; set; }
    }
}

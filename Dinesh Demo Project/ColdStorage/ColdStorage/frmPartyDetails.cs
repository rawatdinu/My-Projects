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
    public partial class frmPartyDetails : Form
    {
        public bool AddMode = false;
        public bool EditMode = false;
        public string ItemId;

        public bool ViewMode = false;




        public frmPartyDetails()
        {
            InitializeComponent();
        }

        private void frmPartyDetails_Load(object sender, EventArgs e)
        {
            ClearControl();

            if (AddMode == true)
            {
                cmdSave.Text = "Save";
                DisplayData();
            }
            else if (EditMode == true)
            {
                cmdSave.Text = "Update";
                DisplayData(ItemId);
            }
            else if (ViewMode == true)
            {
                pnlControl.Enabled = false;
                DisplayData(ItemId);
            }
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
        }

        private void GetNewItemID()
        {

        }

        public void DisplayData(string itemID = "-1")
        {


            try
            {

                if (itemID == "-1")
                {
                    //New Item
                    //Get Item code 
                    txtPartyID.Text = GlobalFunction.GetUniqueCode("PartyMaster");
                }
                else
                {
                    //Existing Item
                    PartyMaster objHandler = new PartyMaster();
                    PartyMaster obj = objHandler.GetPartyMasterDetails(itemID);
                    if (obj != null)
                    {
                        ClearControl();
                        SetItem(obj);
                    }

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
            txtPartyID.Text = obj.PartyID;
            txtPartyName.Text=obj.PartyName;
            txtPersonName.Text=obj.PersonName;
            txtAddress.Text = obj.Address;
            txtContactNo.Text= obj.ContactNo;
            txtMobile.Text= obj.Mobile;
            txtEmail.Text =obj.EamilAddress;
            txtRemarks.Text =obj.Remarks;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                
            }
            else
            {
                MessageBox.Show("Errror Occurs!");
            }
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            //Cancel();
        }
        private void Cancel()
        {
            if (AddMode)
            {
                ClearControl();
                DisplayData("-1");
            }
            else if (EditMode)
            {
                DisplayData(txtPartyID.Text.Trim());
            }

        }



    }
}

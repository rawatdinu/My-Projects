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
    public partial class frmItemMasterDetails : Form
    {
        public bool AddMode = false;
        public bool EditMode = false;
        public string ItemId;


        public frmItemMasterDetails()
        {
            InitializeComponent();
        }

        private void frmItemMasterDetails_Load(object sender, EventArgs e)
        {
            ClearControl();

            if (AddMode == true)
            {
                DisplayData();
            }
            else if (EditMode == true)
            {
                DisplayData(ItemId);
            }
        }
        private void ClearControl()
        {

            txtItemId.Text = "";
            txtItemName.Text = "";
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
                    txtItemId.Text = GlobalFunction.GetUniqueCode("ItemMaster");
                }
                else
                {
                    //Existing Item
                    ItemMaster objHandler = new ItemMaster();
                    ItemMaster obj = objHandler.GetItemMasterDetails(itemID);
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

﻿using System;
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
    public partial class frmTransactionIn : Form
    {

        private bool AddMode = false;
        private bool EditMode = false;
        private string _itemID = "";

        ItemMaster bookMasterItem;
        frmItemMaster frmInterface;


        //Constant
        private const int SNo = 0;
        private const int ItemID = 1;
        private const int ItemName = 2;
        //private const int Author = 3;
        //private const int EditionYear = 4;
        //private const int EditionNo = 5;
        private const int Unit = 3;


        //column width
        private const int SNoWidth = 60;
        private const int ItemIDWidth = 150;
        private const int ItemNameWidth = 200;
        //private const int AuthorWidth = 200;
        //private const int EditionYearWidth = 60;
        //private const int EditionNoWidth = 60;
        private const int UnitWidth = 90;


        public frmTransactionIn()
        {
            InitializeComponent();
        }

        private void frmTransactionIn_Load(object sender, EventArgs e)
        {
            DesignListView();
            DisplayTrasactionList();
            DesignMainGrid();
            ClearControl();
            ControlStatus(true);
            pnlList.BringToFront();
        }

        private void cmdAddNewInList_Click(object sender, EventArgs e)
        {
            pnlMaster.BringToFront();
            ClickAdd();
        }

        private void ClickAdd()
        {
            //get new id for book
            AddMode = true;
            EditMode = false;
            ClearControl();
            ControlStatus(false);
            txtTranID.Text = GlobalFunction.GetUniqueCode("TransactionInMaster");
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            ClickAdd();
        }

        private void cmdGoToList_Click(object sender, EventArgs e)
        {
            pnlList.BringToFront();  
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            bool result = false;

            
            TransactionInMaster objTransactionInMaster = GetTransactionInMasterInterface();

            TransactionInMaster masterhandler = new TransactionInMaster();

            List<TransactionInDetails> objDetailsList = GetTransactionInDetailsInterface();
            TransactionInDetails objDetailsHandler = new TransactionInDetails();

            //Inventory obj;
            if (AddMode)
            {
                result = masterhandler.AddNewTransactionInMaster(objTransactionInMaster);

                if (result)
                {
                    result = objDetailsHandler.AddNewTransactionInDetails(objDetailsList);
                }
                if (result)
                {
                    result = GlobalFunction.UpdateUniqueCode("TransactionInMaster");
                }

               // obj = new Inventory();
                //if (result)
                //{
                //    result = obj.AddInventory(objDetailsList);
                //}
            }
            else if (EditMode)
            {
               // obj = new Inventory();

                result = masterhandler.UpdateTransactionIn(objTransactionInMaster);

                //if (result)
                //{

                //    result = obj.UpdateInventory(objBooksTransactionInMaster.TransactionID, objDetailsList);
                //}

                if (result)
                {
                    result = objDetailsHandler.DeleteTransactionInDetails(objTransactionInMaster.TransactionID);

                    if (result)
                    {
                        result = objDetailsHandler.AddNewTransactionInDetails(objDetailsList);
                    }

                }
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

        private TransactionInMaster GetTransactionInMasterInterface()
        {
            TransactionInMaster obj = new TransactionInMaster();
            obj.TransactionID = txtTranID.Text;
            obj.TransactionDate = GlobalFunction.GetDateTimeWithoutMiliSecond(dtpTranInDate.Value);
            obj.Remarks = txtRemarks.Text;
            //book.Subject = txtSubject.Text;
            //book.Author = txtAuthorName.Text;
            //book.Publication = txtPublication.Text;
            //book.EditionNo = Convert.ToInt32(txtEditionNo.Text);
            //book.EditionYear = Convert.ToInt32(txtEditionYear.Text);
            //book.Price = Convert.ToInt32(txtPrice.Text);
            return obj;
        }

        private List<TransactionInDetails> GetTransactionInDetailsInterface()
        {
            List<TransactionInDetails> objTrasList = new List<TransactionInDetails>();

            int rowCount = dgvMain.RowCount;
            TransactionInDetails obj;
            ItemMaster objItemMaster;
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                obj = new TransactionInDetails();
                obj.TransactionID = txtTranID.Text;

                obj.Unit = Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[Unit].Value);

                objItemMaster = new ItemMaster();
                objItemMaster.ItemID = Convert.ToString(dgvMain.Rows[rowIndex].Cells[ItemID].Value);
                obj.ItemMaster  = objItemMaster;

                objTrasList.Add(obj);
            }
            return objTrasList;
        }

        private void DesignTransactionListView()
        {
            listView1.Columns.Add("Trans ID", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Transaction Date", 100);
            listView1.Columns.Add("Remarks", 200);
            //listView1.Columns.Add("Subject", 100);
            //listView1.Columns.Add("Author", 100);
            //listView1.Columns.Add("Publication", 100);
            //listView1.Columns.Add("EditionNo", 50);
            //listView1.Columns.Add("EditionYear", 50);
            //listView1.Columns.Add("Price", 60);

            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.MultiSelect = false;
            listView1.View = View.Details;

            //listView1.StateImageList = _mediumImageList;


        }

        private void DesignMainGrid()
        {
            dgvMain.RowCount = 1;
            dgvMain.ColumnCount = 4;

            dgvMain.Columns[0].Name = "S.No";
            dgvMain.Columns[0].Width = SNoWidth;
            dgvMain.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMain.Columns[1].Name = "ItemID";
            dgvMain.Columns[1].Width = ItemIDWidth;

            dgvMain.Columns[2].Name = "ItemName";
            dgvMain.Columns[2].Width = ItemNameWidth;

            //dgvMain.Columns[3].Name = "Author";
            //dgvMain.Columns[3].Width = AuthorWidth;      //323

            //dgvMain.Columns[4].Name = "EditionYear";
            //dgvMain.Columns[4].Width = EditionYearWidth;
            //dgvMain.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //dgvMain.Columns[5].Name = "EditionNo";
            //dgvMain.Columns[5].Width = EditionNoWidth;
            //dgvMain.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMain.Columns[3].Name = "Unit";
            dgvMain.Columns[3].Width = UnitWidth;      //323
            dgvMain.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;



            dgvMain.RowHeadersVisible = false;
            dgvMain.AllowUserToDeleteRows = false;
            dgvMain.AllowUserToAddRows = false;
            dgvMain.AllowUserToResizeRows = false;
            dgvMain.AllowUserToResizeColumns = true;
            dgvMain.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvMain.ScrollBars = ScrollBars.Both;
            dgvMain.SelectionMode = DataGridViewSelectionMode.CellSelect;

            GlobalFunction.SetGridStyle(dgvMain);

            //}
        }

        private void AddItemToGrid(ItemMaster item)
        {

            int i = dgvMain.RowCount;
            dgvMain.RowCount = i + 1;

            dgvMain.Rows[i].Cells[SNo].Value = i + 1;
            dgvMain.Rows[i].Cells[ItemID].Value = item.ItemID;
            dgvMain.Rows[i].Cells[ItemName].Value = item.ItemName;
            //dgvMain.Rows[i].Cells[Author].Value = item.Author;
            //dgvMain.Rows[i].Cells[EditionYear].Value = item.EditionYear;
            //dgvMain.Rows[i].Cells[EditionNo].Value = item.EditionNo;

        }

        private bool IsItemAlreadyAdded(string itemCode)
        {
            bool result = false;
            int rowCount = dgvMain.RowCount;

            for (int i = 0; i < rowCount; i++)
            {
                if (Convert.ToString(dgvMain.Rows[i].Cells[ItemID].Value) == itemCode)
                {
                    //update qunatity
                    dgvMain.Rows[i].Cells[Unit].Value = Convert.ToInt32(dgvMain.Rows[i].Cells[Unit].Value) + 1;
                    result = true;
                    break;
                }
            }
            return result;
        }

        private void cmdAddItem_Click(object sender, EventArgs e)
        {
            ProcessInterface();

            if (AddMode || EditMode)
            {
                ItemMaster handler = new ItemMaster();
                if (_itemID != "")
                {
                    bookMasterItem = handler.GetItemMasterDetails(_itemID);
                    AddItemToGrid(bookMasterItem);
                }

                //CalculateTotalAmount();
            }
        }

        private void ProcessInterface()
        {
            frmInterface = new frmItemMaster();
            frmInterface.IsLookUpMode = true;

            DialogResult result;

            result = frmInterface.ShowDialog();
            if (result == DialogResult.OK)
            {
                _itemID = frmInterface.ItemID;
            }
            else
            {
                _itemID = "";
            }


            frmInterface.Close();
            frmInterface = null;
        }
      
        private void dgvMain_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;
            if ((AddMode || EditMode))
            {
                // Qunatiy and Discount%,
                if (colIndex == Unit)
                {
                    dgvMain.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                }
                else
                {
                    dgvMain.EditMode = DataGridViewEditMode.EditProgrammatically;
                }

            }
        }

        private void dgvMain_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;
            if ((AddMode || EditMode))
            {
                if (colIndex == Unit)
                {
                    //CalculateTotalAmount();
                }
            }
        }


        private void ClearControl()
        {

            txtTranID.Text = "";
            dtpTranInDate.Value = DateTime.Now;
            txtRemarks.Text = "";
            dgvMain.RowCount = 0;
        }

        private void ControlStatus(bool status)
        {

            cmdNew.Enabled = status;
            cmdGoToList.Enabled = status;
            cmdEdit.Enabled = status;


            cmdSave.Enabled = !(status);
            cmdAddItem.Enabled = !(status);
            cmdRemoveItem.Enabled = !(status);
            cmdCancel.Enabled = !(status);
            cmdPrint.Enabled = !(status);

            txtTranID.ReadOnly = true;

            txtRemarks.ReadOnly = status;
            dtpTranInDate.Enabled = !(status);


        }





        private void DesignListView()
        {
            listView1.Columns.Add("Trans ID", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Transaction Date", 120);
            listView1.Columns.Add("Remarks", 250);
            //listView1.Columns.Add("Subject", 100);
            //listView1.Columns.Add("Author", 100);
            //listView1.Columns.Add("Publication", 100);
            //listView1.Columns.Add("EditionNo", 50);
            //listView1.Columns.Add("EditionYear", 50);
            //listView1.Columns.Add("Price", 60);

            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.MultiSelect = false;
            listView1.View = View.Details;

            //listView1.StateImageList = _mediumImageList;


        }

        public void DisplayTrasactionList()
        {


            //string fromDate = dtpFromDate.Value.ToString("MM/dd/yyyy");
            //string toDate = dtpToDate.Value.AddDays(1).ToString("MM/dd/yyyy");

            //if (!dateFilter)
            //{
            //    dtpFromDate.Value = DateTime.Now.Date.AddDays(-7);
            //    dtpToDate.Value = DateTime.Now.Date;
            //    fromDate = dtpFromDate.Value.ToString("MM/dd/yyyy");
            //    toDate = DateTime.Now.Date.AddDays(1).ToString("MM/dd/yyyy");
            //}

            try
            {

                List<TransactionInMaster> list = new List<TransactionInMaster>();
                TransactionInMaster masterHandler = new TransactionInMaster();
              
                list = masterHandler.GetTransactionInMasterList();
                ListViewItem lvi = new ListViewItem();
                
                if ((list != null))
                {
                    if (list.Count > 0)
                    {
                        foreach (TransactionInMaster obj in list)
                        {
                            lvi = new ListViewItem(obj.TransactionID);
                            lvi.SubItems.Add(Convert.ToString(obj.TransactionDate));
                            lvi.SubItems.Add(obj.Remarks);

                            listView1.Items.Add(lvi);
                        }
                    }
                }
                

            }

            catch (Exception ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
            }

        }

        public void DisplayData(string transactionID = "-1")
        {


            try
            {
                ClearControl();

                //Master Data
                TransactionInMaster objMasterHandler = new TransactionInMaster();
                TransactionInMaster objMaster = objMasterHandler.GetTransactionInMaster(transactionID);

                if (objMaster != null)
                {
                    txtTranID.Text = objMaster.TransactionID;
                    dtpTranInDate.Value = objMaster.TransactionDate;
                    txtRemarks.Text = objMaster.Remarks;

                    //Transaction Data
                    TransactionInDetails tranDetailsHandler = new TransactionInDetails();
                    List<TransactionInDetails> list = new List<TransactionInDetails>();

                    list = tranDetailsHandler.GetTransactionInList(transactionID);
                    if ((list != null))
                    {
                        if (list.Count > 0)
                        {

                            int i;

                            foreach (TransactionInDetails obj in list)
                            {
                                i = dgvMain.RowCount;

                                dgvMain.RowCount = i + 1;
                                dgvMain.Rows[i].Cells[SNo].Value = i + 1;

                                dgvMain.Rows[i].Cells[ItemID].Value = obj.ItemMaster.ItemID;
                                dgvMain.Rows[i].Cells[ItemName].Value = obj.ItemMaster.ItemName;
                                //dgvMain.Rows[i].Cells[Author].Value = obj.BookMaster.Author;
                                //dgvMain.Rows[i].Cells[EditionYear].Value = obj.BookMaster.EditionYear;
                                //dgvMain.Rows[i].Cells[EditionNo].Value = obj.BookMaster.EditionNo;
                                dgvMain.Rows[i].Cells[Unit].Value = obj.Unit;
                            }

                        }
                    }                    
                    ControlStatus(true);
                
                }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
            }
        }

        private void cmdViewDetails_Click(object sender, EventArgs e)
        {
            string tansID = "";
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                tansID = item.SubItems[0].Text;
            }
            if (tansID != "")
            {
                DisplayData(tansID);
            }

            pnlMaster.BringToFront();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            AddMode = false;
            EditMode = true;
            ControlStatus(false);
        }

        private void cmdRemoveItem_Click(object sender, EventArgs e)
        {
            if (AddMode || EditMode)
            {
                int rowcount = dgvMain.RowCount;

                try
                {
                    dgvMain.Rows.RemoveAt(dgvMain.CurrentCell.RowIndex);

                    SetDataGridViewSerialNo();
                    //CalculateTotalAmount();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
                }

            }
        }

        private void SetDataGridViewSerialNo()
        {

            for (int i = 0; i < dgvMain.RowCount; i++)
            {
                dgvMain.Rows[i].Cells[SNo].Value = i + 1;
            }
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
                DisplayData(txtTranID.Text.Trim());
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

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.BLL;


namespace Library
{
    public partial class frmBooksTransactionIn : Form
    {

        private bool AddMode = false;
        private bool EditMode = false;
        private string _bookID = "";
        
        BooksMaster bookMasterItem;
        frmBooksMaster frmInterface;
        

        //Constant
        private const int SNo = 0;
        private const int BookID = 1;
        private const int Subject = 2;
        private const int Author = 3;
        private const int EditionYear = 4;
        private const int EditionNo = 5;
        private const int Unit = 6;


        //column width
        private const int SNoWidth = 60;
        private const int BookIDWidth = 150;
        private const int SubjectWidth = 200;
        private const int AuthorWidth = 200;
        private const int EditionYearWidth = 60;
        private const int EditionNoWidth = 60;
        private const int UnitWidth = 90;


        public frmBooksTransactionIn()
        {
            InitializeComponent();
        }

        private void frmBooksTransactionIn_Load(object sender, EventArgs e)
        {
            DesignListView();
            DisplayTrasactionList();
            DesignMainGrid();
            DesignSelectedGrid();
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
            txtTranID.Text = GlobalFunction.GetUniqueCode("BooksTransactionInMaster");
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
            BooksTransactionInMaster objBooksTransactionInMaster = GetTransactionInMasterInterface();
            BooksTransactionInMasterHandler masterhandler = new BooksTransactionInMasterHandler();

            List<BooksTransactionInDetails> objDetailsList = GetTransactionInDetailsInterface();
            BooksTransactionInDetailsHandler objDetailsHandler = new BooksTransactionInDetailsHandler();

            Inventory obj;
            if (AddMode)
            {
                result = masterhandler.AddNewTransactionInMaster(objBooksTransactionInMaster);

                if (result)
                {
                    result = objDetailsHandler.AddNewTransactionInDetails(objDetailsList);
                }
                if (result)
                {
                    result = GlobalFunction.UpdateUniqueCode("BooksTransactionInMaster");
                }

                obj = new Inventory();
                if (result)
                {
                    result = obj.AddInventory(objDetailsList);
                }
            }
            else if (EditMode)
            {
                obj = new Inventory();

                result = masterhandler.UpdateTransactionIn(objBooksTransactionInMaster);

                if (result)
                {
                    
                    result = obj.UpdateInventory(objBooksTransactionInMaster.TransactionID, objDetailsList);
                }

                if (result)
                {
                    result = objDetailsHandler.DeleteTransactionInDetails(objBooksTransactionInMaster.TransactionID);

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

        private BooksTransactionInMaster GetTransactionInMasterInterface()
        {
            BooksTransactionInMaster obj = new BooksTransactionInMaster();
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

        private List<BooksTransactionInDetails> GetTransactionInDetailsInterface()
        {
            List<BooksTransactionInDetails> objTrasList = new List<BooksTransactionInDetails>();

            int rowCount = dgvMain.RowCount;
            BooksTransactionInDetails obj;
            BooksMaster objbookMaster;
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                obj = new BooksTransactionInDetails();
                obj.TransactionID = txtTranID.Text;
               
                obj.Unit = Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[Unit].Value);

                objbookMaster = new BooksMaster();
                objbookMaster.BookID = Convert.ToString(dgvMain.Rows[rowIndex].Cells[BookID].Value);
                obj.BookMaster = objbookMaster;

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
            dgvMain.ColumnCount = 7;

            dgvMain.Columns[0].Name = "S.No";
            dgvMain.Columns[0].Width = SNoWidth;
            dgvMain.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMain.Columns[1].Name = "BookID";
            dgvMain.Columns[1].Width = BookIDWidth;

            dgvMain.Columns[2].Name = "Subject";
            dgvMain.Columns[2].Width = SubjectWidth;
            
            dgvMain.Columns[3].Name = "Author";
            dgvMain.Columns[3].Width = AuthorWidth;      //323

            dgvMain.Columns[4].Name = "EditionYear";
            dgvMain.Columns[4].Width = EditionYearWidth;
            dgvMain.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMain.Columns[5].Name = "EditionNo";
            dgvMain.Columns[5].Width = EditionNoWidth;
            dgvMain.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMain.Columns[6].Name = "Unit";
            dgvMain.Columns[6].Width = UnitWidth;      //323
            dgvMain.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;



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

        private void DesignSelectedGrid()
        {
            dgvSelected.RowCount = 1;
            dgvSelected.ColumnCount = 7;

            dgvSelected.Columns[0].Name = "S.No";
            dgvSelected.Columns[0].Width = SNoWidth;
            dgvSelected.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvSelected.Columns[1].Name = "BookID";
            dgvSelected.Columns[1].Width = BookIDWidth;

            dgvSelected.Columns[2].Name = "Subject";
            dgvSelected.Columns[2].Width = SubjectWidth;

            dgvSelected.Columns[3].Name = "Author";
            dgvSelected.Columns[3].Width = AuthorWidth;      //323

            dgvSelected.Columns[4].Name = "EditionYear";
            dgvSelected.Columns[4].Width = EditionYearWidth;
            dgvSelected.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvSelected.Columns[5].Name = "EditionNo";
            dgvSelected.Columns[5].Width = EditionNoWidth;
            dgvSelected.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvSelected.Columns[6].Name = "Unit";
            dgvSelected.Columns[6].Width = UnitWidth;      //323
            dgvSelected.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;



            dgvSelected.RowHeadersVisible = false;
            dgvSelected.AllowUserToDeleteRows = false;
            dgvSelected.AllowUserToAddRows = false;
            dgvSelected.AllowUserToResizeRows = false;
            dgvSelected.AllowUserToResizeColumns = true;
            dgvSelected.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSelected.ScrollBars = ScrollBars.Both;
            dgvSelected.SelectionMode = DataGridViewSelectionMode.CellSelect;

            GlobalFunction.SetGridStyle(dgvSelected);

            //}
        }

        private void AddItemToGrid(BooksMaster item)
        {

            int i = dgvMain.RowCount;
            dgvMain.RowCount = i + 1;

            dgvMain.Rows[i].Cells[SNo].Value = i + 1;
            dgvMain.Rows[i].Cells[BookID].Value = item.BookID;
            dgvMain.Rows[i].Cells[Subject].Value = item.Subject;
            dgvMain.Rows[i].Cells[Author].Value = item.Author;
            dgvMain.Rows[i].Cells[EditionYear].Value = item.EditionYear;
            dgvMain.Rows[i].Cells[EditionNo].Value = item.EditionNo;
            
        }

        private void AddItemToSelectedGrid(BooksMaster item)
        {

            int i = dgvSelected.RowCount;
            dgvSelected.RowCount = i + 1;

            dgvSelected.Rows[i].Cells[SNo].Value = i + 1;
            dgvSelected.Rows[i].Cells[BookID].Value = item.BookID;
            dgvSelected.Rows[i].Cells[Subject].Value = item.Subject;
            dgvSelected.Rows[i].Cells[Author].Value = item.Author;
            dgvSelected.Rows[i].Cells[EditionYear].Value = item.EditionYear;
            dgvSelected.Rows[i].Cells[EditionNo].Value = item.EditionNo;

        }

        private bool IsItemAlreadyAdded(string itemCode)
        {
            bool result = false;
            int rowCount = dgvMain.RowCount;

            for (int i = 0; i < rowCount; i++)
            {
                if (Convert.ToString(dgvMain.Rows[i].Cells[BookID].Value) == itemCode)
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
                BooksMasterHandler handler = new BooksMasterHandler();
                if (_bookID!="")
                {
                    bookMasterItem = handler.GetBooksMasterDetails(_bookID);
                    AddItemToGrid(bookMasterItem);
                }
                
                //CalculateTotalAmount();
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
            frmInterface = new frmBooksMaster();
            frmInterface.IsLookUpMode = true;
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
                _bookID = frmInterface.BookID;
            }
            else
            {
                _bookID = "";
            }
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
                
                List<BooksTransactionInMaster> list = new List<BooksTransactionInMaster>();
                BooksTransactionInMasterHandler masterHandler = new BooksTransactionInMasterHandler();
                list = masterHandler.GetTransactionInMasterList();
                ListViewItem lvi = new ListViewItem();

                if ((list != null) && list.Count > 0)
                {
                    foreach (BooksTransactionInMaster obj in list)
                    {
                        lvi = new ListViewItem(obj.TransactionID);
                        lvi.SubItems.Add(Convert.ToString(obj.TransactionDate));
                        lvi.SubItems.Add(obj.Remarks);
                        
                        listView1.Items.Add(lvi);
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
               BooksTransactionInMasterHandler objMasterHandler = new BooksTransactionInMasterHandler();
               BooksTransactionInMaster objMaster = objMasterHandler.GetTransactionInMaster(transactionID);
               txtTranID.Text = objMaster.TransactionID;
               dtpTranInDate.Value = objMaster.TransactionDate;
               txtRemarks.Text = objMaster.Remarks;

                //Transaction Data
               BooksTransactionInDetailsHandler tranDetailsHandler = new BooksTransactionInDetailsHandler();
              List<BooksTransactionInDetails> list  = new List<BooksTransactionInDetails>();

              list  = tranDetailsHandler.GetTransactionInList(transactionID);
           
              if (list.Count > 0)
              {

                  int i;
                 
                  foreach (BooksTransactionInDetails obj in list)
                  {
                      i = dgvMain.RowCount;

                      dgvMain.RowCount = i + 1;
                      dgvMain.Rows[i].Cells[SNo].Value = i + 1;

                      dgvMain.Rows[i].Cells[BookID].Value = obj.BookMaster.BookID;
                      dgvMain.Rows[i].Cells[Subject].Value = obj.BookMaster.Subject;
                      dgvMain.Rows[i].Cells[Author].Value = obj.BookMaster.Author;
                      dgvMain.Rows[i].Cells[EditionYear].Value = obj.BookMaster.EditionYear;
                      dgvMain.Rows[i].Cells[EditionNo].Value = obj.BookMaster.EditionNo;
                      dgvMain.Rows[i].Cells[Unit].Value = obj.Unit;
                  }

              }

              ControlStatus(true);

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

        private void cmdGoToList_Click_1(object sender, EventArgs e)
        {
            pnlList.BringToFront();
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string strText = txtSearch.Text;

            BooksMasterHandler objHandler = new BooksMasterHandler();
            List<BooksMaster> list = objHandler.SearchBooksMasterList(strText);

            dgvMain.RowCount = 0;

            if ((list != null) && list.Count > 0)
            {
                foreach (BooksMaster obj in list)
                {
                    AddItemToGrid(obj);
                }

                dgvMain.Rows[0].Selected = true;
            } 

        }

      
       
    }
}

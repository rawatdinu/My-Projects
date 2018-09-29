using System;
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
    public partial class frmBooksMaster : Form
    {
       private bool AddMode = false;
       private bool EditMode = false;

       private string _bookID;
       public bool IsLookUpMode = false;

       public string BookID
       {
           get
           {
               return _bookID;
           }
       }

   
        public frmBooksMaster()
        {
            InitializeComponent();
        }

        private void frmBooksMaster_Load(object sender, EventArgs e)
        {
            DesignListView();
            FillListView();
            ClearControl();
            ControlStatus(true);
            pnlList.BringToFront();
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
            txtBookId.Text = GlobalFunction.GetUniqueCode("BooksMaster");
        
        }

        private void ClearControl()
        {

            //txtTranID.Text = "";
            //dtpTranInDate.Value = DateTime.Now;
            //txtRemarks.Text = "";
            //dgvMain.RowCount = 0;
        }

        private void ControlStatus(bool status)
        {

            cmdNew.Enabled = status;
            cmdGoToList.Enabled = status;
            cmdEdit.Enabled = status;


            cmdSave.Enabled = !(status);            
            cmdCancel.Enabled = !(status);
            

            txtBookId.ReadOnly = true;

            txtRemarks.ReadOnly = status;
            
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Save(); 
        }

        private void Save()
        {
            bool result = false;
            BooksMaster book = GetBook();


            BooksMasterHandler handler = new BooksMasterHandler();
            if (AddMode)
            {
                result = handler.AddNewBooksMaster(book);
                if (result)
                {
                    result = GlobalFunction.UpdateUniqueCode("BooksMaster");
                }
            }
            else if (EditMode)
            {
                result = handler.UpdateBooksMaster(book);
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

        public void DisplayData(string bookID = "-1")
        {


            try
            {
                

                //Master Data
                BooksMasterHandler objHandler = new BooksMasterHandler();
                BooksMaster obj = objHandler.GetBooksMasterDetails(bookID);
                if (obj != null)
                {
                    ClearControl();
                    SetBook(obj);
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

        private BooksMaster GetBook()
        {
            BooksMaster book = new BooksMaster();
            book.BookID = txtBookId.Text;
            book.ISBN = txtISBN.Text;
            book.Title = txtTitle.Text;
            book.Subject = txtSubject.Text;
            book.Author = txtAuthorName.Text;
            book.Publication = txtPublication.Text;
            book.EditionNo = Convert.ToInt32(txtEditionNo.Text);
            book.EditionYear = Convert.ToInt32(txtEditionYear.Text);
            book.Price = Convert.ToInt32( txtPrice.Text);  
            return book;
        }

        private void SetBook(BooksMaster obj)
        {
            txtBookId.Text = obj.BookID;
            txtISBN.Text = obj.ISBN;
            txtTitle.Text = obj.Title;
            txtSubject.Text = obj.Subject;
            txtAuthorName.Text = obj.Author;
            txtPublication.Text = obj.Publication;
            txtEditionNo.Text = Convert.ToString(obj.EditionNo);
            txtEditionYear.Text = Convert.ToString(obj.EditionYear);
            txtPrice.Text = Convert.ToString(obj.Price);
        }

        private void DesignListView()
        {
            listView1.Columns.Add("BookID", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("ISBN", 80);
            listView1.Columns.Add("Title", 150);
            listView1.Columns.Add("Subject", 100);
            listView1.Columns.Add("Author", 100);
            listView1.Columns.Add("Publication", 100);
            listView1.Columns.Add("EditionNo", 50);
            listView1.Columns.Add("EditionYear", 50);
            listView1.Columns.Add("Price", 60);
           
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.MultiSelect = false;
            listView1.View = View.Details;

            //listView1.StateImageList = _mediumImageList;


        }

       

        private void FillListView()
        {
            List<BooksMaster> list = new List<BooksMaster>();
            BooksMasterHandler handler = new BooksMasterHandler();
            list = handler.GetBooksMasterList();
            ListViewItem lvi = new ListViewItem();
           
            if (list.Count > 0)
            {
                foreach (BooksMaster obj in list)
                {
                    lvi = new ListViewItem(obj.BookID);
                    lvi.SubItems.Add(obj.ISBN);
                    lvi.SubItems.Add(obj.Title);
                    lvi.SubItems.Add(obj.Subject);
                    lvi.SubItems.Add(obj.Author);
                    lvi.SubItems.Add(obj.Publication);
                    lvi.SubItems.Add(Convert.ToString(obj.EditionNo));
                    lvi.SubItems.Add(Convert.ToString(obj.EditionYear));
                    lvi.SubItems.Add(Convert.ToString(obj.Price));
                    listView1.Items.Add(lvi);
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
                    _bookID = item.SubItems[0].Text;
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
            string bookID = "";
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                bookID = item.SubItems[0].Text;
            }
            if (bookID != "")
            {
                DisplayData(bookID);
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
                DisplayData(txtBookId.Text.Trim());
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

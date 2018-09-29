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
        bool AddMode = false;
        bool EditMode = false;
   
        public frmBooksMaster()
        {
            InitializeComponent();
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            //get new id for book
            AddMode = true;
            EditMode = false;
            txtBookId.Text = GlobalFunction.GetUniqueCode("BooksMaster");
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            bool result=false;
            BooksMaster book = GetBook();


            BooksMasterHandler handler = new BooksMasterHandler();
            if(AddMode)
            {
             result = handler.AddNewBooksMaster(book);
            }
            else if(EditMode)
            {
                result = handler.UpdateBooksMaster(book);
            }
                        

            if (result == true)
            {
                if (AddMode)
                {
                    GlobalFunction.UpdateUniqueCode("BooksMaster");
                }
                MessageBox.Show("New Account created");
            }
            else
            {
                MessageBox.Show("Errror Occurs!");
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

        private void DesignListView()
        {
            listView1.Columns.Add("BookID", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("ISBN", 60);
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

        private void frmBooksMaster_Load(object sender, EventArgs e)
        {
            DesignListView();
            FillListView();
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
            AddMode = true;
            EditMode = false;
            pnlMaster.BringToFront();
            txtBookId.Text = GlobalFunction.GetUniqueCode("BooksMaster");
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            AddMode = false;
            EditMode = true;
        }
    }
}

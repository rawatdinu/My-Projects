using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.BLL;
using System.Data.OleDb;
using System.Data;
using Library.AppCode;

namespace Library.DAL
{
    class BooksMasterDAL
    {

        public bool AddNewBooksMaster(BooksMaster book)
        {
            OleDbParameter[] parameters = new OleDbParameter[]
		{                
			new OleDbParameter("@BookID", book.BookID),
			new OleDbParameter("@ISBN", book.ISBN),
			new OleDbParameter("@Title", book.Title),	
            new OleDbParameter("@Title", book.Subject),
            new OleDbParameter("@Author", book.Author),
            new OleDbParameter("@Publication", book.Publication),
            new OleDbParameter("@EditionNo", book.EditionNo),
            new OleDbParameter("@EditionYear", book.EditionYear),
            new OleDbParameter("@Price", book.Price),
            new OleDbParameter("@CreatedOn", GlobalFunction.GetDateTimeWithoutMiliSecond(DateTime.Now))
	
		};
            string commandText = OleDBHelper.GetQueryText("BooksMaster_Insert", QueryType.Procedures);
            return OleDBHelper.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }

        public bool UpdateBooksMaster(BooksMaster book)
        {
            return true;
        }
        // Same can be used for deactive user
        public bool DeleteBooksMaster(BooksMaster book)
        {
            return true;
        }

        public BooksMaster GetBooksMasterDetails(String bookID)
        {
            BooksMaster books = null;

            return books;
        }

        public List<BooksMaster> GetBooksMasterList()
        {
            List<BooksMaster> list = null;

            string commandText = OleDBHelper.GetQueryText("BooksMaster_SelectAll", QueryType.Views);
            
                        
            using (DataTable table = OleDBHelper.ExecuteSelectCommand(commandText,CommandType.Text))
            {
                //check if any record exist or not
                if (table.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    list = new List<BooksMaster>();

                    //Now lets populate the employee details into the list of employees
                    foreach (DataRow row in table.Rows)
                    {
                        BooksMaster obj = new BooksMaster();

                        obj.BookID = Convert.ToString(row["BookID"]);
                        obj.ISBN = Convert.ToString(row["ISBN"]);
                        obj.Title = Convert.ToString(row["Title"]);
                        obj.Subject = Convert.ToString(row["Subject"]);
                        obj.Author = Convert.ToString(row["Author"]);
                        obj.Publication = Convert.ToString(row["Publication"]);
                        obj.EditionNo = Convert.ToInt32(row["EditionNo"]);
                        obj.EditionYear = Convert.ToInt32(row["EditionYear"]);
                        obj.Price = Convert.ToInt32(row["Price"]);
                        list.Add(obj);
                                               								
                    }
                }
            }

            return list;
        }

    }
}

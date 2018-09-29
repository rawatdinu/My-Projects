using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DAL;

namespace Library.BLL
{
   public class BooksMasterHandler
   {
   
        BooksMasterDAL booksMasterDB = null;

        public BooksMasterHandler()
        {
            booksMasterDB = new BooksMasterDAL();
        }
        public List<BooksMaster> GetBooksMasterList()
        {
            return booksMasterDB.GetBooksMasterList();
        }

        public BooksMaster GetBooksMasterDetails(string bookID)
        {
            return booksMasterDB.GetBooksMasterDetails(bookID);
        }

        public bool AddNewBooksMaster(BooksMaster book)
        {
            return booksMasterDB.AddNewBooksMaster(book);
        }

        public bool UpdateBooksMaster(BooksMaster book)
        {
            return booksMasterDB.UpdateBooksMaster(book);
        }

        public bool DeleteBooksMaster(BooksMaster book)
        {
            return booksMasterDB.DeleteBooksMaster(book);
        }    

   }
}

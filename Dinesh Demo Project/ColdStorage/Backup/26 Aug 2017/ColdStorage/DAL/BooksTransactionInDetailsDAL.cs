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
   public class BooksTransactionInDetailsDAL
    {
       public bool AddNewTransactionInDetails(List<BooksTransactionInDetails> objList)
        {
            string commandText = OleDBHelper.GetQueryText("BooksTransactionInDetails_Insert", QueryType.Procedures);

           int count = objList.Count;
           OleDbParameter[] parameters;
            bool result = false;
            if (count > 0)
            {
               
                foreach (BooksTransactionInDetails obj in objList)
                {
                   parameters = new OleDbParameter[]
                    {
                        new OleDbParameter("@TransactionID", obj.TransactionID),
                        new OleDbParameter("@BookID", obj.BookMaster.BookID),
                        new OleDbParameter("@Unit", obj.Unit)                    
                    };
                    
                    result =  OleDBHelper.ExecuteNonQuery(commandText, CommandType.Text, parameters);
                    if (result == false)
                    {
                        break;
                    }
                }            
            }

            return result;
        }

       public bool UpdateTransactionInDetails(BooksTransactionInDetails book)
        {
            return true;
        }
        // Same can be used for deactive user
       public bool DeleteTransactionInDetails(string transactionID)
        {
            string commandText = OleDBHelper.GetQueryText("BooksTransactionInDetails_Delete", QueryType.Procedures);

            OleDbParameter[] parameters = new OleDbParameter[]
            {
            new OleDbParameter("@TransactionID", transactionID)
            };
            bool result = false;
            result = OleDBHelper.ExecuteNonQuery(commandText, CommandType.Text, parameters);
            return result;
        }

        public BooksMaster GetBooksMasterDetails(String bookID)
        {
            BooksMaster books = null;

            return books;
        }

        public List<BooksTransactionInDetails> GetTransactionInList(string transactionID)
        {
            List<BooksTransactionInDetails> list = null;

            string commandText = OleDBHelper.GetQueryText("BooksTransactionInDetails_SelectID", QueryType.Procedures);

            OleDbParameter[] parameters = new OleDbParameter[]
            {
            new OleDbParameter("@TransactionID", transactionID)
            };

            using (DataTable table = OleDBHelper.ExecuteParamerizedSelectCommand(commandText, CommandType.Text, parameters))
            {
                //check if any record exist or not
                if (table.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    list = new List<BooksTransactionInDetails>();


                    BooksMasterHandler objBookMasterHandler = new BooksMasterHandler();
                    //Now lets populate the employee details into the list of employees
                    foreach (DataRow row in table.Rows)
                    {
                        BooksTransactionInDetails obj = new BooksTransactionInDetails();

                        obj.TransactionID = Convert.ToString(row["TransactionID"]);
                        obj.BookMaster = objBookMasterHandler.GetBooksMasterDetails(Convert.ToString(row["BookID"]));
                        obj.Unit  = Convert.ToInt32(row["Unit"]);
                        //obj.Subject = Convert.ToString(row["Subject"]);
                        //obj.Author = Convert.ToString(row["Author"]);
                        //obj.Publication = Convert.ToString(row["Publication"]);
                        //obj.EditionNo = Convert.ToInt32(row["EditionNo"]);
                        //obj.EditionYear = Convert.ToInt32(row["EditionYear"]);
                        //obj.Price = Convert.ToInt32(row["Price"]);
                        list.Add(obj);

                    }
                }
            }

            return list;
        }
    }
}

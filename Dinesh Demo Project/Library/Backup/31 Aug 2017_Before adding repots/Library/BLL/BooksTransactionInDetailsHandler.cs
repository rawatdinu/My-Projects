using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DAL;

namespace Library.BLL
{
    public class BooksTransactionInDetailsHandler
    {
        BooksTransactionInDetailsDAL transInDetailsDAL = null;

        public BooksTransactionInDetailsHandler()
        {
            transInDetailsDAL = new BooksTransactionInDetailsDAL();
        }
        public List<BooksTransactionInDetails> GetTransactionInList(string transactionID)
        {
            return transInDetailsDAL.GetTransactionInList(transactionID);
        }

        public bool AddNewTransactionInDetails(List<BooksTransactionInDetails> objList)
        {
            return transInDetailsDAL.AddNewTransactionInDetails(objList);
        }

        public bool UpdateTransactionInDetails(BooksTransactionInDetails obj)
        {
            return false;
        }

        public bool DeleteTransactionInDetails(string transactionID)
        {
            return transInDetailsDAL.DeleteTransactionInDetails(transactionID);
        }
    }
}

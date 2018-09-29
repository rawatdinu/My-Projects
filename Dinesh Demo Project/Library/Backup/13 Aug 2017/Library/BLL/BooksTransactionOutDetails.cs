using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DAL;

namespace Library.BLL
{
    public class BooksTransactionOutDetails
    {
        public string TransactionID { get; set; }
        public BooksMaster BookMaster;
        public int Unit { get; set; }


        BooksTransactionOutDetailsDAL transOutDetailsDAL = null;

        public BooksTransactionOutDetails()
        {
            transOutDetailsDAL = new BooksTransactionOutDetailsDAL();
        }
        public List<BooksTransactionOutDetails> GetTransactionInList(string transactionID)
        {
            return transOutDetailsDAL.GetTransactionInList(transactionID);
        }

        public bool AddNewTransactionOutDetails(List<BooksTransactionOutDetails> objList)
        {
            return transOutDetailsDAL.AddNewTransactionOutDetails(objList);
        }

        public bool UpdateTransactionIn(BooksTransactionOutDetails obj)
        {
            return transOutDetailsDAL.UpdateTransactionOutDetails(obj);
        }

        public bool DeleteTransactionIn(BooksTransactionOutDetails obj)
        {
            return transOutDetailsDAL.DeleteTransactionOutDetails(obj);
        }
    }
}

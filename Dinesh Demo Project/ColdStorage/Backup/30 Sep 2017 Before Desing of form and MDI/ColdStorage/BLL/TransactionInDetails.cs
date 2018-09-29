using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using Library.DAL;

namespace ColdStorage.BLL
{
   public class TransactionInDetails
    {
       public string TransactionID { get; set; }
       public ItemMaster ItemMaster;
        public int Unit { get; set; }


        TransactionInDetailsDAL transInDetailsDAL = null;

        public TransactionInDetails()
        {
            transInDetailsDAL = new TransactionInDetailsDAL();
        }
        public List<TransactionInDetails> GetTransactionInList(string transactionID)
        {
            return transInDetailsDAL.GetTransactionInList(transactionID);
        }

        public bool AddNewTransactionInDetails(List<TransactionInDetails> objList)
        {
            return transInDetailsDAL.AddNewTransactionInDetails(objList);
        }

        public bool UpdateTransactionInDetails(TransactionInDetails obj)
        {
            return false;
        }
        public bool DeleteTransactionInDetails(string transactionID)
        {
            return transInDetailsDAL.DeleteTransactionInDetails(transactionID);
        }

        public DataTable GetReportTransactionIn(string transactionID)
        {
            return transInDetailsDAL.GetReportTransactionIn(transactionID);
        }
    }
}

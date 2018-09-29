using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ColdStorage.DAL;

namespace ColdStorage.BLL
{
    public class TransactionOutDetails
    {
        public string TransactionID { get; set; }
        public ItemMaster ItemMaster;
        public int Unit { get; set; }


        TransactionOutDetailsDAL transOutDetailsDAL = null;

        public TransactionOutDetails()
        {
            transOutDetailsDAL = new TransactionOutDetailsDAL();
        }
        public List<TransactionOutDetails> GetTransactionInList(string transactionID)
        {
            return transOutDetailsDAL.GetTransactionInList(transactionID);
        }

        public bool AddNewTransactionOutDetails(List<TransactionOutDetails> objList)
        {
            return transOutDetailsDAL.AddNewTransactionOutDetails(objList);
        }

        public bool UpdateTransactionIn(TransactionOutDetails obj)
        {
            return transOutDetailsDAL.UpdateTransactionOutDetails(obj);
        }

        public bool DeleteTransactionOutMaster(string transactionID)
        {
            return transOutDetailsDAL.DeleteTransactionOutDetails(transactionID);
        }
    }
}

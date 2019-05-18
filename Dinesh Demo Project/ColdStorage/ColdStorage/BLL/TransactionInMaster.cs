using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ColdStorage.DAL;

namespace ColdStorage.BLL
{
    public class TransactionInMaster

    {
        public string TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string PartyID { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }


        #region handler

        TransactionInMasterDAL tranInMasterDAL = null;

        public TransactionInMaster()
        {
            tranInMasterDAL = new TransactionInMasterDAL();
        }

        public TransactionInMaster GetTransactionInMaster(string transactionID)
        {
            return tranInMasterDAL.GetTransactionInMaster(transactionID);
        }
        public List<TransactionInMaster> GetTransactionInMasterList()
        {
            return tranInMasterDAL.GetTransactionInMasterList();
        }

         public bool AddNewTransactionInMaster(TransactionInMaster obj)
        {
            return tranInMasterDAL.AddNewTransactionInMaster(obj);
        }

        public bool UpdateTransactionIn(TransactionInMaster obj)
        {
            return tranInMasterDAL.UpdateTransactionInMaster(obj);
        }

        public bool DeleteTransactionIn(TransactionInMaster obj)
        {
            return tranInMasterDAL.DeleteTransactionInMaster(obj);
        }
        #endregion
    }
}

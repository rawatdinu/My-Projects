using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ColdStorage.DAL;

namespace ColdStorage.BLL
{
    public class TransactionOutMaster
    {
        public string TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }



        TransactionOutMasterDAL tranOutMasterDAL = null;

        public TransactionOutMaster()
        {
            tranOutMasterDAL = new TransactionOutMasterDAL();
        }

        public TransactionOutMaster GetTransactionOutMaster(string transactionID)
        {
            return tranOutMasterDAL.GetTransactionOutMaster(transactionID);
        }
        public List<TransactionOutMaster> GetTransactionOutMasterList()
        {
            return tranOutMasterDAL.GetTransactionOutMasterList();
        }

        public bool AddNewTransactionOutMaster(TransactionOutMaster obj)
        {
            return tranOutMasterDAL.AddNewTransactionOutMaster(obj);
        }

        public bool UpdateTransactionOutMaster(TransactionOutMaster obj)
        {
            return tranOutMasterDAL.UpdateTransactionOutMaster(obj);
        }

        public bool DeleteTransactionOut(TransactionOutMaster obj)
        {
            return tranOutMasterDAL.DeleteTransactionOutMaster(obj);
        }
    }
}

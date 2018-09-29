using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DAL;

namespace Library.BLL
{
    public class BooksTransactionOutMaster
    {
        public string TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Remarks { get; set; }



        BooksTransactionOutMasterDAL tranOutMasterDAL = null;

        public BooksTransactionOutMaster()
        {
            tranOutMasterDAL = new BooksTransactionOutMasterDAL();
        }

        public BooksTransactionOutMaster GetTransactionOutMaster(string transactionID)
        {
            return tranOutMasterDAL.GetTransactionOutMaster(transactionID);
        }
        public List<BooksTransactionOutMaster> GetTransactionOutMasterList()
        {
            return tranOutMasterDAL.GetTransactionOutMasterList();
        }

        public bool AddNewTransactionOutMaster(BooksTransactionOutMaster obj)
        {
            return tranOutMasterDAL.AddNewTransactionOutMaster(obj);
        }

        public bool UpdateTransactionOutMaster(BooksTransactionOutMaster obj)
        {
            return tranOutMasterDAL.UpdateTransactionOutMaster(obj);
        }

        public bool DeleteTransactionOut(BooksTransactionOutMaster obj)
        {
            return tranOutMasterDAL.DeleteTransactionOutMaster(obj);
        }
    }
}

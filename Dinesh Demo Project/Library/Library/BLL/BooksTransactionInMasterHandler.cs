using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DAL;

namespace Library.BLL
{
    public class BooksTransactionInMasterHandler
    {
         BooksTransactionInMasterDAL tranInMasterDAL = null;

        public BooksTransactionInMasterHandler()
        {
            tranInMasterDAL = new BooksTransactionInMasterDAL();
        }

        public BooksTransactionInMaster GetTransactionInMaster(string transactionID)
        {
            return tranInMasterDAL.GetTransactionInMaster(transactionID);
        }
        public List<BooksTransactionInMaster> GetTransactionInMasterList()
        {
            return tranInMasterDAL.GetTransactionInMasterList();
        }

         public bool AddNewTransactionInMaster(BooksTransactionInMaster obj)
        {
            return tranInMasterDAL.AddNewTransactionInMaster(obj);
        }

        public bool UpdateTransactionIn(BooksTransactionInMaster obj)
        {
            return tranInMasterDAL.UpdateTransactionInMaster(obj);
        }

        public bool DeleteTransactionIn(BooksTransactionInMaster obj)
        {
            return tranInMasterDAL.DeleteTransactionInMaster(obj);
        }
    }
}

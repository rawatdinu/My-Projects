using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BLL
{
   public class BooksTransactionInDetails
    {
       public string TransactionID { get; set; }
        public BooksMaster BookMaster;
        public int Unit { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DAL;

namespace Library.BLL
{
   public class AccountHandler
    {

       AccountDAL accountDB = null;

        
        public AccountHandler()
        {
            accountDB = new AccountDAL();
        }

        public List<Account> GetAccountList()
        {
            return accountDB.GetAccountList();
        }

        public bool AddNewAccount(Account account)
        {
            return accountDB.AddNewAccount(account);
        }

        public bool UpdateAccount(Account account)
        {
            return accountDB.UpdateAccount(account);
        }

        public bool DeleteAccount(Account account)
        {
            return accountDB.DeleteAccount(account);
        }
       
    }

}

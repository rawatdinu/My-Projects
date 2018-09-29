using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.BLL;
using System.Data.OleDb;
using System.Data;
using Library.AppCode;

namespace Library.DAL
{
    public class AccountDAL
    {

        public bool AddNewAccount(Account account)
        {
            OleDbParameter[] parameters = new OleDbParameter[]
		{                
			new OleDbParameter("@ID", account.ID),
			new OleDbParameter("@AccountHolderName", account.AccountHolderName),
			new OleDbParameter("@DOB", account.DateOfBirth),	
            new OleDbParameter("@IsActive", 1),
            new OleDbParameter("@CreatedOn", GlobalFunction.GetDateTimeWithoutMiliSecond(DateTime.Now))
			

		};
            string commandText = DBQuery.GetQueryText("AccountMaster1_Insert");
            return OleDBHelper.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }

        public bool UpdateAccount(Account account)
        {
            return true;
        }
        // Same can be used for deactive user
        public bool DeleteAccount(Account account)
        {
            return true;
        }

        public Account GetAccountDetails(String accountID)
        {
            Account account = null;

            return account;
        }

        public List<Account> GetAccountList()
        {
            List<Account> listAccount = null;
            //Lets get the list of all employees in a datataable
            return listAccount;
        }

    }
}

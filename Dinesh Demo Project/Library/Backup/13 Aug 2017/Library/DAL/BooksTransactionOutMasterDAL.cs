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
   public class BooksTransactionOutMasterDAL
    {
        public bool AddNewTransactionOutMaster(BooksTransactionOutMaster obj)
        {
            OleDbParameter[] parameters = new OleDbParameter[]
            {
            new OleDbParameter("@TransactionID", obj.TransactionID),
            new OleDbParameter("@TransactionDate", obj.TransactionDate),
            new OleDbParameter("@Remarks", obj.Remarks),
            new OleDbParameter("@CreatedOn", GlobalFunction.GetDateTimeWithoutMiliSecond(DateTime.Now))
            };

            string commandText = OleDBHelper.GetQueryText("BooksTransactionOutMaster_Insert", QueryType.Procedures);
            return OleDBHelper.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }

        public bool UpdateTransactionOutMaster(BooksTransactionOutMaster book)
        {
            return true;
        }
        // Same can be used for deactive user
        public bool DeleteTransactionOutMaster(BooksTransactionOutMaster book)
        {
            return true;
        }

        public BooksTransactionOutMaster GetTransactionOutMaster(string transactionID)
        {
            BooksTransactionOutMaster obj = null;

            string commandText = OleDBHelper.GetQueryText("BooksTransactionOutMaster_SelectID", QueryType.Procedures);

            OleDbParameter[] parameters = new OleDbParameter[]
            {
            new OleDbParameter("@TransactionID", transactionID)
            };

            using (DataTable table = OleDBHelper.ExecuteParamerizedSelectCommand(commandText, CommandType.Text, parameters))
            {
                //check if any record exist or not
                if (table.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    obj = new BooksTransactionOutMaster();

                    obj.TransactionID = Convert.ToString(table.Rows[0]["TransactionID"]);
                    obj.TransactionDate = Convert.ToDateTime(table.Rows[0]["TransactionDate"]);
                    obj.Remarks = Convert.ToString(table.Rows[0]["Remarks"]);
                }
            }

            return obj;
        }

        public List<BooksTransactionOutMaster> GetTransactionOutMasterList()
        {
            List<BooksTransactionOutMaster> list = null;

            string commandText = OleDBHelper.GetQueryText("BooksTransactionOutMaster_SelectAll", QueryType.Views);


            using (DataTable table = OleDBHelper.ExecuteSelectCommand(commandText, CommandType.Text))
            {
                //check if any record exist or not
                if (table.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    list = new List<BooksTransactionOutMaster>();

                    //Now lets populate the employee details into the list of employees
                    foreach (DataRow row in table.Rows)
                    {
                        BooksTransactionOutMaster obj = new BooksTransactionOutMaster();
                        obj.TransactionID = Convert.ToString(row["TransactionID"]);
                        obj.TransactionDate = Convert.ToDateTime(row["TransactionDate"]);
                        obj.Remarks = Convert.ToString(row["Remarks"]);

                        list.Add(obj);

                    }
                }
            }

            return list;
        }
    }
}

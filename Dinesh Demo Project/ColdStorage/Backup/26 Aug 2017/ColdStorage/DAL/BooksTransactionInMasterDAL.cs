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
    public class BooksTransactionInMasterDAL
    {

        public bool AddNewTransactionInMaster(BooksTransactionInMaster obj)
        {
            OleDbParameter[] parameters = new OleDbParameter[]
            {
            new OleDbParameter("@TransactionID", obj.TransactionID),
            new OleDbParameter("@TransactionDate", obj.TransactionDate),
            new OleDbParameter("@Remarks", obj.Remarks),
            new OleDbParameter("@CreatedOn", GlobalFunction.GetDateTimeWithoutMiliSecond(DateTime.Now))
            };

            string commandText = OleDBHelper.GetQueryText("BooksTransactionInMaster_Insert", QueryType.Procedures);
            return OleDBHelper.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }

        public bool UpdateTransactionInMaster(BooksTransactionInMaster obj)
        {
            OleDbParameter[] parameters = new OleDbParameter[]
            {
            
            new OleDbParameter("@TransactionDate", obj.TransactionDate),
            new OleDbParameter("@Remarks", obj.Remarks),
            new OleDbParameter("@UpdatedOn", GlobalFunction.GetDateTimeWithoutMiliSecond(DateTime.Now)),
            new OleDbParameter("@TransactionID", obj.TransactionID)
            };

            string commandText = OleDBHelper.GetQueryText("BooksTransactionInMaster_Update", QueryType.Procedures);
            return OleDBHelper.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }
        // Same can be used for deactive user
        public bool DeleteTransactionInMaster(BooksTransactionInMaster book)
        {
            return true;
        }

        public BooksTransactionInMaster GetTransactionInMaster(string transactionID)
        {
            BooksTransactionInMaster obj = null;

            string commandText = OleDBHelper.GetQueryText("BooksTransactionInMaster_SelectID", QueryType.Procedures);

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
                    obj = new BooksTransactionInMaster();

                    obj.TransactionID = Convert.ToString(table.Rows[0]["TransactionID"]);
                    obj.TransactionDate = Convert.ToDateTime(table.Rows[0]["TransactionDate"]);
                    obj.Remarks = Convert.ToString(table.Rows[0]["Remarks"]);
                }
            }

            return obj;
        }

        public List<BooksTransactionInMaster> GetTransactionInMasterList()
        {
            List<BooksTransactionInMaster> list = null;

            string commandText = OleDBHelper.GetQueryText("BooksTransactionInMaster_SelectAll", QueryType.Views);


            using (DataTable table = OleDBHelper.ExecuteSelectCommand(commandText, CommandType.Text))
            {
                //check if any record exist or not
                if (table.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    list = new List<BooksTransactionInMaster>();

                    //Now lets populate the employee details into the list of employees
                    foreach (DataRow row in table.Rows)
                    {
                        BooksTransactionInMaster obj = new BooksTransactionInMaster();
                        obj.TransactionID = Convert.ToString(row["TransactionID"]);
                        obj.TransactionDate = Convert.ToDateTime( row["TransactionDate"]);
                        obj.Remarks = Convert.ToString(row["Remarks"]);
                        
                        list.Add(obj);

                    }
                }
            }

            return list;
        }
    }
}
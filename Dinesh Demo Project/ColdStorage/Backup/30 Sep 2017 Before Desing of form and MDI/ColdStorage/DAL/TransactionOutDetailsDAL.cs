using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using ColdStorage.AppCode;
using ColdStorage.BLL;

namespace ColdStorage.DAL
{
  public class TransactionOutDetailsDAL

    {
        public bool AddNewTransactionOutDetails(List<TransactionOutDetails> objList)
        {
            string commandText = OleDBHelper.GetQueryText("TransactionOutDetails_Insert", QueryType.Procedures);

            int count = objList.Count;
            OleDbParameter[] parameters;
            bool result = false;
            if (count > 0)
            {

                foreach (TransactionOutDetails obj in objList)
                {
                    parameters = new OleDbParameter[]
                    {
                        new OleDbParameter("@TransactionID", obj.TransactionID),
                        new OleDbParameter("@BookID", obj.ItemMaster.ItemID),
                        new OleDbParameter("@Unit", obj.Unit)                    
                    };

                    result = OleDBHelper.ExecuteNonQuery(commandText, CommandType.Text, parameters);
                    if (result == false)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        public bool UpdateTransactionOutDetails(TransactionOutDetails book)
        {
            return true;
        }
        // Same can be used for deactive user
        public bool DeleteTransactionOutDetails(string transactionID)
        {
            string commandText = OleDBHelper.GetQueryText("TransactionOutDetails_Delete", QueryType.Procedures);

            OleDbParameter[] parameters = new OleDbParameter[]
            {
            new OleDbParameter("@TransactionID", transactionID)
            };
            bool result = false;
            result = OleDBHelper.ExecuteNonQuery(commandText, CommandType.Text, parameters);
            return result;
        }

        public ItemMaster  GetBooksMasterDetails(String itemID)
        {
            ItemMaster item = null;

            return item;
        }

        public List<TransactionOutDetails> GetTransactionInList(string transactionID)
        {
            List<TransactionOutDetails> list = null;

            string commandText = OleDBHelper.GetQueryText("TransactionOutDetails_SelectID", QueryType.Procedures);

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
                    list = new List<TransactionOutDetails>();


                    ItemMaster objBookMasterHandler = new ItemMaster();
                    //Now lets populate the employee details into the list of employees
                    foreach (DataRow row in table.Rows)
                    {
                        TransactionOutDetails obj = new TransactionOutDetails();

                        obj.TransactionID = Convert.ToString(row["TransactionID"]);
                        obj.ItemMaster = objBookMasterHandler.GetItemMasterDetails(Convert.ToString(row["ItemID"]));
                        obj.Unit = Convert.ToInt32(row["Unit"]);
                        //obj.Subject = Convert.ToString(row["Subject"]);
                        //obj.Author = Convert.ToString(row["Author"]);
                        //obj.Publication = Convert.ToString(row["Publication"]);
                        //obj.EditionNo = Convert.ToInt32(row["EditionNo"]);
                        //obj.EditionYear = Convert.ToInt32(row["EditionYear"]);
                        //obj.Price = Convert.ToInt32(row["Price"]);
                        list.Add(obj);

                    }
                }
            }

            return list;
        }

        //DataTable
        public DataTable GetReportTransactionOut(string transactionID)
        {
            DataTable dt = null;

            string commandText = OleDBHelper.GetQueryText("rptTransactionOut", QueryType.Procedures);

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
                    dt = new DataTable();

                    dt = table;

                }
            }
            return dt;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ColdStorage.BLL;
using System.Data.OleDb;
using System.Data;
using ColdStorage;
using ColdStorage.AppCode;
using ColdStorage.BLL;

namespace Library.DAL
{
   public class InventoryDAL
    {
       public bool AddNewInventory(List<Inventory> objList)
        {
            string commandText = OleDBHelper.GetQueryText("Inventory_Insert", QueryType.Procedures);

            int count = objList.Count;
            OleDbParameter[] parameters;
            bool result = false;
            if (count > 0)
            {

                foreach (Inventory obj in objList)
                {
                    parameters = new OleDbParameter[]
                    {
                        //new OleDbParameter("@ItemID", obj.ItemID),
                        new OleDbParameter("@UnitID", obj.UnitID),
                        //new OleDbParameter("@LastTranID", obj.LastTranID),                   
                        new OleDbParameter("@QtyIn", obj.QtyIn),
                        new OleDbParameter("@QtyOut", obj.QtyOut),
                        new OleDbParameter("@PrevBalance", obj.PrevBalance),                        
                        new OleDbParameter("@CurrBalance", obj.CurrBalance),
                        new OleDbParameter("@CreatedOn", GlobalFunction.GetDateTimeWithoutMiliSecond(DateTime.Now))            
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

       public bool UpdateInventory(Inventory obj)
        {
            string commandText = OleDBHelper.GetQueryText("Inventory_Update", QueryType.Procedures);

            OleDbParameter[] parameters = new OleDbParameter[]
            {
                //new OleDbParameter("@LastTranID", obj.LastTranID),                   
                new OleDbParameter("@QtyIn", obj.QtyIn),
                new OleDbParameter("@QtyOut", obj.QtyOut),
                new OleDbParameter("@PrevBalance", obj.PrevBalance),                        
                new OleDbParameter("@CurrBalance", obj.CurrBalance),
                //new OleDbParameter("@UpdatedOn", GlobalFunction.GetDateTimeWithoutMiliSecond(DateTime.Now)),
                //new OleDbParameter("@ItemID", obj.ItemID)
                //new OleDbParameter("@UnitID", obj.UnitID)
            };

           
            return OleDBHelper.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }
        // Same can be used for deactive user
       public bool DeleteInventory(Inventory obj)
        {
            string commandText = OleDBHelper.GetQueryText("BooksTransactionOutDetails_Delete", QueryType.Procedures);

            OleDbParameter[] parameters = new OleDbParameter[]
            {
            //new OleDbParameter("@TransactionID", transactionID)
            };
            bool result = false;
            result = OleDBHelper.ExecuteNonQuery(commandText, CommandType.Text, parameters);
            return result;
        }

       public Inventory GetInventoryDetails(Inventory obj)
        {
            Inventory objDetails = null;

            string commandText = OleDBHelper.GetQueryText("Inventory_SelectID", QueryType.Procedures);

            OleDbParameter[] parameters = new OleDbParameter[]
            {
              //new OleDbParameter("@ItemID", obj.ItemID)
              //new OleDbParameter("@UnitID", obj.UnitID)
            };

            using (DataTable table = OleDBHelper.ExecuteParamerizedSelectCommand(commandText, CommandType.Text, parameters))
            {
                //check if any record exist or not
                if (table.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    objDetails = new Inventory();

                    //objDetails.ItemID = Convert.ToString(table.Rows[0]["ItemID"]);
                    objDetails.UnitID = Convert.ToString(table.Rows[0]["UnitID"]);
                    //objDetails.LastTranID = Convert.ToString(table.Rows[0]["LastTranID"]);                    
                    objDetails.QtyIn = Convert.IsDBNull(table.Rows[0]["QtyIn"])? 0 : Convert.ToInt32(table.Rows[0]["QtyIn"]);
                    objDetails.QtyOut = Convert.IsDBNull(table.Rows[0]["QtyOut"]) ? 0 : Convert.ToInt32(table.Rows[0]["QtyOut"]);
                    objDetails.PrevBalance = Convert.IsDBNull(table.Rows[0]["PrevBalance"]) ? 0 : Convert.ToInt32(table.Rows[0]["PrevBalance"]);
                    objDetails.CurrBalance = Convert.IsDBNull(table.Rows[0]["CurrBalance"]) ? 0 : Convert.ToInt32(table.Rows[0]["CurrBalance"]);
                }
            }

            return objDetails;
        }

       public List<Inventory> GetInventoryList()
        {
            List<Inventory> list = null;

            string commandText = OleDBHelper.GetQueryText("Inventory_SelectAll", QueryType.Views);

            OleDbParameter[] parameters = new OleDbParameter[]
            {
             //new OleDbParameter("@TransactionID", transactionID)
            };

            using (DataTable table = OleDBHelper.ExecuteSelectCommand(commandText, CommandType.Text))
            {
                //check if any record exist or not
                if (table.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    list = new List<Inventory>();


                    Inventory obj;
                    ItemMaster objItemMaster;
                    //Now lets populate the employee details into the list of employees
                    foreach (DataRow row in table.Rows)
                    {
                        obj = new Inventory();
                        objItemMaster = new ItemMaster();


                        objItemMaster.ItemID = Convert.ToString(row["ItemID"]);
                        objItemMaster.ItemName = Convert.ToString(row["ItemName"]);                        
                        //obj.LastTranID = Convert.ToString(row["LastTranID"]);
                        obj.ItemMaster = objItemMaster;
                        obj.QtyIn = Convert.IsDBNull(row["QtyIn"]) ? 0 : Convert.ToInt32(row["QtyIn"]);
                        obj.QtyOut = Convert.IsDBNull(row["QtyOut"]) ? 0 : Convert.ToInt32(row["QtyOut"]);
                        //obj.CurrBalance = Convert.IsDBNull(row["QtyBalance"]) ? 0 : Convert.ToInt32(row["QtyBalance"]);

                        list.Add(obj);
                    }
                }
            }

            return list;
        }
    }
}
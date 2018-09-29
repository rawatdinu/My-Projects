using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ColdStorage.BLL;
using System.Data.OleDb;
using System.Data;
using ColdStorage.AppCode;


namespace ColdStorage.DAL
{
  public class ItemMasterDAL
    {
        public bool AddNewItemMaster(ItemMaster obj)
        {
            OleDbParameter[] parameters = new OleDbParameter[]
		{                
			new OleDbParameter("@ItemID", obj.ItemID),
			new OleDbParameter("@ItemName", obj.ItemName),
			new OleDbParameter("@Remarks", obj.Remarks),	            
            new OleDbParameter("@CreatedOn", GlobalFunction.GetDateTimeWithoutMiliSecond(DateTime.Now))
	
		};
            string commandText = OleDBHelper.GetQueryText("ItemMaster_Insert", QueryType.Procedures);
            return OleDBHelper.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }

        public bool UpdateItemMaster(ItemMaster obj)
        {
            OleDbParameter[] parameters = new OleDbParameter[]
            {
             
			new OleDbParameter("@ItemName", obj.ItemName),
			new OleDbParameter("@Remarks", obj.Remarks),            
            new OleDbParameter("@UpdatedOn", GlobalFunction.GetDateTimeWithoutMiliSecond(DateTime.Now)),
            new OleDbParameter("@ItemID", obj.ItemID)
            };

            string commandText = OleDBHelper.GetQueryText("ItemMaster_Update", QueryType.Procedures);
            return OleDBHelper.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }
        // Same can be used for deactive user
        public bool DeleteItemMaster(ItemMaster obj)
        {
            return true;
        }

        public ItemMaster GetItemMasterDetails(String itemID)
        {
            ItemMaster obj = null;

            string commandText = OleDBHelper.GetQueryText("ItemMaster_SelectID", QueryType.Procedures);

            OleDbParameter[] parameters = new OleDbParameter[]
            {
            new OleDbParameter("@ItemID", itemID)
            };

            using (DataTable table = OleDBHelper.ExecuteParamerizedSelectCommand(commandText, CommandType.Text, parameters))
            {
                //check if any record exist or not
                if (table.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    obj = new ItemMaster();

                    obj.ItemID = Convert.ToString(table.Rows[0]["ItemID"]);
                    obj.ItemName = Convert.ToString(table.Rows[0]["ItemName"]);
                    obj.Remarks = Convert.ToString(table.Rows[0]["Remarks"]);  
                }
            }

            return obj;
        }

        public List<ItemMaster> GetItemMasterList()
        {
            List<ItemMaster> list = null;

            string commandText = OleDBHelper.GetQueryText("ItemMaster_SelectAll", QueryType.Views);


            using (DataTable table = OleDBHelper.ExecuteSelectCommand(commandText, CommandType.Text))
            {
                //check if any record exist or not
                if (table.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    list = new List<ItemMaster>();

                    //Now lets populate the employee details into the list of employees
                    foreach (DataRow row in table.Rows)
                    {
                        ItemMaster obj = new ItemMaster();

                        obj.ItemID = Convert.ToString(row["ItemID"]);
                        obj.ItemName = Convert.ToString(row["ItemName"]);
                        obj.Remarks = Convert.ToString(row["Remarks"]);
                        
                        list.Add(obj);

                    }
                }
            }

            return list;
        }

    }
}

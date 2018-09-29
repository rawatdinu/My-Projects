using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ColdStorage.DAL;

namespace ColdStorage.BLL
{
   public class ItemMaster
    {

        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public string Remarks { get; set; }


        ItemMasterDAL objDB = null;

        public ItemMaster()
        {
            objDB = new ItemMasterDAL();
        }
        public List<ItemMaster> GetItemMasterList()
        {
            return objDB.GetItemMasterList();
        }

        public ItemMaster GetItemMasterDetails(string itemID)
        {
            return objDB.GetItemMasterDetails(itemID);
        }

        public bool AddNewItemMaster(ItemMaster obj)
        {
            return objDB.AddNewItemMaster(obj);
        }

        public bool UpdateItemMaster(ItemMaster obj)
        {
            return objDB.UpdateItemMaster(obj);
        }

        public bool DeleteItemMaster(ItemMaster obj)
        {
            return objDB.DeleteItemMaster(obj);
        }  

    }
}

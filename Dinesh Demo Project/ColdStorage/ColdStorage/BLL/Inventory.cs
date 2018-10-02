using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DAL;


namespace ColdStorage.BLL
{
    public class Inventory
    {
        public ItemMaster ItemMaster { get; set; }

        public string Quantity { get; set; }
        
        public string UnitID { get; set; }

        public int QtyIn { get; set; }
        public int QtyOut { get; set; }
        public int PrevBalance { get; set; }
        public int CurrBalance { get; set; }


        InventoryDAL inventoryDAL = null;

        public Inventory()
        {
            inventoryDAL = new InventoryDAL();
        }
        
        public List<Inventory> GetInventoryList()
        {
            return inventoryDAL.GetInventoryList();
        }

        private Inventory GetInventoryDetails(Inventory obj)
        {
            return inventoryDAL.GetInventoryDetails(obj);
        }

        private bool AddNewInventory(List<Inventory> objList)
        {
            return inventoryDAL.AddNewInventory(objList);
        }

        private bool UpdateInventory(Inventory obj)
        {
            return inventoryDAL.UpdateInventory(obj);
        }

        private bool DeleteInventory(string transactionID)
        {
            return false;
           // return inventoryDAL.DeleteInventory(transactionID);
        }

   


    }
}

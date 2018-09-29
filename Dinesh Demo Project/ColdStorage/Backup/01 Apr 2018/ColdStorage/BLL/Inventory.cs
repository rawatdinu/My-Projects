using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DAL;

namespace Library.BLL
{
    public class Inventory
    {
        public string ItemID { get; set; }
        public string UnitID = "";
        public string LastTranID { get; set; }
        public int QtyIn { get; set; }
        public int QtyOut { get; set; }
        public int PrevBalance { get; set; }
        public int CurrBalance { get; set; }


        InventoryDAL inventoryDAL = null;

        public Inventory()
        {
            inventoryDAL = new InventoryDAL();
        }
        
        private List<Inventory> GetInventoryList()
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

        #region Transaction In Inventory
        public bool AddInventory(List<BooksTransactionInDetails> objList)
        {
            bool result = false;
            Inventory currInvt;
            Inventory newInvt;

            List<Inventory> addList;


            string itemID;
            foreach (BooksTransactionInDetails obj in objList)
            {
                

                itemID = obj.BookMaster.BookID;
                if (IsItemExist(itemID, out currInvt))
                {
                    //upate inventory
                    
                    newInvt = new Inventory();
                    newInvt.ItemID = itemID;
                    newInvt.LastTranID = obj.TransactionID;
                    newInvt.QtyIn = obj.Unit;
                    newInvt.QtyOut = 0;
                    newInvt.PrevBalance = currInvt.CurrBalance;
                    newInvt.CurrBalance = newInvt.PrevBalance + newInvt.QtyIn;

                    result = newInvt.UpdateInventory(newInvt);
                }
                else
                {
                    //insert inventory
                    addList = new List<Inventory>();

                    newInvt = new Inventory();
                    newInvt.ItemID = itemID;
                    newInvt.LastTranID = obj.TransactionID;
                    newInvt.QtyIn = obj.Unit;
                    newInvt.QtyOut = 0;
                    newInvt.PrevBalance = 0;
                    newInvt.CurrBalance = newInvt.PrevBalance + newInvt.QtyIn;

                    addList.Add(newInvt);

                    result = newInvt.AddNewInventory(addList);
                }

                if (!result)
                {
                    break;
                }

            }

            return result;
        }

        public bool UpdateInventory(string transactionID, List<BooksTransactionInDetails> objList)
        {
            bool result = false;

            result = RemoveTranInInventory(transactionID);

            if (result)
            {
                result = AddInventory(objList);
            }            
            return result;
        }

        private bool RemoveTranInInventory(string transInID)
        {

            bool result = false;

            Inventory currInvt;
            Inventory newInvt;
            List<BooksTransactionInDetails> objList = new List<BooksTransactionInDetails>();
            BooksTransactionInDetailsHandler objHandler = new BooksTransactionInDetailsHandler();

            objList = objHandler.GetTransactionInList(transInID);


            string itemID;
            foreach (BooksTransactionInDetails obj in objList)
            {
                currInvt = new Inventory();
                itemID = obj.BookMaster.BookID;

                if (IsItemExist(itemID, out currInvt))
                {                      
                    //upate inventory

                    newInvt = new Inventory();
                    newInvt.ItemID = itemID;
                    newInvt.LastTranID = obj.TransactionID;

                    //Subtract In item from Inventory
                    newInvt.QtyIn = 0;

                    newInvt.QtyOut = obj.Unit;
                    newInvt.PrevBalance = currInvt.CurrBalance;
                    newInvt.CurrBalance = newInvt.PrevBalance - newInvt.QtyOut;

                    result = newInvt.UpdateInventory(newInvt);
                }
                else
                {
                    //Item does not exist in intentory
                    result = true;
                }
                
                if (!result)
                {
                    break;
                }

            }

            return result;
        
        }

        #endregion



        private bool IsItemExist(string itemID, out Inventory objDetail)
        {
            bool result = false;
            Inventory obj = new Inventory();
           
            obj.ItemID =itemID;
            //obj.UnitID =unitID;            
            objDetail = obj.GetInventoryDetails(obj);
            if (objDetail != null)
            {
                result = true;
            }
            return result;        
        }

     


        #region Transaction Out Inventory
        public bool AddInventory(List<BooksTransactionOutDetails> objList)
        {
            bool result = false;
            Inventory currInvt;
            Inventory newInvt;

            
           

            string itemID;
            foreach (BooksTransactionOutDetails obj in objList)
            {

                itemID = obj.BookMaster.BookID;
                if (IsItemExist(itemID, out currInvt))
                {
                    //upate inventory

                    newInvt = new Inventory();
                    newInvt.ItemID = itemID;
                    newInvt.LastTranID = obj.TransactionID;
                    newInvt.QtyIn = 0;
                    newInvt.QtyOut = obj.Unit;
                    newInvt.PrevBalance = currInvt.CurrBalance;
                    newInvt.CurrBalance = newInvt.PrevBalance - newInvt.QtyOut;

                    result = newInvt.UpdateInventory(newInvt);
                }
                
                if (!result)
                {
                    break;
                }

            }

            return result;
        }

        public bool UpdateInventory(string transactionID, List<BooksTransactionOutDetails> objList)
        {
            bool result = false;

            result = RemoveTranOutIventory(transactionID);

            if (result)
            {
                result = AddInventory(objList);
            }
            return result;
        }

        private bool RemoveTranOutIventory(string transOutID)
        {

            bool result = false;

            Inventory currInvt;
            Inventory newInvt;
            List<BooksTransactionOutDetails> objList = new List<BooksTransactionOutDetails>();
            BooksTransactionOutDetails objHandler = new BooksTransactionOutDetails();

            objList = objHandler.GetTransactionInList(transOutID);


            string itemID;
            foreach (BooksTransactionOutDetails obj in objList)
            {
                currInvt = new Inventory();
                itemID = obj.BookMaster.BookID;

                if (IsItemExist(itemID, out currInvt))
                {
                    //upate inventory

                    newInvt = new Inventory();
                    newInvt.ItemID = itemID;
                    newInvt.LastTranID = obj.TransactionID;

                    //Subtract In item from Inventory
                    newInvt.QtyIn = obj.Unit;

                    newInvt.QtyOut = 0;
                    newInvt.PrevBalance = currInvt.CurrBalance;
                    newInvt.CurrBalance = newInvt.PrevBalance + newInvt.QtyIn;

                    result = newInvt.UpdateInventory(newInvt);
                }
                
                if (!result)
                {
                    break;
                }

            }

            return result;

        }

        #endregion


    










    }
}

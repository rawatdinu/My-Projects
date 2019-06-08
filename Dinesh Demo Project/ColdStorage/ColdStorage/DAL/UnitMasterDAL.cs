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
    class UnitMasterDAL
    {

        public UnitMaster GetUnitMasterDetails(String ID)
        {
            UnitMaster obj = null;

            string commandText = OleDBHelper.GetQueryText("UnitMaster_SelectID", QueryType.Procedures);

            OleDbParameter[] parameters = new OleDbParameter[]
            {
            new OleDbParameter("@ID", ID)
            };

            using (DataTable table = OleDBHelper.ExecuteParamerizedSelectCommand(commandText, CommandType.Text, parameters))
            {
                //check if any record exist or not
                if (table.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    obj = new UnitMaster();

                    obj.ID = Convert.ToString(table.Rows[0]["ID"]);
                    obj.UnitName = Convert.ToString(table.Rows[0]["UnitName"]);
                    
                }
            }

            return obj;
        }

        public List<UnitMaster> GetUnitMasterList()
        {
            List<UnitMaster> list = null;

            string commandText = OleDBHelper.GetQueryText("UnitMaster_SelectAll", QueryType.Views);


            using (DataTable table = OleDBHelper.ExecuteSelectCommand(commandText, CommandType.Text))
            {
                //check if any record exist or not
                if (table.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    list = new List<UnitMaster>();

                    //Now lets populate the employee details into the list of employees
                    foreach (DataRow row in table.Rows)
                    {
                        UnitMaster obj = new UnitMaster();

                        obj.ID = Convert.ToString(row["ID"]);
                        obj.UnitName = Convert.ToString(row["UnitName"]);                        
                        list.Add(obj);
                    }
                }
            }

            return list;
        }

    }
}

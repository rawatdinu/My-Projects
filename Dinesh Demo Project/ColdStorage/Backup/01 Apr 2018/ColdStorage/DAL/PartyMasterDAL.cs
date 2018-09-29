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
   public class PartyMasterDAL
    {
        public bool AddNewPartyMaster(PartyMaster obj)
        {
            OleDbParameter[] parameters = new OleDbParameter[]
		{                
			new OleDbParameter("@PartyID", obj.PartyID),
			new OleDbParameter("@PartyName", obj.PartyName),
            new OleDbParameter("@PersonName", obj.PersonName),
            new OleDbParameter("@Address", obj.Address),
            new OleDbParameter("@ContactNo", obj.ContactNo),
            new OleDbParameter("@Mobile", obj.Mobile),
            new OleDbParameter("@EamilAddress", obj.EamilAddress),
			new OleDbParameter("@Remarks", obj.Remarks),	            
            new OleDbParameter("@CreatedOn", GlobalFunction.GetDateTimeWithoutMiliSecond(DateTime.Now))
	
		};
            string commandText = OleDBHelper.GetQueryText("PartyMaster_Insert", QueryType.Procedures);
            return OleDBHelper.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }

        public bool UpdatePartyMaster(PartyMaster obj)
        {
            OleDbParameter[] parameters = new OleDbParameter[]
            {
             
			new OleDbParameter("@PartyName", obj.PartyName),
			 new OleDbParameter("@PersonName", obj.PersonName),
            new OleDbParameter("@Address", obj.Address),
            new OleDbParameter("@ContactNo", obj.ContactNo),
            new OleDbParameter("@Mobile", obj.Mobile),
            new OleDbParameter("@EamilAddress", obj.EamilAddress),
			new OleDbParameter("@Remarks", obj.Remarks),         
            new OleDbParameter("@UpdatedOn", GlobalFunction.GetDateTimeWithoutMiliSecond(DateTime.Now)),
            new OleDbParameter("@PartyID", obj.PartyID)
            };

            string commandText = OleDBHelper.GetQueryText("PartyMaster_Update", QueryType.Procedures);
            return OleDBHelper.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }
        // Same can be used for deactive user
        public bool DeletePartyMaster(PartyMaster obj)
        {
            return true;
        }

        public PartyMaster GetPartyMasterDetails(String partyID)
        {
            PartyMaster obj = null;

            string commandText = OleDBHelper.GetQueryText("PartyMaster_SelectID", QueryType.Procedures);

            OleDbParameter[] parameters = new OleDbParameter[]
            {
            new OleDbParameter("@PartyID", partyID)
            };

            using (DataTable table = OleDBHelper.ExecuteParamerizedSelectCommand(commandText, CommandType.Text, parameters))
            {
                //check if any record exist or not
                if (table.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    obj = new PartyMaster();

                    obj.PartyID = Convert.ToString(table.Rows[0]["PartyID"]);
                    obj.PartyName = Convert.ToString(table.Rows[0]["PartyName"]);
                    obj.PersonName = Convert.ToString(table.Rows[0]["PersonName"]);
                    obj.Address = Convert.ToString(table.Rows[0]["Address"]);
                    obj.ContactNo = Convert.ToString(table.Rows[0]["ContactNo"]);
                    obj.Mobile = Convert.ToString(table.Rows[0]["Mobile"]);
                    obj.EamilAddress = Convert.ToString(table.Rows[0]["EamilAddress"]);
                    obj.Remarks = Convert.ToString(table.Rows[0]["Remarks"]);

                }
            }

            return obj;
        }

        public List<PartyMaster> GetPartyMasterList()
        {
            List<PartyMaster> list = null;

            string commandText = OleDBHelper.GetQueryText("PartyMaster_SelectAll", QueryType.Views);


            using (DataTable table = OleDBHelper.ExecuteSelectCommand(commandText, CommandType.Text))
            {
                //check if any record exist or not
                if (table.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    list = new List<PartyMaster>();

                    //Now lets populate the employee details into the list of employees
                    foreach (DataRow row in table.Rows)
                    {
                        PartyMaster obj = new PartyMaster();

                        obj.PartyID = Convert.ToString(row["PartyID"]);
                        obj.PartyName = Convert.ToString(row["PartyName"]);
                        obj.PersonName = Convert.ToString(row["PersonName"]);
                        obj.Address = Convert.ToString(row["Address"]);
                        obj.ContactNo = Convert.ToString(row["ContactNo"]);
                        obj.Mobile = Convert.ToString(row["Mobile"]);
                        obj.EamilAddress = Convert.ToString(row["EamilAddress"]);
                        obj.Remarks = Convert.ToString(row["Remarks"]);

                        list.Add(obj);

                    }
                }
            }

            return list;
        }

    }
}

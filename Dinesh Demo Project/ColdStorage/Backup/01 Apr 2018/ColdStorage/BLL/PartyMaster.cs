using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ColdStorage.DAL;

namespace ColdStorage.BLL
{
  public  class PartyMaster
    {
        public string PartyID { get; set; }
        public string PartyName { get; set; }
        public string PersonName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string Mobile { get; set; }
        public string EamilAddress { get; set; }
        public string Remarks { get; set; }

        PartyMasterDAL objDB = null;

        public PartyMaster()
        {
            objDB = new PartyMasterDAL();
        }
        public List<PartyMaster> GetPartyMasterList()
        {
            return objDB.GetPartyMasterList();
        }

        public PartyMaster GetPartyMasterDetails(string partyID)
        {
            return objDB.GetPartyMasterDetails(partyID);
        }

        public bool AddNewPartyMaster(PartyMaster obj)
        {
            return objDB.AddNewPartyMaster(obj);
        }

        public bool UpdatePartyMaster(PartyMaster obj)
        {
            return objDB.UpdatePartyMaster(obj);
        }

        public bool DeletePartyMaster(PartyMaster obj)
        {
            return objDB.DeletePartyMaster(obj);
        }  

    }
}

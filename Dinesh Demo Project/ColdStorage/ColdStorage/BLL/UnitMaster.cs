using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ColdStorage.DAL;

namespace ColdStorage.BLL
{
    class UnitMaster
    {
        public string ID { get; set; }
        public string UnitName { get; set; }

        UnitMasterDAL objDB = null;

        public UnitMaster()
        {
            objDB = new UnitMasterDAL();
        }
        public List<UnitMaster> GetUnitMasterList()
        {
            return objDB.GetUnitMasterList();
        }

        public UnitMaster GetUnitMasterDetails(string ID)
        {
            return objDB.GetUnitMasterDetails(ID);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NIITBilling.BLL
{
    public class Resource
    {
      public int ResourceID {get; set;}
      public string FirstName {get; set;}
      public string LastName { get; set; }
      public string SOW { get; set; }
      public string PONumber { get; set; }
      public string SONumber { get; set; }
      public DateTime StartDate { get; set; }
      public DateTime EndDate { get; set; }
      public string BillingType { get; set; }

      public string ProjectName { get; set; }
      public string Location { get; set; }
      public double HourlyRate { get; set; }
      public string Status { get; set; } // active or not
                
    }


}
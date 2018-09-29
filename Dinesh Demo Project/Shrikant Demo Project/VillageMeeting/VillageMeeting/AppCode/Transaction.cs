using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VillageMeeting.AppCode
{
  public  class Transaction
    {
        public string Querry;
        public string[] Para;
        public object[] Values;

        public Transaction(string querry, string[] para, object[] values)
        {
            Querry = querry;
            Para = para;
            Values = values;
        }
    }
}

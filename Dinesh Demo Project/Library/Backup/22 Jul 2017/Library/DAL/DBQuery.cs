using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Resources;

namespace Library.DAL
{
  public  class DBQuery
    {
      public static string GetQueryText(string queryName)
      {
          string queryText = "";
          ResourceManager rm = new ResourceManager("Library.DAL.DatabaseQueryList", Assembly.GetExecutingAssembly());
          queryText = rm.GetString(queryName);
          return queryText;      
      }
    }
}

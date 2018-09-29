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
    public class GlobalFunctionDAL
    {
        public static DataTable GetUniqueCodeForTable(string tableName)
        {
            DataTable dt = new DataTable();
            OleDbParameter[] parameters = new OleDbParameter[]
		    {                
			    new OleDbParameter("@TableName", tableName)	
		    };
            string commandText = OleDBHelper.GetQueryText("GetUniqueCodeForTable", QueryType.Procedures);
            dt = OleDBHelper.ExecuteParamerizedSelectCommand(commandText, CommandType.Text, parameters);
            return dt;
        }

        public static bool UpdateUniqueCodeForTable(string tableName)
        {

            bool result;
            OleDbParameter[] parameters = new OleDbParameter[]
		    {                
			    new OleDbParameter("@TableName", tableName)	
		    };
            string commandText = OleDBHelper.GetQueryText("UniqueCodeMaster_Update", QueryType.Procedures);
            result = OleDBHelper.ExecuteNonQuery(commandText, CommandType.Text, parameters);
            return result;
        }
    }
}

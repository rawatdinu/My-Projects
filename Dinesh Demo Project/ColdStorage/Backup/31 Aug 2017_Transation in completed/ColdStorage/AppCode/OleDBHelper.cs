using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Windows.Forms;

namespace ColdStorage.AppCode
{
   public class OleDBHelper
    {


        private static OleDbConnection conStatic;

        static int TimeOutInMs = 2000;

        #region Connection
        private static void OpenConnection()
        {
            try
            {
                if (conStatic == null)
                {
                    string str = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                   // str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\LibraryProject.accdb;Jet OLEDB:Database Password=123456";
                    conStatic = new OleDbConnection(str);                    
                }
                if (conStatic.State == ConnectionState.Closed)
                {
                    conStatic.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void CloseConnection()
        {
            if (conStatic.State == ConnectionState.Open)
            {
                conStatic.Close();
            }
        }

        #endregion



       private static string CONNECTION_STRING = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\LibraryProject.accdb;Jet OLEDB:Database Password=123456"; 

        //private static void GetConnectionString()
        //{

        //            CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DataLocation"].ConnectionString;
        //            //str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\Meeting.accdb;Jet OLEDB:Database Password=123456";            
        //}




        // This function will be used to execute R(CRUD) operation of parameterless commands
        public static DataTable ExecuteSelectCommand(string CommandName, CommandType cmdType)
        {
            DataTable table = null;
            //using (OleDbConnection con = new OleDbConnection(CONNECTION_STRING))
            //{
            //OleDbConnection con = new OleDbConnection(CONNECTION_STRING);
            OpenConnection();
                using (OleDbCommand cmd = conStatic.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;

                    try
                    {
                        if (conStatic.State != ConnectionState.Open)
                        {
                            conStatic.Open();
                        }

                        using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                        {
                            table = new DataTable();
                            da.Fill(table);
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            //}

            return table;
        }

        // This function will be used to execute R(CRUD) operation of parameterized commands
        public static DataTable ExecuteParamerizedSelectCommand(string CommandName, CommandType cmdType, OleDbParameter[] param)
        {
            DataTable table = new DataTable();

            //using (OleDbConnection con = new OleDbConnection(CONNECTION_STRING))
            //{
            //OleDbConnection con = new OleDbConnection(CONNECTION_STRING);
            OpenConnection();
                using (OleDbCommand cmd = conStatic.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    cmd.Parameters.AddRange(param);

                    try
                    {
                        if (conStatic.State != ConnectionState.Open)
                        {
                            conStatic.Open();
                        }

                        using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                        {
                            da.Fill(table);
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            //}

            return table;
        }

        // This function will be used to execute CUD(CRUD) operation of parameterized commands
        public static bool ExecuteNonQuery(string CommandName, CommandType cmdType, OleDbParameter[] pars)
        {
            int result = 0;

            //using (OleDbConnection con = new OleDbConnection(CONNECTION_STRING))
            //{
            //OleDbConnection con = new OleDbConnection(CONNECTION_STRING);
            OpenConnection();
                using (OleDbCommand cmd = conStatic.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    cmd.Parameters.AddRange(pars);

                    try
                    {
                        if (conStatic.State != ConnectionState.Open)
                        {
                            conStatic.Open();
                        }                       
                        result = cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        throw;
                    }
                }
            //}

            return (result > 0);
        }

        public static String GetQueryText(string queryName, string queryType)
        {
            string queryText = "";
            DataTable dt = new DataTable();
            //using (OleDbConnection con = new OleDbConnection(CONNECTION_STRING))
            //{
            //OleDbConnection con = new OleDbConnection(CONNECTION_STRING);
            OpenConnection();
                                    
                    try
                    {
                        if (conStatic.State != ConnectionState.Open)
                        {
                            conStatic.Open();
                        }
                       
                        if (queryType == QueryType.Procedures)
                        {
                            dt = conStatic.GetSchema("Procedures").AsEnumerable().Where(row => row.Field<String>("PROCEDURE_NAME") == queryName).CopyToDataTable();
                            if (dt.Rows.Count > 0)
                            {
                                queryText = Convert.ToString(dt.Rows[0]["PROCEDURE_DEFINITION"]);
                            }
                        }
                        else
                        {
                            dt = conStatic.GetSchema("Views").AsEnumerable().Where(row => row.Field<String>("TABLE_NAME") == queryName).CopyToDataTable();
                            if (dt.Rows.Count > 0)
                            {
                                queryText = Convert.ToString(dt.Rows[0]["VIEW_DEFINITION"]);
                            }
                        }
                        
                       
                    }
                    catch
                    {
                        throw;
                    }                
            //}
            return queryText;
        }
    }

   public class QueryType
   {
       public static string Procedures = "Procedures";
       public static string Views = "Views";
   
   }
}

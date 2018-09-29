using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;


namespace ColdStorage.AppCode
{
   public static class DBService
    {
      private static OleDbConnection con;
       
       static int TimeOutInMs = 2000;

#region Connection
       private static void OpenConnection()
       {
           try
           {
               if (con == null)
               {
                   string str;
                   str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\Meeting.accdb;Jet OLEDB:Database Password=123456";
                   con = new OleDbConnection(str);
               }
               if (con.State == ConnectionState.Closed)
               {
                   con.Open();
               }              
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
       }

       public static void CloseConnection()
       {
           if (con.State == ConnectionState.Open)
           {
               con.Close();
           }
       }

#endregion
       
#region ExecuteNonQuerry

       public static object ExecuteNonQuerry(string querry)
       {
           OleDbCommand cmd;
           object obj = null;
           try
           {
               OpenConnection();
               cmd = new OleDbCommand();
               cmd.Connection = con;
               cmd.CommandType = CommandType.Text;
               cmd.CommandText = querry;
               cmd.CommandTimeout = TimeOutInMs;
               obj = cmd.ExecuteNonQuery();
               return obj;

           }
           catch (Exception ex)
           {
               return null;
           }
       }

       public static object ExecuteNonQuerry(string querry,string[] para,object[] values)
       {
           OleDbCommand cmd;
           object obj = null;
           try
           {
               OpenConnection();
               cmd = new OleDbCommand();
               cmd.Connection = con;
               cmd.CommandText = querry;
               cmd.CommandTimeout = TimeOutInMs;

               if (para != null)
               {
                   if (para.Length > 0)
                   {
                       for (int i = 0; i < para.Length; i++)
                       {
                           cmd.Parameters.AddWithValue(para[i], values[i]);
                       }
                   }
               }
               
               obj = cmd.ExecuteNonQuery();
               return obj;
           }
           catch (Exception ex)
           {
               return null;
           }
       }
#endregion

#region ExecuteScalar
       public static object ExecuteScalar(string querry)
       {
           OleDbCommand cmd;
           object obj = null;
           try
           {
               OpenConnection();
               cmd = new OleDbCommand();
               cmd.Connection = con;
               cmd.CommandText = querry;
               cmd.CommandTimeout = TimeOutInMs;
               obj = cmd.ExecuteScalar();
               return obj;

           }
           catch (Exception ex)
           {
               return null;
           }
       }

       public static object ExecuteScalar(string querry, string[] para, object[] values)
       {
           OleDbCommand cmd;
           object obj = null;
           try
           {
               OpenConnection();
               cmd = new OleDbCommand();
               cmd.Connection = con;
               cmd.CommandText = querry;
               cmd.CommandTimeout = TimeOutInMs;

               if (para != null)
               {
                   if (para.Length > 0)
                   {
                       for (int i = 0; i < para.Length; i++)
                       {
                           cmd.Parameters.AddWithValue(para[i], values[i]);
                       }
                   }
               }

               obj = cmd.ExecuteScalar();
               return obj;
           }
           catch (Exception ex)
           {
               return null;
           }
       }
#endregion

#region Get Data Table
       public static DataTable GetDataTable(string querry)
         {
             OleDbCommand cmd;
             OleDbDataAdapter da;
             DataSet ds = new DataSet();
             DataTable dt = new DataTable();

             OpenConnection();
             cmd = new OleDbCommand();
             cmd.Connection = con;
             cmd.CommandType = CommandType.Text;
             cmd.CommandText = querry;
             cmd.CommandTimeout = TimeOutInMs;
             da = new OleDbDataAdapter(cmd);
             da.Fill(dt);
             return dt;
         }

       public static DataTable GetDataTable(string querry, string[] para, object[] values)
         {
             OleDbCommand cmd;
             OleDbDataAdapter da;
             DataSet ds = new DataSet();
             DataTable dt = new DataTable();
             OpenConnection();
             cmd = new OleDbCommand();
             cmd.Connection = con;
             cmd.CommandType = CommandType.Text;
             cmd.CommandText = querry;
             cmd.CommandTimeout = TimeOutInMs;
             if (para != null)
             {
                 if (para.Length > 0)
                 {
                     for (int i = 0; i < para.Length; i++)
                     {
                         cmd.Parameters.AddWithValue(para[i], values[i]);
                     }
                 }
             }
             da = new OleDbDataAdapter(cmd);
             da.Fill(dt);
             return dt;

         }
#endregion

       #region GetDataSet
       public static DataSet GetDataSet(string querry)
       {
           OleDbCommand cmd;
           OleDbDataAdapter da;
           DataSet ds = new DataSet();
           
           OpenConnection();
           cmd = new OleDbCommand();
           cmd.Connection = con;
           cmd.CommandType = CommandType.Text;
           cmd.CommandText = querry;
           cmd.CommandTimeout = TimeOutInMs;
           da = new OleDbDataAdapter(cmd);
           da.Fill(ds);
           return ds;
           
       }

       public static DataSet GetDataSet(string querry, string[] para, object[] values)
       {
           OleDbCommand cmd;
           OleDbDataAdapter da;
           DataSet ds = new DataSet();
           
           OpenConnection();
           cmd = new OleDbCommand();
           cmd.Connection = con;
           cmd.CommandType = CommandType.Text;
           cmd.CommandText = querry;
           cmd.CommandTimeout = TimeOutInMs;
           if (para != null)
           {
               if (para.Length > 0)
               {
                   for (int i = 0; i < para.Length; i++)
                   {
                       cmd.Parameters.AddWithValue(para[i], values[i]);
                   }
               }
           }
           da = new OleDbDataAdapter(cmd);
           da.Fill(ds);
           return ds;

       }

       #endregion
     
       public static DataTable GetSchema()
       {          
           DataTable dt = new DataTable();
           OpenConnection();          
          //dt= con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
           dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
          return dt;
       }


#region Database Transaction
       public static object ExecuteTransaction(List<Transaction> transList)
       {
           OleDbCommand cmd;
           object obj = null;
           OpenConnection();
           OleDbTransaction trans = con.BeginTransaction();           
           try
           {
               foreach (Transaction tr in transList)
               {
                   cmd = new OleDbCommand();
                   cmd.Connection = con;
                   cmd.CommandType = CommandType.Text;
                   cmd.CommandText = tr.Querry;
                   cmd.Transaction = trans;
                   if (tr.Para != null)
                   {
                       if (tr.Para.Length > 0)
                       {
                           for (int i = 0; i < tr.Para.Length; i++)
                           {
                               cmd.Parameters.AddWithValue(tr.Para[i], tr.Values[i]);
                           }
                       }
                   }
                  obj = cmd.ExecuteNonQuery();
               }
               trans.Commit();
               return obj;
              
           }
           catch (Exception ex)
           {
               trans.Rollback();
               return null;
           }
       }
#endregion

    }   
}

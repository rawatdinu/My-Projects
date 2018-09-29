using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace DemoStoredProcCSharp
{
   public static class DBService
    {
        static SqlConnection con;
        static SqlCommand cmd;


        public static void OpenConnection()
        {
            try
            {
                if (con == null)
                {
                    string str;
                    // con = new SqlConnection("Data Source=ADMIN-2747177B8;Initial Catalog=Meeting;Integrated Security=True");
                    // con = new SqlConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\bin\\Debug\\Meeting.accdb");
                    //"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\bin\Debug\Meeting.accdb"
                    // str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\MeetingDB.mdb";
                    str = "Data Source=DINESH-PC;Initial Catalog=Test;User ID=sa;Password=12345";
                    //str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Meeting.accdb;Jet OLEDB:Database Password=123456";
                    con = new SqlConnection(str);
                }
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd = new SqlCommand();
                cmd.Connection = con;
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

        public static object ExecuteNonQuery(string querry)
        {
            object r = null;

            try
            {
                OpenConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = querry;
                r = cmd.ExecuteNonQuery();
                return r;
            }
            catch (Exception ex)
            {

                return null;
            }

        }
        public static object ExecuteNonQuery(string querry, SqlParameter[] p)
        {
            object r = null;

            try
            {
                OpenConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = querry;
                cmd.Parameters.AddRange(p);
                r = cmd.ExecuteNonQuery();
                return r;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }


        public static DataSet GetDataSet(string querry)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            OpenConnection();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = querry;
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;

        }

        public static DataSet GetDataSet(string querry, SqlParameter[] p)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            OpenConnection();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = querry;
            cmd.Parameters.AddRange(p);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
            //r = cmd.ExecuteNonQuery();
        }



        public static DataTable GetDataTable(string querry)
        {

            SqlDataAdapter da;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            OpenConnection();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = querry;            
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }


        public static DataTable GetDataTable(string querry, SqlParameter[] p)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            OpenConnection();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = querry;
            cmd.Parameters.AddRange(p);            
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static object ExecuteScalar(string querry)
        {
            Object obj = null;
            try
            {
                OpenConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = querry;
                obj = cmd.ExecuteScalar();
                return obj;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        #region StoredProcedure

        public static object ExecuteNonQuery(string querry, string[] parameter, object[] value)
        {
            object r = null;

            try
            {
                OpenConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = querry;
                for (int i = 0; i < parameter.Length; i++)
                {                    
                    cmd.Parameters.AddWithValue(parameter[i], value[i]);
                }
                r = cmd.ExecuteNonQuery();
                return r;
            }
            catch (Exception ex)
            {

                return null;
            }

        }


        public static object ExecuteStoredProcedure(string querry, string[] parameter, object[] value)
        {
            object r = null;

            try
            {
                OpenConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = querry;
                for (int i = 0; i < parameter.Length; i++)
                {
                    cmd.Parameters.AddWithValue(parameter[i], value[i]);
                }
                r = cmd.ExecuteNonQuery();
                return r;
            }
            catch (Exception ex)
            {

                return null;
            }

        }



        #endregion


    }
}

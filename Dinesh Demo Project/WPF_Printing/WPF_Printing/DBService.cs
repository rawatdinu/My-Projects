using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;


namespace WPF_Printing
{
   public class DBService
   {
    OleDbConnection con;
    OleDbCommand cmd;
    OleDbDataAdapter adap;
    public DBService()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private void OpenConnection()
    {
        if (con == null)
        {
            //string s = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\dbbskm.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //String exedPath = System.Environment.GetCommandLineArgs()[0];
            //String exePath = System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;

          string AppPath=  AppDomain.CurrentDomain.BaseDirectory;

          //String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);


          string s = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppPath + "Printing.accdb";


            con = new OleDbConnection(s);
        }
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        cmd = new OleDbCommand();
        cmd.Connection = con;
    }


    private void CloseConnection()
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
    }
    public string CheckUser(string SQL)
    {
        OpenConnection();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = SQL;
        cmd.CommandTimeout = 2000;
        object ob = cmd.ExecuteScalar();
        string s;
        CloseConnection();
        if (ob == null)
            return null;
        else
        {
            s = ob.ToString();
            return s;
        }
    }
    
    public int ExecuteSQL(string SQL)
    {
        try
        {
            OpenConnection();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = SQL;
            cmd.CommandTimeout = 2000;
            int result = cmd.ExecuteNonQuery();           
            return result;
        }
        catch (Exception e)
        {
            return -1;
        }
    }


    public DataSet ddlBind(string SQL, string table_name)
    {
        OpenConnection();
        DataSet ds = new DataSet();
        adap = new OleDbDataAdapter(SQL, con);
        adap.Fill(ds, table_name);
        return ds;
    }

    public DataSet ddlBind(string SQL)
    {
        OpenConnection();
        DataSet ds = new DataSet();
        adap = new OleDbDataAdapter(SQL, con);
        adap.Fill(ds);
        CloseConnection();
        return ds;
    }
    public DataSet getDataSet(string SQL)
    {
        OpenConnection();
        DataSet ds = new DataSet();
        adap = new OleDbDataAdapter(SQL, con);
        adap.Fill(ds);
        CloseConnection();
        return ds;
    }

    public DataTable getDataTable(string SQL)
    {
        OpenConnection();
        DataTable dt = new DataTable();
        adap = new OleDbDataAdapter(SQL, con);
        adap.Fill(dt);        
        return dt;
    }


    public int lastId(string query)
    {
        OpenConnection();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = query;
        object ob = cmd.ExecuteScalar();
        CloseConnection();
        int r = 0;
        if (ob != null)
        {
            if (ob != DBNull.Value)
                r = Convert.ToInt32(ob);
        }
        return r;
    }

    public int sp_Execute(string spname, OleDbParameter[] p)
    {
        OpenConnection();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = spname;
        cmd.CommandTimeout = 2000;
        foreach (OleDbParameter para in p)
        {
            cmd.Parameters.Add(para);
        }
        int r = cmd.ExecuteNonQuery();
        CloseConnection();
        return r;
    }

    public DataSet sp_getDataset(string spname, OleDbParameter[] p)
    {
        DataSet ds = new DataSet();
        OpenConnection();
        //SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = spname;
        cmd.CommandTimeout = 2000;
        foreach (OleDbParameter para in p)
        {
            cmd.Parameters.Add(para);
        }
        adap = new OleDbDataAdapter(cmd);
        adap.Fill(ds);
        CloseConnection();
        return ds;
    }

    public DataTable sp_getDataTable(string spname, OleDbParameter[] p)
    {
        DataTable dt = new DataTable();
        OpenConnection();
        //SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = spname;
        cmd.CommandTimeout = 2000;
        foreach (OleDbParameter para in p)
        {
            cmd.Parameters.Add(para);
        }
        adap = new OleDbDataAdapter(cmd);
        adap.Fill(dt);
        CloseConnection();
        return dt;
    }

    public string sp_getStringValue(string spname, OleDbParameter[] p)
    {
        DataTable dt = new DataTable();
        string s;
        OpenConnection();
        //SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = spname;
        cmd.CommandTimeout = 2000;
        foreach (OleDbParameter para in p)
        {
            cmd.Parameters.Add(para);
        }
        adap = new OleDbDataAdapter(cmd);
        adap.Fill(dt);
        s=dt.Rows[0][0].ToString();
        CloseConnection();
        return s;
    }

}
}

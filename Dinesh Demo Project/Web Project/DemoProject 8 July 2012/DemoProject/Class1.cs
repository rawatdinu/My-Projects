using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace DemoProject
{
    public class Class1
    {
        SqlConnection connection;
        string FromPassword;

       
        public void OpenConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                connection.Open();
            }
            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }
            
        public string GetCode(string HEAD)
        {

            OpenConnection();
           
            string Code;
            int Length;       
            string Prefix;
            SqlCommand cmdGet = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                cmdGet.CommandText = "SELECT    Head,Prefix, CurrentValue + Increment AS Code, Max, LEN(Max) AS CodeLength,Increment FROM CodeGenerator WHERE (CurrentValue < Max) and (Head = @HEAD)";

                cmdGet.Parameters.Add("@HEAD", SqlDbType.VarChar, 50).Value = HEAD.Trim();
                cmdGet.Connection = connection;
                da = new SqlDataAdapter(cmdGet);
                da.Fill(ds, "Code");
                if (ds.Tables["Code"].Rows.Count > 0)
                {
                    Prefix = Convert.ToString(ds.Tables["Code"].Rows[0]["Prefix"]);
                    Length = Convert.ToInt32(ds.Tables["Code"].Rows[0]["CodeLength"]);
                    Code = Prefix + (Convert.ToString(ds.Tables["Code"].Rows[0]["Code"]).PadLeft(Length, '0'));
                    return Code;
                }
                else
                    return "-1";

            }
            catch (Exception ex)
            {
                return "-1";
            }

            finally
            {
                cmdGet.Dispose();
                da.Dispose();
                ds.Dispose();
            }
               
        }

        public string UniqueCode()
        {  
            string Code;
            SqlCommand com = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try 
            {
                OpenConnection();
                com.CommandText = "SELECT REPLACE(CONVERT(varchar, GETDATE(), 112) + CONVERT(varchar(8), GETDATE(), 114), ':', '') AS FileName";
                com.Connection = connection;
                da= new SqlDataAdapter(com);
                da.Fill(ds,"Code");
                if (ds.Tables["Code"].Rows.Count > 0)
                {
                    Code = Convert.ToString(ds.Tables["Code"].Rows[0]["FileName"]);
                    return Code;
                }

                else
                {
                    return "-1";
                }
              
            }
            catch(Exception ex)
            {
                return "-1";
            }
            finally
            {
                com.Dispose();
                da.Dispose();
                ds.Dispose();
            }

        
        
        }

        public static string GetRandomPassword(int length)
        {
            char[] chars = "!@#$%^&*abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string password = string.Empty;
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                int x = random.Next(1, chars.Length);
                //Don't Allow Repetation of Characters
                if (!password.Contains(chars.GetValue(x).ToString()))
                    password += chars.GetValue(x);
                else
                    i--;
            }
            return password;
        }

        public  bool IsUserExist(string Email)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand();

            command.CommandText = "SELECT  Email FROM  RegistrationTable WHERE (Email = @EmailId)";
            command.Parameters.Add("@EmailId", SqlDbType.VarChar, 50).Value = Email.Trim();
            command.Connection = connection;
            SqlDataReader dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Dispose();
                connection.Close(); 
                return true;
            }
            else
            {
                dr.Dispose();
                connection.Close(); 
                return false;
            }
                         
        }

        public static string SendMail(string RecepientEmail, string Subject, string Body)
        {
            try
            {
                /*******************Sender Details***********************/
                var FromAddress = "rawatdinu@gmail.com";
                var FromPassword = "password";
                /******************************************************/
                var smtp = new SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(FromAddress, FromPassword);
                    smtp.Timeout = 20000;
                }
                smtp.Send(FromAddress, RecepientEmail, Subject, Body);
                return "1";
            }
            catch (Exception ex)
            {
            return "-1";
            }
           
        }

        public static string SendHTMLMessege(string RecepientEmail, string Subject, string Body)
        {
            try
            {
               
                MailMessage message = new MailMessage();
                message.From = new MailAddress("rawatdinu@gmail.com");
                message.To.Add(RecepientEmail);
                message.Subject = Subject;
                message.IsBodyHtml = true;
                message.Body = Body;
                var FromAddress = "rawatdinu@gmail.com";
                var FromPassword = "Dinu9911499398.";
                

                var smtp = new SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(FromAddress, FromPassword);
                   
                    
                    smtp.Timeout = 20000;
                }
                smtp.Send(message);

                return "1";
            }
            catch (Exception ex)
            { 
            return "-1";
            }
            

        
        
        }


    }
}

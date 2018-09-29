using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace DemoProject
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        SqlConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*****************Connection***********************/
            if (connection == null)
            {
                connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                connection.Open();
            }
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            /****************************************/
            if (Session["UserCode"] != null)
            {
                Response.Redirect("~/Home.aspx");
            }

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            Class1 obj = new Class1();
            
            if (!(obj.IsUserExist(txtEmailAddress.Text.Trim())))
            {
                lblResult.Text = "* Your are not registered user";
                return;
            }
             
            /**************************Get new password***********************************************/
            string newPassword = Class1.GetRandomPassword(10);
            string UserName="";
           
            /**********************Set new password***************************************************/
            if(connection.State == ConnectionState.Closed)
                connection.Open();
            SqlCommand com = new SqlCommand();
            SqlCommand comGetName = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlTransaction Trans1 = connection.BeginTransaction();

            try
            {

                com.CommandText = "UPDATE RegistrationTable SET Pwd = @Pwd WHERE Email = @Email";
                com.Parameters.Add("@Pwd", SqlDbType.VarChar, 50).Value = newPassword;
                com.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = txtEmailAddress.Text.Trim();
                com.Connection = connection;
                com.Transaction = Trans1;
                com.ExecuteNonQuery();


                /*******************************Send new password***********************************************/

                comGetName.CommandText = "SELECT     ISNULL(ISNULL(JobSeekerPersonalDetails.FirstName, EmployerDetails.FirstName), RegistrationTable.Email) AS Name, RegistrationTable.UserCode, RegistrationTable.Email FROM RegistrationTable LEFT OUTER JOIN JobSeekerPersonalDetails ON RegistrationTable.UserCode = JobSeekerPersonalDetails.UserCode LEFT OUTER JOIN EmployerDetails ON RegistrationTable.UserCode = EmployerDetails.UserCode WHERE     (RegistrationTable.Email = @Email)";
                comGetName.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = txtEmailAddress.Text.Trim();
                comGetName.Connection = connection;
                comGetName.Transaction = Trans1;
                da = new SqlDataAdapter(comGetName);
                da.Fill(ds, "Data");
                if (ds.Tables["Data"].Rows.Count > 0)
                {
                    UserName = Convert.ToString(ds.Tables["Data"].Rows[0]["Name"]);
                   
                }


                string ReceipientEmail = txtEmailAddress.Text.Trim();
                string Subject = "Password from NaukariChahiye.com";
                string Body = "Dear " + UserName + " \n We welcome you to NaukriChahiyie.com.\n Your account is reset by your new password. Following is the your login details for the site\n\n To login the account click on the following link or copy-paste it in your browser: http://NaukriChahiye.com/index.php \n Your  username and password: \n\n Username:  " + txtEmailAddress.Text.Trim() + "  \n Password: " + newPassword + "";

                string str = Class1.SendMail(ReceipientEmail, Subject, Body);

                /*******************************display msg***********************************************/
                if (str == "-1")
                    throw new Exception();
                else if (str == "1")
                {
                    lblResult.Text = "* Your password is reset successfully";
                    Trans1.Commit();
                }
            }
            catch (Exception ex)
            {
                Trans1.Rollback();
                lblResult.Text = "* Error occurs";
            }
            finally
            {
                com.Dispose();
               
            }



        }
    }
}

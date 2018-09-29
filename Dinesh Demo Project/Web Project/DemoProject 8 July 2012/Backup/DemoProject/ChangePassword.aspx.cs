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
    public partial class ChangePassword : System.Web.UI.Page
    {
        SqlConnection connection ;
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
            if (Session["UserCode"] == null)
            {
                Response.Redirect("~/Home.aspx");
            }
          
        }

       

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if(Convert.ToString(Session["UserType"])=="JobSeeker")
                Response.Redirect("~/Profile.aspx");
            else
                Response.Redirect("~/EmployerProfile.aspx");
            
        }

        protected void btnChangePwd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmdSave = new SqlCommand();
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                cmd.CommandText = "SELECT UserCode,Email,Pwd FROM RegistrationTable WHERE (UserCode = @UserCode) AND (CAST(Pwd AS varbinary(30)) = CAST(@Pwd AS varbinary(30)))";
                cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["UserCode"]);
                cmd.Parameters.Add("@Pwd", SqlDbType.VarChar, 50).Value = txtOldPwd.Text;
                cmd.Connection = connection;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Close();
                    dr.Dispose();
                    cmdSave.CommandText = "Update RegistrationTable set Pwd=@Pwd where UserCode=@UserCode";
                    cmdSave.Parameters.Add("@UserCode", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["UserCode"]);
                    cmdSave.Parameters.Add("@Pwd", SqlDbType.VarChar, 50).Value = txtNewPwd.Text;
                    cmdSave.Connection = connection;
                    cmdSave.ExecuteNonQuery();

                    cmd.Dispose();
                    cmdSave.Dispose();
                    lblResult.Text = "Password has changed successfully";
                               

                }

                else
                {

                    dr.Close();
                    dr.Dispose();
                    lblResult.Text = "Old password is not correct";
                    return;
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex);

            }
            finally
            {
                cmd.Dispose();
                cmdSave.Dispose();
                connection.Close();

            }
           

        }

        protected void linkBtMyDesboard_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["UserType"]) == "JobSeeker")
                Response.Redirect("~/Profile.aspx");
            else
                Response.Redirect("~/EmployerProfile.aspx");
        }

        protected void linkViewProfile_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["UserType"]) == "JobSeeker")
                Response.Redirect("~/Profile.aspx");
            else
                Response.Redirect("~/EmployerProfile.aspx");
        }

        protected void linkBtUpdateProfile_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["UserType"]) == "JobSeeker")
                Response.Redirect("~/UpdateProfile.aspx");
            else
                Response.Redirect("~/UpdateEmployerProfile.aspx");
        }

       
    }
}

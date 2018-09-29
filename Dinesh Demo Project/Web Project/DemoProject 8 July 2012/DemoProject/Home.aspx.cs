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
    public partial class Home : System.Web.UI.Page
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
                linkforgetPwd.Visible = true;
            else
                linkforgetPwd.Visible = false;
                /*********************************************/


                if (!IsPostBack)
                {


                }
                string str = Convert.ToString(DateTime.Now.Date);
           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            SqlCommand cmd = new SqlCommand();
            SqlCommand comDetails = new SqlCommand();
            SqlDataAdapter DA = new SqlDataAdapter();
            DataSet ds = new DataSet();
            string UserName="";
            string UserEmail="";
            // Case Sensitive SQL matching for Password and Simple matchin for email id
            try
            {
                 cmd.CommandText = "SELECT UserCode,UserType,Email FROM RegistrationTable WHERE (Email = @EmailId) AND (CAST(Pwd AS varbinary) = CAST(@pwd AS varbinary))";
           
          //  cmd.CommandText = "select count(*) from RegistrationTable where Email=@EmailId";
           
            cmd.Parameters.Add("@EmailId", SqlDbType.VarChar, 50).Value =txtEmailId.Text.Trim();
            cmd.Parameters.Add("@pwd", SqlDbType.VarChar, 50).Value =txtPassword.Text;
            cmd.Connection = connection;
           

            /*  New code for login*/
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                if (Session["UserCode"] == null)
                {
                    dr.Read();
                   // Session["EmailId"] = dr["Email"].ToString();
                  //  Session["FirstName"] = Convert.ToString(dr["FirstName"]);
                    Session["UserCode"] = Convert.ToString(dr["UserCode"]);
                    Session["UserType"] = Convert.ToString(dr["UserType"]);
                    dr.Close();
                    dr.Dispose();
                    cmd.Dispose();
                    
                    /*********************Select User Details from here**************************/
                    if (Convert.ToString(Session["UserType"]) == "JobSeeker")
                    {
                        comDetails.CommandText = "SELECT     RegistrationTable.UserCode, JobSeekerPersonalDetails.FirstName, RegistrationTable.Email FROM RegistrationTable INNER JOIN JobSeekerPersonalDetails ON RegistrationTable.UserCode = JobSeekerPersonalDetails.UserCode WHERE (RegistrationTable.UserCode = @UserCode)";
                    }
                    else
                    {
                        comDetails.CommandText = "SELECT     RegistrationTable.UserCode, RegistrationTable.Email, EmployerDetails.FirstName FROM RegistrationTable INNER JOIN EmployerDetails ON RegistrationTable.UserCode = EmployerDetails.UserCode WHERE (RegistrationTable.UserCode = @UserCode)";
                    }


                    comDetails.Parameters.Add("@UserCode",SqlDbType.VarChar,50).Value= Convert.ToString(Session["UserCode"]);
                    comDetails.Connection=connection;
                    DA = new SqlDataAdapter(comDetails);
                    DA.Fill(ds, "Data");
                    if (ds.Tables["Data"].Rows.Count > 0)
                    { 
                    UserName= Convert.ToString(ds.Tables["Data"].Rows[0]["FirstName"]);
                    UserEmail = Convert.ToString(ds.Tables["Data"].Rows[0]["Email"]);
                    }



                    /*********************Select User Details from here**************************/

                   

                    //Response.Redirect("Requirement.aspx?comid="+id);
              
                   

                    if (UserName == "")
                    {
                        Session["FirstName"] =UserEmail;
                    }
                    else
                    {
                        Session["FirstName"] = UserName;
                    }
                   

                    if (Convert.ToString(Session["UserType"])=="JobSeeker")
                        Response.Redirect("~/Profile.aspx",false);
                    else
                        Response.Redirect("~/EmployerProfile.aspx",false);
                }
                else 
                {
                    lblStatus.Visible = true;
                    lblStatus.Text = "You are Already Sign in,Log out first";
                }

            }
            else
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Email id or password you entered is incorrect ?";
            }
            
            }
            catch(Exception ex)
            {
                lblStatus.Text="Error Occurs";
                Session.Abandon();
                Response.Write(ex);
              
            
            }
            finally
            {
                connection.Close();
                comDetails.Dispose();
                DA.Dispose();
                ds.Clear();
                ds.Dispose();
            }
               
        }

        protected void linkforgetPwd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ForgetPassword.aspx");
        }
    }
}

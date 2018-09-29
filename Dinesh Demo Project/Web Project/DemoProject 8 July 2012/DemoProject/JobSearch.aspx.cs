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
    public partial class JobSearch : System.Web.UI.Page
    {
        SqlConnection connection;
               
        protected void Page_Load(object sender, EventArgs e)
        {
            /*****************conncetion*************************/
            if (connection == null)
            {
                connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                connection.Open();
            }
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            /******************************************************/
           
            if ((Session["UserCode"])!= null)
            {
                Panel2.Visible = true;
            }
            else
            {
                Panel2.Visible = false;
            }
            if (!IsPostBack)
            {
               
                Display();
               
            }
            Session["JobID"] = null;
           
           
          
        }
        /*
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.Item.ItemIndex);
            // string str = e.Item.FindControl("lblJobType").Controls[index].ToString();
            Label str = (Label)e.Item.FindControl("lblJobID");
            string x = str.Text;
            Session["JobID"] = str.Text.Trim();
            Response.Redirect("~/CompanyProfile.aspx");
        }
        */
        protected void Button1_Click(object sender, EventArgs e)
        {

            Display();

        }
        protected void Display()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlCommand com = new SqlCommand();
            SqlDataAdapter da;
            DataSet ds = new DataSet();


            com.CommandText = "SELECT     EmployerSubmitJobs.JobID, EmployerSubmitJobs.JobType, EmployerSubmitJobs.JobTitle, EmployerDetails.CompanyName, EmployerDetails.Website, EmployerSubmitJobs.Location, CONVERT(varchar, EmployerSubmitJobs.JobPostDate, 106) AS PostDate, EmployerSubmitJobs.ExpMin, EmployerSubmitJobs.ExpMax, ISNULL(A.Num, 0) AS Num FROM         EmployerSubmitJobs INNER JOIN RegistrationTable ON EmployerSubmitJobs.UserCode = RegistrationTable.UserCode INNER JOIN EmployerDetails ON RegistrationTable.UserCode = EmployerDetails.UserCode LEFT OUTER JOIN (SELECT     JobID, COUNT(*) AS Num FROM  JobSeekerAppliedJob GROUP BY JobID) AS A ON EmployerSubmitJobs.JobID = A.JobID WHERE (EmployerSubmitJobs.JobTitle LIKE '%" + Server.HtmlEncode(txtKeyWord.Text.Trim()) + "%') AND (EmployerSubmitJobs.Location LIKE '%" + Server.HtmlEncode( txtLocation.Text.Trim()) + "%')AND ( EmployerSubmitJobs.IsActive = 1) ORDER BY EmployerSubmitJobs.JobPostDate DESC";

            // com.CommandText = "SELECT     JobID, JobType, JobTitle, CompanyName, CompanyWebsite, Location, CONVERT(varchar(12), JobPostDate, 106) AS JobPostDate FROM EmployerSubmitJobs WHERE (JobTitle LIKE '%" + txtKeyWord.Text + "%') AND (Location LIKE '%" + txtLocation.Text + "%')";

            com.Connection = connection;
            da = new SqlDataAdapter(com);
            da.Fill(ds, "Data");

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void linkBtMyDesboard_Click(object sender, EventArgs e)
        {
            if(Convert.ToString(Session["UserType"])=="JobSeeker")
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

        protected void linkBtChangePassword_Click(object sender, EventArgs e)
        {           
                Response.Redirect("~/ChangePassword.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            Label lblfile = (Label)GridView1.Rows[index].FindControl("lblJobID");
            if ((e.CommandName == "Apply") || (e.CommandName == "Details"))
            {
                Session["JobID"] = lblfile.Text.Trim();
                Response.Redirect("~/CompanyProfile.aspx");
            }
            
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Display();
            
        }

        protected void txtKeyWord_TextChanged(object sender, EventArgs e)
        {
            Display();
        }

        protected void txtLocation_TextChanged(object sender, EventArgs e)
        {
            Display();
        }
       

    }
}

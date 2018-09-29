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
    public partial class ContactUs : System.Web.UI.Page
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

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string Subject = txtSubject.Text;
            string Name = txtName.Text.Trim();
            string SenderEmail = txtEmailAddress.Text.Trim();
            string MObile = txtMobile.Text;
            string Message = txtMessage.Text;
            Message = "<h3>" + Subject + "<h3> <br />" + Message + "<br /> <br />" + "From:" + Name + "<br />" + "Email id:" + SenderEmail + "<br />" + "Mobile:" + MObile + "<br />";

            string status = Class1.SendHTMLMessege("dinesh.ostech@gmail.com", Subject, Message);

            if (status == "1")
            {
                lblResult.Text = "* Messege send successfully";
            }
            else 
            {
                lblResult.Text = "* Error occurs";
            }
                

        }
    }
}

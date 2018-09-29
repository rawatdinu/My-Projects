using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace DemoProject
{
    public partial class NewMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserCode"] != null)
            {
                LoginStatus(true);
                if (Session["FirstName"] != null)
                {
                    lblUserName.Text = Convert.ToString(Session["FirstName"]);
                }
                else
                {
                    lblUserName.Text = "";
                }
               
            }
            else
            {
                LoginStatus(false);
            }           
           }

        protected void linkbtLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            LoginStatus(false);
             Response.Redirect("~/Home.aspx");
        }

      
        protected void linkProfile_Click(object sender, EventArgs e)
        {
            if(Convert.ToString(Session["UserType"])=="JobSeeker")
                Response.Redirect("~/Profile.aspx");
            else
                Response.Redirect("~/EmployerProfile.aspx");
            
        }

        protected void LoginStatus(bool status)
        {
            lblUserName.Visible = status;
            linkbtLogOut.Visible = status;
            linkProfile.Visible = status;
        }

    }
}

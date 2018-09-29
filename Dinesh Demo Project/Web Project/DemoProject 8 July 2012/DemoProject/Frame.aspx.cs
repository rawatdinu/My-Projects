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

namespace DemoProject
{
    public partial class Frame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            frame1.Attributes["src"] = Session["ResumeName"].ToString();
            frame1.Attributes["width"] = Convert.ToString(1000);
            frame1.Attributes["height"] = Convert.ToString(500);
          

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIITBilling.BLL;


namespace NIITBilling
{
    public partial class ResourceDetails : System.Web.UI.Page
    {
         
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            Resource resource = new Resource();
            

            resource.ResourceID = Convert.ToInt32(txtResourceID.Text);
            resource.FirstName = txtFirstName.Text;
            resource.LastName = txtLastName.Text;
            resource.SOW = txtSOW.Text;
            resource.PONumber = txtPONumber.Text;
            resource.SONumber = txtSONumber.Text;
            resource.StartDate =Convert.ToDateTime(txtStartDate.Text);
            resource.EndDate = Convert.ToDateTime(txtEndDate.Text);
            resource.BillingType = ddBillingType.SelectedValue;

            resource.ProjectName = txtProjectName.Text;
            resource.Location = txtLocation.Text;
            resource.HourlyRate = Convert.ToDouble(txtHourlyRate.Text);

            if (rdoActive.Checked == true)
            {
                resource.Status = "Active";
            }
            else
            {
                resource.Status = "Non-Active";
            }

            ResourceHandler resourceHandler = new ResourceHandler();
            if (resourceHandler.AddNewResource(resource) == true)
            {
                //Response.Redirect("");
                //lblResult.Text = "Resource id added succesfully";
            }
        }


    }
}
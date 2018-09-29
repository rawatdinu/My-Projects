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
using System.IO;
using System.Text;

namespace DemoProject
{
    public partial class UpdateEmployerProfile : System.Web.UI.Page
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

            if (Session["UserCode"] == null)
            {
                Response.Redirect("~/Home.aspx");

            }
            if(Convert.ToString(Session["UserType"])!="Employer")
            {
                Response.Redirect("~/Home.aspx");
            }

            if (!IsPostBack)
            {
                Display();
            }

        }
       

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            SqlCommand ComSAVEDetail = new SqlCommand();
            SqlCommand com = new SqlCommand();
            string curDate;
         
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            try
            {
                com.CommandText = "SELECT     REPLACE(CONVERT(varchar, GETDATE(), 112) + CONVERT(varchar(8), GETDATE(), 114), ':', '') AS FileName";
                com.Connection = connection;
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();

                curDate = Convert.ToString(dr["FileName"]);
                string FileName = Convert.ToString(Session["UserCode"]) + curDate;
                dr.Close();
                dr.Dispose();
                /**********************************Upload Logo*************************************************************/
                if (FileUploadComLogo.HasFile)
                {
                    string imagePath = Server.MapPath("images\\");
                    string ext = Path.GetExtension(FileUploadComLogo.FileName);
                    if (ext.ToLower() == ".gif" || ext.ToLower() == ".jpeg" || ext.ToLower() == ".jpg")
                    {
                        //  string filenam = Guid.NewGuid().ToString();
                        FileUploadComLogo.PostedFile.SaveAs(imagePath + FileName + ext);
                        ViewState["Logo"] = FileName + ext;

                    }
                    else
                    {
                        lblResult.Text = "Wrong file type for Photo";
                       
                        return;
                    }
                }

                /*****************************************************************************************************/
                

  
                ComSAVEDetail.CommandText = "UPDATE  EmployerDetails  SET FirstName = @FirstName ,LastName = @LastName ,CompanyName = @CompanyName ,Staff = @Staff ,CompanyAddress = @CompanyAddress ,State = @State ,Country = @Country ,Phone = @Phone,  AlternateNo = @AlternateNo,AlternateEmail = @AlternateEmail,Website = @Website ,FacebookID = @FacebookID ,TwitterID = @TwitterID ,Logo=@Logo,LastUpdate = @LastUpdate WHERE (UserCode = @UserCode)";

                ComSAVEDetail.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = txtFirstName.Text.Trim();
                ComSAVEDetail.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = txtLastName.Text.Trim();
                ComSAVEDetail.Parameters.Add("@CompanyName", SqlDbType.VarChar, 50).Value = txtCompanyName.Text.Trim();
                if (ddlStaff.SelectedIndex == 0)
                {
                    ComSAVEDetail.Parameters.Add("@Staff", SqlDbType.VarChar, 50).Value = "";
                }
                else
                {
                    ComSAVEDetail.Parameters.Add("@Staff", SqlDbType.VarChar, 50).Value = ddlStaff.SelectedItem.Text;
                }
               
                ComSAVEDetail.Parameters.Add("@CompanyAddress", SqlDbType.VarChar, 50).Value = txtAddress.Text.Trim();
                ComSAVEDetail.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = txtState.Text.Trim();
                ComSAVEDetail.Parameters.Add("@Country", SqlDbType.VarChar, 50).Value = ddlistCountry.SelectedItem.Text;
                ComSAVEDetail.Parameters.Add("@Phone", SqlDbType.VarChar, 50).Value = txtPhone.Text.Trim();
                ComSAVEDetail.Parameters.Add("@AlternateNo", SqlDbType.VarChar, 50).Value = txtContactList.Text.Trim();
                ComSAVEDetail.Parameters.Add("@AlternateEmail", SqlDbType.VarChar, 50).Value = txtEmailList.Text.Trim();
                
                /*******************Website and Social media******************************************/
                ComSAVEDetail.Parameters.Add("@Website", SqlDbType.VarChar, 50).Value = txtWebSite.Text.Trim();
                ComSAVEDetail.Parameters.Add("@FacebookID", SqlDbType.VarChar, 50).Value = txtFacebook.Text.Trim();
                ComSAVEDetail.Parameters.Add("@TwitterID", SqlDbType.VarChar, 50).Value = txtTwitter.Text.Trim();

                /*************************************Upload Company Logo*************************************************/
                ComSAVEDetail.Parameters.Add("@Logo", SqlDbType.VarChar, 50).Value = Convert.ToString(ViewState["Logo"]);

                /**************************************************************************************/



                ComSAVEDetail.Parameters.Add("@LastUpdate", SqlDbType.VarChar, 50).Value = DateTime.Now.Date;
              

                ComSAVEDetail.Parameters.Add("@UserCode", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["UserCode"]);
              
                ComSAVEDetail.Connection = connection;
                ComSAVEDetail.ExecuteNonQuery();

              
                 /* Redirect to Employer profile*/
                Response.Redirect("~/EmployerProfile.aspx",false);

            }

            catch (Exception ex)
            {
                Response.Write(ex);
                if (File.Exists(Server.MapPath(("~/images/" +Convert.ToString(ViewState["Logo"])))))
                    File.Delete(Server.MapPath(("~/images/" + ViewState["Logo"])));
               lblResult.Text = "Error occure";

            }

            finally
            {
                connection.Close();
                ComSAVEDetail.Dispose();
                com.Dispose();
               

            }
        }
       
        protected void Display()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand com = new SqlCommand();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                com.CommandText = "SELECT     RegistrationTable.UserCode, RegistrationTable.UserType, RegistrationTable.Email, EmployerDetails.FirstName, EmployerDetails.LastName, EmployerDetails.CompanyName, EmployerDetails.Staff, EmployerDetails.CompanyAddress, EmployerDetails.State, EmployerDetails.Country,  EmployerDetails.Phone, EmployerDetails.Website, EmployerDetails.FacebookID, EmployerDetails.TwitterID, EmployerDetails.Logo  FROM  EmployerDetails INNER JOIN RegistrationTable ON EmployerDetails.UserCode = RegistrationTable.UserCode WHERE     (RegistrationTable.UserCode = @UserCode)";

                com.Parameters.Add("@UserCode", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["UserCode"]);
                com.Connection = connection;
                da = new SqlDataAdapter(com);
                da.Fill(ds, "Data");




                if (ds.Tables["Data"].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables["Data"].Rows.Count; i++)
                    {
                        /*************PErsonal details*******************/
                        if(Convert.ToString(ds.Tables["Data"].Rows[i]["FirstName"])=="")
                        {
                         lblEmployerName.Text = "Your Profile";
                        }
                        else
                        {
                            lblEmployerName.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["FirstName"]) + "'s Profile";
                        }
                       
                        txtFirstName.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["FirstName"]);
                        txtLastName.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["LastName"]);
                        
                        lblEmailID.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Email"]);
                        txtCompanyName.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["CompanyName"]);

                      if(Convert.ToString(ds.Tables["Data"].Rows[i]["Staff"])=="")
                      {
                        ddlStaff.SelectedIndex = -1;
                      }
                        else
                      {
                       ddlStaff.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Staff"]);
                      }
                        
                       
                        txtAddress.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["CompanyAddress"]);
                         txtState.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["State"]);

                        if (Convert.ToString(ds.Tables["Data"].Rows[i]["Country"]) == "")
                        {
                            ddlistCountry.SelectedIndex = -1;
                        }

                        else
                        {
                            ddlistCountry.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Country"]);
                        }
                        
                        txtPhone.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Phone"]);
                         txtWebSite.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Website"]);
                         txtFacebook.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["FacebookID"]);
                         txtTwitter.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["TwitterID"]);

                         ViewState["Logo"] = Convert.ToString(ds.Tables["Data"].Rows[i]["Logo"]);

                       
                    }

                }

            }
            catch (Exception ex)
            {
                Response.Write(ex);
                
            }

            finally
            {
                connection.Close();
                com.Dispose();
                ds.Clear();
               

            }


        }

        protected void linkBtMyDesboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EmployerProfile.aspx");
        }

        protected void linkViewProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EmployerProfile.aspx");
        }

      

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EmployerProfile.aspx");
        }

        protected void linkBtChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ChangePassword.aspx");
        }
        
    }
}
        
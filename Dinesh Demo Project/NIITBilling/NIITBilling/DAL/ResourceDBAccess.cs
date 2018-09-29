using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using NIITBilling.BLL;

namespace NIITBilling.DAL
{
    public class ResourceDBAccess
    {

        public bool AddNewResource(Resource resource)
        {
            SqlParameter[] parameters = new SqlParameter[]
		{                
			new SqlParameter("@ResourceID", resource.ResourceID),
			new SqlParameter("@FirstName", resource.FirstName),
			new SqlParameter("@LastName", resource.LastName),
			new SqlParameter("@SOW", resource.SOW),
			new SqlParameter("@PONumber", resource.PONumber),
			new SqlParameter("@SONumber", resource.SONumber),
			new SqlParameter("@StartDate", resource.StartDate),
			new SqlParameter("@EndDate", resource.EndDate),
			new SqlParameter("@BillingType", resource.BillingType),
            new SqlParameter("@ProjectName", resource.ProjectName),
			new SqlParameter("@Location", resource.Location),
            new SqlParameter("@HourlyRate", resource.HourlyRate),
            new SqlParameter("@Status", resource.Status),

		};

            return SqlDBHelper.ExecuteNonQuery("AddNewResource", CommandType.StoredProcedure, parameters);
        }

        public bool UpdateResource(Resource resource)
        {
            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@ResourceID", resource.ResourceID),
			new SqlParameter("@FirstName", resource.FirstName),
			new SqlParameter("@LastName", resource.LastName),
			new SqlParameter("@SOW", resource.SOW),
			new SqlParameter("@PONumber", resource.PONumber),
			new SqlParameter("@SONumber", resource.SONumber),
			new SqlParameter("@StartDate", resource.StartDate),
			new SqlParameter("@EndDate", resource.EndDate),
			new SqlParameter("@BillingType", resource.BillingType),
            new SqlParameter("@ProjectName", resource.ProjectName),
			new SqlParameter("@Location", resource.Location),
            new SqlParameter("@HourlyRate", resource.HourlyRate),
            new SqlParameter("@Status", resource.Status),
		};
            return SqlDBHelper.ExecuteNonQuery("UpdateResource", CommandType.StoredProcedure, parameters);
        }

        // Same can be used for deactive user
        public bool DeleteResource(int resourceID)
        {
            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@ResourceID", resourceID)
		};

            return SqlDBHelper.ExecuteNonQuery("DeleteResource", CommandType.StoredProcedure, parameters);
        }


        public Resource GetResourceDetails(int resourceID)
        {
            Resource resource = null;

            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@ResourceID", resourceID)
		};
            //Lets get the list of all resource in a datataable
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("GetResourceDetails", CommandType.StoredProcedure, parameters))
            {
                //check if any record exist or not
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];

                    //Lets go ahead and create the list of resource
                    resource = new Resource();

                    //Now lets populate the resource details into the list of resource 

                    resource.ResourceID = Convert.ToInt32(row["ResourceID"]);
                    resource.FirstName = row["FirstName"].ToString();
                    resource.LastName = row["LastName"].ToString();
                    resource.SOW = row["SOW"].ToString();
                    resource.PONumber = row["PONumber"].ToString();
                    resource.SONumber = row["SONumber"].ToString();
                    resource.StartDate = (DateTime)row["StartDate"];
                    resource.EndDate = (DateTime)row["EndDate"];
                    resource.BillingType = row["BillingType"].ToString();

                    resource.ProjectName = row["ProjectName"].ToString();
                    resource.Location = row["Location"].ToString();
                    resource.HourlyRate = Convert.ToDouble(row["HourlyRate"]);
                    resource.Status = row["Status"].ToString();


                }
            }

            return resource;
        }


        public List<Resource> GetResourceList()
        {
            List<Resource> listResource = null;

            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("GetResourceList", CommandType.StoredProcedure))
            {
                //check if any record exist or not
                if (table.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    listResource = new List<Resource>();

                    //Now lets populate the employee details into the list of employees
                    foreach (DataRow row in table.Rows)
                    {
                        Resource resource = new Resource();

                        resource.ResourceID = Convert.ToInt32(row["ResourceID"]);
                        resource.FirstName = row["FirstName"].ToString();
                        resource.LastName = row["LastName"].ToString();
                        resource.SOW = row["SOW"].ToString();
                        resource.PONumber = row["PONumber"].ToString();
                        resource.SONumber = row["SONumber"].ToString();
                        resource.StartDate = (DateTime)row["StartDate"];
                        resource.EndDate = (DateTime)row["EndDate"];
                        resource.BillingType = row["BillingType"].ToString();

                        resource.ProjectName = row["ProjectName"].ToString();
                        resource.Location = row["Location"].ToString();
                        resource.HourlyRate = Convert.ToDouble(row["HourlyRate"]);
                        resource.Status = row["Status"].ToString();

                        listResource.Add(resource);
                    }
                }
            }

            return listResource;
        }

        //Get List of Holida on the basis of location
        public List<DateTime> GetListOfHoliday()
        {
            List<DateTime> listofHoliday = null;

            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("GetHolidayList", CommandType.StoredProcedure))
            {
                //check if any record exist or not
                if (table.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    listofHoliday = new List<DateTime>();

                    //Now lets populate the employee details into the list of employees
                    foreach (DataRow row in table.Rows)
                    {
                        
                        listofHoliday.Add((DateTime)row["HolidayDate"]);
                    }
                }
            }

            return listofHoliday;
        }

       //For particular resourceID
        public List<DateTime> GetListOfLeaves(int resourceID, DateTime startDate, DateTime endDate)
        {
            List<DateTime> listofLeaves = null;

            DateTime leaveStartDate;
            DateTime leaveEndDate;

            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("GetListOfLeaves", CommandType.StoredProcedure))
            {
                //check if any record exist or not
                if (table.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    listofLeaves = new List<DateTime>();
                    
                    //Now lets populate the employee details into the list of employees
                    foreach (DataRow row in table.Rows)
                    {
                        leaveStartDate = (DateTime)row["LeaveStartDate"];
                        leaveEndDate = (DateTime)row["LeaveSEndDate"];
                        while (leaveEndDate > leaveStartDate)
                        {
                            listofLeaves.Add(leaveStartDate);
                            leaveStartDate = leaveStartDate.AddDays(1);
                        }                        
                    }
                }
            }

            return listofLeaves;
        }


    }
}
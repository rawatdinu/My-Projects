using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NIITBilling.DAL;

namespace NIITBilling.BLL
{
    public class ResourceHandler
    {
        ResourceDBAccess resourceDb = null;

        private DateTime effectiveStartDate;
        private DateTime effectiveEndDate;



        public ResourceHandler()
        {
            resourceDb = new ResourceDBAccess();
        }

        // This fuction does not contain any business logic, it simply returns the 
        // list of employees, we can put some logic here if needed
        public List<Resource> GetResourceList()
        {
            return resourceDb.GetResourceList();
        }

        // This fuction does not contain any business logic, it simply returns the 
        // list of employees, we can put some logic here if needed
        public bool UpdateResource(Resource resource)
        {
            return resourceDb.UpdateResource(resource);
        }

        // This fuction does not contain any business logic, it simply returns the 
        // list of employees, we can put some logic here if needed
        public Resource GetResourceDetails(int empID)
        {
            return resourceDb.GetResourceDetails(empID);
        }

        // This fuction does not contain any business logic, it simply returns the 
        // list of employees, we can put some logic here if needed
        public bool DeleteResource(int empID)
        {
            return resourceDb.DeleteResource(empID);
        }

        // This fuction does not contain any business logic, it simply returns the 
        // list of employees, we can put some logic here if needed
        public bool AddNewResource(Resource resource)
        {
            return resourceDb.AddNewResource(resource);
        }


        DateTime[] ListOfHoliday;
        DateTime[] ListOfLeaves;


        public static int GetWorkingDay(int resourceID)
        {
            int workingday = 0;

            return workingday;
        }







        








    }
}
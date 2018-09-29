using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCFromYouTube.Models;

namespace MVCFromYouTube.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FillCustomer()
        {
            return View();

        }
        public ActionResult DisplayCustomer()
        {
            Customer objCustomer = new Customer();
            objCustomer.Id = Convert.ToInt32(Request.Form["CustomerId"]);
            //objCustomer.CustomerCode = Convert.ToString(Request.Form["CustomerCode"]);
                objCustomer.CustomerCode = typeof(Controller).Assembly.GetName().Version.ToString();
            objCustomer.Amount = Convert.ToDouble(Request.Form["Amount"]);
            return View(objCustomer);
        }

    }
}

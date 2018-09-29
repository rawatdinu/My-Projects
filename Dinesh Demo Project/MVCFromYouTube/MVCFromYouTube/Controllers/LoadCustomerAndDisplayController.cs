using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCFromYouTube.Models;

namespace MVCFromYouTube.Controllers
{
    public class LoadCustomerAndDisplayController : Controller
    {
        //
        // GET: /LoadCustomerAndDisplay/

        public ActionResult Index()
        {
            Customer objCustomer = new Customer();
            objCustomer.Id = 101;
            objCustomer.CustomerCode = "CUS001245";
            objCustomer.Amount = 1500.20;
            return View(objCustomer);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movies.Controllers
{
    public class HelloWorldController : Controller
    {
        //
        // GET: /HelloWorld/

        //public ActionResult Index()
        //{

        //return View();
        //}


        public string Index()
        {
            return "This id default action";
            //return View();
        }
        //public string HelloWorld()
        //{
        //    return "This is Welcome action.............";
        //    //return View();
        //}

        public string Welcome(string name, int numTimes = 1)
        {
            string message = "Hello " + name + ", NumTimes is: " + numTimes;
            return "" + Server.HtmlEncode(message) + "";
        }

    }
}

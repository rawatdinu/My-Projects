using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFromYouTube.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        //public ActionResult Index()
        //{
        //    return View();
        //}
        
        public ViewResult Index()
        {
            
            ViewData["Countries"] = new List<string>()
            {"india",
                "Us",
                "Australia",
                "Germany"
            };
           return View();
        }
        public ActionResult GoHomePage()
        {
            //return View("MyHomePage");
            ViewData["CurrentTime"] = DateTime.Now;
            return View();
        }

    }
}

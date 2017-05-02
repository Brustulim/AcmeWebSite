using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcmeWebsite.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Acme Inc.";

            return View();
        }

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Contact page.";

        //    return View();
        //}

        public ActionResult ContactAcme()
        {
            ViewBag.Message = "Acme Contact page.";

            return View();
        }

        public ActionResult Acme()
        {
            ViewBag.Message = "Acme.";

            return View();
        }



        public String SendContact()
        {
            
            return "Ok";

        } 


    }
}
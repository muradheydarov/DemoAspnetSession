using DemoAspnetSession.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoAspnetSession.Controllers
{    
    public class HomeController : Controller
    {        
        public ActionResult Index()
        {
            if (Session["login"] != null)
            {
                ViewBag.Logined = true;                
            }
            
            return View();
        }

        [Auth]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Auth]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Auth]
        public ActionResult LogOut()
        {
            Session.Clear();

            return RedirectToAction("Index","Auth");
        }
    }
}
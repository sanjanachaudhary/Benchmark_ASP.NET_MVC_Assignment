using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RazorExpression.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult StudentDetails()
        {
            ViewBag.studentid = 101;
            ViewBag.studentname = "sanjana";
            ViewBag.studentphone = 9089786756;
            ViewBag.marks = 80;

            return View();

        }
    }
}
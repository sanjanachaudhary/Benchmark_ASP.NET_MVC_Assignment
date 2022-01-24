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
            ViewBag.NoOfSemisters = 6;
            ViewBag.subjects=new List<string>() { "maths","physics","chemistry" };
            return View();

        }


        public ActionResult Currency(int amount)
        {
            ViewBag.amount = amount;

            return View();
        }


        public ActionResult RequestExample()
        {
            ViewBag.Url = Request.Url;
            ViewBag.PhysicalApplicationPath = Request.PhysicalApplicationPath;
            ViewBag.Path=Request.Path;
            ViewBag.BrowserType = Request.Browser.Type;
            ViewBag.QueryString = Request.QueryString["n"];
            ViewBag.Headers = Request.Headers["Accept"];
            ViewBag.HttpMethod=Request.HttpMethod;
            return View();
        }

        public ActionResult ResponseExample()
        {
            Response.Write("hello from responseExample");
            Response.ContentType = "text/html";
            Response.Headers["server"] = "My Server";
            Response.StatusCode = 500;
            return View();  
        }
    }
}
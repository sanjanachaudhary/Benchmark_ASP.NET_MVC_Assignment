using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View("About");
        }
        public ActionResult Product()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult GetEmpName(int empid)
        {

            var employees = new[] {
            new{empid=1,empname="sanjana",salary=8000},
            new{empid=2,empname="purvesh",salary=6000},
            new{empid=3,empname="vaish",salary=5000}
        };
            string matchempname = null;
            foreach (var emp in employees)
            {
                if (emp.empid == empid)
                {
                    matchempname = emp.empname;
                }
            }

            //return nee ContentResult(){Content=matchempname,ContentType="Text/plain"};

            return Content(matchempname, "text/plain");
        }


        public ActionResult EmpFacebookpage(int empid)
        {

            var employees = new[] {
            new{empid=1,empname="sanjana",salary=8000},
            new{empid=2,empname="purvesh",salary=6000},
            new{empid=3,empname="vaish",salary=5000}
        };
            string fburl = null;
            foreach (var emp in employees)
            {
                if (emp.empid == empid)
                {
                    fburl = "http://www.facebook.com/emp" + empid;
                }
            }
            if(fburl == null)
            {
                return Content("invalid emp id");
            }
            else
            {
                return Redirect(fburl);
            }

            

        }
    }
}
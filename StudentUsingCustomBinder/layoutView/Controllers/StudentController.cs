using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using layoutView.Models;

namespace layoutView.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([ModelBinder(typeof(CustomBinder))]Student stu)
        {
            return View();
        }
    }
}
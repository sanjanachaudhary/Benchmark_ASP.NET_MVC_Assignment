using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFramework1.Models;

namespace EntityFramework1.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        public ActionResult Index()
        {
            endemo1Entities1 db = new endemo1Entities1();
             List<Brand> brands= db.Brands.ToList();
            return View(brands);


            
        }
    }
}
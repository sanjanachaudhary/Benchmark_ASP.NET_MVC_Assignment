using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFramework1.Models;

namespace EntityFramework1.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            endemo1Entities1 db=new endemo1Entities1();
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
    }
}
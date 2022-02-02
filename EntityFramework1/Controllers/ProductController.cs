using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFramework1.Models;

namespace EntityFramework1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(string search="")
        {

            endemo1Entities1 db = new endemo1Entities1();
            ViewBag.s = search;
            List<product> products = db.products.Where(temp => temp.pname.Contains(search)).ToList();
            return View(products);

            
        }
        public ActionResult Index1()
        {

            endemo1Entities1 db = new endemo1Entities1();
            List<product> products = db.products.Where(temp=>temp.cid==1).ToList();
            return View(products);


        }
        public ActionResult Detail(int id)
        {

            endemo1Entities1 db = new endemo1Entities1();
            product products = db.products.Where(temp => temp.pid == id).FirstOrDefault();
            return View(products);


        }

        public ActionResult Create()
        {

            endemo1Entities1 db = new endemo1Entities1();
            ViewBag.category = db.Categories;
            ViewBag.brand=db.Brands;
            return View();
        }
        [HttpPost]
        public ActionResult Create(product p)
        {

            endemo1Entities1 db = new endemo1Entities1();
            db.products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {

            endemo1Entities1 db = new endemo1Entities1();
            
            ViewBag.category = db.Categories;
            ViewBag.brand = db.Brands;
            product exp = db.products.Where(temp => temp.pid == id).FirstOrDefault();
            return View(exp);
        }
        [HttpPost]
        public ActionResult Edit(product p)
        {
            endemo1Entities1 db = new endemo1Entities1();
            product exp = db.products.Where(temp => temp.pid == p.pid).FirstOrDefault();
            exp.pname = p.pname;
            exp.price = p.price;
            exp.dop = p.dop;
            exp.cid = p.cid;
            exp.astatus = p.astatus;
            exp.active = p.active;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult Delete(int id)
        {

            endemo1Entities1 db = new endemo1Entities1();
            product exp = db.products.Where(temp => temp.pid == id).FirstOrDefault();
            return View(exp);
        }
        [HttpPost]
        //we are passing product p dumy bcz we have already mehod delete to make this method diff we pass product p
        public ActionResult Delete(int id,product p)
        {

            endemo1Entities1 db = new endemo1Entities1();
            product exp = db.products.Where(temp => temp.pid == id).FirstOrDefault();
            db.products.Remove(exp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentActivity.Models;

namespace StudentActivity.Controllers
{
    public class activityController : Controller
    {
        // GET: activity/Index
        public ActionResult Index(string search="")
        {
            studentActivityDBEntities db = new studentActivityDBEntities();
            ViewBag.search = search;
            List<activity> activities = db.activities.Where(temp=>temp.activity1.Contains(search)).ToList();
            return View(activities);

        }



        public ActionResult Details(long id)
        {
            studentActivityDBEntities db = new studentActivityDBEntities();
            activity a = db.activities.Where(temp => temp.aid == id).FirstOrDefault();
            return View(a);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(activity a)
        {
            studentActivityDBEntities db = new studentActivityDBEntities();
            db.activities.Add(a);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {
            studentActivityDBEntities db = new studentActivityDBEntities();
            activity existingactivity = db.activities.Where(temp => temp.aid == id).FirstOrDefault();
            ViewBag.activity = existingactivity;
            
            return View(existingactivity);
        }

        [HttpPost]
        public ActionResult Edit(activity a)
        {
            studentActivityDBEntities db = new studentActivityDBEntities();
            activity existingactivity = db.activities.Where(temp => temp.aid == a.aid).FirstOrDefault();
            existingactivity.aid = a.aid;
            existingactivity.activity1 = a.activity1;
            existingactivity.cost = a.cost;
            existingactivity.stud_id = a.stud_id;
            db.SaveChanges();
            return RedirectToAction("Index", "activity");
        }

        public ActionResult Delete(int id)
        {
            studentActivityDBEntities db = new studentActivityDBEntities();
            activity existingactivity = db.activities.Where(temp => temp.aid == id).FirstOrDefault();
            return View(existingactivity);
        }

        [HttpPost]

        public ActionResult Delete(int id, student s)
        {
            studentActivityDBEntities db = new studentActivityDBEntities();
            activity existingactivity = db.activities.Where(temp => temp.aid == id).FirstOrDefault();
            db.activities.Remove(existingactivity);
            db.SaveChanges();

            return RedirectToAction("Index", "activity");
        }
    }
}
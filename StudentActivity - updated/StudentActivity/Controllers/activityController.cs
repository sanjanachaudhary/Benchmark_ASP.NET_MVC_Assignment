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
        public ActionResult Index(string search="", string sortColumn = "sname", string iconClass = "fa-sort-desc",int pageNumber = 1)
        {
            studentActivityDBEntities db = new studentActivityDBEntities();
            ViewBag.search = search;
            List<activity> activities = db.activities.Where(temp=>temp.activity1.Contains(search)).ToList();

            //sorting
            ViewBag.sortColumn = sortColumn;
            ViewBag.iconClass = iconClass;
            //sorting by activity id
            if (ViewBag.sortColumn == "aid")
            {
                if (ViewBag.iconClass == "fa-sort-asc")
                    activities = activities.OrderBy(temp => temp.aid).ToList();
                else
                    activities = activities.OrderByDescending(temp => temp.aid).ToList();
            }

            //sorting by activity1
            if (ViewBag.sortColumn == "activity1")
            {
                if (ViewBag.iconClass == "fa-sort-asc")
                    activities = activities.OrderBy(temp => temp.activity1).ToList();
                else
                    activities = activities.OrderByDescending(temp => temp.activity1).ToList();
            }

            //sorting by cost
            if (ViewBag.sortColumn == "cost")
            {
                if (ViewBag.iconClass == "fa-sort-asc")
                    activities = activities.OrderBy(temp => temp.cost).ToList();
                else
                    activities = activities.OrderByDescending(temp => temp.cost).ToList();
            }

            //sorting by student id
            if (ViewBag.sortColumn == "stud_id")
            {
                if (ViewBag.iconClass == "fa-sort-asc")
                    activities = activities.OrderBy(temp => temp.stud_id).ToList();
                else
                    activities = activities.OrderByDescending(temp => temp.stud_id).ToList();
            }

            //pagging
            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(activities.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (pageNumber - 1) * NoOfRecordsPerPage;
            ViewBag.pageNumber = pageNumber;
            ViewBag.NoOfPages = NoOfPages;
            activities = activities.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();

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

            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
            {
                var file = Request.Files[0];
                var imgBytes = new Byte[file.ContentLength];
                file.InputStream.Read(imgBytes,0,file.ContentLength);
                var base64String=Convert.ToBase64String(imgBytes,0,imgBytes.Length);
                a.photo = base64String;
            }
            db.activities.Add(a);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            else
            {
                ViewBag.student = db.students.ToList();
                return View();
            }

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
            if (Request.Files.Count >= 1)
            {
                var file = Request.Files[0];
                var imgBytes = new Byte[file.ContentLength];
                file.InputStream.Read(imgBytes, 0, file.ContentLength);
                var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                a.photo = base64String;
                
            }
            
            activity existingactivity = db.activities.Where(temp => temp.aid == a.aid).FirstOrDefault();
            existingactivity.aid = a.aid;
            existingactivity.activity1 = a.activity1;
            existingactivity.cost = a.cost;
            existingactivity.stud_id = a.stud_id;
            existingactivity.photo = a.photo;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentActivity.Models;


namespace StudentActivity.Controllers
{
    public class studentController : Controller
    {
        // GET: student/Index
        /*   public ActionResult Index(string search = "")
           {
               studentActivityDBEntities db = new studentActivityDBEntities();
               ViewBag.search = search;
               List<student> students = db.students.Where(temp => temp.sname.Contains(search)).ToList();
               //List<student> students1 = db.students.Where(temp => temp.address.Contains(searchaddress)).ToList();
              // List<student> students2 = db.students.Where(temp => temp.gender.Contains(searchgender)).ToList();
               return View(students);
           }*/

        public ActionResult Index(string searchname = "",string searchaddress="",string searchgender="")
        {
            studentActivityDBEntities db = new studentActivityDBEntities();
            ViewBag.searchname = searchname;
            ViewBag.searchaddress = searchaddress;
            ViewBag.searchgender = searchgender;
            return View(db.students.ToList().Where(temp => temp.sname.Contains(searchname)).Where(temp => temp.address.Contains(searchaddress)).Where(temp => temp.gender.Contains(searchgender)));
            //ViewBag.searchname = searchname;
            //List<student> students = db.students.Where(temp => temp.sname.Contains(searchname)).ToList();
            //List<student> students1 = db.students.Where(temp => temp.address.Contains(searchaddress)).ToList();
            // List<student> students2 = db.students.Where(temp => temp.gender.Contains(searchgender)).ToList();
            
        }

        public ActionResult Details(long id)
        {
            studentActivityDBEntities db = new studentActivityDBEntities();
            student s = db.students.Where(temp => temp.stud_id == id).FirstOrDefault();
            return View(s);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(student s)
        {
            studentActivityDBEntities db = new studentActivityDBEntities();
            db.students.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {
            studentActivityDBEntities db = new studentActivityDBEntities();
            student existingstudent = db.students.Where(temp => temp.stud_id == id).FirstOrDefault();
            ViewBag.student = existingstudent;
            return View(existingstudent);
        }

        [HttpPost]
        public ActionResult Edit(student s)
        {
            studentActivityDBEntities db = new studentActivityDBEntities();
            student existingstudent = db.students.Where(temp => temp.stud_id == s.stud_id).FirstOrDefault();
            existingstudent.sname = s.sname;
            existingstudent.phone = s.phone;
            existingstudent.address = s.address;
            existingstudent.gender= s.gender;
            db.SaveChanges();
            return RedirectToAction("Index","student");
        }

        public ActionResult Delete(int id)
        {
            studentActivityDBEntities db = new studentActivityDBEntities();
            student existingstudent = db.students.Where(temp => temp.stud_id == id).FirstOrDefault();
            return View(existingstudent);
        }

        [HttpPost]

        public ActionResult Delete(int id,student s)
        {
            studentActivityDBEntities db = new studentActivityDBEntities();
            student existingstudent = db.students.Where(temp => temp.stud_id == id).FirstOrDefault();
            db.students.Remove(existingstudent);
            db.SaveChanges();
            
            return RedirectToAction("Index", "student");
        }
    }
}
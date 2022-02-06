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

       /* public ActionResult Index(string search = "")
        {
            studentActivityDBEntities db = new studentActivityDBEntities();
            ViewBag.search = search;
            List<student> students = db.students.Where(temp => temp.sname.Contains(search)).ToList();
            //List<student> students1 = db.students.Where(temp => temp.address.Contains(searchaddress)).ToList();
            //List<student> students2 = db.students.Where(temp => temp.gender.Contains(searchgender)).ToList();
            return View(students);
        }*/

        public ActionResult Index(string searchname = "", string searchaddress = "",string searchgender = "", string sortColumn="sname",string iconClass="fa-sort-desc",int pageNumber =1)
        {
            studentActivityDBEntities db = new studentActivityDBEntities();
         
            List<student> students = db.students.ToList();


            //sorting
            ViewBag.sortColumn = sortColumn;
            ViewBag.iconClass = iconClass;
            //sorting by student id
            if (ViewBag.sortColumn == "stud_id")
            {
                if (ViewBag.iconClass == "fa-sort-asc")
                    students = students.OrderBy(temp => temp.stud_id).ToList();
                else
                    students = students.OrderByDescending(temp => temp.stud_id).ToList();
            }

            //sorting by student name
            if (ViewBag.sortColumn == "sname")
            {
                if (ViewBag.iconClass == "fa-sort-asc")
                    students = students.OrderBy(temp => temp.sname).ToList();
                else
                    students = students.OrderByDescending(temp => temp.sname).ToList();
            }

            //sorting by address
            if (ViewBag.sortColumn == "address")
            {
                if (ViewBag.iconClass == "fa-sort-asc")
                    students = students.OrderBy(temp => temp.address).ToList();
                else
                    students = students.OrderByDescending(temp => temp.address).ToList();
            }




            //seaching

            if (searchname != null || searchaddress != null || searchgender != null)
            {
                int NoOfRecordsPerPage1 = 5;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(students.Count) / Convert.ToDouble(NoOfRecordsPerPage1)));
                int NoOfRecordsToSkip1 = (pageNumber - 1) * NoOfRecordsPerPage1;
                ViewBag.pageNumber = pageNumber;
                ViewBag.NoOfPages = NoOfPages1;
                students = students.Skip(NoOfRecordsToSkip1).Take(NoOfRecordsPerPage1).ToList();

                ViewBag.search = searchname;
                ViewBag.search = searchaddress;
                List<student> students1 = db.students.Where(temp => temp.sname.Contains(searchname) && temp.address.Contains(searchaddress) && temp.gender.Contains(searchgender)).ToList();
                return View(students1);
            }
            else if (searchname != null || searchaddress != null)
            {
                int NoOfRecordsPerPage1 = 5;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(students.Count) / Convert.ToDouble(NoOfRecordsPerPage1)));
                int NoOfRecordsToSkip1 = (pageNumber - 1) * NoOfRecordsPerPage1;
                ViewBag.pageNumber = pageNumber;
                ViewBag.NoOfPages = NoOfPages1;
                students = students.Skip(NoOfRecordsToSkip1).Take(NoOfRecordsPerPage1).ToList();

                ViewBag.search = searchname;
                ViewBag.search = searchaddress;
                List<student> students1 = db.students.Where(temp => temp.sname.Contains(searchname) && temp.address.Contains(searchaddress)).ToList();
                return View(students1);
            }
            else if (searchaddress != null || searchgender != null)
            {
                int NoOfRecordsPerPage1 = 5;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(students.Count) / Convert.ToDouble(NoOfRecordsPerPage1)));
                int NoOfRecordsToSkip1 = (pageNumber - 1) * NoOfRecordsPerPage1;
                ViewBag.pageNumber = pageNumber;
                ViewBag.NoOfPages = NoOfPages1;
                students = students.Skip(NoOfRecordsToSkip1).Take(NoOfRecordsPerPage1).ToList();

                ViewBag.search = searchname;
                ViewBag.search = searchaddress;
                List<student> students1 = db.students.Where(temp => temp.address.Contains(searchaddress) && temp.gender.Contains(searchgender)).ToList();
                return View(students1);
            }
            else if (searchname != null || searchgender != null)
            {
                int NoOfRecordsPerPage1 = 5;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(students.Count) / Convert.ToDouble(NoOfRecordsPerPage1)));
                int NoOfRecordsToSkip1 = (pageNumber - 1) * NoOfRecordsPerPage1;
                ViewBag.pageNumber = pageNumber;
                ViewBag.NoOfPages = NoOfPages1;
                students = students.Skip(NoOfRecordsToSkip1).Take(NoOfRecordsPerPage1).ToList();

                ViewBag.search = searchname;
                ViewBag.search = searchaddress;
                List<student> students1 = db.students.Where(temp => temp.sname.Contains(searchname) && temp.gender.Contains(searchgender)).ToList();
                return View(students1);
            }
            else if (searchname != null)
            {
                int NoOfRecordsPerPage1 = 5;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(students.Count) / Convert.ToDouble(NoOfRecordsPerPage1)));
                int NoOfRecordsToSkip1 = (pageNumber - 1) * NoOfRecordsPerPage1;
                ViewBag.pageNumber = pageNumber;
                ViewBag.NoOfPages = NoOfPages1;
                students = students.Skip(NoOfRecordsToSkip1).Take(NoOfRecordsPerPage1).ToList();

                ViewBag.search = searchname;

                List<student> students1 = db.students.Where(temp => temp.sname.Contains(searchname)).ToList();
                return View(students1);

            }
            else if (searchaddress != null)
            {
                int NoOfRecordsPerPage1 = 5;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(students.Count) / Convert.ToDouble(NoOfRecordsPerPage1)));
                int NoOfRecordsToSkip1 = (pageNumber - 1) * NoOfRecordsPerPage1;
                ViewBag.pageNumber = pageNumber;
                ViewBag.NoOfPages = NoOfPages1;
                students = students.Skip(NoOfRecordsToSkip1).Take(NoOfRecordsPerPage1).ToList();


                ViewBag.search = searchaddress;
                List<student> students1 = db.students.Where(temp => temp.address.Contains(searchaddress)).ToList();
                return View(students1);
            }
            else if (searchgender != null)
            {
                int NoOfRecordsPerPage1 = 5;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(students.Count) / Convert.ToDouble(NoOfRecordsPerPage1)));
                int NoOfRecordsToSkip1 = (pageNumber - 1) * NoOfRecordsPerPage1;
                ViewBag.pageNumber = pageNumber;
                ViewBag.NoOfPages = NoOfPages1;
                students = students.Skip(NoOfRecordsToSkip1).Take(NoOfRecordsPerPage1).ToList();

                ViewBag.search = searchname;

                List<student> students1 = db.students.Where(temp => temp.gender.Contains(searchgender)).ToList();
                return View(students1);

            }



            //pagging
            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(students.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (pageNumber - 1) * NoOfRecordsPerPage;
            ViewBag.pageNumber = pageNumber;
            ViewBag.NoOfPages = NoOfPages;
            students = students.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();



            return View(db.students);
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

        /*public ActionResult Delete(int id)
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
        }*/

        public ActionResult Delete(int id)
        {
            studentActivityDBEntities db = new studentActivityDBEntities();

            student existingstudent = db.students.Where(temp => temp.stud_id == id).FirstOrDefault();
            db.students.Remove(existingstudent);

            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
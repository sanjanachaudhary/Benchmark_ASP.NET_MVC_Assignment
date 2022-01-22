using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login(string username ,string password)
        {
            if(username =="admin" && password == "manager")
            {
                return RedirectToAction("Dashboard","Admin");
            }
            else
            {
                return RedirectToAction("InvalidLogin");

                /*If want to redirect to the same controller, you need not specify the controller name.By default, it takes the current working controller name.
                 * If you want to redirect to other controller, you should specify the controller name manually, as second argument.*/

            }


        }

        public ActionResult InvalidLogin(string username,string password)
        {
            return View();
        }
    }
}
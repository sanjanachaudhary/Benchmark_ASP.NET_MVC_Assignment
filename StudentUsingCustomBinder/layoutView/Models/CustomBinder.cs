using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace layoutView.Models
{
    public class CustomBinder:IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,ModelBindingContext bindingContext)
        {
            int studentid =Convert.ToInt32(controllerContext.HttpContext.Request.Form["studentid"]);
            string studentname = controllerContext.HttpContext.Request.Form["studentname"];
            string DNo = controllerContext.HttpContext.Request.Form["DNo"];
            string street = controllerContext.HttpContext.Request.Form["street"];
            string landmark = controllerContext.HttpContext.Request.Form["landmark"];
            string City = controllerContext.HttpContext.Request.Form["city"];

            return new Student() { studentid = studentid, studentname = studentname, Address = DNo + "," + street + "," + landmark + "," + City };
        }
    }
}
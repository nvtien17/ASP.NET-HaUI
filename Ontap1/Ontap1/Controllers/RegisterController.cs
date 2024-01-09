using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ontap1.Models;

namespace Ontap1.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save(Student s)
        {
            return View(s);
        }
        public ActionResult Save2(FormCollection f)
        {
            Student s = new Student();
            s.Fname = f["fname"];
            s.Lname = f["lname"];
            s.Email = f["email"];
            s.Passw = f["passw"];
            s.City = f["city"];
            s.Gender = f["gender"];

            // Checkbox
            string strTemp = "";
            if (f["Math"] == "true,false")
            {
                strTemp = "Math";
            }
            if (f["Physical"] == "true,false")
            {
                strTemp += " " + "Physical";
            }
            if (f["English"] == "true,false")
            {
                strTemp += " " + "English";
            }
            s.Subjects = strTemp;

            return View("Save", s);
        }
    }
}
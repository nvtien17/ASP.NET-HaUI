using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TX1_De1.Models;

namespace TX1_De1.Controllers
{
    public class HomeController : Controller
    {
         static List<Hang> list = new List<Hang>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Cau1()
        {
            return View();
        }

        public ActionResult Cau2()
        {
            return View();

        }
        
        public ActionResult Ketqua(Hang h)
        {

            list.Add(h);
            ViewBag.list = list;
            return View();
        }
    }
}
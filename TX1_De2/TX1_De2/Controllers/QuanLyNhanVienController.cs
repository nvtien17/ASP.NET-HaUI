using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using TX1_De2.Models;

namespace TX1_De2.Controllers
{
    public class QuanLyNhanVienController : Controller
    {
        // GET: QuanLyNhanVien

        List<NhanVien> danhsach = new List<NhanVien>();
        public ActionResult Index()
        {
            return View();
        }

        public QuanLyNhanVienController()
        {
            danhsach.Add(new NhanVien("Nv01","Nguyễn Văn Anh", "Nam","Hà Nội",15,200000));
            danhsach.Add(new NhanVien("Nv02", "Nguyễn Văn B", "Nam", "Hải Phòng", 27, 250000));
            danhsach.Add(new NhanVien("Nv03", "Nguyễn Văn C", "Nam", "Quảng Ninh",18, 250000));
            danhsach.Add(new NhanVien("Nv04", "Nguyễn Văn D", "Nam", "Hà nội", 25, 190000));
            danhsach.Add(new NhanVien("Nv05", "Nguyễn Văn E", "Nam", "Hà nội", 20, 280000));

        }
        public ActionResult ShowList()
        {
            List<NhanVien> list1 = new List<NhanVien>();
            List<NhanVien> list2 = new List<NhanVien>();
            foreach (var item in danhsach)
            {
                if (item.songaylam < 20) list1.Add(item);
                if (item.luongngay > 190000) list2.Add(item);
            }
            ViewBag.list1 = list1;
            ViewBag.list2 = list2;
            return View();
        }

        public ActionResult Nhap()
        {
            return View();
           
        }
        public ActionResult Xuat(NhanVien h)
        {
            bool check = true; ;
            if (h.manv.IsEmpty() || h.hoten.IsEmpty() || h.diachi.IsEmpty() || h.songaylam == 0 || h.luongngay == 0)
            {
                check = false;
            }
            if (!check)
            {
                return View("Error");
            }
            return View(h);
        }
    }
}
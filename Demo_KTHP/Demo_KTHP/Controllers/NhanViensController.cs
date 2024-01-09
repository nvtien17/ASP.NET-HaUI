using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo_KTHP.Models;

namespace Demo_KTHP.Controllers
{
    public class NhanViensController : Controller
    {
        private QLNhanVienDB db = new QLNhanVienDB();

        // GET: NhanViens
        public ActionResult Index()
        {
            var nhanViens = db.NhanViens.Include(n => n.Phong);
            return View(nhanViens.ToList());
        }
        [ChildActionOnly]
        public PartialViewResult Menu()
        {
            var list = db.Phongs.ToList();
            return PartialView(list);
        }

        [Route("danhmuc/{Maphong}")]
        public ActionResult ListMenu(int Maphong)
        {
            var list = db.NhanViens.Where(x => x.Maphong == Maphong).ToList();

            return View(list);
        }

        // GET: NhanViens/Create
        public ActionResult Create()
        {
            ViewBag.Maphong = new SelectList(db.Phongs, "Maphong", "Tenphong");
            return View();
        }

        // POST: NhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(NhanVien nv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.NhanViens.Add(nv);
                    db.SaveChanges();
                }
                return Json(new { result = true, JsonRequestBehavior.AllowGet });

            }
            catch (Exception e)
            {

                return Json(new { result = false, error = e.Message });

            }
        }

 

        // GET: NhanViens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

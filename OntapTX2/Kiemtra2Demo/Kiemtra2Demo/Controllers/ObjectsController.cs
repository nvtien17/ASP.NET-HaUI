using Kiemtra2Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Kiemtra2Demo.Controllers
{
    public class ObjectsController : Controller
    {
        // GET: Objects
        public ActionResult Index()
        {
            return View();
        }
        private QLSanPhamDB db = new QLSanPhamDB();

        public ActionResult XemDanhSach(string timkiem, string sx)
        {
            var products = db.Products.Select(p => p);
            if (!String.IsNullOrEmpty(timkiem))
            {
                int x = int.Parse(timkiem);
                products = products.Where(p => p.Price >= x);
            }
            ViewBag.sapxep = sx == "soluong" ? "soluong_desc" : "soluong";
            switch(sx)
            {
                case "soluong":
                    products = products.OrderBy(p => p.Quantity);
                    break;
                case "soluong_desc":
                    products = products.OrderByDescending(p => p.Quantity);
                    break;
            }
            return View(products.ToList());
        }
        public ActionResult ThemDuLieu()
        {
            ViewBag.CatalogyID = new SelectList(db.Catalogies, "CatalogyID", "CatalogyName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemDuLieu([Bind(Include = "ProductID,ProductName,Description,PurchasePrice,Price,Quantity,Vintage,CatalogyID,Image,Region")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var f = Request.Files["ImageFile"];
                    if (f != null)
                    {
                        string fileName = System.IO.Path.GetFileName(f.FileName);
                        string path = Server.MapPath("~/Images/" + fileName);
                        f.SaveAs(path);
                        product.Image = fileName;
                    }
                    db.Products.Add(product);
                    db.SaveChanges();
                    
                }
                return RedirectToAction("XemDanhSach");
            }
            catch (Exception e)
            {
                ViewBag.error = "Lỗi thêm dữ liệu!" + e.Message;
                ViewBag.CatalogyID = new SelectList(db.Catalogies, "CatalogyID", "CatalogyName", product.CatalogyID);
                return View(product);
      
            }
           
        }
        public ActionResult XoaDuLieu(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("XoaDuLieu")]
        [ValidateAntiForgeryToken]
        public ActionResult XacNhanXoa(int id)
        {
            try
            {
                Product product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return RedirectToAction("XemDanhSach");
            }
            catch (Exception e)
            {
                ViewBag.error = "Lỗi xóa dữ liệu!" + e.Message;
                return View(id);
            }
            
        }

    }
}
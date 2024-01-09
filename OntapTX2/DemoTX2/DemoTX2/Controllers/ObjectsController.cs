using DemoTX2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DemoTX2.Controllers
{
    public class ObjectsController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        private QLSanPhamDB db = new QLSanPhamDB();


        public ActionResult XemDanhSach(string input)
        {
            var products = db.Products.Select(p => p);
            if (!String.IsNullOrEmpty(input))
            {
                int x = int.Parse(input);
                products = products.Where(p => p.Price >= x);
            }
            return View(products.ToList());


        }
        public ActionResult ThemDuLieu()
        {
            ViewBag.CatalogyID = new SelectList(db.Catalogies, "CatalogyID", "CatalogyName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemDuLieu([Bind(Include = "ProductID,ProductName,Description,PurchasePrice,Price,Quantity,Vintage,CatalogyID,Image,Region")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var file = Request.Files["Image"];
                    if (file != null)
                    {
                        string fileName = System.IO.Path.GetFileName(file.FileName);
                        string path = Server.MapPath("~/HinhAnh/" + fileName);
                        file.SaveAs(path);
                        product.Image = fileName;
                    }
                    db.Products.Add(product);
                    db.SaveChanges();
                    
                }
                return RedirectToAction("XemDanhSach");
            }
            catch (Exception ex)
            {
                ViewBag.error = "Lỗi thêm dữ liệu : " + ex.Message;
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
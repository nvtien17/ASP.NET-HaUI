using baiktra2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace baiktra2.Controllers
{
    public class ObjectsController : Controller
    {
        // GET: Objects
        public ActionResult Index()
        {
            return View();
        }

        private QLSanPhamDB db = new QLSanPhamDB();

        // GET: Products
        public ActionResult XemDanhSach(string search)
        {
            var products = db.Products.Select(p => p);
            if (!String.IsNullOrEmpty(search))
            {
                int x = int.Parse(search);
                products = products.Where(p => p.Price > x);
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
                ViewBag.error = "loi " + e.Message;
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
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("XemDanhSach");
        }
    }
}
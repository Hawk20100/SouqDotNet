using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
//
using SouqDotNet.Models.Context;
using SouqDotNet.Models.Entities;

namespace SouqDotNet.Controllers
{
    public class ProductsController : Controller
    {
        SouqContext db = new SouqContext();
        
        public FileContentResult ImageUplaod(string path)
        {
            path = Path.Combine(Server.MapPath("~/Uploads/ProductImages/") + path);
            byte[] photoArray = System.IO.File.ReadAllBytes(path);
            return new FileContentResult(photoArray, "image.jpg");
        }

        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.categoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Product newProduct)
        {
            if (ModelState.IsValid)
            {
                string _fileName = Path.GetFileNameWithoutExtension(newProduct.FilePhoto.FileName);
                string _extension = Path.GetExtension(newProduct.FilePhoto.FileName);
                _fileName = _fileName + DateTime.Now.ToString("yyMMddhhmmssfff") + _extension;
                newProduct.ImageUrl = _fileName;

                _fileName = Path.Combine(Server.MapPath("~/Uploads/ProductImages/") + _fileName);
                newProduct.FilePhoto.SaveAs(_fileName);

                db.Products.Add(newProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newProduct);
         
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.categoryId = new SelectList(db.Categories, "Id", "Name");
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            TempData.Add("product", product.ImageUrl);
            return View(product);
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Product updateProduct)
        {
            //string _fileName = Path.GetFileNameWithoutExtension(updateProduct.FilePhoto.FileName);
            //string _extension = Path.GetExtension(updateProduct.FilePhoto.FileName);
            //_fileName = _fileName + DateTime.Now.ToString("yyMMddhhmmssfff") + _extension;
            //updateProduct.ImageUrl = _fileName;

            if (ModelState.IsValid)
            {
                string _fileName = Path.Combine(Server.MapPath("~/Uploads/ProductImages/") + TempData["product"].ToString());
                updateProduct.ImageUrl = TempData["product"].ToString();
                TempData.Remove("product");
                if (updateProduct.FilePhoto != null)
                    updateProduct.FilePhoto.SaveAs(_fileName);
                db.Entry(updateProduct).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(updateProduct);
            
        }

        [HttpGet]
        public ActionResult Details(int? id)
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

        //[ValidateAntiForgeryToken]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product DeletedProduct = db.Products.Find(id);
            if (DeletedProduct == null)
            {
                return HttpNotFound();
            }
            return View(DeletedProduct);
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(Product deletedProduct)
        {
            db.Entry(deletedProduct).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Search(string name)
        {
            var SearchedProduct = db.Products.Where(p => p.ProductName.StartsWith(name));
            return View("Index",SearchedProduct.ToList());
        }
    }
}
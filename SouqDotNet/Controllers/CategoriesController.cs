using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
//
using SouqDotNet.Models.Context;
using SouqDotNet.Models.Entities;

namespace SouqDotNet.Controllers
{
    public class CategoriesController : Controller
    {
        SouqContext db = new SouqContext();
        // GET: Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Category newCategory)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(newCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newCategory);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Category updatedCatgory)
        {
            db.Entry(updatedCatgory).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category DeletedCategory = db.Categories.Find(id);
            if (DeletedCategory == null)
            {
                return HttpNotFound();
            }
            return View(DeletedCategory);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(Category deletedCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deletedCategory).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deletedCategory);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Search(string name)
        {
            var SearchEmployee = db.Categories.Where(q => q.Name.Contains(name));
            return View("Index",SearchEmployee.ToList());
        }
    }
}
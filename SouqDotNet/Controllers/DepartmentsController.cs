using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//
using SouqDotNet.Models.Entities;
using SouqDotNet.Models.Context;
using System.Net;

namespace SouqDotNet.Controllers
{
    public class DepartmentsController : Controller
    {
        SouqContext db = new SouqContext();
        // GET: Department
        public ActionResult Index()
        {
            return View(db.Departments.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Department newDepartment)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(newDepartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newDepartment);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department ==  null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Department updatedDepartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(updatedDepartment).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(updatedDepartment);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department== null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department DeletedDepartment = db.Departments.Find(id);
            if (DeletedDepartment == null)
            {
                return HttpNotFound();
            }
            return View(DeletedDepartment);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(Department deletedDepartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deletedDepartment).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deletedDepartment);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Search(string name)
        {
            var SearchedDepartment = db.Departments.Where(d => d.Name.Contains(name));
            return View("Index",SearchedDepartment.ToList());
        }
    }
}
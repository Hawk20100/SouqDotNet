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
    public class EmployeesController : Controller
    {
        SouqContext db = new SouqContext();
        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.departmentID = new SelectList(db.Departments, "ID", "Name");
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Employee newEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(newEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newEmployee);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.departmentID = new SelectList(db.Departments, "ID", "Name");
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Employee updateEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(updateEmployee).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(updateEmployee);
           
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee ==  null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee DeletedEmployee = db.Employees.Find(id);
            if (DeletedEmployee == null)
            {
                return HttpNotFound();
            }
            return View(DeletedEmployee);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(Employee deletedEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deletedEmployee).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deletedEmployee);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Search(string name)
        {
            var Searchedemployee = db.Employees.Where(e => e.Name.Contains(name));
            return View("Index",Searchedemployee.ToList());
        }
    }
}
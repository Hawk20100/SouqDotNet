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
    public class CustomersController : Controller
    {
        SouqContext db = new SouqContext();   
        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Customer newCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(newCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newCustomer);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Customer updatedCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(updatedCustomer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(updatedCustomer);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id ==  null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer DeleteCustomer = db.Customers.Find(id);
            if (DeleteCustomer== null)
            {
                return HttpNotFound();
            }
            return View(DeleteCustomer);
        }

       //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(Customer deletedCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deletedCustomer).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deletedCustomer);
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Search(string name)
        {
            var SearchedCustomer = db.Customers.Where(e => e.CustomerName.Contains(name));
            return View("Index",SearchedCustomer.ToList());
        }
    }
}
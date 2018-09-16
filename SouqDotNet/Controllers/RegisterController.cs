using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//
using SouqDotNet.Models.Context;
using SouqDotNet.Models.Entities;
namespace SouqDotNet.Controllers
{
    public class RegisterController : Controller
    {
        SouqContext db = new SouqContext();

        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserRegister(User newUser)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(newUser);
                db.SaveChanges();
                return RedirectToAction("Index", "Login");
            }
            return View(newUser);
        }
    }
}
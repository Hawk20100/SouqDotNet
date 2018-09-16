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
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAutherize(User loginUser)
        {
            using (SouqContext db = new SouqContext())
            {

                var User = db.Users.Where(q => q.Username == loginUser.Username
                && q.Password == loginUser.Password).FirstOrDefault();
                if (User== null)
                {
                    ViewBag.Error = "Username Or Password is Invalid..";
                    return View("Index", loginUser);
                }
                else
                {
                    Session["Username"] = loginUser.Username;
                    return RedirectToAction("Index", "Home");
                }
            }
            
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
    }
}
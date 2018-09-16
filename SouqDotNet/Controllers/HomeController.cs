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
    public class HomeController : Controller
    {
        SouqContext db = new SouqContext();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
    }
}
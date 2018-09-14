using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//
using SouqDotNet.Models.Context; 
namespace SouqDotNet.Controllers
{
    public class ManagementsController : Controller
    {
        SouqContext db = new SouqContext();
        // GET: Management
        public ActionResult Index()
        {
            return View();
        }
    }
}
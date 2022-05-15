using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 10, VaryByParam = "*")]
        public ActionResult Index()
        {
            ViewBag.TestTime = System.DateTime.Now.ToString();
            return View();
        }


    }
}
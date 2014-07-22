﻿using System.Web.Mvc;

namespace Stefans.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.HeaderFixed = true;
            return View();
        }

        public ActionResult Test()
        {
            ViewBag.Message = "satesto";
            return View("Message");
        }
    }
}
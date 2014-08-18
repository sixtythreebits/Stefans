using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.CM;
using Core.Properties;

namespace Stefans.Areas.Admin.Controllers
{
    public class ContactsController : Controller
    {
        //
        // GET: /Admin/Contacts/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContactsGrid()
        {
            var model = new Contact().ListContacts();
            ViewBag.DateFormat = Resources.LongDateFormat;
            return PartialView("_ContactsGrid", model);
        }
	}
}
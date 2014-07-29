using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.CM;

namespace Stefans.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int ID)
        {
            if (ID > 0)
            {
                var model = new Product().GetSingle(ID, true);
                if (model != null)
                {
                    return View(model);
                }
            }
            return HttpNotFound();
        }
    }
}
using System.Web.Mvc;

namespace Stefans.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View("CreateEdit");
        }
    }
}
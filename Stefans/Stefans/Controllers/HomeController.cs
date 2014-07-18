using System.Web.Mvc;
using Lib;

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
            return Content("3a22kgle3zbkk000".DecryptWeb());
        }
    }
}
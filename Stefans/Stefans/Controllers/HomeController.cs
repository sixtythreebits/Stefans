using System.Web.Mvc;
using Core.CM;

namespace Stefans.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.HomePage = true;
            ViewBag.Products = new Product().GetTopFeatured();
            return View();
        }

        public ActionResult Test()
        {
            ViewBag.Message = "satesto";
            return View("Message");
        }
    }
}
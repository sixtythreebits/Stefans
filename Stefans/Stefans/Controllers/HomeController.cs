using System.Web.Mvc;
using Core.CM;
using Stefans.Reusable.FrameworkExtensions;

namespace Stefans.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.HomePage = true;
            ViewBag.Products = new Product().GetTopFeatured();
            return View();
        }

        public ActionResult Message()
        {
            ViewBag.IsError = ErrorMessage != null;
            ViewBag.Message = ErrorMessage ?? SuccessMessage;

            return View("Message");
        }

        [HttpPost]
        public ActionResult AddContact(Contact Contact)
        {
            return View("Index", Contact);
        }
    }
}
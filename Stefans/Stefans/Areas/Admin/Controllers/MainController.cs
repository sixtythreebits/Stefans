using System.Web.Mvc;

namespace Stefans.Areas.Admin.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
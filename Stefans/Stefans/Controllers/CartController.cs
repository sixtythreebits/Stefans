using System.Web.Mvc;
using Stefans.Reusable.Attributes;

namespace Stefans.Controllers
{
    [SecureAccess]
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(int ID)
        {
            if (ID > 0)
            {
            }
            return HttpNotFound();
        }
    }
}
using System.Web.Mvc;
using Core.CM;
using Core.Properties;
using Stefans.Reusable.Attributes;
using Stefans.Reusable.FrameworkExtensions;

namespace Stefans.Controllers
{
    [SecureAccess]
    public class CartController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(int ID)
        {
            if (ID > 0)
            {
                var repo = new CartItem();
                repo.TSP(0, null, User.ID, ID, 1);

                if (repo.IsError)
                {
                    ErrorMessage = Resources.Fail;
                }
                else
                {
                    SuccessMessage = Resources.Success;
                }
                return RedirectToAction("Details", "Product", new { ID });
            }
            return HttpNotFound();
        }
    }
}
using System.Web.Mvc;
using Core.CM;
using Stefans.Reusable.Attributes;
using Stefans.Reusable.FrameworkExtensions;
using Res = Core.Properties.Resources;

namespace Stefans.Controllers
{
    public class ProductController : BaseController
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

        [SecureAccess]
        public ActionResult AddToFavourites(int ID)
        {
            if (ID > 0)
            {
                var repo = new Favourite();
                repo.TSP(0, null, User.ID, ID);

                if (repo.IsError)
                {
                    ErrorMessage = Res.Fail;
                }
                else
                {
                    SuccessMessage = Res.Success;
                }

                return RedirectToAction("Details", "Product", new { ID });
            }
            return HttpNotFound();
        }
    }
}
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
        private readonly CartItem _cartRepository = new CartItem();

        public ActionResult Index()
        {
            var model = _cartRepository.GetList(User.ID);
            return View(model);
        }

        public ActionResult Add(int ID)
        {
            if (ID > 0)
            {
                _cartRepository.TSP(0, null, User.ID, ID, 1);
                if (_cartRepository.IsError)
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

        public ActionResult Remove(int ID)
        {
            if (ID > 0)
            {
                _cartRepository.TSP(2, null, User.ID, ID);
                if (_cartRepository.IsError)
                {
                    ErrorMessage = Resources.Fail;
                }
                else
                {
                    SuccessMessage = Resources.Success;
                }
                return RedirectToAction("Index", "Cart");
            }
            return HttpNotFound();
        }
    }
}
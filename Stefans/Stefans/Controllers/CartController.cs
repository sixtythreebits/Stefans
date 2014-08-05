using System.Threading.Tasks;
using System.Web.Mvc;
using Core;
using Core.CM;
using Core.Properties;
using Stefans.Models;
using Stefans.Reusable;
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
            return View(InitCheckoutModel(new CheckoutModel(User)));
        }

        [HttpPost]
        public async Task<ActionResult> Checkout(CheckoutModel Model)
        {
            if (ModelState.IsValid)
            {
                await ADNAssistant.SubmitPaymentTransactionAsync(2, Model.Card, Model.Billing);
            }
            return View("Index", InitCheckoutModel(Model));
        }

        private CheckoutModel InitCheckoutModel(CheckoutModel Model)
        {
            Model.CartItems = _cartRepository.GetList(User.ID);
            Model.States = new Dictionary().ListDictionaries(1, 1).ToSelectList(m => m.ID, m => m.Caption);
            return Model;
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

        public ActionResult Update(int ID, int Quantity)
        {
            if (ID > 0)
            {
                if (Quantity > 0)
                {
                    _cartRepository.TSP(1, null, User.ID, ID, Quantity);
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

                if (Quantity == 0)
                {
                    return RedirectToAction("Remove", "Cart", new { ID });
                }

                return RedirectToAction("Index", "Cart");
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
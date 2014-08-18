using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Core;
using Core.CM;
using Core.Properties;
using Core.Utilities;
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
                var amount = new CartItem().GetTotalAmount(User.ID);
                var postString = BuildADNPostString(amount, Model);

                var adnRepo = new ADNTransaction();
                await adnRepo.SubmitPaymentTransactionAsync(ConfigAssistant.ADNApiUrl, postString);

                if (Model.Card.CardNumber.Length > 4)
                {
                    postString = postString.Replace(Model.Card.CardNumber, "XXXX-XXXX-XXXX-" + Model.Card.CardNumber.Substring(Model.Card.CardNumber.Length - 4, 4));
                }

                if (adnRepo.IsTransactionSuccessful)
                {
                    var xml = BuildOrderXml(Model, postString, adnRepo.TransactionResponseString, adnRepo.TransactionID);
                    var orderRepo = new Order();
                    orderRepo.TX(0, xml);

                    if (!orderRepo.IsError && orderRepo.ID > 0)
                    {
                        var mail = RenderRazorViewToString("CheckoutConfirmationEmail", orderRepo);
                        Task.Run(() => new Mail().Send(User.Email, "Order confirmation", mail));

                        SuccessMessage = Resources.Success;
                        return RedirectToAction("Profile", "Account");
                    }

                    ErrorMessage = Resources.Fail;
                    return RedirectToAction("Message", "Home");
                }

                new ADNTransaction().Create(User.ID, null, postString, adnRepo.TransactionResponseString);

                if (!adnRepo.IsCardNumberValid)
                {
                    ModelState.AddModelError(() => Model.Card.CardNumber, Resources.ErrorADNCardNumber);
                }
                else if (!adnRepo.IsExpDateValid)
                {
                    ModelState.AddModelError(() => Model.Card.Month, Resources.ErrorADNExpDate);
                    ModelState.AddModelError(() => Model.Card.Year, Resources.ErrorADNExpDate);
                }
                else if (!adnRepo.IsCCVValid)
                {
                    ModelState.AddModelError(() => Model.Card.CCV, Resources.ErrorADNCCV);
                }
                else
                {
                    ModelState.AddModelError(() => Model.Card, Resources.Fail);
                }
            }
            return View("Index", InitCheckoutModel(Model));
        }

        private static string BuildADNPostString(decimal Amount, CheckoutModel Model)
        {
            var postValues = new Dictionary<string, string>
                {
                    {"x_login", ConfigAssistant.ADNLogin},
                    {"x_tran_key", ConfigAssistant.ADNTransactionKey},
                    {"x_version", "3.0"},
                    {"x_amount", Amount.ToString()},
                    //{"x_description", PI.Description},
                    {"x_card_num", Model.Card.CardNumber},
                    {"x_exp_date", Model.Card.Month + Model.Card.Year},
                    {"x_card_code", Model.Card.CCV},
                    {"x_first_name", Model.Card.FirstName},
                    {"x_last_name ", Model.Card.LastName},
                    {"x_city", Model.Billing.City},
                    {"x_address", Model.Billing.Address1},
                    //{"x_state", PI.State},
                    {"x_zip ", Model.Billing.Zip},
                    //{"x_country", Billing.couy},
                    //{"x_customer_ip", PI.IP},
                    {"x_delim_data", "TRUE"},
                    {"x_delim_char", ADNTransaction.TransactionReponseDelimiter.ToString()},
                    {"x_relay_response", "FALSE"}
                };

            var sb = postValues.Aggregate(new StringBuilder(), (aggregated, current) => aggregated.AppendFormat("{0}={1}&", current.Key, HttpUtility.UrlEncode(current.Value)));
            return sb.ToString();
        }

        private string BuildOrderXml(CheckoutModel Model, string ADNRequest, string ADNResponse, string ADNTransactionID)
        {
            var addressArray = new[] {new { CodeVal = 1, Address = Model.Shipping }, new { CodeVal = 2, Address = Model.Billing }};

            var addressXml = addressArray.Select(a => string.Format(@"
            <address>
                <type_code_val>{0}</type_code_val>
                <state_id>{1}</state_id>
                <first_name>{2}</first_name>
                <last_name>{3}</last_name>
                <address1>{4}</address1>
                <address2>{5}</address2>
                <zip>{6}</zip>
                <city>{7}</city>
                <phone>{8}</phone>
            </address>
            ", a.CodeVal
             , a.Address.StateID
             , a.Address.FirstName.WrapWithCData()
             , a.Address.LastName.WrapWithCData()
             , a.Address.Address1.WrapWithCData()
             , a.Address.Address2.WrapWithCData()
             , a.Address.Zip.WrapWithCData()
             , a.Address.City.WrapWithCData()
             , a.Address.Phone.WrapWithCData())).JoinStrings();

            var xml = string.Format(@"
            <data>
                <user_id>{0}</user_id>
                <addresses>{1}</addresses>
                <adn>
                    <request>{2}</request>
                    <response>{3}</response>
                    <transaction_id>{4}</transaction_id>
                </adn>
            </data>", 
            User.ID,
            addressXml,
            ADNRequest.WrapWithCData(),
            ADNResponse.WrapWithCData(),
            ADNTransactionID.WrapWithCData());

            return xml;
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
                //return RedirectToAction("Details", "Product", new { ID });
                return Redirect(Request.UrlReferrer.AbsoluteUri);
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
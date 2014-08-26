using System.Web.Mvc;
using Core.CM;
using Stefans.Reusable.FrameworkExtensions;
using Core;
using Core.Properties;

namespace Stefans.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.HomePage = true;
            ViewBag.Products = new Product().GetTopFeatured();
            ViewBag.PromoImages = new PromoImage().List_PromoImages();            

            ViewBag.States = new Dictionary().ListDictionaries(1, 1);
            ViewBag.Topic = new Dictionary().ListDictionaries(1, 6);
            ViewBag.LicensedHairCareProfessional = new Dictionary().ListDictionaries(1, 5);

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
            if (ModelState.IsValid)
            {
                Contact.IP = Request.UserHostAddress;
                if (User != null)
                {
                    Contact.UserID = User.ID; 
                }               

                Contact.TSP_Contacts(0, null, Contact.UserID, Contact.StateID, Contact.FirstName, Contact.LastName, Contact.Email, Contact.Phone, Contact.City,
                    Contact.LicensedHairCareProfessionalID, Contact.TopicID, Contact.Message, Contact.IP);

                if (Contact.IsError)
                {
                    ErrorMessage = Resources.Fail;
                }
                else
                {
                    SuccessMessage = Resources.Success;
                }
                return RedirectToAction("Index", "Home");
            }

            ViewBag.States = new Dictionary().ListDictionaries(1, 1);
            ViewBag.Topic = new Dictionary().ListDictionaries(1, 6);
            ViewBag.LicensedHairCareProfessional = new Dictionary().ListDictionaries(1, 5);

            ViewBag.ScrollTo = "#contact";

            return View("Index", Contact);
        }
    }
}
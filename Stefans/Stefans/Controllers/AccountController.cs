using System.Web.Mvc;
using Stefans.Models;

namespace Stefans.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationModel Input)
        {
            return View(Input);
        }
    }
}
using System.Web.Mvc;
using Core.UM;
using Lib;
using Stefans.Reusable;
using Stefans.Reusable.Attributes;

namespace Stefans.Areas.Admin.Controllers
{
    [AdminAuthentication]
    public class MainController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult LogIn()
        {
            return View();
        }

        [AllowAnonymous, HttpPost]
        public ActionResult LogIn(string Email, string Password)
        {
            if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
            {
                var user = new User().GetSingle(null, Email);
                if (user != null && user.IsAdmin && user.Password == Password.MD5())
                {
                    Session.SetUser(user);
                    return RedirectToAction("Index", "Product");
                }
            }
            ViewBag.Message = "Wrong Credentials";
            return View();
        }
    }
}
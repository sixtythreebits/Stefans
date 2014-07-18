using System.Web.Mvc;
using Stefans.Models;
using Stefans.Reusable;
using UM;
using Res = General.Properties.Resources;

namespace Stefans.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationModel Model)
        {
            if (Model.ConfirmPassword != Model.User.Password)
            {
                ModelState.AddModelError(() => Model.ConfirmPassword, Res.ErrorPasswordMismatch);
            }

            var repo = new User();
            if (!repo.IsEmailUnique(Model.User.Email))
            {
                ModelState.AddModelError(() => Model.User.Email, Res.ErrorEmailDuplication);
            }

            if (ModelState.IsValid)
            {
                repo.TSP_Users(0, null, Model.User.Password, Model.User.FirstName, Model.User.LastName, Model.User.Email);

                if (!repo.IsError)
                {
                    return Content("yes it is!");
                }
            }

            return View(Model);
        }
    }
}
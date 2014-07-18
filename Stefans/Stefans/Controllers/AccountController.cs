using System.Threading.Tasks;
using System.Web.Mvc;
using General;
using Stefans.Models;
using Stefans.Reusable;
using UM;
using Lib;
using Res = General.Properties.Resources;

namespace Stefans.Controllers
{
    public class AccountController : BaseController
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

                if (!repo.IsError && repo.ID > 0)
                {
                    var mailBody = RenderRazorViewToString("EmailActivation", repo.ID);
                    Task.Run(() =>
                    {
                        var mail = new Mail();
                        mail.Send(Model.User.Email, "Account activation", mailBody);
                    });

                    return Content("You have successfully registered. Please follow the link we sent on your email to activate your account");
                }
            }

            return View(Model);
        }


        public ActionResult Activate(string ID)
        {
            int userID;
            if (int.TryParse(ID.DecryptWeb(), out userID))
            {
                var repo = new User();
                repo.TSP_Users(1, userID, IsActive: true);

                if (!repo.IsError)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return HttpNotFound();
        }
    }
}
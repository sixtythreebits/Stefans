using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using General;
using Newtonsoft.Json;
using Stefans.Models;
using Stefans.Reusable;
using Stefans.Reusable.Attributes;
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
                repo.TSP(0, null, Model.User.Password, Model.User.FirstName, Model.User.LastName, Model.User.Email);

                if (!repo.IsError && repo.ID > 0)
                {
                    var mailBody = RenderRazorViewToString("EmailActivation", repo.ID);
                    Task.Run(() =>
                    {
                        var mail = new Mail();
                        mail.Send(Model.User.Email, "Account activation", mailBody);
                    });

                    ViewBag.Message = "You have successfully registered. Please follow the link we sent on your email to activate your account";
                    return View("Message");
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
                repo.TSP(1, userID, IsActive: true);

                if (!repo.IsError)
                {
                    Session.SetUser(repo.GetSingle(userID));
                    return RedirectToAction("Profile", "Account");
                }
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult SendPasswordResetMail(string Email)
        {
            if (!string.IsNullOrWhiteSpace(Email))
            {
                var user = new User().GetSingle(null, Email);
                if (user != null)
                {
                    var encryptedJson = new
                    {
                        UserID = user.ID,
                        ExparationTime = DateTime.Now
                    }.ToJson().EncryptWeb();
                    var emailBody = RenderRazorViewToString("ResetPasswordEmail", encryptedJson);

                    Task.Run(() =>
                    {
                        var mail = new Mail();
                        mail.Send(Email, "Reset Password", emailBody);
                    });

                    ViewBag.Message = "Please follow the link we sent on your email to reset your password";
                    return View("Message");
                }
            }
            return HttpNotFound();
        }

        public ActionResult ResetPassword(string ID)
        {
            int userID;
            if (IsResetPasswordRequestValid(ID, out userID))
            {
                return View("ResetPassword", new ResetPasswordModel
                {
                    AdditionalData = ID
                });
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordModel Model)
        {
            int userID;
            if (IsResetPasswordRequestValid(Model.AdditionalData, out userID))
            {
                if (Model.ConfirmPassword != Model.Password)
                {
                    ModelState.AddModelError(() => Model.ConfirmPassword, Res.ErrorPasswordMismatch);
                }

                if (ModelState.IsValid)
                {
                    var repo = new User();
                    repo.TSP(1, userID, Model.Password);
                    Session.SetUser(repo.GetSingle(userID));

                    return RedirectToAction("Profile", "Account");
                }

                return View("ResetPassword", Model);
            }
            return HttpNotFound();
        }

        private static bool IsResetPasswordRequestValid(string EncryptedData, out int UserID)
        {
            var data = JsonConvert.DeserializeXNode(EncryptedData.DecryptWeb(), "data").Element("data");
            var userID = data.IntValueOf("UserID");
            var expTime = data.DateTimeValueOf("ExparationTime");
            if (userID.HasValue && userID > 0 && expTime.HasValue && DateTime.Now.Subtract(expTime.Value) < 60.Minutes())
            {
                UserID = userID.Value;
                return true;
            }
            UserID = 0;
            return false;
        }

        [HttpPost]
        public ActionResult Authorize(string Email, string Password)
        {
            if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
            {
                var user = new User().GetSingle(null, Email);
                if (user != null && user.Password == Password.MD5())
                {
                    Session.SetUser(user);
                    return Json(new { Success = true, RedirectUrl = Url.Action("Index", "Home") }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        [SecureAccess]
        public ActionResult Profile()
        {
            ViewBag.States = new Dictionary().ListDictionaries(1, 1);
            return View(new ProfileModel { AccountModel = new AccountModel(new User().GetSingle(User.ID)) });
        }

        [SecureAccess]
        public ActionResult UpdateProfile(AccountModel AccountModel)
        {
            if (ModelState.IsValid)
            {
                var repo = new User();
                repo.TSP(1, 
                        User.ID, 
                        FirstName: AccountModel.FirstName, 
                        LastName: AccountModel.LastName, 
                        Phone: AccountModel.Phone, 
                        Address1: AccountModel.Address1, 
                        Address2: AccountModel.Address2, 
                        StateID: AccountModel.StateID, 
                        City: AccountModel.City,
                        Zip: AccountModel.Zip);

                if (!repo.IsError)
                {
                    return RedirectToAction("Profile", "Account");
                }
            }
            ViewBag.States = new Dictionary().ListDictionaries(1, 1);
            ViewBag.AccountFormValid = false;
            return View("Profile", new ProfileModel { AccountModel = AccountModel });
        }

        [SecureAccess]
        public ActionResult ChangePassword(ChangePasswordModel PasswordModel)
        {
            if (PasswordModel.OriginalPassword != null && User.Password != PasswordModel.OriginalPassword.MD5())
            {
                ModelState.AddModelError(() => PasswordModel.OriginalPassword, Res.ErrorOriginalPassword);
            }

            if (PasswordModel.NewPassword != PasswordModel.ConfirmPassword)
            {
                ModelState.AddModelError(() => PasswordModel.ConfirmPassword, Res.ErrorPasswordMismatch);
            }

            var repo = new User();
            if (ModelState.IsValid)
            {
                repo.TSP(1, User.ID, PasswordModel.NewPassword);

                if (!repo.IsError)
                {
                    Session.SetUser(repo.GetSingle(User.ID));
                    return RedirectToAction("Profile");
                }
            }

            ViewBag.States = new Dictionary().ListDictionaries(1, 1);
            ViewBag.PasswordFormValid = false;
            return View("Profile", new ProfileModel { PasswordModel = PasswordModel, AccountModel = new AccountModel(repo.GetSingle(User.ID)) });
        }
    }
}
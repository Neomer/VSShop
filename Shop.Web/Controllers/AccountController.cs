using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.SDK.Models;
using Shop.SDK.Models.Managers;
using Shop.Web.ViewModels;
using System.Web.Security;

namespace Shop.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserAuthViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = null;
                try
                {
                    user = UserManager.GetUserByLoginPassword(model.Email, model.Password);
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                    return View(model);
                }
                if (user == null)
                {
                    ViewBag.ErrorMessage = "Пользователь не найден!";
                    return View(model);
                }
                FormsAuthentication.SetAuthCookie(user.ID.ToString(), true);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserRegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserModel()
                {
                    ID = Guid.NewGuid(),
                    Email = model.Email,
                    Password = model.Password,
                    RegisterDate = DateTime.Now
                };
                try
                {
                    UserManager.CreateEntity(user);
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                    return View(model);
                }
                return RedirectToAction("Index", "Account");
            }
            return View(model);
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

    }
}
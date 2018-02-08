using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.SDK.Models;
using Shop.SDK.Models.Managers;
using Shop.Web.ViewModels;

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
        public ActionResult Index(UserAuthViewModel model)
        {
            if (ModelState.IsValid)
            {
                
            }

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserModel()
                {
                    Email = model.Email,
                    Password = model.Password,
                    RegisterDate = DateTime.Now

                };
                user = UserManager.CreateUser(user);
                if (user != null)
                {
                    return RedirectToAction("Index", "Account");
                }
            }
            return View();
        }
    }
}
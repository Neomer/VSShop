using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Web.Managers;
using Shop.Web.ViewModels.Ajax;
using Shop.SDK.Models;
using Shop.SDK.Models.Managers;
using Shop.Web.ViewModels;

namespace Shop.Web.Controllers
{
    public class BasketController : Controller
    {
        // GET: Basket
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult AjaxAddProduct(Guid product, double count)
        {
            Guid uid = Guid.Empty;
            if (!Guid.TryParse(User.Identity.Name, out uid))
            {
                return Content(AjaxManager.SerializeAjaxAnswer(AjaxManager.CreateErrorAjaxAnswer(null, "User not found!")));
            }
            var user = UserManager.GetById(uid);
            if (user == null)
            {
                return Content(AjaxManager.SerializeAjaxAnswer(AjaxManager.CreateErrorAjaxAnswer(null, "User not found!")));
            }
            var basket = BasketManager.GetBasketByUser(user).FirstOrDefault();
            if (basket == null)
            {
                basket = BasketManager.CreateBasterForUser(user);
            }
            return Content(
                AjaxManager.SerializeAjaxAnswer(
                    AjaxManager.CreateSuccessAjaxAnswer(
                        new AddProductToBasketViewModel() {
                            Basket = new BasketStatisticViewModel(basket)
                        }
                    )
                )
            );
        }
    }
}
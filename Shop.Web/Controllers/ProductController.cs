using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.SDK.Models.Managers;
using Shop.SDK.Models;
using Shop.Web.ViewModels;

namespace Shop.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(Guid id)
        {
            var product = ProductManager.GetById(id);
            if (product == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new ProductDetailsViewModel(product));
        }
    }
}
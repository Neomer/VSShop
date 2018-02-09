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
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index(Guid id)
        {
            var category = ProductCategoryManager.GetById(id);
            var list = new List<ProductDetailsViewModel>();
            foreach (var p in category.Products)
            {
                list.Add(new ProductDetailsViewModel(p));
            }
            return View(list);
        }
    }
}
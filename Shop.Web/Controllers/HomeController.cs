using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.SDK.Core;
using Shop.SDK.Models;
using Shop.SDK.Models.Managers;

namespace Shop.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Create()
        {
            var category = new ProductCategoryModel()
            {
                ID = Guid.NewGuid(),
                Name = "Category_2"
            };
            ProductCategoryManager.CreateCategory(category);
            var product = new ProductModel()
            {
                ID = Guid.NewGuid(),
                Name = "Product_1",
                Category = category,
                Description = "Description for Product_1"
            };
            ProductManager.CreateProduct(product);

            product = new ProductModel()
            {
                ID = Guid.NewGuid(),
                Name = "Product_2",
                Category = category,
                Description = "Description for Product_2"
            };
            ProductManager.CreateProduct(product);
            product = new ProductModel()
            {
                ID = Guid.NewGuid(),
                Name = "Product_3",
                Category = category,
                Description = "Description for Product_3"
            };
            ProductManager.CreateProduct(product);
            product = new ProductModel()
            {
                ID = Guid.NewGuid(),
                Name = "Product_4",
                Category = category,
                Description = "Description for Product_4"
            };
            ProductManager.CreateProduct(product);

            return RedirectToAction("Index");
        }
    }
}
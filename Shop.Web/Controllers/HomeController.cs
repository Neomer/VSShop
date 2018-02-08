using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.SDK.Core;
using Shop.SDK.Models;

namespace Shop.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var session = NHibernateHelper.Instance.OpenSession();

            var category = new ProductCategoryModel {
                ID = Guid.NewGuid(),
                Name = "Category_1" };

            var product = new ProductModel() {
                ID = Guid.NewGuid(),
                Description = "This is some experimental product!",
                Name = "Product_1",
                Category = category };

            using (var tr = session.BeginTransaction())
            {
                try
                {
                    session.Save(category);
                    session.Save(product);
                    tr.Commit();
                }
                catch (Exception)
                {
                    tr.Rollback();
                }
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
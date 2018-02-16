using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.SDK.Core;
using Shop.SDK.Models;
using Shop.SDK.Models.Managers;
using Shop.Web.ViewModels.Categories;

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
            using (var transaction = NHibernateHelper.Instance.GetCurrentSession().BeginTransaction())
            {
                try
                {
                    var categoryParent = new ProductCategoryModel()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Удилища"
                    };
                    ProductCategoryManager.CreateEntity(categoryParent);
                    var category = new ProductCategoryModel()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Фидерные",
                        Parent = categoryParent
                    };
                    ProductCategoryManager.CreateEntityUnsave(categoryParent);
                    category = new ProductCategoryModel()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Спиннинговые",
                        Parent = categoryParent,
                        Specification = new SpinningRodCategorySpecification()
                    };
                    ProductCategoryManager.CreateEntityUnsave(categoryParent);
                    category = new ProductCategoryModel()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Маховые",
                        Parent = categoryParent
                    };
                    ProductCategoryManager.CreateEntityUnsave(categoryParent);

                    var product = new ProductModel()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Product_1",
                        Category = category,
                        Description = "Description for Product_1"
                    };
                    ProductManager.CreateEntityUnsave(product);

                    product = new ProductModel()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Product_2",
                        Category = category,
                        Description = "Description for Product_2"
                    };
                    ProductManager.CreateEntityUnsave(product);
                    product = new ProductModel()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Product_3",
                        Category = category,
                        Description = "Description for Product_3"
                    };
                    ProductManager.CreateEntityUnsave(product);
                    product = new ProductModel()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Product_4",
                        Category = category,
                        Description = "Description for Product_4"
                    };
                    ProductManager.CreateEntityUnsave(product);

                    var cons = new ConsignmentModel()
                    {
                        ID = Guid.NewGuid(),
                        CreationDate = DateTime.Now
                    };
                    ConsignmentManager.CreateEntityUnsave(cons);

                    var consItem = new ConsignmentItemModel()
                    {
                        Product = product,
                        Cost = 25.23,
                        Count = 34,
                        Consignment = cons
                    };
                    ConsignmentItemManager.CreateEntityUnsave(consItem);

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
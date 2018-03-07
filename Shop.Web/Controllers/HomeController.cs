using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.SDK.Core;
using Shop.SDK.Models;
using Shop.SDK.Models.Managers;
using Shop.Web.ViewModels.Categories;
using System.Xml.Serialization;
using System.IO;

namespace Shop.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var specification = new SpinningRodCategorySpecification();
            specification.Length = 2.3;
            specification.Manufacturer = "Test";
            specification.Test = new Range<int>() { Min = 10, Max = 30 };
            specification.Sections = 2;

            var xml = new XmlSerializer(specification.GetType());

            string ret;
            using (StringWriter textWriter = new StringWriter())
            {
                xml.Serialize(textWriter, specification);
                ret = textWriter.ToString();
            }

            using (var textReader = new StringReader(ret))
            {
                var obj = xml.Deserialize(textReader) as SpinningRodCategorySpecification;
            }

            return View();
        }

        public ActionResult Create()
        {
            using (var transaction = NHibernateHelper.Instance.GetCurrentSession().BeginTransaction())
            {
                try
                {
                    #region Категория "Удилища"
                    var categoryParent = new ProductCategoryModel()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Удилища"
                    };
                    ManagerFactory.Instance.GetManager<ProductCategoryManager>().SaveEntity(categoryParent);
                    var category = new ProductCategoryModel()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Фидерные",
                        Parent = categoryParent
                    };
                    ManagerFactory.Instance.GetManager<ProductCategoryManager>().SaveEntity(category);
                    category = new ProductCategoryModel()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Спиннинговые",
                        Parent = categoryParent,
                        Specification = null
                    };
                    ManagerFactory.Instance.GetManager<ProductCategoryManager>().SaveEntity(category);
                    category = new ProductCategoryModel()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Маховые",
                        Parent = categoryParent
                    };
                    ManagerFactory.Instance.GetManager<ProductCategoryManager>().SaveEntity(category);
                    #endregion

                    #region Категория "Приманки"
                    var catBaits = new ProductCategoryModel()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Приманки"
                    };
                    ManagerFactory.Instance.GetManager<ProductCategoryManager>().SaveEntity(catBaits);

                    var catSpoons = new ProductCategoryModel()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Блесны",
                        Parent = catBaits
                    };
                    ManagerFactory.Instance.GetManager<ProductCategoryManager>().SaveEntity(catSpoons);

                    var catWaveringSpoon = new ProductCategoryModel()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Колеблющиеся",
                        Parent = catSpoons
                    };
                    ManagerFactory.Instance.GetManager<ProductCategoryManager>().SaveEntity(catWaveringSpoon);

                    var catRotatingSpoon = new ProductCategoryModel()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Вращающиеся",
                        Parent = catSpoons
                    };
                    ManagerFactory.Instance.GetManager<ProductCategoryManager>().SaveEntity(catRotatingSpoon);

                    var catWobblers = new ProductCategoryModel()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Воблеры",
                        Parent = catBaits,
                        Specification = null
                    };
                    ManagerFactory.Instance.GetManager<ProductCategoryManager>().SaveEntity(catWobblers);
                    var catTwisters = new ProductCategoryModel()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Силиконовые приманки",
                        Parent = catBaits
                    };
                    ManagerFactory.Instance.GetManager<ProductCategoryManager>().SaveEntity(catTwisters);
                    #endregion

                    #region Товары для категории Воблеры
                    var productTungsten = new ProductModel()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Bearking Tungsten",
                        Category = catWobblers,
                        Description = "Bearking Tungsten balls long casting 10cm 17.5g New model fishing lures hard bait dive 1.8m minnow,quality professional minnow"
                    };
                    ManagerFactory.Instance.GetManager<ProductManager>().SaveEntity(productTungsten);

                    var productSparrow = new ProductModel()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Bearking Sparrow",
                        Category = catWobblers,
                        Description = "Bearking A+ 2017 hot model fishing lures hard bait 7color for choose 10cm 15g minnow,quality professional minnow depth0.8-1.5m"
                    };
                    ManagerFactory.Instance.GetManager<ProductManager>().SaveEntity(productSparrow);
                    var productPlusOne = new ProductModel()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Bearking Plus One Minnow Pro",
                        Category = catWobblers,
                        Description = "Great Discount!Retail fishing lures,assorted colors quality Minnow 110mm 14g,Tungsten ball bearking 2017 model crank bait"
                    };
                    ManagerFactory.Instance.GetManager<ProductManager>().SaveEntity(productPlusOne);
                    #endregion

                    #region Поставки для товаров категории "Воблеры"
                    var random = new Random(DateTime.Now.Millisecond + DateTime.Now.Second * 1000);
                    var cons = new ConsignmentModel()
                    {
                        ID = Guid.NewGuid(),
                        CreationDate = DateTime.Now
                    };
                    ManagerFactory.Instance.GetManager<ConsignmentManager>().SaveEntity(cons);

                    var consItem = new ConsignmentItemModel()
                    {
                        Product = productSparrow,
                        Cost = random.Next() % 1000 + Math.Round(random.NextDouble(), 2),
                        Count = random.Next() % 100,
                        Consignment = cons
                    };
                    ManagerFactory.Instance.GetManager<ConsignmentItemManager>().SaveEntity(consItem);

                    cons = new ConsignmentModel()
                    {
                        ID = Guid.NewGuid(),
                        CreationDate = DateTime.Now
                    };
                    ManagerFactory.Instance.GetManager<ConsignmentManager>().SaveEntity(cons);

                    consItem = new ConsignmentItemModel()
                    {
                        Product = productSparrow,
                        Cost = random.Next() % 1000 + Math.Round(random.NextDouble(), 2),
                        Count = random.Next() % 100,
                        Consignment = cons
                    };
                    ManagerFactory.Instance.GetManager<ConsignmentItemManager>().SaveEntity(consItem);

                    cons = new ConsignmentModel()
                    {
                        ID = Guid.NewGuid(),
                        CreationDate = DateTime.Now
                    };
                    ManagerFactory.Instance.GetManager<ConsignmentManager>().SaveEntity(cons);
                    consItem = new ConsignmentItemModel()
                    {
                        Product = productSparrow,
                        Cost = random.Next() % 1000 + Math.Round(random.NextDouble(), 2),
                        Count = random.Next() % 100,
                        Consignment = cons
                    };
                    ManagerFactory.Instance.GetManager<ConsignmentItemManager>().SaveEntity(consItem);
                    #endregion

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
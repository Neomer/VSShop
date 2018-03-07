using Shop.SDK.Models;
using Shop.SDK.Models.Managers;
using Shop.Web.Managers;
using Shop.Web.ViewModels;
using Shop.Web.ViewModels.Ajax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class ConsignmentController : Controller
    {
        // GET: Consignment
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult AjaxGetProductConsignments(Guid productId)
        {
            var product = ManagerFactory.Instance.GetManager<ProductManager>().GetById(productId) as ProductModel;
            if (product == null)
            {
                return Content(AjaxManager.SerializeAjaxAnswer(AjaxManager.CreateErrorAjaxAnswer(null, "Товар не найден!")));
            }
            var cons = ManagerFactory.Instance.GetManager<ConsignmentItemManager>().GetByProduct(product);

            return Content(
                AjaxManager.SerializeAjaxAnswer(
                    AjaxManager.CreateSuccessAjaxAnswer(
                        new GetProductConsignmentsViewModel(cons)
                    )
                )
            );
        }

        [Authorize]
        [HttpGet]
        public ActionResult AjaxSelectConsignment(Guid consignmentId, Guid productId)
        {
            var product = ManagerFactory.Instance.GetManager<ProductManager>().GetById(productId) as ProductModel;
            if (product == null)
            {
                return Content(AjaxManager.SerializeAjaxAnswer(AjaxManager.CreateErrorAjaxAnswer(null, "Товар не найден!")));
            }
            var cons = product.Consignments.FirstOrDefault(_ => _.Consignment.ID == consignmentId);

            return Content(
                AjaxManager.SerializeAjaxAnswer(
                    AjaxManager.CreateSuccessAjaxAnswer(
                        new ProductConsignmentItemViewModel(cons)
                    )
                )
            );
        }
        
    }
}
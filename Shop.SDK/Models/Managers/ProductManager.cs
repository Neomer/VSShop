using Shop.SDK.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models.Managers
{
    public class ProductManager
    {
        public static ProductModel GetById(Guid id)
        {
            return NHibernateHelper.Instance.GetCurrentSession().Get<ProductModel>(id);
        }

        public static IEnumerable<ProductModel> GetAll()
        {
            return NHibernateHelper.Instance.GetCurrentSession().CreateCriteria<ProductModel>()
                .List<ProductModel>();
        }
    }
}
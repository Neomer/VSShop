using NHibernate.Criterion;
using Shop.SDK.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models.Managers
{
    public class ConsignmentItemManager : BaseManager<ConsignmentItemModel>
    {
        public static IEnumerable<ConsignmentItemModel> GetByProduct(ProductModel model)
        {
            return NHibernateHelper.Instance.GetCurrentSession().CreateCriteria<ConsignmentItemModel>()
                .Add(Expression.Eq("Product", model))
                .List<ConsignmentItemModel>();
        }
    }
}
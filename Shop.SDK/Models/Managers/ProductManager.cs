using NHibernate;
using NHibernate.Criterion;
using Shop.SDK.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models.Managers
{
    public class ProductManager : BaseManager<ProductModel>
    {
        /// <summary>
        /// Вовзращает все продукты указанной категории
        /// </summary>
        /// <param name="category">Категория продукта</param>
        /// <returns></returns>
        public static IEnumerable<ProductModel> GetByCategory(ProductCategoryModel category)
        {
            return NHibernateHelper.Instance.GetCurrentSession().CreateCriteria<ProductModel>()
                .Add(Expression.Eq("Category", category))
                .List<ProductModel>();
        }

        public static double GetProductRemain(ProductModel product)
        {
            var session = NHibernateHelper.Instance.GetCurrentSession();
            try
            {
                ConsignmentItemModel cons = null;

                var ret = session.QueryOver<ProductModel>()
                    .Left.JoinAlias(x => x.Consignments, () => cons)
                    .List<ProductModel>();
            }
            catch (Exception ex)
            { }

            return 0;
        }
    }
}
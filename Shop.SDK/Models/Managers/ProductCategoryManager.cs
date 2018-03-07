using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.SDK.Models;
using Shop.SDK.Core;
using NHibernate.Criterion;

namespace Shop.SDK.Models.Managers
{
    /// <summary>
    /// Менеджер для обслуживания категорий товаров
    /// </summary>
    public class ProductCategoryManager : AbstractManager<ProductCategoryModel>
    {
        /// <summary>
        /// Возвращает список всех категорий верхнего уровня
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductCategoryModel> GetTopLevel()
        {
            return NHibernateHelper.Instance.GetCurrentSession().CreateCriteria<ProductCategoryModel>()
                .Add(Expression.Eq("Parent", null))
                .List<ProductCategoryModel>();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.SDK.Models;
using Shop.SDK.Core;

namespace Shop.SDK.Models.Managers
{
    /// <summary>
    /// Менеджер для обслуживания категорий товаров
    /// </summary>
    public class ProductCategoryManager
    {
        /// <summary>
        /// Вовзращает категорию по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор категории</param>
        /// <returns></returns>
        public static ProductCategoryModel GetById(Guid id)
        {
            return NHibernateHelper.Instance.GetCurrentSession().Get<ProductCategoryModel>(id);
        }

        /// <summary>
        /// Вовзращает список всех категорий
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ProductCategoryModel> GetAll()
        {
            return NHibernateHelper.Instance.GetCurrentSession().CreateCriteria<ProductCategoryModel>()
                .List<ProductCategoryModel>();
        }


    }
}
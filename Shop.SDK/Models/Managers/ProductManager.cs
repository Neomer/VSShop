using NHibernate;
using NHibernate.Criterion;
using Shop.SDK.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models.Managers
{
    public class ProductManager
    {
        /// <summary>
        /// Возвращает продукт по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор продукта</param>
        /// <returns></returns>
        public static ProductModel GetById(Guid id)
        {
            return NHibernateHelper.Instance.GetCurrentSession().Get<ProductModel>(id);
        }

        /// <summary>
        /// Вовзращает список всех продуктов
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ProductModel> GetAll()
        {
            return NHibernateHelper.Instance.GetCurrentSession().CreateCriteria<ProductModel>()
                .List<ProductModel>();
        }

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

        /// <summary>
        /// Создает продукт
        /// </summary>
        /// <param name="model"></param>
        public static void CreateProduct(ProductModel model)
        {
            var session = NHibernateHelper.Instance.GetCurrentSession();
            if (session == null)
            {
                throw new Exception("Не удалось получить сессию Nhibernate");
            }

            using (var tr = session.BeginTransaction())
            {
                try
                {
                    session.Save(model);
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }
        }
    }
}
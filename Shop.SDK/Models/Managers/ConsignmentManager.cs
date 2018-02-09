using Shop.SDK.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models.Managers
{
    /// <summary>
    /// Менеджер для работы с партиями товаров
    /// </summary>
    public class ConsignmentManager
    {
        /// <summary>
        /// Получить партию по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор партии</param>
        /// <returns></returns>
        public static ConsignmentModel GetById(Guid id)
        {
            return NHibernateHelper.Instance.GetCurrentSession().Get<ConsignmentModel>(id);
        }

        /// <summary>
        /// Создает новую партию
        /// </summary>
        /// <param name="model"></param>
        public static void CreateConsignment(ConsignmentModel model)
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
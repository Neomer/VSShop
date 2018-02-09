using Shop.SDK.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models.Managers
{
    public class ConsignmentItemManager
    {
        /// <summary>
        /// Создает новый элемент партию
        /// </summary>
        /// <param name="model"></param>
        public static void CreateConsignment(ConsignmentItemModel model)
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
using NHibernate;
using Shop.SDK.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models.Managers
{
    public abstract class BaseManager<T> where T:BaseEntity
    {
        /// <summary>
        /// Вовзращает список всех сущностей
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<T> GetAll()
        {
            return NHibernateHelper.Instance.GetCurrentSession().CreateCriteria(typeof(T)).List<T>();
        }

        /// <summary>
        /// Возвращает сущность по ее идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        /// <returns></returns>
        public static T GetById(Guid id)
        {
            return NHibernateHelper.Instance.GetCurrentSession().Get<T>(id);
        }

        /// <summary>
        /// Создает сущность
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        public static void CreateEntity(T entity, ITransaction transaction = null)
        {
            var session = NHibernateHelper.Instance.GetCurrentSession();
            if (session == null)
            {
                throw new Exception("Не удалось получить сессию Nhibernate");
            }

            if (transaction == null)
            {
                transaction = session.BeginTransaction();
            }

            try
            {
                session.Save(entity);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
    }
}
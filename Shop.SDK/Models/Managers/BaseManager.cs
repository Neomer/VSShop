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
        /// Создает сущность внутри собственной транзакции
        /// </summary>
        /// <param name="entity"></param>
        public static void CreateEntity(T entity)
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
                    session.Save(entity);
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Сохраняет сущность внутри внешней транзакции
        /// </summary>
        /// <param name="entity"></param>
        public static void CreateEntityUnsave(T entity)
        {
            var session = NHibernateHelper.Instance.GetCurrentSession();
            if (session == null)
            {
                throw new Exception("Не удалось получить сессию Nhibernate");
            }
            session.Save(entity);
        }
    }
}
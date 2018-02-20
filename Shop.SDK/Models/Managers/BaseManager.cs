using NHibernate;
using Shop.SDK.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models.Managers
{
    public abstract class BaseManager : IEntityManager
    {
        void IEntityManager.CreateEntity<T>(T entity)
        {
            var session = NHibernateHelper.Instance.GetCurrentSession();
            if (session == null)
            {
                throw new Exception("Сессия не инициализирована!");
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

        void IEntityManager.CreateEntityUnsave<T>(T entity)
        {
            var session = NHibernateHelper.Instance.GetCurrentSession();
            if (session == null)
            {
                throw new Exception("Сессия не инициализирована!");
            }
            session.Save(entity);
        }

        IEnumerable<T> IEntityManager.GetAll<T>()
        {
            var session = NHibernateHelper.Instance.GetCurrentSession();
            if (session == null)
            {
                throw new Exception("Сессия не инициализирована!");
            }
            return session.CreateCriteria<T>()
                .List<T>();
        }

        T IEntityManager.GetById<T>(Guid id)
        {
            var session = NHibernateHelper.Instance.GetCurrentSession();
            if (session == null)
            {
                throw new Exception("Сессия не инициализирована!");
            }
            return session.Get<T>(id);
        }
    }
}
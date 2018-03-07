using Shop.SDK.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models.Managers
{
    public class AbstractManager<T> : IManager
        where T : IEntity
    {
        public Type GetEntity
        {
            get
            {
                return typeof(T);
            }
        }

        public void CreateEntity(IEntity entity)
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

        public IEnumerable<IEntity> GetAll(int limit = -1)
        {
            return NHibernateHelper.Instance.GetCurrentSession().CreateCriteria(typeof(T)).List<T>() as IEnumerable<IEntity>;
        }

        public IEntity GetById(Guid id)
        {
            return NHibernateHelper.Instance.GetCurrentSession().Get<T>(id);
        }

        public void SaveEntity(IEntity entity)
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
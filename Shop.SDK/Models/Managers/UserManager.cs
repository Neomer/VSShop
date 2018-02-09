using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.SDK.Models;
using NHibernate;
using NHibernate.Criterion;
using Shop.SDK.Core;

namespace Shop.SDK.Models.Managers
{
    public abstract class UserManager
    {
        public static UserModel GetUserByLoginPassword(string email, string password)
        {
            return NHibernateHelper.Instance.GetCurrentSession().CreateCriteria<UserModel>()
                .Add(Expression.Eq("Email", email))
                .Add(Expression.Eq("Password", password))
                .UniqueResult<UserModel>();
        }

        public static IEnumerable<UserModel> GetAll()
        {
            return NHibernateHelper.Instance.GetCurrentSession().CreateCriteria<UserModel>()
                .AddOrder(Order.Asc("Email"))
                .List<UserModel>();
        }

        public static void CreateUser(UserModel model)
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
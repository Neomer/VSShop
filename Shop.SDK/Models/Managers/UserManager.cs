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
    public abstract class UserManager : BaseManager<UserModel>
    {
        public static UserModel GetUserByLoginPassword(string email, string password)
        {
            return NHibernateHelper.Instance.GetCurrentSession().CreateCriteria<UserModel>()
                .Add(Expression.Eq("Email", email))
                .Add(Expression.Eq("Password", password))
                .UniqueResult<UserModel>();
        }
    }
}
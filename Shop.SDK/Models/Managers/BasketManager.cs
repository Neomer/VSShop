using NHibernate.Criterion;
using Shop.SDK.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models.Managers
{
    public class BasketManager : AbstractManager<BasketModel>
    {
        /// <summary>
        /// Возвращает корзины, созданные для пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        public IEnumerable<BasketModel> GetBasketByUser(UserModel user)
        {
            return NHibernateHelper.Instance.GetCurrentSession().CreateCriteria<BasketModel>()
                .Add(Expression.Eq("User", user))
                .List<BasketModel>();
        }
        /// <summary>
        /// Создаёт корзину для пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        public BasketModel CreateBasketForUser(UserModel user)
        {
            var basket = new BasketModel() { ID = Guid.NewGuid(), CreationDate = DateTime.Now, User = user };
            ManagerFactory.Instance.GetManager<BasketManager>().CreateEntity(basket);
            return basket;
        }
    }
}
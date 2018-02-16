using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models
{
    /// <summary>
    /// Корзина с товарами
    /// </summary>
    public class BasketModel : BaseEntity
    {
        /// <summary>
        /// Пользователь-владелец корзины
        /// </summary>
        public virtual UserModel User { get; set; }
        /// <summary>
        /// Дата создания корзины
        /// </summary>
        public virtual DateTime CreationDate { get; set; }
        /// <summary>
        /// Товары, добавленные в корзину
        /// </summary>
        public virtual IList<BasketItemModel> Items { get; set; }
    }
}
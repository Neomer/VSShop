using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models
{
    /// <summary>
    /// Элемент корзины
    /// </summary>
    public class BasketItemModel : IEntity
    {
        /// <summary>
        /// Корзина
        /// </summary>
        public virtual BasketModel Basket { get; set; }
        /// <summary>
        /// Поставка товара
        /// </summary>
        public virtual ConsignmentItemModel Consignment { get; set; }
        /// <summary>
        /// Количество товара
        /// </summary>
        public virtual double Count { get; set; }
        public virtual Guid ID { get; set; }
    }
}
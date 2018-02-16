using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models
{
    /// <summary>
    /// Элемент корзины
    /// </summary>
    public class BasketItemModel : BaseEntity
    {
        /// <summary>
        /// Поставка товара
        /// </summary>
        public virtual ConsignmentItemModel Consignment { get; set; }
        /// <summary>
        /// Количество товара
        /// </summary>
        public virtual double Count { get; set; }
    }
}
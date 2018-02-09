using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models
{
    /// <summary>
    /// Элемент партии
    /// </summary>
    public class ConsignmentItemModel
    {
        /// <summary>
        /// Продукт
        /// </summary>
        public virtual ProductModel Product { get; set; }
        /// <summary>
        /// Цена за штуку товара
        /// </summary>
        public virtual double Cost { get; set; }
        /// <summary>
        /// Количество товара
        /// </summary>
        public virtual double Count { get; set; }
        /// <summary>
        /// Поставка
        /// </summary>
        public virtual СonsignmentModel Consignment { get; set; }
    }
}
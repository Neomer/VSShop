using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models
{
    /// <summary>
    /// Элемент партии
    /// </summary>
    public class ConsignmentItemModel : IEntity
    {
        public virtual Guid ID { get; set; }
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
        public virtual ConsignmentModel Consignment { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var t = obj as ConsignmentItemModel;
            if (t == null)
                return false;
            if (Product == t.Product && Consignment == t.Consignment)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return (Product.Name + "|" + Consignment.ID.ToString()).GetHashCode();
        }
    }
}
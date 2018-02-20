using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models
{
    /// <summary>
    /// Вариант исполнения продукта
    /// </summary>
    public class ProductVariantModel : IEntity
    {
        public virtual ProductModel Product { get; set; }
        public virtual Guid ID { get; set; }
    }
}
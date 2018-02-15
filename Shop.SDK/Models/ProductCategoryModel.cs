using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models
{
    public class ProductCategoryModel : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual ProductCategoryModel Parent { get; set; }
        /// <summary>
        /// Технические характеристики для товаров данной категории
        /// </summary>
        public virtual IProductCategorySpecification Specification { get; set; }
        /// <summary>
        /// Список фильтров
        /// </summary>
        public virtual string Filters { get; set; }

        public virtual IList<ProductModel> Products { get; set; }
        public virtual IList<ProductCategoryModel> SubCategories { get; set; }
    }
}
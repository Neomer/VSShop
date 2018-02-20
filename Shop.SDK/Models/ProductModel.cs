using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models
{
    /// <summary>
    /// Товар
    /// </summary>
    public class ProductModel : IEntity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual ProductCategoryModel Category { get; set; }
        public virtual string Image { get; set; }

        public virtual IList<ProductVariantModel> Variants { get; set; }
        public virtual IEnumerable<ConsignmentItemModel> Consignments { get; set; }
        public virtual Guid ID { get; set; }
    }
}
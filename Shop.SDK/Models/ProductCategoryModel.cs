using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models
{
    public class ProductCategoryModel : IIdentifyed
    {
        public virtual string Name { get; set; }
        public virtual IList<ProductModel> Products { get; set; }
    }
}
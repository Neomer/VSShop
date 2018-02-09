using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models
{
    public class ProductModel : IIdentifyed
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual ProductCategoryModel Category { get; set; }
        public virtual string Image { get; set; }
    }
}
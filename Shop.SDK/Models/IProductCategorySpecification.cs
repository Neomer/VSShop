using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.SDK.Models
{
    public interface IProductCategorySpecification
    {
        IDictionary<string, string> toList();
    }

    public class ProductSpecificationItem
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}

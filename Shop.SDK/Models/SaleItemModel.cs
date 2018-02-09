using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models
{
    /// <summary>
    /// Элемент покупки
    /// </summary>
    public class SaleItemModel
    {
        public virtual ProductModel Product { get; set; }
        public virtual ConsignmentItemModel Consignment { get; set; }
        public virtual SaleModel Sale { get; set; }
        public virtual double Count { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var t = obj as SaleItemModel;
            if (t == null)
                return false;
            if (Product == t.Product && Consignment == t.Consignment && Sale == t.Sale)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return (Product.Name + "|" + Consignment.Consignment.ID.ToString() + "|" + Sale.ID.ToString()).GetHashCode();
        }
    }
}
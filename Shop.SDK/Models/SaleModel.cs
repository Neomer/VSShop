using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models
{
    /// <summary>
    /// Продажа
    /// </summary>
    public class SaleModel : IIdentifyed
    {
        public virtual DateTime CreationDate { get; set; }
        public virtual UserModel Buyer { get; set; }
        public virtual string Address { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual IList<SaleItemModel> Items { get; set; }
    }

    public enum PaymentType
    {
        Cash
    }
}
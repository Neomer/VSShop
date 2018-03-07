using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models
{
    public class BaseEntity : IEntity
    {
        public virtual Guid ID { get; set; }
    }
}
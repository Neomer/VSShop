using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models
{
    public abstract class IIdentifyed
    {
        public virtual Guid ID { get; set; } 
    }
}
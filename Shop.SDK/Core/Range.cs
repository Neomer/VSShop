using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Core
{
    public class Range<T>
    {
        public T Min { get; set; }
        public T Max { get; set; }
    }
}
using Shop.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Extension
{
    public static class HtmlHelperExtension
    {
        public static IHtmlString EditBlockFor<T, TValue>(this HtmlHelper<T> helper,
                                                  Expression<System.Func<T, TValue>> prop,
                                                  Dictionary<String, Object> htmlAttributes = null)
        {
            if (prop is BaseEntity)
            {
                return MvcHtmlString.Create(prop.ReturnType.ToString() + " YES");
            }
            return MvcHtmlString.Create(prop.ReturnType.ToString() + " NOT");
        }
    }
}
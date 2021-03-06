﻿using Shop.SDK.Models;
using Shop.SDK.Models.Managers;
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

        public static MvcHtmlString CreateNavigationTree(this HtmlHelper helper)
        {
            var top = ProductCategoryManager.GetTopLevel();
            var rootElement = new TagBuilder("ul");
            rootElement.AddCssClass("nav");
            foreach (var item in top)
            {
                rootElement.InnerHtml += HtmlHelperExtension.CreateNavigationElement(helper, item);
            }
            return MvcHtmlString.Create(rootElement.ToString());
        }

        private static string CreateNavigationElement(HtmlHelper helper, ProductCategoryModel model)
        {
            var element = new TagBuilder("li");
            if (model.SubCategories.Count() == 0)
            {
                var a_tag = new TagBuilder("a");
                a_tag.Attributes["href"] = "#";
                a_tag.SetInnerText(model.Name);
                element.InnerHtml +=  a_tag.ToString();
            }
            else
            {
            }
            return element.ToString();
        }

        public static string CreateSpecification(this HtmlHelper helper, IProductCategorySpecification model)
        {
            var ret = model.GetType().GetProperties();
            return "";
        }
    }
}
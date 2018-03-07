using Shop.SDK.Models;
using Shop.SDK.Models.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace Shop.SDK.Web.Extensions
{
    public static class HtmlExtensions
    {
        /// <summary>
        /// Выводит список элементов сущности в виде таблицы
        /// </summary>
        /// <param name="html"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static MvcHtmlString ListEntity(this HtmlHelper html, Type entityType)
        {
            var manager = ManagerFactory.Instance.GetManager(entityType);
            if (manager == null)
            {
                return MvcHtmlString.Create("Менеджер для данной сущности не создан!");
            }
            /*
            var list = manager.GetAll();
            foreach (var item in list)
            {
                var entity = Convert.ChangeType(item, entityType);
                if (entity == null)
                {
                    throw new Exception("Приведение типов не удалось!");
                }
            }
            */
            string s = "";
            var fields = entityType.GetProperties();
            foreach (var f in fields)
            {
                var display = f.CustomAttributes.FirstOrDefault();
                string name = display == null ? f.Name : display.NamedArguments.FirstOrDefault(p => p.MemberName == "Name").TypedValue.Value as string;
                s += "<li>" + name + "</li>";
            }
            return MvcHtmlString.Create("<ul>" + s + "</ul>");
        }
    }
}
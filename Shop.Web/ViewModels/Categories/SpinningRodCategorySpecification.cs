using Shop.SDK.Core;
using Shop.SDK.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Shop.Web.ViewModels.Categories
{
    [Serializable]
    public class SpinningRodCategorySpecification : IProductCategorySpecification
    {
        [Display(Name = "Длина")]
        public double Length { get; set; }
        [Display(Name = "Количество секций")]
        public int Sections { get; set; }
        [Display(Name = "Производитель")]
        public string Manufacturer { get; set; }
        [Display(Name = "Вес")]
        public double Weight { get; set; }
        [Display(Name = "Тест")]
        public Range<int> Test { get; set; }

        public IDictionary<string, string> toList()
        {
            return null;
        }
    }
}
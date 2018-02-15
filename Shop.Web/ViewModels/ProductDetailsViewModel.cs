using Shop.SDK.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml;

namespace Shop.Web.ViewModels
{
    public class ProductDetailsViewModel
    {
        public ProductDetailsViewModel()
        {

        }

        public ProductDetailsViewModel(ProductModel model)
        {
            ID = model.ID;
            Name = model.Name;
            Category = model.Category;
            Description = model.Description;
        }

        [Display(Name = "Идентификатор")]
        public Guid ID { get; set; }

        [Required]
        [Display(Name = "Наименование")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Подробное описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Категория")]
        public ProductCategoryModel Category { get; set; }

        [Display(Name = "Изображение")]
        public string Image { get; set; }
    }
}
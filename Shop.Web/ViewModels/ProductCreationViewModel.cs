using Shop.SDK.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Web.ViewModels
{
    public class ProductCreationViewModel
    {
        [Required]
        [Display(Name = "Наименование")]
        [DataType(DataType.Text)]
        [MaxLength(255, ErrorMessage = "Длина не должна превышать 255 сиволов.")]
        public string Name { get; set; }

        [Display(Name = "Подробное описание")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Категория")]
        public ProductCategoryModel Category { get; set; }

        [Display(Name = "Изображение")]
        public string Image { get; set; }
    }
}
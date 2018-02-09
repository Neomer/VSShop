using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.SDK.Models;
using System.ComponentModel.DataAnnotations;

namespace Shop.Web.ViewModels
{
    public class CategoryDetailsViewModel
    {
        public CategoryDetailsViewModel()
        {

        }

        public CategoryDetailsViewModel(ProductCategoryModel model)
        {
            ID = model.ID;
            Name = model.Name;
        }

        [Display(Name = "Идентификатор")]
        public Guid ID { get; set; }

        [Required]
        [Display(Name = "Наименование")]
        public string Name { get; set; }
    }
}
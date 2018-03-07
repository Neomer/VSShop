using Shop.SDK.Models;
using Shop.SDK.Models.Managers;
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
            var cons = ManagerFactory.Instance.GetManager<ConsignmentItemManager>().GetByProduct(model).FirstOrDefault();
            ItemsAvailable = (cons == null) ? 0 : cons.Count;
            Consignment = model.Consignments.FirstOrDefault();
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

        [Display(Name = "Кол-во на складе")]
        public double ItemsAvailable { get; set; }

        [Display(Name = "Поставка")]
        public ConsignmentItemModel Consignment { get; set; }
    }
}
using Shop.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.ViewModels
{
    public class ProductConsignmentItemViewModel
    {
        public ProductConsignmentItemViewModel(ConsignmentItemModel model)
        {
            if (model == null) return;

            ID = model.Consignment.ID;
            CreationDate = model.Consignment.CreationDate;
            Count = model.Count;
            Cost = model.Cost;
        }

        public Guid ID { get; set; }
        public DateTime CreationDate { get; set; }
        public double Count { get; set; }
        public double Cost { get; set; }
    }
}
using Shop.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.ViewModels.Ajax
{
    public class GetProductConsignmentsViewModel : IAjaxResult
    {
        public GetProductConsignmentsViewModel(IEnumerable<ConsignmentItemModel> model)
        {
            if (model == null) return;

            var list = new List<ProductConsignmentItemViewModel>();
            foreach (var item in model)
            {
                list.Add(new ProductConsignmentItemViewModel(item));
            }
            Items = list;
        }

        public IEnumerable<ProductConsignmentItemViewModel> Items { get; set; }
    }
}
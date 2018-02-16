using Shop.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.ViewModels
{
    /// <summary>
    /// Общая информация о состоянии корзины
    /// </summary>
    public class BasketStatisticViewModel
    {
        public BasketStatisticViewModel()
        {

        }

        public BasketStatisticViewModel(BasketModel model)
        {
            ID = model.ID;
            ItemsCount = (model.Items != null) ? model.Items.Count() : 0;
        }

        public Guid ID { get; set; }
        public int ItemsCount { get; set; }
    }
}
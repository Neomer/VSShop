using Shop.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.ViewModels.Ajax
{
    /// <summary>
    /// Ответ сервера на добавление товара в корзину с помощью AJAX
    /// </summary>
    public class AddProductToBasketViewModel : IAjaxResult
    {
        public BasketStatisticViewModel Basket { get; set; }
    }
}
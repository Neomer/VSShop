using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.ViewModels.Ajax
{
    [Serializable]
    public class BaseAjaxViewModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public IAjaxResult Result { get; set; }
    }
}
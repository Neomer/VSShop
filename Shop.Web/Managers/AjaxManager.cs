using Shop.Web.ViewModels.Ajax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace Shop.Web.Managers
{
    public static class AjaxManager
    {
        public static BaseAjaxViewModel CreateSuccessAjaxAnswer(IAjaxResult result, string message = null)
        {
            return new BaseAjaxViewModel() { State = AjaxViewModelState.Success, Message = message, Result = result };
        }

        public static BaseAjaxViewModel CreateErrorAjaxAnswer(IAjaxResult result, string message)
        {
            return new BaseAjaxViewModel() { State = AjaxViewModelState.Error, Message = message, Result = result };
        }

        public static string SerializeAjaxAnswer(BaseAjaxViewModel model)
        {
            string buffer;
            using (var textWriter = new StringWriter())
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(textWriter, model, model.GetType());
                buffer = textWriter.ToString();
            }
            return buffer;
        }
    }
}
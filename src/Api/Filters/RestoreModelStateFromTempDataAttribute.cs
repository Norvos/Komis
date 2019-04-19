using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Komis.Api.Filters
{
    public class RestoreModelStateFromTempDataAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var controller = filterContext.Controller as Controller;
            var tempData = controller?.TempData?.Keys;
            if (controller != null && tempData != null)
            {
                if (tempData.Contains("ModelState"))
                {
                    var modelStateString = controller.TempData["ModelState"].ToString();
                    var listError = JsonConvert.DeserializeObject<Dictionary<string, string>>(modelStateString);
                    var modelState = new ModelStateDictionary();
                    foreach (var item in listError)
                    {
                        modelState.AddModelError(item.Key, item.Value ?? "");
                    }

                    controller.ViewData.ModelState.Merge(modelState);
                }
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Linq;

namespace Komis.Api.Filters
{
    public class SetTempDataModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            var controller = filterContext.Controller as Controller;
            var modelState = controller?.ViewData.ModelState;
            if (modelState != null)
            {
                var listError = modelState.Where(x => x.Value.Errors.Any())
                    .ToDictionary(m => m.Key, m => m.Value.Errors
                    .Select(s => s.ErrorMessage)
                    .FirstOrDefault(s => s != null));
                controller.TempData["ModelState"] = JsonConvert.SerializeObject(listError);
            }
        }
    }
}

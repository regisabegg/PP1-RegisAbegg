using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace PP1.CONTRATO.WEB.Util
{
    public abstract class ModelStateTempDataTransfer : ActionFilterAttribute
    {
        protected static readonly string Key = typeof(ModelStateTempDataTransfer).FullName;
    }

    public class ExportModelStateToTempData : ModelStateTempDataTransfer
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!filterContext.Controller.ViewData.ModelState.IsValid)
                if ((filterContext.Result is RedirectResult) || (filterContext.Result is RedirectToRouteResult))
                    filterContext.Controller.TempData[Key] = filterContext.Controller.ViewData.ModelState;

            if (!string.IsNullOrEmpty(filterContext.Controller.ViewBag.Message))
                filterContext.Controller.TempData["Message"] = filterContext.Controller.ViewBag.Message;

            base.OnActionExecuted(filterContext);
        }
    }

    public class ImportModelStateFromTempData : ModelStateTempDataTransfer
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var modelState = filterContext.Controller.TempData[Key] as ModelStateDictionary;

            if (modelState != null)
                if (filterContext.Result is ViewResult)
                    filterContext.Controller.ViewData.ModelState.Merge(modelState);
                else
                    filterContext.Controller.TempData.Remove(Key);

            if (!string.IsNullOrEmpty((string)filterContext.Controller.TempData["Message"]))
                filterContext.Controller.ViewBag.Message = filterContext.Controller.TempData["Message"];

            base.OnActionExecuted(filterContext);
        }
    }
}

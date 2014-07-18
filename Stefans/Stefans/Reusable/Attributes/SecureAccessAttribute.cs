using System.Web.Mvc;
using System.Web.Routing;

namespace Stefans.Reusable.Attributes
{
    public class SecureAccessAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext FilterContext)
        {
            if (!SessionExt.IsAuthorized())
            {
                FilterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Home", Action = "Index" }));
            }
        }
    }
}
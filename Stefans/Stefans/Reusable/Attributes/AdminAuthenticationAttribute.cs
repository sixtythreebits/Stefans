using System.Web.Mvc;
using System.Web.Routing;

namespace Stefans.Reusable.Attributes
{
    public class AdminAuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext FilterContext)
        {
            var isAuthorized = FilterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) || (SessionExt.IsAuthorized() && SessionExt.Session.GetUser().IsAdmin);
            if (!isAuthorized)
            {
                FilterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Main", Action = "LogIn" }));
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.CM;

namespace Stefans.Reusable.Attributes
{
    public class CartStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Result is ViewResult && SessionExt.IsAuthorized())
            {                
                filterContext.Controller.ViewBag.IsCartFull = new CartItem().IsCartFull(SessionExt.Session.GetUser().ID);
            }
        }
    }
}
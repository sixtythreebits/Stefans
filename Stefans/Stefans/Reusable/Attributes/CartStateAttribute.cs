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
                var isCartFull = new CartItem().IsCartFull(SessionExt.Session.GetUser().ID);
                if(isCartFull)
                {
                    filterContext.Controller.ViewBag.isCartFool = true;
                }
                else
                {
                    filterContext.Controller.ViewBag.isCartFool = false;
                }

            }
        }
    }
}
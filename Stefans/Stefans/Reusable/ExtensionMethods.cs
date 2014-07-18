using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Stefans.Reusable
{
    public static class ExtensionMethods
    {
        #region Request extensions

        public static string SchemeAndAuthority(this HttpRequestBase Request)
        {
            return string.Concat(Request.Url.Scheme, Uri.SchemeDelimiter, Request.Url.Authority);
        }

        #endregion

        #region HtmlHelper extensions

        public static bool HasPropertyError<TModel, TProperty>(this HtmlHelper<TModel> Helper, Expression<Func<TModel, TProperty>> PropertySelector)
        {
            ModelState modelState;
            Helper.ViewData.ModelState.TryGetValue(Helper.NameFor(PropertySelector).ToString(), out modelState);
            return modelState != null && modelState.Errors.Any();
        }

        #endregion

        #region ModelState extensions

        public static void AddModelError<TProperty>(this ModelStateDictionary ModelState, Expression<Func<TProperty>> PropertySelector, string ErrorMessage)
        {
            ModelState.AddModelError(ExpressionHelper.GetExpressionText(PropertySelector), ErrorMessage);
        }

        #endregion
    }
}
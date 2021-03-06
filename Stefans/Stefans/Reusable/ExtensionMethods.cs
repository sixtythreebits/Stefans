﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
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

        #region IEnumerable extensions

        public static IEnumerable<SelectListItem> ToSelectList<TItem, TValue, TText>(this IEnumerable<TItem> Items, Expression<Func<TItem, TValue>> ValueExpression, Expression<Func<TItem, TText>> TextExpression)
        {
            return new SelectList(Items, ExpressionHelper.GetExpressionText(ValueExpression), ExpressionHelper.GetExpressionText(TextExpression));
        }

        #endregion

        #region TempDataDictionary extensions

        public static void Set(this TempDataDictionary TempData, object Value, [CallerMemberName] string CallerName = "")
        {
            TempData[CallerName] = Value;
        }

        public static object Get(this TempDataDictionary TempData, [CallerMemberName] string CallerName = "")
        {
            return TempData[CallerName];
        }

        #endregion
    }
}
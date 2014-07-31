using System.Web.Mvc;

namespace Stefans.Reusable.FrameworkExtensions
{
    public abstract class AppWebViewPage<T> : WebViewPage<T>
    {
        public string SuccessMessage
        {
            get { return TempData.Get() as string; }
            set { TempData.Set(value); }
        }

        public string ErrorMessage
        {
            get { return TempData.Get() as string; }
            set { TempData.Set(value); }
        }
    }
}
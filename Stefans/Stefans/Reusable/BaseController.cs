using System.IO;
using System.Web.Mvc;

namespace Stefans.Reusable
{
    public class BaseController : Controller
    {
        public string RenderRazorViewToString(string ViewName, object Model)
        {
            ViewData.Model = Model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, ViewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}
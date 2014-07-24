using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using Core.CM;
using Core.Utilities;
using Lib;
using Stefans.Reusable;
using Res = Core.Properties.Resources;

namespace Stefans.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Ingredients = new Dictionary().ListDictionaries(1, 2);
            return View("CreateEdit");
        }

        [HttpPost]
        public ActionResult Create(Product Model, HttpPostedFileBase Upload)
        {
            if (Upload != null && !Utility.AllowedImageExtensions.Contains(Path.GetExtension(Upload.FileName)))
            {
                ModelState.AddModelError(() => Model.Image, string.Format(Res.ErrorFileExtension, Utility.AllowedImageExtensions.JoinStrings(", ")));
            }

            if (ModelState.IsValid)
            {
                if (Upload != null)
                {
                    Model.Image = Upload.FileName.ToAZ09Dash(true);
                }

                var repo = new Product();
                repo.TX((byte)(Model.ID > 0 ? 1 : 0), BuildXml(Model));

                if (!repo.IsError && repo.ID > 0)
                {
                    if (Upload != null)
                    {
                        Upload.SaveAs(Server.MapPath(Path.Combine(ConfigAssistant.ProductsFolderRelativePath, Model.Image)));
                    }
                }
            }

            ViewBag.Ingredients = new Dictionary().ListDictionaries(1, 2);
            return View("CreateEdit", Model);
        }

        private static string BuildXml(Product Model)
        {
            var ingredientsXml = Model.Ingredients.Select(i => string.Format(@"
            <ingredient>
                <id>{0}</id>
            </ingredient>
            ", i.ID)).JoinStrings();

            return string.Format(@"
            <data>
                {0}
                <caption>{1}</caption>
                <price>{2}</price>
                <description>{3}</description>
                <instructions>{4}</instructions>
                <image>{5}</image>
                <ingredients>{6}</ingredients>
            </data>
            ", Model.ID > 0 ? string.Format("<id>{0}</id>", Model.ID) : ""
             , Model.Caption
             , Model.Price
             , Model.Description
             , Model.Instruction
             , Model.Image
             , ingredientsXml);
        }
    }
}
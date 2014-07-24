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
using FileIO = System.IO.File;

namespace Stefans.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        public ActionResult Index()
        {
            var model = new Product().GetList();
            return View(model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = new Product().GetList();
            return PartialView("_GridViewPartial", model);
        }

        public ActionResult Create()
        {
            ViewBag.Ingredients = new Dictionary().ListDictionaries(1, 2);
            return View("CreateEdit");
        }

        [HttpPost]
        public ActionResult Save(Product Model, HttpPostedFileBase Upload)
        {
            if (Upload != null && !Utility.AllowedImageExtensions.Contains(Path.GetExtension(Upload.FileName)))
            {
                ModelState.AddModelError(() => Model.Image, string.Format(Res.ErrorFileExtension, Utility.AllowedImageExtensions.JoinStrings(", ")));
            }

            if (ModelState.IsValid)
            {
                var repo = new Product();
                if (Upload != null)
                {
                    Model.Image = Upload.FileName.ToAZ09Dash(true);
                    if (Model.ID > 0)
                    {
                        var product = repo.GetSingle(Model.ID);

                        if (product != null && !string.IsNullOrWhiteSpace(product.Image))
                        {
                            var path = Server.MapPath(Path.Combine(ConfigAssistant.ProductsFolderRelativePath, product.Image));
                            if (FileIO.Exists(path))
                            {
                                FileIO.Delete(path);
                            }
                        }
                    }
                }

                repo.TX((byte)(Model.ID > 0 ? 1 : 0), BuildXml(Model));

                if (!repo.IsError && repo.ID > 0)
                {
                    if (Upload != null)
                    {
                        Upload.SaveAs(Server.MapPath(Path.Combine(ConfigAssistant.ProductsFolderRelativePath, Model.Image)));
                    }
                    return RedirectToAction("Edit", "Product", new { repo.ID });
                }
            }

            ViewBag.Ingredients = new Dictionary().ListDictionaries(1, 2);
            return View("CreateEdit", Model);
        }

        public ActionResult Edit(int ID)
        {
            if (ID > 0)
            {
                var model = new Product().GetSingle(ID);
                if (model != null)
                {
                    ViewBag.Ingredients = new Dictionary().ListDictionaries(1, 2);
                    return View("CreateEdit", model);
                }
            }
            return HttpNotFound();
        }

        private static string BuildXml(Product Model)
        {
            var ingredients = Model.Ingredients ?? Enumerable.Empty<Dictionary>();
            var ingredientsXml = ingredients.Select(i => string.Format(@"
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
                {5}
                <ingredients>{6}</ingredients>
            </data>
            ", Model.ID > 0 ? string.Format("<id>{0}</id>", Model.ID) : ""
             , Model.Caption.WrapWithCData()
             , Model.Price
             , Model.Description.WrapWithCData()
             , Model.Instruction.WrapWithCData()
             , string.IsNullOrWhiteSpace(Model.Image) ? "" : string.Format("<image>{0}</image>", Model.Image.WrapWithCData()) 
             , ingredientsXml);
        }
    }
}
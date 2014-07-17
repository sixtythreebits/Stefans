using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Stefans
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection Bundles)
        {
            //Bundles.Add(new ScriptBundle("~/bundles/layout").Include(
            //            "~/Scripts/jquery-{version}.js",
            //            "~/Scripts/jquery-ui-{version}.js",
            //            "~/Scripts/General/utils.js",
            //            "~/Scripts/CM/layout.js",
            //            "~/Scripts/CM/calendar.js",
            //            "~/Scripts/CM/cart.js",
            //            "~/Scripts/CM/player.js"));

            //Bundles.Add(new ScriptBundle("~/bundles/validation").Include(
            //    "~/Scripts/jquery.validate.js",
            //    "~/Scripts/jquery.validate.unobtrusive.js"));

            Bundles.Add(new StyleBundle("~/bundles/content").Include(
                "~/Content/style.css",
                "~/Content/fonts.css"));
        }

        public static IHtmlString PutLayoutStyle()
        {
            return Styles.Render("~/bundles/content");
        }
    }
}
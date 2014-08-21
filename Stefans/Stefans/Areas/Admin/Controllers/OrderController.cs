using System.Web.Mvc;
using Core.CM;
using System.Linq;
using System.Resources;
using System.Reflection;
using Core.Properties;
using Core;
using DevExpress.Web.Mvc;

namespace Stefans.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderGrid()
        {
            var model = new Order().GetList();
            ViewBag.DateFormat = Resources.LongDateFormat;            
            ViewBag.Statuses = new Dictionary().ListDictionaries(1, 4);
            return PartialView("_OrderGrid", model);
        }

        public ActionResult Details(int? ID)
        {
            if (ID == null)
            {
                return RedirectToAction("Index", "Order");
            }
            else if (ID > 0)
            {
                ViewBag.DateFormat = Resources.LongDateFormat;
                var model = new Order().GetSingleOrder(ID.Value);

                if (model != null)
                {
                    if (Request.IsAjaxRequest())
                    {
                        return PartialView(model);
                    }
                    return View(model);
                }
            }

            return HttpNotFound();
        }

        public ActionResult EditStatuses([ModelBinder(typeof(DevExpressEditorsBinder))]Order Order)
        {
            Order.TSP_Orders(1, Order.ID, null, Order.StatusID, null);

            if(Order.IsError)
            {
                ViewData["EditError"] = Resources.Fail;
            }
                       
            var model = new Order().GetList();
            ViewBag.DateFormat = Resources.LongDateFormat;
            ViewBag.Statuses = new Dictionary().ListDictionaries(1, 4);
            return PartialView("_OrderGrid", model);
        }
    }
}
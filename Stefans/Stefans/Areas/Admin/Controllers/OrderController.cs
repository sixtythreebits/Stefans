using System.Web.Mvc;
using Core.CM;
using System.Linq;
using System.Resources;
using System.Reflection;
using Core.Properties;

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
            return PartialView("_OrderGrid", model);
        }

        public ActionResult Details(int ID)
        {
            var model = new OrderDetail().GetList(ID);

            var OrderDetail = new Order().GetSingleOrder(ID);

            ViewBag.Shipping = OrderDetail.OrderAdresses.FirstOrDefault(x => x.CodeVal == 1);
            ViewBag.Billing = OrderDetail.OrderAdresses.FirstOrDefault(x => x.CodeVal == 2);
            //ViewBag.TotalPrice = OrderDetail.TotalPrice;
            ViewBag.OrderDate = new Order().GetList().Where(x => x.ID == ID).Select(o => o.CRTime).FirstOrDefault();
            ViewBag.OrderNo = OrderDetail.ID;
            ViewBag.Status = OrderDetail.StatusCaption;
            ViewBag.Email = OrderDetail.UserEmail;

            ViewBag.DateFormat = Resources.LongDateFormat;

           

            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }
            return View(model);
        }
    }
}
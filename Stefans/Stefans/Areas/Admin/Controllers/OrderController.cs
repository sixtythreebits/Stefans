using System.Web.Mvc;
using Core.CM;
using System.Linq;

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
            return PartialView("_OrderGrid", model);
        }

        public ActionResult Details(int ID)
        {
            var model = new OrderDetail().GetList(ID);

            var OrderDetail = new Order().GetSingleOrder(ID);

            ViewBag.Shipping = OrderDetail.OrderAdresses.FirstOrDefault(x => x.CodeVal == 1);
            ViewBag.Billing = OrderDetail.OrderAdresses.FirstOrDefault(x => x.CodeVal == 2);

            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }
            return View(model);
        }
    }
}
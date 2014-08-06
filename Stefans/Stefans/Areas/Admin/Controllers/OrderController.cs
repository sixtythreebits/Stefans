using System.Web.Mvc;
using Core.CM;

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
            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }
            return View(model);
        }
    }
}
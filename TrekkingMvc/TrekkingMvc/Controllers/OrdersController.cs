using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrekkingMvc.Models;
using TrekkingMvc.Models.ViewModel;

namespace TrekkingMvc.Controllers
{
    public class OrdersController : Controller
    {
        OrderOparations op = new OrderOparations();
        // GET: Orders
        [Authorize]
        public ActionResult Index()
        {
            TREKKINGDBEntities db = new TREKKINGDBEntities();
            List<MyOrderVM> myodList = new List<MyOrderVM>();
            int userID = (int)Session["UserID"];
            myodList = op.Siparislerim(userID);

            return View(myodList);
        }
        [Authorize]
        public ActionResult OrderDetail(string OrderNumber)
        {
            OrderDetailVM odvm = new OrderDetailVM();
            odvm = op.SiparisDetay(OrderNumber);

            return View(odvm);
        }
    }
}
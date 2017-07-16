using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrekkingMvc.Models;
using TrekkingMvc.Models.ViewModel;

namespace TrekkingMvc.Controllers
{
    public class OrderSummaryController : Controller
    {
        // GET: OrderSummary
        [Authorize]
        public ActionResult Index()
        {
            OrderSummaryVM odvm = new OrderSummaryVM();
            odvm._odList = (List<OrderVM>)Session["Basket"];
            odvm._add = (AddressVM)Session["Address"];

            return View(odvm);
        }
        [Authorize]
        public ActionResult OrderCompleted()
        {
            //Mehmet Akif Ersoy Cad. Çiftlik Mah. No: 24 / 2 Beykoz / Çavuşbaşı
            OrderOparations odop = new OrderOparations();
            int sayi =  odop.SiparisTamamla();
            Session["TamamlandiMi"] = sayi;
            return View();

        }
    }
}
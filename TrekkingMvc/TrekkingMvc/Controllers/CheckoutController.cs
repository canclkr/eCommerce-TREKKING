using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrekkingMvc.Models;

namespace TrekkingMvc.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult checkoutUpdate(int productdtID, string size, int quantity)
        {
            OrderOparations op = new OrderOparations();
            int sayi = op.mtdSepetGuncelle(productdtID, size, quantity);


            return Json(sayi, JsonRequestBehavior.AllowGet);
        }
        public JsonResult checkoutDelete(int productdtID, string size)
        {
            OrderOparations op = new OrderOparations();
            int sayi = op.mtdSepetSil(productdtID, size);


            return Json(sayi, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddAddress(string adSoyad, string ulke, string sehir, string postaKodu, string adres)
        {
            OrderOparations op = new OrderOparations();
            int sayi = op.mtdAdresEkle(adSoyad, ulke, sehir, postaKodu, adres);


            return Json(sayi, JsonRequestBehavior.AllowGet);
        }
    }
}
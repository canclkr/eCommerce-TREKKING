using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using TrekkingMvc.Models;
using TrekkingMvc.Models.ViewModel;

namespace TrekkingMvc.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        public ActionResult Index(int prcID)
        {
            TREKKINGDBEntities db = new TREKKINGDBEntities();
            ProductDetailVM prcVM = new ProductDetailVM();
            ProductList prc = new ProductList();

            prcVM.ProductDt = prc.mtdProductDt(prcID);
            prcVM.Sizes = prc.mtdProductDtSize(prcID);
            prcVM.KategoriBirListe = prc.KatBirListe();
            prcVM.KategoriIkiListe = prc.KatIkiListe();

            return View(prcVM);
        }
        public JsonResult AddtoBasket(int productdtID,string size,int quantity)
        {
            OrderOparations oo = new OrderOparations();
            OrderVM ov = new OrderVM();
            ov = oo.mtdAddtoBasket(productdtID, size, quantity);

            return Json(ov,JsonRequestBehavior.AllowGet);
        }
    }
}
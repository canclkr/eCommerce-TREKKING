using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrekkingMvc.Models;
using TrekkingMvc.Models.ViewModel;

namespace TrekkingMvc.Controllers
{
    public class ProductsController : Controller
    {
        TREKKINGDBEntities db = new TREKKINGDBEntities();

        // GET: Products
        public ActionResult Index()
        {

            ProductsVM prvm = new ProductsVM();
            ProductList prc = new ProductList();

            prvm.ErkekList = prc.KatBirUrunListele(1);
            prvm.KadınList = prc.KatBirUrunListele(2);
            prvm.CocukList = prc.KatBirUrunListele(3);
            prvm.KategoriBirListe = prc.KatBirListe();
            prvm.KategoriIkiListe = prc.KatIkiListe();

            return View(prvm);
        }
        public ActionResult CatFilter(string CatID)
        {

            ProductList prc = new ProductList();
            ProductsVM prcVM = new ProductsVM();

            int kat1, kat2;

            string[] karakter = new string[2];
            karakter = CatID.Split('-');
            kat1 = Convert.ToInt32(karakter[0]);
            kat2 = Convert.ToInt32(karakter[1]);

            //if (kat1 == 1)
            //{
            //    prcVM.ErkekList = prc.KatIkiUrunListele(kat1, kat2);
            //}
            //else if (kat1 == 2)
            //{
            //    prcVM.KadınList = prc.KatIkiUrunListele(kat1, kat2);
            //}
            //else
            //{
            //    prcVM.CocukList = prc.KatIkiUrunListele(kat1, kat2);
            //}
            prcVM.KategoriBirListe = prc.KatBirListe();
            prcVM.KategoriIkiListe = prc.KatIkiListe();
            prcVM.UrunListe = prc.KatIkiUrunListele(kat1, kat2);
            prcVM.KatBirAd = db.ProductCatOne.FirstOrDefault(x => x.ProductCatOneID == kat1).CategoryName;
          

            return View(prcVM);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrekkingMvc.Models;
using TrekkingMvc.Models.ViewModel;

namespace TrekkingMvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Session["AnasayfaMi"] = true;
            HomeVM hm = new HomeVM();
            ProductList prc = new ProductList();

            hm.ErkekProductsList = prc.KatBirUrunListele(1);
            hm.KadınProductList = prc.KatBirUrunListele(2);

            return View(hm);

        }
    }
}
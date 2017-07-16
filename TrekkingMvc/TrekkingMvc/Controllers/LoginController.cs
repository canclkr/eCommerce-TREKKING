using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TrekkingMvc.Models;

namespace TrekkingMvc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        private TREKKINGDBEntities db = new TREKKINGDBEntities();
        private LoginOparations lg = new LoginOparations();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Register(string reNameSurname, string reEmail, string rePass)
        {
            bool Donen = lg.Register(reNameSurname, reEmail, rePass);
            if (Donen)
            {
                FormsAuthentication.SetAuthCookie("Var", Donen);
            }
            return Json(Donen, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult LoginControl(string user, string pass)
        {
            bool Donen = lg.Login(user, pass);
            if (Donen)
            {
                FormsAuthentication.SetAuthCookie("Var", Donen);
            }
            
            return Json(Donen, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Remove("Basket");
            Session.Remove("UserID");
            Session.Remove("Email");
            Session.Remove("AdSoyad");

            return RedirectToAction("Index","Home");
        }
    }
}
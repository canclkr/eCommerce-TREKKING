using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrekkingMvc.Models;

namespace TrekkingMvc.Models
{
    public class LoginOparations
    {
        TREKKINGDBEntities db = new TREKKINGDBEntities();
        bool BasariliMi = false;

        public bool Register(string _NameSurname, string _email, string _password)
        {
            HttpContext.Current.Session.Remove("AdSoyad");
            HttpContext.Current.Session.Remove("UserID");
            HttpContext.Current.Session.Remove("Email");
            try
            {
                db.spRegister(_email, _password);
                spLogin_Result user = db.spLogin(_email, _password).FirstOrDefault();
                db.spRegisterDetail(_NameSurname, user.UserID);


                
                UserDetails ud = db.UserDetails.FirstOrDefault(x => x.UserID == user.UserID);
                HttpContext.Current.Session["AdSoyad"] = ud.Name_Surname;
                HttpContext.Current.Session["UserID"] = user.UserID;
                HttpContext.Current.Session["Email"] = user.Email;

                BasariliMi = true;
            }
            catch (Exception e)
            {
                BasariliMi = false;
            }
            return BasariliMi;
        }
        public bool Login(string _email, string _password)
        {
            HttpContext.Current.Session.Remove("AdSoyad");
            HttpContext.Current.Session.Remove("UserID");
            HttpContext.Current.Session.Remove("Email");
            try
            {
                spLogin_Result user = db.spLogin(_email, _password).FirstOrDefault();
             
                BasariliMi = true;

                UserDetails ud = db.UserDetails.FirstOrDefault(x => x.UserID == user.UserID);
                HttpContext.Current.Session["AdSoyad"] = ud.Name_Surname;
                HttpContext.Current.Session["UserID"] = user.UserID;
                HttpContext.Current.Session["Email"] = user.Email;
                
                
            }
            catch (Exception e)
            {
                BasariliMi = false;
            }
            return BasariliMi;
        }
    }
}
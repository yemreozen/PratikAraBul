
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PratikAraBul.Models;
using PratikAraBul.Models.Entity;

namespace PratikAraBul.Controllers
{
    
    public class AdLoginsController : Controller
    {
        AraBulEntities db = new AraBulEntities();
       
        public ActionResult Index()
        {
            AdLogin objLogin = new AdLogin();

            return View(objLogin);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "AdLogins");
        }
        [HttpPost]
        public ActionResult Index(AdLogin objLogin)
        {
            if (ModelState.IsValid)
            {
                if (db.tblAdmin.Where(m => m.KullaniciAdi == objLogin.KullaniciAdi && m.Sifre == objLogin.Sifre).FirstOrDefault() == null)
                {

                    ModelState.AddModelError("Error", "Kullanıcı adı /şifre yanlış !");
                    return View();


                }
                else
                {
                    FormsAuthentication.SetAuthCookie(objLogin.KullaniciAdi, false);
                    Session["Admin"] = objLogin.KullaniciAdi;
                    return RedirectToAction("Index", "Kategori");
                }
            }
            return View();
        }
    }
}
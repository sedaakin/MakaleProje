using MakaleProje.DAL;
using MakaleProje.DTO;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MakaleProje.UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private static Logger logger = LogManager.GetLogger("db");
        // GET: Login
        public ActionResult Index()
        {
            if (Request.Cookies != null && Request.Cookies["GirisCookie"] != null)
            {
                HttpCookie gelenCookie = Request.Cookies["GirisCookie"];
                return View(new KullaniciDTO() { KullaniciAd = gelenCookie.Values["kullaniciAdi"], Sifre = gelenCookie.Values["sifre"]});
            }
            else
                return View(new KullaniciDTO() { });
        }
        [HttpPost]
        public ActionResult Index(KullaniciDTO kullanici,bool rememberMe)
        {
            logger.Info("Login controller,Index method girildi.");
            if (ModelState.IsValid)
            {
                try
                {
                    if (new KullaniciDAL().Getir(kullanici.KullaniciAd, kullanici.Sifre) != null)
                    {
                        FormsAuthentication.SetAuthCookie(kullanici.KullaniciAd, true);
                        Session["user"] = JsonConvert.SerializeObject(kullanici.KullaniciID);
                        logger.Info("Login controller'dan çıkılıyor,login başarılı.");

                        if (rememberMe)
                        {
                            HttpCookie cookie = new HttpCookie("GirisCookie");
                            cookie.Expires = DateTime.Now.AddDays(1);
                            cookie["kullaniciAdi"] = kullanici.KullaniciAd;
                            cookie["sifre"] = kullanici.Sifre;
                            Response.Cookies.Add(cookie);
                        }
                        return RedirectToAction("Index", "Makale");
                    }
                    //veritabanı tasarımında tek kullanıcı admin olduğundan rolle ilgili kontrollere gerek kalmadı, fakat yazar tipinde bir kullanıcı tipi daha ekleyip rol yönetimini de yapacağım   
                    else
                    {
                        ViewBag.Mesaj = "hatalı e-posta ya da şifre girdiniz.";
                        logger.Info("Login controller'dan çıkılıyor,login başarısız.");

                        return View();
                    }
                }
                catch (Exception e)
                {
                    logger.Error("Hata:"+e.Message);
                    return Content("Hata:" + e.Message);
                }
            }
            else
            {
                ViewBag.Mesaj = "Tüm alanları giriniz.";
                return View();
            }
        }
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session["user"] = null;
            return RedirectToAction("Index", "Login");
        }
        public ActionResult ForgetMe()
        {
            if (Request.Cookies != null && Request.Cookies["GirisCookie"] != null)
            {
                HttpCookie cookie = Request.Cookies["GirisCookie"];
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
            return RedirectToAction("Index", "Login");

        }
    }
}
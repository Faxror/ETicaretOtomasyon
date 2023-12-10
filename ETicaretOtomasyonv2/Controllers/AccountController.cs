using ETicaretOtomasyonv2.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ETicaretOtomasyonv2.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        Context c = new Context();
        public ActionResult Index()
        {
            var users = c.Urunlers.ToList();
            return View(users);
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LoginOUT()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult Login(Cariler s)
        {
            var bilgi = c.Carilers.First(x => x.CariMail == s.CariMail && x.password == s.password);

            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.CariMail, false);
                Session["Mail"] = bilgi.CariMail.ToString();
                Session["Ad"] = bilgi.CariAd.ToString();
                Session["SoyAd"] = bilgi.CariSoyad.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.hata = "Kullanıcı Adı veya Şifre Hatalı";
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Cariler x)
        {
            c.Carilers.Add(x);
            x.Rol = "U";
            x.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Login", "Account");
        }

    }
}
using ETicaretOtomasyonv2.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretOtomasyonv2.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        Context c = new Context();
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var kullanici = c.Carilers.FirstOrDefault(x => x.CariMail == kullaniciadi);
                var model = c.Sales.Where(x => x.UserId == kullanici.SepetID).ToList();
                return View(model);
            }
            return HttpNotFound();
        }

        public ActionResult Buy(int id)
        {
            List<Sepet> sepetList = c.Sepets.ToList(); // Sepetleri almak için bir sorgu yapılmalı veya oluşturulmalı
            return View(sepetList);
        }

        [HttpPost]
        public ActionResult Buy2(int? id)
        {


            var model = c.Sepets.FirstOrDefault(x => x.Sepetıd == id);
            if (model != null)
            {
                var satis = new Sales
                {
                    UserId = model.kullaniciid,
                    Fiyat = model.Fiyat,
                    Tarih = DateTime.Now,
                    Adet = model.Adet,
                    UrunId = model.UrunId
                };

                c.Sepets.Remove(model);
                c.Sales.Add(satis);
                c.SaveChanges();
                ViewBag.Success = "Başarılı şekilde satın aldınız.";
            }
            else
            {
                ViewBag.Success = "Belirtilen ID ile sepet bulunamadı.";
                return View("islem");
            }



            return View("islem");

        }
    }
    }
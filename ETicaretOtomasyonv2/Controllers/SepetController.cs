using ETicaretOtomasyonv2.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretOtomasyonv2.Controllers
{
    public class SepetController : Controller
    {
        // GET: Sepet
        Context c = new Context();
        public ActionResult Index(decimal?Tutar)
        {

            if(User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var kullanici = c.Carilers.FirstOrDefault(x => x.CariMail == kullaniciadi);
                var model = c.Sepets.Where(x => x.kullaniciid == kullanici.Cariid).ToList();
                var kid = c.Sepets.FirstOrDefault(x => x.kullaniciid == kullanici.Cariid);

                if (model !=null)
                {
                    if (kid == null)
                    {
                        ViewBag.Tutar = "Sepetinizde Ürün Bulunmamaktadır.";
                    }
                    else if (kid!=null)
                    {
                        Tutar = c.Sepets.Where(b => b.kullaniciid == kid.kullaniciid).Sum(x => x.Urunler.Fiyat + x.Adet);
                        ViewBag.Tutar = "Tutar = " + Tutar + "TL";
                    }
                    return View(model);
                }
            }
            return HttpNotFound();
        }

        public ActionResult SepeteEkle(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var model = c.Carilers.FirstOrDefault(x => x.CariMail == kullaniciadi);
                var U = c.Urunlers.Find(id);
                var sepet = c.Sepets.FirstOrDefault(x => x.kullaniciid == model.Cariid && x.UrunID == id);
                if (model !=null)
                {
                    if (sepet!=null)
                    {
                        sepet.Adet++;
                        sepet.Fiyat = U.Fiyat * sepet.Adet;
                        c.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    var s = new Sepet()
                    {
                        kullaniciid = model.SepetID,
                        Adet = 1,
                        Fiyat = U.Fiyat,
                        Tarih = DateTime.Now,
                        UrunID = U.UrunID // İkinci 'UrunID' ataması
                    };
                    c.Sepets.Add(s);
                    c.SaveChanges();
                
                    return RedirectToAction("Index");
                }
                return View();
            }
            return HttpNotFound();
            }

        public ActionResult SepetCount(int?count)
        {
            if (User.Identity.IsAuthenticated)
            {
                var model = c.Carilers.FirstOrDefault(x => x.CariMail == User.Identity.Name);
                count = c.Sepets.Where(x => x.kullaniciid == model.SepetID).Count();
                ViewBag.count = count;
                if (count == 0)
                {
                    ViewBag.count = "";
                }
                return PartialView();
            }
            return HttpNotFound();
            }
    }
}
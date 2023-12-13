using ETicaretOtomasyonv2.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretOtomasyonv2.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis

        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult SatisYap()
        {

            List<SelectListItem> satiss = (from x in c.Urunlers.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.UrunAd,
                                                   Value = x.UrunID.ToString()
                                               }).ToList();
            List<SelectListItem> satiss2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.Cariid.ToString()
                                           }).ToList();

            List<SelectListItem> satiss3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.satis = satiss;

            ViewBag.satis2 = satiss2;

            ViewBag.satis3 = satiss3;

            return View();
        }

        [HttpPost]
        public ActionResult SatisYap(SatisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> satiss4 = (from x in c.Urunlers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();
            List<SelectListItem> satiss5 = (from x in c.Carilers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd + " " + x.CariSoyad,
                                                Value = x.Cariid.ToString()
                                            }).ToList();

            List<SelectListItem> satiss6 = (from x in c.Personels.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                Value = x.PersonelID.ToString()
                                            }).ToList();
            ViewBag.satis4 = satiss4;

            ViewBag.satis5 = satiss5;

            ViewBag.satis6 = satiss6;
            var satis = c.SatisHarekets.Find(id);
            return View("SatisGetir", satis);
        }

        public ActionResult SatisGuncelle(SatisHareket p)
        {
            var deger = c.SatisHarekets.Find(p.SatisID);
            deger.CariID = p.CariID;
            deger.Adet = p.Adet;
            deger.Fiyat = p.Fiyat;
            deger.Tarih = p.Tarih;
            deger.ToplamTutar = p.ToplamTutar;
            deger.UrunID = p.UrunID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay (int id ) 
        {
            var degersi = c.SatisHarekets.Where(x => x.SatisID == id).ToList();

            return View(degersi);



        }

        public ActionResult Buy ( int id )
        {
            var model = c.Sepets.Where(x => x.Sepetıd == id).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Buy2(int? id)
        {
            try
            {
                if (ModelState.IsValid)
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

                        ViewBag.Success = "Belirtilen ID ile sepet bulunamadı veya eksik bilgi gönderildi. ID: " + id;
                        return View("islem");
                    }


                }
               
            } catch (Exception)
            {
                ViewBag.Success = "Satın alma işlemi başarısız.";
            }
            return View("islem");

        }
    }
}
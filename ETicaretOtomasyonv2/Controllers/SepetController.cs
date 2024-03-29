﻿using ETicaretOtomasyonv2.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretOtomasyonv2.Controllers
{
    public class SepetController : Controller
    {
        // GET: Sepet
        Context c = new Context();


        [Authorize]
        public PartialViewResult Index(decimal? Tutar)
        {
            return PartialView();

        }


        public ActionResult CartPayment()
        {

            return View();
        }
        public ActionResult SepeteEkle(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var model = c.Carilers.FirstOrDefault(x => x.CariMail == kullaniciadi);
                var Uurunler = c.Urunlers.Find(id);
               

                
                if (model != null && Uurunler != null)
                {
                    var sepet = c.Sepets.FirstOrDefault(x => x.kullaniciid == model.Cariid && x.UrunId == id);
                    if (sepet != null)
                    {
                        decimal vergiliFiyat = Uurunler.Fiyat + Uurunler.Vergi;

                       
                        sepet.Adet++;

                       
                        sepet.Fiyat = vergiliFiyat * sepet.Adet;
                    }
                    else
                    {
                        var urunSepet = new Sepet()
                        {
                            kullaniciid = model.Cariid,
                            UrunId = Uurunler.UrunID,
                            Adet = 1,
                            Fiyat = Uurunler.Fiyat,
                            Tarih = DateTime.Now,
                            Vergi = Uurunler.Vergi
                        };
                        c.Sepets.Add(urunSepet);
                    }
                    try
                    {
                        c.SaveChanges();
                        return RedirectToAction("DetaylarPage", "Home");
                    }
                    catch (DbUpdateException ex)
                    {
                        Exception innerException = ex.InnerException;
                        while (innerException != null)
                        {
                           
                            Console.WriteLine(innerException.Message);
                            innerException = innerException.InnerException;
                        }

                     
                        throw;
                    }
                }
                return View(); 
            }
            return HttpNotFound();
        }

        public ActionResult SepetCount(int? count)
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

        public PartialViewResult checkout(decimal? Tutar2)
        {


            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi2 = User.Identity.Name;
                var kullanici2= c.Carilers.SingleOrDefault(x => x.CariMail == kullaniciadi2);
                var model = c.Sepets.Where(x => x.kullaniciid == kullanici2.Cariid).ToList();
                var kid2 = c.Sepets.FirstOrDefault(x => x.kullaniciid == kullanici2.Cariid);

                if (model != null)
                {
                    if (kid2 == null)
                    {
                        ViewBag.Tutar = "Sepetinizde Ürün Bulunmamaktadır.";
                    }
                    else if (kid2 != null)
                    {
                        Tutar2 = c.Sepets.Where(b => b.kullaniciid == kid2.kullaniciid).Sum(x => x.Urunler.Fiyat * x.Adet);
                        ViewBag.Tutar2 = Tutar2 + "TL";
                    }
                    return PartialView(model);
                }
            }
            return PartialView();







        }
        public PartialViewResult sepetim(decimal? Tutar)
        {

            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var kullanici = c.Carilers.SingleOrDefault(x => x.CariMail == kullaniciadi);
                var model = c.Sepets.Where(x => x.kullaniciid == kullanici.Cariid).ToList();
                var kid = c.Sepets.FirstOrDefault(x => x.kullaniciid == kullanici.Cariid);

                if (model != null)
                {
                    if (kid == null)
                    {
                        ViewBag.Tutar = "Sepetinizde Ürün Bulunmamaktadır.";
                    }
                    else if (kid != null)
                    {
                        Tutar = c.Sepets.Where(b => b.kullaniciid == kid.kullaniciid).Sum(x => x.Urunler.Fiyat + x.Adet);
                        ViewBag.Tutar =   Tutar + "TL";
                    }
                    return PartialView(model);
                }
            }
            return PartialView();

        }
    }
}
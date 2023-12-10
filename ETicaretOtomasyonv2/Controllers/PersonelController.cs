using ETicaretOtomasyonv2.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretOtomasyonv2.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel

        Context c = new Context();
        public ActionResult Index()
        {
            var deger = c.Personels.Where(x => x.Durum == true).ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {

            List<SelectListItem> urunle2r2s = (from x in c.Departmans.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.DepartmanAdı,
                                                  Value = x.DepartmanID.ToString()
                                              }).ToList();
            ViewBag.dgr22 = urunle2r2s;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel P)
        {
            c.Personels.Add(P);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelDelete(int id)
        {
           var personeldel =  c.Personels.Find(id);
            personeldel.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {

            List<SelectListItem> urunle2r2s2 = (from x in c.Departmans.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.DepartmanAdı,
                                                   Value = x.DepartmanID.ToString()
                                               }).ToList();
            ViewBag.dgr222 = urunle2r2s2;
            var per = c.Personels.Find(id);

            return View("PersonelGetir", per);
        }

        public ActionResult PersonelGuncelle (Personel p)
        {
         var persn = c.Personels.Find(p.PersonelID);
            persn.PersonelAd = p.PersonelAd;    
            persn.PersonelSoyad = p.PersonelSoyad;
            persn.PersonelGorsel = p.PersonelGorsel;
            persn.Durum = p.Durum;
            persn.DepartmanID = p.DepartmanID;
            c.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}

using ETicaretOtomasyonv2.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretOtomasyonv2.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        Context c = new Context();
        public ActionResult Index()
        {
            var degeler = c.Kategoris.ToList();
            return View(degeler);
        }

        [HttpGet]
        public ActionResult KategoriAdd()
        {
       
            return View();
        }

        [HttpPost]
        public ActionResult KategoriAdd(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult KategoriDelete(int id)
        {
            var kate = c.Kategoris.Find(id);
            c.Kategoris.Remove(kate);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var getir = c.Kategoris.Find(id);
            return View("KategoriGetir", getir);

        }

        public ActionResult KategoriGuncelle(Kategori k)
        {
            var guncelle = c.Kategoris.Find(k.KategoriID);
            guncelle.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
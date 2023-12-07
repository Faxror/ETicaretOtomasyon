using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaretOtomasyonv2.Models.Siniflar;


namespace ETicaretOtomasyonv2.Controllers
{

    public class DepartmanController : Controller
    {
        // GET: Departman


        Context c = new Context();

        public ActionResult Index()
        {
            var degerrr = c.Departmans.Where(x => x.Durum == true).ToList();
            return View(degerrr);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DepartmanDelete(int id)
        {
            var urun = c.Departmans.Find(id);
            urun.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var dpt = c.Departmans.Find(id);
            
            return View("DepartmanGetir", dpt);
        }

        public ActionResult DepartmanGuncelle(Departman k)
        {
            var guncelle = c.Departmans.Find(k.DepartmanID);
            guncelle.DepartmanAdı = k.DepartmanAdı;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var dep = c.Personels.Where(x => x.DepartmanID == id).ToList();
            var de = c.Departmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAdı).FirstOrDefault();
            ViewBag.d = de;
            return View(dep);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degersi = c.SatisHarekets.Where(x => x.PersonelID == id).ToList();
            var perr =  c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = perr;
            return View(degersi);
        }

    }
}
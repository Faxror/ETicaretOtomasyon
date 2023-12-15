using ETicaretOtomasyonv2.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretOtomasyonv2.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }


        public PartialViewResult Home()
        {
            var model = c.Urunlers.Where(x => x.Durum == true).ToList();
            return PartialView(model);
        }
    }
}
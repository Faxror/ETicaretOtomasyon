using ETicaretOtomasyonv2.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretOtomasyonv2.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]

       
        public ActionResult Index()
        {
            Context c = new Context();
            var users = c.Urunlers.ToList();
            return View(users);
           
        }

       public ActionResult DetaylarPage()
        {

            Context c = new Context();
            var userss = c.Urunlers.ToList();
            return View(userss);

        }

    }
}
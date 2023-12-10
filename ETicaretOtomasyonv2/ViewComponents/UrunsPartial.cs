using ETicaretOtomasyonv2.Models.Siniflar;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretOtomasyonv2.ViewComponents
{
    public class UrunsPartial : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var values = c.Urunlers.Where(x => x.Durum == true).ToList();
            return View(values);
        }
    }
}
﻿using ETicaretOtomasyonv2.Models.Siniflar;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretOtomasyonv2.ViewComponents
{ 
    public class DetaylarChackList : ViewComponent
    {

        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var values = c.Urunlers.ToList();
            return View(values);
        }
    }
}
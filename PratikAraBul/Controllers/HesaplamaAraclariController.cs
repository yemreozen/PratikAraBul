using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PratikAraBul.Controllers
{
    public class HesaplamaAraclariController : Controller
    {
        // GET: HesaplamaAraclari
       
        public ActionResult Index()
        {
            return View();
        }
       

        [Route("hesaplamaaraclari/{kategoriad}")]
        public ActionResult LgsPuanHesaplama()
        {
            return View();
        }
        public PartialViewResult HesaplamaMenu()
        {
            return PartialView();
        }

    }
}
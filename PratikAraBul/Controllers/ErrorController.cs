using PratikAraBul.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PratikAraBul.Controllers
{
    public class ErrorController : Controller
    {
        AraBulEntities ara = new AraBulEntities();
        public ActionResult Page404()
        {
            return View();
        }
        public PartialViewResult AramaSonucuBulunamadi()
        {
            var result = ara.tblPopularHizmet.ToList();

            return PartialView(result);
        }
    }
}
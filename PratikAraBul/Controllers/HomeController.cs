using PratikAraBul.Models;
using PratikAraBul.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PratikAraBul.Controllers
{

    public class HomeController : Controller
    {
        HizmetlerModel hizmetler = new HizmetlerModel();
        AraBulEntities db = new AraBulEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Menu()
        {
            hizmetler.HizmetKategoriList = db.tblHizmetKategori.ToList();
            hizmetler.HizmetlerList = db.tblHizmetler.ToList();
            return PartialView(hizmetler);
        }
        public ActionResult Page404()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }

    }
}
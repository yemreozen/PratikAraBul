using PratikAraBul.Models;
using PratikAraBul.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace PratikAraBul.Controllers
{

    public class MusteriHizmetleriNumaralariController : Controller
    {
        AraBulEntities db = new AraBulEntities();
        HizmetlerModel model = new HizmetlerModel();

        public ActionResult Index(int sayfa = 1)
        {


            var dgr = db.tblHizmetler.OrderBy(x => x.HizmetAdi).ToList().ToPagedList(sayfa, 6);

            return View(dgr);
        }

        [Route("musterihizmetlerinumaralari/details/{id}/{hizmetadi}")]

        public ActionResult Details(int id)
        {
            model.HizmetlerList = db.tblHizmetler.Where(x => x.HizmetId == id).ToList();
            model.HizmetKategoriList = db.tblHizmetKategori.ToList();
            model.PopularHizmetList = db.tblPopularHizmet.ToList();

            return View(model);
        }

        public PartialViewResult Comments(int id)
        {
            ViewBag.com = id;
            model.CommendList = db.tblCommend.Where(x => x.ComHizmetId == id).ToList();
            return PartialView(model);
        }


        public JsonResult YorumYap(string adsoyad, string eposta, string yorum, int hizmetid)
        {
            if (yorum == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            db.tblCommend.Add(new tblCommend { KullaniciAdi = adsoyad, KullaniciMail = eposta, KullaniciYorum = yorum, ComHizmetId = hizmetid });
            db.SaveChanges();

            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Arama(string p)
        {


            model.HizmetlerList = from d in db.tblHizmetler select d;
            if (!string.IsNullOrEmpty(p))
            {
               
                model.HizmetlerList = model.HizmetlerList.Where(x => x.HizmetAdi.Contains(p)).ToList();
                model.PopularHizmetList = db.tblPopularHizmet.ToList();
                 return View(model);
            }
            return RedirectToAction("Error", "Page404");

            




        }
        [Route("musterihizmetlerinumaralari/kategori/{id}/{kategoriad}")]
        public ActionResult Kategori(int id, int sayfa = 1)
        {
            var dgr = db.tblHizmetler.Where(m => m.HizmetKategori == id).ToList().ToPagedList(sayfa, 2);

            return View(dgr);
        }


    }
}
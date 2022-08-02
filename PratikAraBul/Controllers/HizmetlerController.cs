using PratikAraBul.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PratikAraBul.Controllers
{
    [Authorize]
    public class HizmetlerController : Controller
    {

        AraBulEntities db = new AraBulEntities();

        public ActionResult Index(string p)

        {
            var degerler = from d in db.tblHizmetler select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(x => x.HizmetAdi.Contains(p));
            }
            return View(degerler.ToList());

        }

        [HttpGet]
        public ActionResult YeniHizmet()

        {
            List<SelectListItem> deger = (from i in db.tblHizmetKategori.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.KategoriAd,
                                              Value = i.Id.ToString()

                                          }).ToList();


            ViewBag.kate = deger;
            return View();

        }

        [HttpPost]
        public ActionResult YeniHizmet(tblHizmetler pr)

        {
            if (Request.ContentLength > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/images/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                pr.HizmetResimUrl = dosyaadi + uzanti;

            }
            var ktg = db.tblHizmetKategori.Where(m => m.Id == pr.tblHizmetKategori.Id).FirstOrDefault();
            pr.tblHizmetKategori = ktg;

            db.tblHizmetler.Add(pr);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Sil(int id)
        {
            var kategori = db.tblHizmetler.Find(id);
            db.tblHizmetler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult HizmetGuncelle(int? id)
        {
            var hizmet = db.tblHizmetler.Find(id);
            List<SelectListItem> deger = (from i in db.tblHizmetKategori.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.KategoriAd,
                                              Value = i.Id.ToString()

                                          }).ToList();


            ViewBag.dgr = deger;
            return View("HizmetGuncelle", hizmet);


        }

        public ActionResult Guncelle(tblHizmetler p1)
        {
            var hizmetler = db.tblHizmetler.Find(p1.HizmetId);
            hizmetler.HizmetAdi = p1.HizmetAdi;
            hizmetler.HizmetNo = p1.HizmetNo;

            var ktg = db.tblHizmetKategori.Where(m => m.Id == p1.tblHizmetKategori.Id).FirstOrDefault();
            hizmetler.HizmetKategori = ktg.Id;

            //hizmetler.HizmetResimUrl=p1.HizmetResimUrl;
            if (Request.ContentLength < 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/images/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                hizmetler.HizmetResimUrl = dosyaadi + uzanti;

            }


            hizmetler.HizmetDesc = p1.HizmetDesc;
            hizmetler.BaslikAlti = p1.BaslikAlti;

            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
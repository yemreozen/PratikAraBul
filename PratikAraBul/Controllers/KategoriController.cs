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
    public class KategoriController : Controller
    {
        AraBulEntities db = new AraBulEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.tblHizmetKategori select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(x => x.KategoriAd.Contains(p));
            }
            return View(degerler.ToList());
            
        }
        public ActionResult YeniKategori()

        {
            return View();

        }
        
        [HttpPost]
        public ActionResult YeniKategori(tblHizmetKategori p1)

        {
           
            db.tblHizmetKategori.Add(p1);
            db.SaveChanges();
            return View();

        }
       
        public ActionResult Sil(int id)
        {
            var kategori = db.tblHizmetKategori.Find(id);
            db.tblHizmetKategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        public ActionResult KategoriGuncelle(int? id)
        {
            var ktgr = db.tblHizmetKategori.Find(id);
            return View("KategoriGuncelle", ktgr);


        }
        
        public ActionResult Guncellet(tblHizmetKategori p1)
        {
            var ktg = db.tblHizmetKategori.Find(p1.Id);
            ktg.KategoriAd = p1.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
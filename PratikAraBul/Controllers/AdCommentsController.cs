using PratikAraBul.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PratikAraBul.Controllers
{
    public class AdCommentsController : Controller
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
        public ActionResult CommentSil(int id)
        {
            var kategori = db.tblHizmetler.Find(id);
            db.tblHizmetler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
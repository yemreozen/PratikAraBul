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
        [Authorize]
        public ActionResult Index(string p)

        {
            var degerler = from d in db.tblCommend select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(x => x.KullaniciAdi.Contains(p));
            }
            return View(degerler.ToList());

        }
        public ActionResult CommentSil(int id)
        {
            var yorum = db.tblCommend.Find(id);
            db.tblCommend.Remove(yorum);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MakaleProje.DAL;
using MakaleProje.DTO;
using MakaleProje.Model;
using Newtonsoft.Json;

namespace MakaleProje.UI.Controllers
{
    public class YorumsController : Controller
    {
        // GET: Yorums
        public ActionResult Index()
        {
            return View(new YorumDAL().TumListe());
        }
        [Authorize]
        public ActionResult AdminIndex()
        {
            return View(new YorumDAL().OnaylanacakListe());
        }
        // GET: Yorums/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YorumID,MakaleID,ZiyaretciMail,YorumIcerik,AktifMi,Onay,OnayTarihi,ModifiedBy")] YorumDTO yorum)
        {
            if (ModelState.IsValid)
            {
                var sonuc = new YorumDAL().Ekle(yorum);
                return RedirectToAction("Index");
            }

            return View(yorum);
        }

        // GET: Yorums/Edit/5
        [Authorize]
        public ActionResult Edit(int id,bool onayDurum)
        {
            if (ModelState.IsValid)
            {
                int onaylayan = Convert.ToInt32(JsonConvert.DeserializeObject(Session["User"].ToString()));
                int sonuc = new YorumDAL().Guncelle(id,onayDurum,onaylayan);
                return RedirectToAction("AdminIndex");
            }
            return View();
        }
        // GET: Yorums/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YorumDTO yorum = new YorumDAL().TumListe().Where(a => a.YorumID == id).FirstOrDefault();
            if (yorum == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: Yorums/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Delete(int id)
        {
            int sonuc = new YorumDAL().Sil(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        base.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}

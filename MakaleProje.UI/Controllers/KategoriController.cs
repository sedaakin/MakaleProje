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

namespace MakaleProje.UI.Controllers
{
    public class KategoriController : Controller
    {

        // GET: Kategori
        public ActionResult Index()
        {
            return View(new KategoriDAL().Listele());
        }
        
        public ActionResult AltKategori(int id)
        {
            SelectList rt = new SelectList(new KategoriDAL().AltKategoriListele(id), "KategoriID", "KategoriAd");
            return Json(rt);
        }

        // GET: Kategori/Create
        public ActionResult Create()
        {
            ViewBag.UstKategori = (from k in new KategoriDAL().AnaKategoriListele()
                                   select new SelectListItem { Value = k.KategoriID.ToString(), Text = k.KategoriAd, }).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KategoriAd,CreatedBy,CreatedDate")] KategoriDTO kategori)
        {
            if (ModelState.IsValid)
            {
                kategori.CreatedDate = DateTime.Now;
                kategori.CreatedBy = 1;
                var sonuc = new KategoriDAL().Ekle(kategori);
                return RedirectToAction("Index");
            }

            return View(kategori);
        }

        // GET: Kategori/Edit/5
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategoriDTO kategori = new KategoriDAL().Listele().Where(a => a.KategoriID == id).FirstOrDefault();
            if (kategori == null)
            {
                return HttpNotFound();
            }
            ViewBag.UstKategori = (from k in new KategoriDAL().AnaKategoriListele()
                                   select new SelectListItem
                                   { Selected = kategori.UstKategoriID == k.KategoriID ? true : false,
                                       Value = k.KategoriAd.ToString()
                                   }).ToList();
            return View(kategori);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KategoriID,KategoriAd,AktifMi,CreatedBy,CreatedDate")] KategoriDTO kategori)
        {
            if (ModelState.IsValid)
            {
                int sonuc = new KategoriDAL().Guncelle(kategori);
                return RedirectToAction("Index");
            }
            return View(kategori);
        }

        // GET: Kategori/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategoriDTO kategori = new KategoriDAL().Listele().Where(a => a.KategoriID == id).FirstOrDefault();
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        // POST: Kategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            int sonuc = new KategoriDAL().Sil(id);
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

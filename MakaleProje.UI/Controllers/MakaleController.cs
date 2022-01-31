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
    
    public class MakaleController : Controller
    {

        // GET: Admin
        public ActionResult Index()
        {
            return View(new MakaleDAL().Listele());
        }

        //create ile ilgili hatam var, düzelteceğim
        // GET: Admin/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.UstKategori = (from k in new KategoriDAL().AnaKategoriListele()
                                  select new SelectListItem {Value=k.KategoriID.ToString(), Text= k.KategoriAd, }).ToList();
            ViewBag.AltKategori = (from k in new KategoriDAL().AltKategoriListele()
                                  select new SelectListItem { Value = k.KategoriID.ToString(), Text=k.KategoriAd}).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)] // html tagları için
        [Authorize]
        public ActionResult Create([Bind(Include = "KategoriID,MakaleMetni,MakaleBaslik")] MakaleDTO makale)
        {
            makale.CreatedDate = DateTime.Now;
            makale.CreatedBy = 1;
            if (ModelState.IsValid)
            {
                var sonuc = new MakaleDAL().Ekle(makale);
                return RedirectToAction("Index");
            }

            return View(makale);
        }

        // GET: Admin/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MakaleDTO makale = new MakaleDAL().Listele().Where(a => a.MakaleID == id).FirstOrDefault();
            if (makale == null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit( MakaleDTO makale)
        {
            if (ModelState.IsValid)
            {
                int sonuc = new MakaleDAL().Guncelle(makale);
                return RedirectToAction("Index");
            }
            return View(makale);
        }

        // GET: Admin/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MakaleDTO makale =  new MakaleDAL().Listele().Where(a => a.MakaleID == id).FirstOrDefault();
            if (makale == null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            int sonuc = new MakaleDAL().Sil(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
    }
}

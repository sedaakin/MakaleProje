
using MakaleProje.DAL;
using MakaleProje.DTO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MakaleProje.UI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int? page)
        {
            ViewBag.Makaleler =new MakaleDAL().Listele().ToPagedList(page ?? 1,3);
            return View();
        }
        public ActionResult Makale(int makaleId) //makaleyi okumaya devaö et butonuyla seçili makaleyi getirme
        {
            ViewBag.Makale = new MakaleDAL().Listele().Where(a => a.MakaleID == makaleId).FirstOrDefault();
            ViewBag.Yorum = new YorumDAL().Getir(makaleId);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Makale([Bind(Include = "AdSoyad,ZiyaretciMail,YorumIcerik,MakaleID")] YorumDTO yorum)
        {
            if (ModelState.IsValid)
            {
                var sonuc = new YorumDAL().Ekle(yorum);
                return RedirectToAction("Makale","Home",new { makaleId = yorum.MakaleID });
            }

            return View(yorum);
        }
        //[OutputCache(SqlDependency = "mainSqlDependency:MakaleTag;mainSqlDependency:Makale", Duration = 3600)]//ilgili tag için makaleleri cashe alıyorum,sql dependecy ile veri tabanı değişikliğine duyarlılığı da sağladım
        public ActionResult Tag(string tag,int? page) //aratılan tag'e göre makale listesini getirdim
        {
            ViewBag.Tag = Request.Form["search-text"];
            ViewBag.Makaleler = (from t in new MakaleTagDAL().Listele(Request.Form["search-text"])
                                 join m in new MakaleDAL().Listele() on t.MakaleID equals m.MakaleID
                                 select m).ToList().ToPagedList(page ?? 1, 3);
            return View();
        }
        [OutputCache(SqlDependency = "mainSqlDependency:Kategori", Duration = 3600)] //ilgili kategori için makaleleri cashe alıyorum,sql dependecy ile veri tabanı değişikliğine duyarlılığı da sağladım
        public ActionResult Kategori(int kategori,int? page) // menuden seçilen kategoriye göre makale listesini getirdim
        {
            ViewBag.Kategori =(new KategoriDAL().Listele().Where(a => a.KategoriID == kategori).FirstOrDefault()).KategoriAd;
            ViewBag.Makaleler = (from m in new MakaleDAL().Listele()
                                 where m.KategoriID==kategori
                                 select m).ToList().ToPagedList(page ?? 1, 3);
            return View();
        }
    }
}
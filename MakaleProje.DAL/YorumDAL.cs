using MakaleProje.DAL.Repository;
using MakaleProje.DTO;
using MakaleProje.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleProje.DAL
{
    public class YorumDAL
    {
        public List<YorumDTO> OnayliListele()
        {
            return MyAutoMapper<Yorum, YorumDTO>.MyMapList(new Repo<Yorum>().Listele().Where(a=> a.AktifMi == true && a.Onay == true).ToList());
        }
        public List<YorumDTO> TumListe()
        {
            return MyAutoMapper<Yorum, YorumDTO>.MyMapList(new Repo<Yorum>().Listele().Where(a => a.AktifMi == true).ToList());
        }
        public List<YorumDTO> OnaylanacakListe()
        {
            return MyAutoMapper<Yorum, YorumDTO>.MyMapList(new Repo<Yorum>().Listele().Where(a => a.AktifMi == true&&a.Onay==null).ToList());
        }
        public List<YorumDTO> Getir(int makaleId)
        {
            return MyAutoMapper<Yorum, YorumDTO>.MyMapList(new Repo<Yorum>().Listele().Where(a=>a.MakaleID==makaleId&&a.AktifMi==true&&a.Onay==true).OrderBy(a=>a.CreatedDate).ToList());
        }
        public int Ekle(YorumDTO yorum)
        {
            Yorum m = MyAutoMapper<YorumDTO, Yorum>.MyMap(yorum);
            m.AktifMi = true;
            m.CreatedDate = DateTime.Now;
            return new Repo<Yorum>().Ekle(m);
        }
        public int Guncelle(int Id,bool onayDurum,int onaylayan)
        {
            Yorum m = new Repo<Yorum>().IDyeGoreGetir(Id);
            m.Onay = onayDurum;
            m.Onaylayan = onaylayan;
            m.OnayTarihi = DateTime.Now;
            return new Repo<Yorum>().Guncelle(m);
        }

        public int Sil(int Id)
        {
            Yorum m = new Repo<Yorum>().Listele().Where(a => a.YorumID == Id).FirstOrDefault();
            m.AktifMi = false;
            return new Repo<Yorum>().Sil(m);
        }
    }
}

using MakaleProje.DAL.Repository;
using MakaleProje.DTO;
using MakaleProje.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleProje.DAL
{
    public class KullaniciDAL
    {
        public KullaniciDTO Getir(string kullaniciAdi,string sifre)
        {
            return MyAutoMapper<Kullanici, KullaniciDTO>.MyMap(new Repo<Kullanici>().Listele().Where(b => b.KullaniciAd == kullaniciAdi && b.Sifre == sifre).FirstOrDefault());
   
        }
        public List<KullaniciDTO> Listele()
        {
            return MyAutoMapper<Kullanici, KullaniciDTO>.MyMapList(new Repo<Kullanici>().Listele());
                   
        }
    }
}

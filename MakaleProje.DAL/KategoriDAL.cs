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
    public class KategoriDAL
    {
        public List<KategoriDTO> Listele()
        {
            return MyAutoMapper<Kategori, KategoriDTO>.MyMapList(new Repo<Kategori>().Listele().ToList());

        }
        public List<KategoriDTO> AnaKategoriListele()
        {
            return MyAutoMapper<Kategori, KategoriDTO>.MyMapList(new Repo<Kategori>().Listele().Where(a => a.KategoriID == a.UstKategoriID && a.AktifMi == true).ToList());
                     
        }
        public List<KategoriDTO> AltKategoriListele(int ustKategoriID)
        {
            return MyAutoMapper<Kategori, KategoriDTO>.MyMapList(new Repo<Kategori>().Listele().Where(a => a.UstKategoriID == ustKategoriID && a.KategoriID != ustKategoriID && a.AktifMi == true).ToList());
                   
        }
        public List<KategoriDTO> AltKategoriListele()
        {
            return MyAutoMapper<Kategori, KategoriDTO>.MyMapList(new Repo<Kategori>().Listele().Where(a => a.KategoriID != a.UstKategoriID && a.AktifMi == true).ToList());
        }
        public int Ekle(KategoriDTO kategori)
        {
            Kategori k = MyAutoMapper<KategoriDTO, Kategori>.MyMap(kategori);
            return new Repo<Kategori>().Ekle(k);
        }
        public int Guncelle(KategoriDTO  kategori)
        {
            Kategori k = MyAutoMapper<KategoriDTO, Kategori>.MyMap(kategori);
            return new Repo<Kategori>().Guncelle(k);
        }

        public int Sil(int Id)
        {
            Kategori k = new Repo<Kategori>().Listele().Where(a => a.KategoriID == Id).FirstOrDefault();
            k.AktifMi = false;
            return new Repo<Kategori>().Sil(k);
        }
    }
}

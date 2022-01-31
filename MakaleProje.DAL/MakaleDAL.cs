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
    public class MakaleDAL
    {
        public List<MakaleDTO> Listele()
        {
            return MyAutoMapper<Makale, MakaleDTO>.MyMapList(new Repo<Makale>().Listele().OrderByDescending(a=>a.CreatedDate).ToList());
        }
        public int Ekle(MakaleDTO makale)
        {
            Makale m = MyAutoMapper<MakaleDTO,Makale>.MyMap(makale);
           return new Repo<Makale>().Ekle(m);
        }
        public int Guncelle(MakaleDTO makale)
        {
            Makale m= MyAutoMapper<MakaleDTO, Makale>.MyMap(makale);
            return new Repo<Makale>().Guncelle(m);
        }
    
        public int Sil(int Id)
        {
           Makale m = new Repo<Makale>().Listele().Where(a=>a.MakaleID==Id).FirstOrDefault();
            m.AktifMi = false;
            return new Repo<Makale>().Sil(m);
        }
    }
}

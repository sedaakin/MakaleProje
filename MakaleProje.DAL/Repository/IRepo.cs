using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleProje.DAL.Repository
{
    public interface IRepo<T> where T : class
    {
        int Ekle(T eklenecekVeri);
        int Guncelle(T guncellenecekVer);
        int Sil(T silinecekVeri);
        List<T> Listele();
        List<T> Listele(Func<T, bool> listelenecekVeri);
        T IDyeGoreGetir(object ID);
    }
}

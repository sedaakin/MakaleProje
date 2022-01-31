using MakaleProje.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleProje.DAL.Repository
{
    public class Repo<T> : IRepo<T> where T : class
    {
        DbContext db;
        DbSet tablo;
        public Repo()
        {
            db = new Model1();
            // tablo = db.Set<T>();
        }
        public int Ekle(T eklenecekVeri)
        {
            db.Set<T>().Add(eklenecekVeri);
            return db.SaveChanges();
        }

        public int Guncelle(T guncellenecekVeri)
        {
            db.Set<T>().Attach(guncellenecekVeri);
            db.Entry(guncellenecekVeri).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public T IDyeGoreGetir(object ID)
        {
            return db.Set<T>().Find(ID); //tablo.find(ID);
        }

        public List<T> Listele()
        {
            return db.Set<T>().ToList();
        }

        public List<T> Listele(Func<T, bool> listelenecekVeri)
        {
            return db.Set<T>().Where(listelenecekVeri).ToList();
        }

        public int Sil(T silinecekVeri)
        {
            db.Set<T>().Attach(silinecekVeri);
            db.Entry(silinecekVeri).State = EntityState.Modified;
            return db.SaveChanges();
        }

    }
}

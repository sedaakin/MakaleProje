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
    public class MakaleTagDAL
    {
        public List<MakaleTagDTO> Listele(string Tag)
        {
            //kullanıcının gönderdiği tage göre makale listesi
            return (MyAutoMapper<MakaleTag, MakaleTagDTO>.MyMapList(new Repo<MakaleTag>().Listele().Where(a => a.MakaleTagi.Contains(Tag)).ToList()));
                   
        }
    }
}

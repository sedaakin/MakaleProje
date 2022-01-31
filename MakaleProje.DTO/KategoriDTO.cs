using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleProje.DTO
{
    public class KategoriDTO
    {
        public int KategoriID { get; set; }

        public int? UstKategoriID { get; set; }

        public string KategoriAd { get; set; }

        public bool AktifMi { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

    }
}

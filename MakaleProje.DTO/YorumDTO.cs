using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleProje.DTO
{
    public class YorumDTO
    {
        public int YorumID { get; set; }
        public int MakaleID { get; set; }
        [DisplayName("Email")]
        public string ZiyaretciMail { get; set; }
        [DisplayName("Yorum")]
        public string YorumIcerik { get; set; }
        public bool AktifMi { get; set; }
        public bool? Onay { get; set; }
        public DateTime? OnayTarihi { get; set; }
        public int? Onaylayan { get; set; }
        public DateTime? CreatedDate { get; set; }
        [DisplayName("Ad Soyad")]
        public string AdSoyad { get; set; }
    }
}

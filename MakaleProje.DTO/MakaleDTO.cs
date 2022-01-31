using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleProje.DTO
{
    public class MakaleDTO
    {
        public int MakaleID { get; set; }
        [DisplayName("Kategori")]
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }
        public int? YazarID { get; set; }
        [DisplayName("Makale Başlığı")]
        public string MakaleBaslik { get; set; }
        [DisplayName("Makale Metni")]
        public string MakaleMetni { get; set; }
        public bool AktifMi { get; set; }
        [DisplayName("Ekleyen")]
        public int CreatedBy { get; set; }
        [DisplayName("Eklenme Zamanı")]
      //  [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

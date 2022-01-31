using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleProje.DTO
{
    public class KullaniciDTO
    {
        public int KullaniciID { get; set; }
        [Required(ErrorMessage = "Boş geçilemez"), DisplayName("Kullanıcı Adı")]
        public string KullaniciAd { get; set; }
        [Required(ErrorMessage = "Boş geçilemez"), DisplayName("Şifre")]
        public string Sifre { get; set; }
        public int RolID { get; set; }
    }
}

namespace MakaleProje.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanici")]
    public partial class Kullanici
    {
        [Key]
        [Column(Order = 0)]
        public int KullaniciID { get; set; }

        [Column(Order = 1)]
        [StringLength(50)]
        public string KullaniciAd { get; set; }

        [Column(Order = 2)]
        [StringLength(50)]
        public string Sifre { get; set; }

        [Column(Order = 3)]
        public bool AktifMi { get; set; }

        public int? RolID { get; set; }
    }
}

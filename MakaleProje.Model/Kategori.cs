namespace MakaleProje.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kategori")]
    public partial class Kategori
    {
        [Key]
        [Column(Order = 0)]
        public int KategoriID { get; set; }

        public int? UstKategoriID { get; set; }

        [Column(Order = 1)]
        [StringLength(50)]
        public string KategoriAd { get; set; }

        [Column(Order = 2)]
        public bool AktifMi { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}

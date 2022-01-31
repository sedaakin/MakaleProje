namespace MakaleProje.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yorum")]
    public partial class Yorum
    {
        [Key]
        [Column(Order = 0)]
        public int YorumID { get; set; }

        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MakaleID { get; set; }

        [Column(Order = 2)]
        [StringLength(50)]
        public string ZiyaretciMail { get; set; }

        [Column(Order = 3)]
        [StringLength(1000)]
        public string YorumIcerik { get; set; }

        [Column(Order = 4)]
        public bool AktifMi { get; set; }

        public bool? Onay { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OnayTarihi { get; set; }

        public int? Onaylayan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(100)]
        public string AdSoyad { get; set; }
    }
}

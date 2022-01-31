namespace MakaleProje.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rol")]
    public partial class Rol
    {
        [Key]
        [Column(Order = 0)]
        public int RolID { get; set; }

        [Column(Order = 1)]
        [StringLength(50)]
        public string RolAdi { get; set; }
    }
}

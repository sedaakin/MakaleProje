namespace MakaleProje.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MakaleTag")]
    public partial class MakaleTag
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string MakaleTagi { get; set; }

        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MakaleID { get; set; }
    }
}

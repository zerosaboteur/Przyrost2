namespace ZapisXmlJsonSql
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Albumy")]
    public partial class Albumy
    {
        [Key]
        public int id_album { get; set; }

        [Required]
        [StringLength(30)]
        public string nazwa_albumu { get; set; }

        [StringLength(30)]
        public string wykonawca { get; set; }

        [StringLength(30)]
        public string wytwornia { get; set; }

        [StringLength(20)]
        public string gatunek { get; set; }

        public DateTime data_wydania { get; set; }

        public virtual Zespoly Zespoly { get; set; }

        public virtual Wytwornie Wytwornie { get; set; }
    }
}

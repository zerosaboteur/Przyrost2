namespace ZapisXmlJsonSql
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Adresy")]
    public partial class Adresy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_adresow { get; set; }

        [StringLength(30)]
        public string naz_wyt { get; set; }

        [StringLength(20)]
        public string miasto { get; set; }

        public virtual Wytwornie Wytwornie { get; set; }
    }
}

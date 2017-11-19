namespace ZapisXmlJsonSql
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Autorzy")]
    public partial class Autorzy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_autor { get; set; }

        [StringLength(30)]
        public string nazwisko { get; set; }

        [StringLength(10)]
        public string kraj { get; set; }
    }
}

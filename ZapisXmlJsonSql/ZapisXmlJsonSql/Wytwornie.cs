namespace ZapisXmlJsonSql
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Wytwornie")]
    public partial class Wytwornie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Wytwornie()
        {
            Adresies = new HashSet<Adresy>();
            Albumies = new HashSet<Albumy>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_wytworni { get; set; }

        [Key]
        [StringLength(30)]
        public string nazwa_wytworni { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adresy> Adresies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Albumy> Albumies { get; set; }
    }
}

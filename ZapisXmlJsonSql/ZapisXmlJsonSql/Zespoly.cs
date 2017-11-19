namespace ZapisXmlJsonSql
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Zespoly")]
    public partial class Zespoly
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zespoly()
        {
            Albumies = new HashSet<Albumy>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_zespolu { get; set; }

        [Key]
        [StringLength(30)]
        public string nazwa_zespolu { get; set; }

        public DateTime data_zalozenia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Albumy> Albumies { get; set; }
    }
}

namespace ZapisXmlJsonSql
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Muzyka : DbContext
    {
        public Muzyka()
            : base("name=Muzyka")
        {
        }

        public virtual DbSet<Adresy> Adresies { get; set; }
        public virtual DbSet<Albumy> Albumies { get; set; }
        public virtual DbSet<Autorzy> Autorzies { get; set; }
        public virtual DbSet<Wytwornie> Wytwornies { get; set; }
        public virtual DbSet<Zespoly> Zespolies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adresy>()
                .Property(e => e.naz_wyt)
                .IsUnicode(false);

            modelBuilder.Entity<Adresy>()
                .Property(e => e.miasto)
                .IsUnicode(false);

            modelBuilder.Entity<Albumy>()
                .Property(e => e.nazwa_albumu)
                .IsUnicode(false);

            modelBuilder.Entity<Albumy>()
                .Property(e => e.wykonawca)
                .IsUnicode(false);

            modelBuilder.Entity<Albumy>()
                .Property(e => e.wytwornia)
                .IsUnicode(false);

            modelBuilder.Entity<Albumy>()
                .Property(e => e.gatunek)
                .IsUnicode(false);

            modelBuilder.Entity<Autorzy>()
                .Property(e => e.nazwisko)
                .IsUnicode(false);

            modelBuilder.Entity<Autorzy>()
                .Property(e => e.kraj)
                .IsUnicode(false);

            modelBuilder.Entity<Wytwornie>()
                .Property(e => e.nazwa_wytworni)
                .IsUnicode(false);

            modelBuilder.Entity<Wytwornie>()
                .HasMany(e => e.Adresies)
                .WithOptional(e => e.Wytwornie)
                .HasForeignKey(e => e.naz_wyt);

            modelBuilder.Entity<Wytwornie>()
                .HasMany(e => e.Albumies)
                .WithOptional(e => e.Wytwornie)
                .HasForeignKey(e => e.wytwornia);

            modelBuilder.Entity<Zespoly>()
                .Property(e => e.nazwa_zespolu)
                .IsUnicode(false);

            modelBuilder.Entity<Zespoly>()
                .HasMany(e => e.Albumies)
                .WithOptional(e => e.Zespoly)
                .HasForeignKey(e => e.wykonawca);
        }
    }
}

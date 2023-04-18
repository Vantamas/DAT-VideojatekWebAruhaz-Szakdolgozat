using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GameMaintenance.Models
{
    public partial class jatekshopContext : DbContext
    {
        public jatekshopContext()
        {
        }

        public jatekshopContext(DbContextOptions<jatekshopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Felhasznalok> Felhasznaloks { get; set; }
        public virtual DbSet<Kosar> Kosars { get; set; }
        public virtual DbSet<Osszesjatek> Osszesjateks { get; set; }
        public virtual DbSet<Registry> Registries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;database=jatekshop;user=root;password=;ssl mode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Felhasznalok>(entity =>
            {
                entity.ToTable("felhasznalok");

                entity.HasIndex(e => e.Email, "Email")
                    .IsUnique();

                entity.HasIndex(e => e.FelhasznaloNev, "FelhasznaloNev")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Aktiv).HasColumnType("int(1)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FelhasznaloNev)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Hash)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("HASH");

                entity.Property(e => e.Jogosultsag).HasColumnType("int(1)");

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("SALT");

                entity.Property(e => e.TeljesNev)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Kosar>(entity =>
            {
                entity.ToTable("kosar");

                entity.HasIndex(e => e.JatekId, "jatekId");

                entity.HasIndex(e => e.VasarloId, "vasarloId");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Darab)
                    .HasColumnType("int(5)")
                    .HasColumnName("darab");

                entity.Property(e => e.JatekId)
                    .HasColumnType("int(11)")
                    .HasColumnName("jatekId");

                entity.Property(e => e.VasarloId)
                    .HasColumnType("int(11)")
                    .HasColumnName("vasarloId");

                entity.HasOne(d => d.Jatek)
                    .WithMany(p => p.Kosars)
                    .HasForeignKey(d => d.JatekId)
                    .HasConstraintName("kosar_ibfk_1");

                entity.HasOne(d => d.Vasarlo)
                    .WithMany(p => p.Kosars)
                    .HasForeignKey(d => d.VasarloId)
                    .HasConstraintName("kosar_ibfk_2");
            });

            modelBuilder.Entity<Osszesjatek>(entity =>
            {
                entity.ToTable("osszesjatek");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Ar)
                    .HasColumnType("int(11)")
                    .HasColumnName("ar");

                entity.Property(e => e.Kategoria)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("kategoria");

                entity.Property(e => e.Kep)
                    .IsRequired()
                    .HasColumnType("mediumblob")
                    .HasColumnName("kep");

                entity.Property(e => e.Leiras)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("leiras");

                entity.Property(e => e.Megjelenes)
                    .HasColumnType("date")
                    .HasColumnName("megjelenes");

                entity.Property(e => e.Nev)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nev");
            });

            modelBuilder.Entity<Registry>(entity =>
            {
                entity.ToTable("registry");

                entity.HasIndex(e => e.Key, "key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FelhasznaloNev)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Hash)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("HASH");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("SALT");

                entity.Property(e => e.TeljesNev)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

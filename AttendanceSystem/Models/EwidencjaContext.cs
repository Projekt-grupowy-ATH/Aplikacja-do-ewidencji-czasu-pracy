using System;
using AttendanceSystem.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AttendanceSystem.Models
{
    public partial class EwidencjaContext : IdentityDbContext<AttendanceSystemUser>
    {
        public EwidencjaContext()
        {
        }

        public EwidencjaContext(DbContextOptions<EwidencjaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pracownik> Pracownik { get; set; }
        public virtual DbSet<Projekt> Projekt { get; set; }
        public virtual DbSet<Wykonanie> Wykonanie { get; set; }
        public virtual DbSet<Zadanie> Zadanie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=EwidencjaDb;User=sa;Password=<YourNewStrong@Passw0rd>;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pracownik>(entity =>
            {
                entity.HasKey(e => e.Idpracownika)
                    .HasName("PK__Pracowni__F649A2ACA22A28C7");

                entity.Property(e => e.Idpracownika).HasColumnName("IDPracownika");

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Stanowisko)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Uprawnienia)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Projekt>(entity =>
            {
                entity.HasKey(e => e.Idprojektu)
                    .HasName("PK__Projekt__7D606A1302230AB9");

                entity.Property(e => e.Idprojektu).HasColumnName("IDProjektu");

                entity.Property(e => e.Idpracownika).HasColumnName("IDPracownika");

                entity.Property(e => e.NazwaProjektu)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdpracownikaNavigation)
                    .WithMany(p => p.Projekt)
                    .HasForeignKey(d => d.Idpracownika)
                    .HasConstraintName("FK__Projekt__IDPraco__267ABA7A");
            });

            modelBuilder.Entity<Wykonanie>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Idpracownika).HasColumnName("IDPracownika");

                entity.Property(e => e.Idzadania).HasColumnName("IDZadania");

                entity.HasOne(d => d.IdpracownikaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idpracownika)
                    .HasConstraintName("FK__Wykonanie__IDPra__2B3F6F97");

                entity.HasOne(d => d.IdzadaniaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idzadania)
                    .HasConstraintName("FK__Wykonanie__IDZad__2C3393D0");
            });

            modelBuilder.Entity<Zadanie>(entity =>
            {
                entity.HasKey(e => e.Idzadania)
                    .HasName("PK__Zadanie__4D3096C7D80B50FE");

                entity.Property(e => e.Idzadania).HasColumnName("IDZadania");

                entity.Property(e => e.Idprojektu).HasColumnName("IDProjektu");

                entity.Property(e => e.NazwaZadania)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdprojektuNavigation)
                    .WithMany(p => p.Zadanie)
                    .HasForeignKey(d => d.Idprojektu)
                    .HasConstraintName("FK__Zadanie__IDProje__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

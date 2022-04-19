using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RaktarkezeloAPI.Models
{
    public partial class raktarkezeloContext : DbContext
    {
        public raktarkezeloContext()
        {
        }

        public raktarkezeloContext(DbContextOptions<raktarkezeloContext> options)
            : base(options)
        {
        }

        public virtual DbSet<eladas> eladas { get; set; }
        public virtual DbSet<raktar> raktar { get; set; }
        public virtual DbSet<termek> termek { get; set; }
        public virtual DbSet<termekcsoport> termekcsoport { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=root;database=raktarkezelo", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.14-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_hungarian_ci");

            modelBuilder.Entity<eladas>(entity =>
            {
                entity.HasOne(d => d.termek)
                    .WithMany(p => p.eladas)
                    .HasForeignKey(d => d.termekID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("eladas_ibfk_1");
            });

            modelBuilder.Entity<termek>(entity =>
            {
                entity.HasOne(d => d.raktar)
                    .WithMany(p => p.termek)
                    .HasForeignKey(d => d.raktarID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("termek_ibfk_2");

                entity.HasOne(d => d.termekcsoport)
                    .WithMany(p => p.termek)
                    .HasForeignKey(d => d.termekcsoportID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("termek_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

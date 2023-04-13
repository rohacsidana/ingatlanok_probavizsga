using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ingatlanok_vizsgafeladat.Models;

public partial class IngatlanContext : DbContext
{
    public IngatlanContext()
    {
    }

    public IngatlanContext(DbContextOptions<IngatlanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ingatlanok> Ingatlanoks { get; set; }

    public virtual DbSet<Kategoriak> Kategoriaks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=ingatlan;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingatlanok>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ingatlan__3213E83F927A7C14");

            entity.ToTable("ingatlanok");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ar).HasColumnName("ar");
            entity.Property(e => e.HirdetesDatuma)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("hirdetesDatuma");
            entity.Property(e => e.Kategoria).HasColumnName("kategoria");
            entity.Property(e => e.KepUrl)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("kepUrl");
            entity.Property(e => e.Leiras)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("leiras");
            entity.Property(e => e.Tehermentes).HasColumnName("tehermentes");

            entity.HasOne(d => d.KategoriaNavigation).WithMany(p => p.Ingatlanoks)
                .HasForeignKey(d => d.Kategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ingatlano__kateg__398D8EEE");
        });

        modelBuilder.Entity<Kategoriak>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__kategori__3213E83FCDBFA25C");

            entity.ToTable("kategoriak");

            entity.HasIndex(e => e.Nev, "UQ__kategori__DF900F6744CDA537").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nev)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nev");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

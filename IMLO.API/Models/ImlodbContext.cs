using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IMLO.API.Models;

public partial class ImlodbContext : DbContext
{
    public ImlodbContext()
    {
    }

    public ImlodbContext(DbContextOptions<ImlodbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MemTraMdadet> MemTraMdadets { get; set; }

    public virtual DbSet<MemTraMtrdet> MemTraMtrdets { get; set; }

    public virtual DbSet<MemTraTbfinVw> MemTraTbfinVws { get; set; }

    public virtual DbSet<MemTraTcDet> MemTraTcDets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-36E7U2LK\\SQLEXPRESS;Initial Catalog=imlodb;User ID=sa;Password=12345678;Integrated Security=False;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MemTraMdadet>(entity =>
        {
            entity.HasKey(e => new { e.ClaNodo, e.Fecha, e.Hora });

            entity.ToTable("MemTraMDADet", "MemSch");

            entity.Property(e => e.ClaNodo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("claNodo");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.FechaUltimaMod).HasColumnType("datetime");
            entity.Property(e => e.IdMda).HasColumnName("idMDA");
            entity.Property(e => e.NombrePcMod)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.Pml)
                .HasColumnType("decimal(10, 5)")
                .HasColumnName("pml");
            entity.Property(e => e.PmlCng)
                .HasColumnType("decimal(10, 5)")
                .HasColumnName("pml_cng");
            entity.Property(e => e.PmlEne)
                .HasColumnType("decimal(10, 5)")
                .HasColumnName("pml_ene");
            entity.Property(e => e.PmlPer)
                .HasColumnType("decimal(10, 5)")
                .HasColumnName("pml_per");
        });

        modelBuilder.Entity<MemTraMtrdet>(entity =>
        {
            entity.HasKey(e => new { e.ClaNodo, e.Fecha, e.Hora });

            entity.ToTable("MemTraMTRDet", "MemSch");

            entity.Property(e => e.ClaNodo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("claNodo");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.FechaUltimaMod).HasColumnType("datetime");
            entity.Property(e => e.IdMtr).HasColumnName("idMTR");
            entity.Property(e => e.NombrePcMod)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.Pml)
                .HasColumnType("decimal(10, 5)")
                .HasColumnName("pml");
            entity.Property(e => e.PmlCng)
                .HasColumnType("decimal(10, 5)")
                .HasColumnName("pml_cng");
            entity.Property(e => e.PmlEne)
                .HasColumnType("decimal(10, 5)")
                .HasColumnName("pml_ene");
            entity.Property(e => e.PmlPer)
                .HasColumnType("decimal(10, 5)")
                .HasColumnName("pml_per");
        });

        modelBuilder.Entity<MemTraTbfinVw>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MemTraTBFinVw", "MemSch");

            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.TbFin).HasColumnType("numeric(38, 14)");
            entity.Property(e => e.TbFinTgr)
                .HasColumnType("numeric(38, 9)")
                .HasColumnName("TbFinTGR");
        });

        modelBuilder.Entity<MemTraTcDet>(entity =>
        {
            entity.HasKey(e => e.Fecha);

            entity.ToTable("MemTraTcDet", "MemSch");

            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.FechaUltimaMod).HasColumnType("datetime");
            entity.Property(e => e.IdTc).HasColumnName("idTc");
            entity.Property(e => e.NombrePcMod)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(10, 6)")
                .HasColumnName("valor");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

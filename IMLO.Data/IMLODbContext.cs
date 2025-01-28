using IMLO.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace IMLO.Data;

public partial class IMLODbContext : DbContext
{
    public IMLODbContext()
    {
    }

    public IMLODbContext(DbContextOptions<IMLODbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MemTraMdadet> MemTraMDADet { get; set; }

    public virtual DbSet<MemTraMtrdet> MemTraMTRDet { get; set; }

    public virtual DbSet<MemTraTbfinVw> MemTraTBFinVw { get; set; }

    public virtual DbSet<MemTraTcDet> MemTraTcDet { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MemTraMdadet>(entity =>
        {
            entity.HasKey(e => new { e.ClaNodo, e.Fecha, e.Hora });

            entity.Property(e => e.ClaNodo)
                .HasMaxLength(10)
                .IsUnicode(false);
            

            entity.Property(e => e.NombrePcMod)
                .HasMaxLength(30);
        });

        modelBuilder.Entity<MemTraMtrdet>(entity =>
        {
            entity.HasKey(e => new { e.ClaNodo, e.Fecha, e.Hora });

            entity.Property(e => e.ClaNodo)
                .HasMaxLength(10)
                .IsUnicode(false);

           
            entity.Property(e => e.NombrePcMod)
                .HasMaxLength(30);
        });

        modelBuilder.Entity<MemTraTbfinVw>(entity =>
        {
            entity
                .HasNoKey();
        });

        modelBuilder.Entity<MemTraTcDet>(entity =>
        {
            entity.HasKey(e => e.Fecha);

            entity.Property(e => e.NombrePcMod)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TallerMecanico.DAL.Models;

public partial class TallerMecanicoContext : DbContext
{
    public TallerMecanicoContext()
    {
    }

    public TallerMecanicoContext(DbContextOptions<TallerMecanicoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Automovile> Automoviles { get; set; }

    public virtual DbSet<DescuentosRecargo> DescuentosRecargos { get; set; }

    public virtual DbSet<Desperfecto> Desperfectos { get; set; }

    public virtual DbSet<DesperfectosRepuesto> DesperfectosRepuestos { get; set; }

    public virtual DbSet<Moto> Motos { get; set; }

    public virtual DbSet<Presupuesto> Presupuestos { get; set; }

    public virtual DbSet<Repuesto> Repuestos { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-KR5DOH6;Initial Catalog=TallerMecanico;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Automovile>(entity =>
        {
            entity.Property(e => e.CantidadPuertas).HasColumnType("smalldatetime");

            entity.HasOne(d => d.IdVehiculoNavigation).WithMany(p => p.Automoviles)
                .HasForeignKey(d => d.IdVehiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Automoviles_Vehiculos");
        });

        modelBuilder.Entity<DescuentosRecargo>(entity =>
        {
            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.ValorAbsoluto)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(16, 2)");
            entity.Property(e => e.ValorPorcentual)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(16, 2)");
        });

        modelBuilder.Entity<Desperfecto>(entity =>
        {
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ManoDeObra).HasColumnType("decimal(16, 2)");

            entity.HasOne(d => d.IdPresupuestoNavigation).WithMany(p => p.Desperfectos)
                .HasForeignKey(d => d.IdPresupuesto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Desperfectos_Presupuestos");
        });

        modelBuilder.Entity<DesperfectosRepuesto>(entity =>
        {
            entity.HasOne(d => d.IdDesperfectoNavigation).WithMany(p => p.DesperfectosRepuestos)
                .HasForeignKey(d => d.IdDesperfecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DesperfectosRepuestos_Desperfectos");

            entity.HasOne(d => d.IdRepuestoNavigation).WithMany(p => p.DesperfectosRepuestos)
                .HasForeignKey(d => d.IdRepuesto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DesperfectosRepuestos_Repuestos");
        });

        modelBuilder.Entity<Moto>(entity =>
        {
            entity.Property(e => e.Cilindrada)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdVehiculoNavigation).WithMany(p => p.Motos)
                .HasForeignKey(d => d.IdVehiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Motos_Vehiculos");
        });

        modelBuilder.Entity<Presupuesto>(entity =>
        {
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Total).HasColumnType("decimal(16, 2)");

            entity.HasOne(d => d.IdVehiculoNavigation).WithMany(p => p.Presupuestos)
                .HasForeignKey(d => d.IdVehiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Presupuestos_Vehiculos");
        });

        modelBuilder.Entity<Repuesto>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(16, 2)");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
            entity.Property(e => e.Marca)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Patente)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

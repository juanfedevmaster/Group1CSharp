using System;
using System.Collections.Generic;
using FarmaciaTalentoTech.Model.Modelos;
using FarmaciaTalentoTech.RepositoryEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FarmaciaTalentoTech.RepositoryEF.DataBaseContext;

public partial class FarmaciaTalentoTechContext : DbContext
{
    public FarmaciaTalentoTechContext(DbContextOptions<FarmaciaTalentoTechContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Farmaceutica> Farmaceuticas { get; set; }

    public virtual DbSet<Presentacione> Presentaciones { get; set; }

    public virtual DbSet<PrincipiosActivo> PrincipiosActivos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductoPresentacione> ProductoPresentaciones { get; set; }

    public virtual DbSet<ProductoPrincipioActivo> ProductoPrincipioActivos { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("FarmaciaTalentoTechDBConnection"));
    */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.IdRols).WithMany(p => p.IdPermisos)
                .UsingEntity<Dictionary<string, object>>(
                    "PermisosRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PermisosRoles_Roles"),
                    l => l.HasOne<Permiso>().WithMany()
                        .HasForeignKey("IdPermiso")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PermisosRoles_Permisos"),
                    j =>
                    {
                        j.HasKey("IdPermiso", "IdRol");
                        j.ToTable("PermisosRoles");
                    });
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Roles");
        });

        modelBuilder.Entity<Farmaceutica>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasOne(d => d.IdFarmaceuticaNavigation).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Productos_Farmaceuticas");
        });

        modelBuilder.Entity<ProductoPresentacione>(entity =>
        {
            entity.HasOne(d => d.IdPresentacionNavigation).WithMany(p => p.ProductoPresentaciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductoPresentaciones_Presentaciones");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProductoPresentaciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductoPresentaciones_Productos");
        });

        modelBuilder.Entity<ProductoPrincipioActivo>(entity =>
        {
            entity.HasOne(d => d.IdPrincipioActivoNavigation).WithMany(p => p.ProductoPrincipioActivos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductoPrincipioActivo_PrincipiosActivos");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProductoPrincipioActivos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductoPrincipioActivo_Productos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

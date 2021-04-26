using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tienda.core.Entidades;

namespace Tienda.infrec.Data
{
    public partial class TiendaContext : DbContext
    {
        public TiendaContext()
        {
        }

        public TiendaContext(DbContextOptions<TiendaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<HistorialVentas> HistorialVentas { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Vendedor> Vendedor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Apellido)
                    .HasColumnName("apellido")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HistorialVentas>(entity =>
            {
                entity.HasKey(e => e.IdHistorial);

                entity.ToTable("Historial_ventas");

                entity.Property(e => e.IdHistorial).HasColumnName("idHistorial");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.IdVendedor).HasColumnName("idVendedor");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.HistorialVentas)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Historial__idCli__29572725");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.HistorialVentas)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK__Historial__idPro__2B3F6F97");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.HistorialVentas)
                    .HasForeignKey(d => d.IdVendedor)
                    .HasConstraintName("FK__Historial__idVen__2A4B4B5E");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnName("precio");
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.HasKey(e => e.IdVendedor);

                entity.Property(e => e.IdVendedor).HasColumnName("idVendedor");

                entity.Property(e => e.Apellido)
                    .HasColumnName("apellido")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.FecharContratado)
                    .HasColumnName("fechar_Contratado")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });
        }
    }
}

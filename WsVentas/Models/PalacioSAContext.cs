using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WsVentas.Models
{
    public partial class PalacioSAContext : DbContext
    {
        public PalacioSAContext()
        {
        }

        public PalacioSAContext(DbContextOptions<PalacioSAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<DetalleVenta> DetalleVentas { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-K65QDHU\\SQLEXPRESS;Database=PalacioSA;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.cliId);

                entity.Property(e => e.cliId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("cli_Id");

                entity.Property(e => e.CliNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cli_Nombre");
            });

            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.HasKey(e => e.DveId);

                entity.Property(e => e.DveId)
                    .ValueGeneratedNever()
                    .HasColumnName("dve_Id");

                entity.Property(e => e.DveCantidad).HasColumnName("dve_Cantidad");

                entity.Property(e => e.DveCliId).HasColumnName("dve_cli_Id");

                entity.Property(e => e.DveImporte)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("dve_Importe");

                entity.Property(e => e.DvePrdId).HasColumnName("dve_prd_Id");

                entity.Property(e => e.DvePrecioUnitario)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("dve_PrecioUnitario");

                entity.Property(e => e.DveVenId).HasColumnName("dve_ven_Id");

                entity.HasOne(d => d.DveCli)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.DveCliId)
                    .HasConstraintName("FK_DetalleVentas_Clientes");

                entity.HasOne(d => d.DvePrd)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.DvePrdId)
                    .HasConstraintName("FK_DetalleVentas_Productos");

                entity.HasOne(d => d.DveVen)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.DveVenId)
                    .HasConstraintName("FK_DetalleVentas_Ventas");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.PrdId);

                entity.Property(e => e.PrdId)
                    .ValueGeneratedNever()
                    .HasColumnName("prd_Id");

                entity.Property(e => e.PrdCosto)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("prd_Costo");

                entity.Property(e => e.PrdNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("prd_Nombre");

                entity.Property(e => e.PrdPrecioUnitario)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("prd_PrecioUnitario");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.VenId);

                entity.Property(e => e.VenId).HasColumnName("ven_Id");

                entity.Property(e => e.VenFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("ven_Fecha");

                entity.Property(e => e.VenTotal)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("ven_Total");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

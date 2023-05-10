using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Warehouse.Model;

public partial class WarehouseDataBaseContext : DbContext
{
    public WarehouseDataBaseContext()
    {
    }

    public virtual DbSet<Carryng> Carryngs { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<Sales> Saleses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=> optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=WarehouseDataBase;Username=postgres;Password=0000");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carryng>(entity =>
        {
            entity.ToTable("carryng");
            entity.HasKey(e => e.IdCarryng).HasName("carryng_pkey");

            entity.Property(e => e.IdCarryng).ValueGeneratedNever().HasColumnName("id_carryng");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IdWarehouse).HasColumnName("id_warehouse");
            entity.Property(e => e.Quanity).HasColumnName("quanity");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Carryngs).HasForeignKey(d => d.IdProduct).HasConstraintName("carryng_id_product_fkey");
            entity.HasOne(d => d.IdWarehouseNavigation).WithMany(p => p.Carryngs).HasForeignKey(d => d.IdWarehouse).HasConstraintName("carryng_id_warehouse_fkey");
        });

        modelBuilder.Entity<Sales>(entity =>
        {
            entity.ToTable("sales");
            entity.HasKey(e => e.IdSales).HasName("sales_pkey");

            entity.Property(e => e.IdSales).ValueGeneratedNever().HasColumnName("id_sales");
            entity.Property(e => e.idProduct).HasColumnName("id_product");
            entity.Property(e => e.idWarehouse).HasColumnName("id_warehouse");
            entity.Property(e => e.Quanity).HasColumnName("quanity");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Saleses).HasForeignKey(d => d.idProduct).HasConstraintName("sales_id_product_fkey");
            entity.HasOne(d => d.IdWarehouseNavigation).WithMany(p => p.Saleses).HasForeignKey(d => d.idWarehouse).HasConstraintName("sales_id_warehouse_fkey");
        });

        modelBuilder.Entity<Category>(entity => 
        {
            entity.HasKey(e => e.IdCategory).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.IdCategory).ValueGeneratedNever().HasColumnName("id_category");
            entity.Property(e => e.NameCategory).HasMaxLength(255).HasColumnName("name_category");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("product_pkey");

            entity.ToTable("product");

            entity.Property(e => e.IdProduct).ValueGeneratedNever().HasColumnName("id_product");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.NameProduct).HasMaxLength(255).HasColumnName("name_product");
            entity.Property(e => e.Price).HasPrecision(10, 2).HasColumnName("price");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products).HasForeignKey(d => d.IdCategory).HasConstraintName("product_id_category_fkey");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => new { e.IdProduct, e.IdWarehouse }).HasName("stock_pkey");

            entity.ToTable("stock");

            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IdWarehouse).HasColumnName("id_warehouse");
            entity.Property(e => e.Quanity).HasColumnName("quanity");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Stocks).HasForeignKey(d => d.IdProduct).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("stock_id_product_fkey");

            entity.HasOne(d => d.IdWarehouseNavigation).WithMany(p => p.Stocks).HasForeignKey(d => d.IdWarehouse).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("stock_id_warehouse_fkey");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.IdWarehouse).HasName("warehouse_pkey");

            entity.ToTable("warehouse");

            entity.Property(e => e.IdWarehouse).ValueGeneratedNever().HasColumnName("id_warehouse");
            entity.Property(e => e.AddressWarehouse).HasMaxLength(255).HasColumnName("address_warehouse");
            entity.Property(e => e.NameWarehouse).HasMaxLength(255).HasColumnName("name_warehouse");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

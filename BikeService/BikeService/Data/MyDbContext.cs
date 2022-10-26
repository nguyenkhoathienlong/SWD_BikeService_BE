using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BikeService.Models;

namespace BikeService.Data
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<District> Districts { get; set; } = null!;
        public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public virtual DbSet<Model> Models { get; set; } = null!;
        public virtual DbSet<Motorbike> Motorbikes { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;
        public virtual DbSet<StoreCategory> StoreCategories { get; set; } = null!;
        public virtual DbSet<Ward> Wards { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("area");

                entity.HasIndex(e => e.DistrictId, "fk_district_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DistrictId).HasColumnName("district_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Areas)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("fk_district_id");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brand");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsActived)
                    .HasColumnType("bit(1)")
                    .HasColumnName("is_actived")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(11)
                    .HasColumnName("phoneNumber");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("district");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("manufacturer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("model");

                entity.HasIndex(e => e.BrandId, "id_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.Code)
                    .HasMaxLength(15)
                    .HasColumnName("code");

                entity.Property(e => e.EngineCapacity).HasColumnName("engine_capacity");

                entity.Property(e => e.ManufacturingDate).HasColumnName("manufacturing_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("brand_id");
            });

            modelBuilder.Entity<Motorbike>(entity =>
            {
                entity.ToTable("motorbike");

                entity.HasIndex(e => e.CustomerId, "fk_customer_motorbike_idx");

                entity.HasIndex(e => e.ModelId, "fk_model_id_idx");

                entity.HasIndex(e => e.LicensePlate, "license_plate_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.IsActived)
                    .HasColumnType("bit(1)")
                    .HasColumnName("is_actived")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.LicensePlate)
                    .HasMaxLength(11)
                    .HasColumnName("license_plate");

                entity.Property(e => e.ModelId).HasColumnName("model_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Motorbikes)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customer_motorbike");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Motorbikes)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("fk_model_id");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.HasIndex(e => e.MotorbikeId, "motobike_id_idx");

                entity.HasIndex(e => e.StoreId, "store_id_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.MotorbikeId).HasColumnName("motorbike_id");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.Motorbike)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.MotorbikeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("motobike_id");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("store_id");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("order_detail");

                entity.HasIndex(e => e.OrderId, "order_id_idx");

                entity.HasIndex(e => e.ProductId, "product_id_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.OriginalPrice).HasColumnName("original_price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.PromotionPrice).HasColumnName("promotion_price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("order_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_id");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payment");

                entity.HasIndex(e => e.OrderId, "order_id_idx");

                entity.HasIndex(e => e.PaymentMethodId, "payment_method_id_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AmountPaid).HasColumnName("amount_paid");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_id");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("payment_method_id");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("payment_method");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .HasColumnName("type_name");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.HasIndex(e => e.CategoryId, "fk_category_id");

                entity.HasIndex(e => e.ManufacturerId, "fk_manufacturer_id");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.IsActive)
                    .HasColumnType("bit(1)")
                    .HasColumnName("is_active");

                entity.Property(e => e.IsService)
                    .HasColumnType("bit(1)")
                    .HasColumnName("is_service");

                entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.StoreId)
                    .HasMaxLength(45)
                    .HasColumnName("store_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_category_id");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Product)
                    .HasForeignKey<Product>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_product_store");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_manufacturer_id");

                entity.HasMany(d => d.Products)
                    .WithMany(p => p.Services)
                    .UsingEntity<Dictionary<string, object>>(
                        "ServiceMapping",
                        l => l.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_product_id"),
                        r => r.HasOne<Product>().WithMany().HasForeignKey("ServiceId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_service_id"),
                        j =>
                        {
                            j.HasKey("ProductId", "ServiceId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("service_mapping");

                            j.HasIndex(new[] { "ServiceId" }, "fk_service_id_idx");

                            j.IndexerProperty<int>("ProductId").ValueGeneratedOnAdd().HasColumnName("product_id");

                            j.IndexerProperty<int>("ServiceId").HasColumnName("service_id");
                        });

                entity.HasMany(d => d.Services)
                    .WithMany(p => p.Products)
                    .UsingEntity<Dictionary<string, object>>(
                        "ServiceMapping",
                        l => l.HasOne<Product>().WithMany().HasForeignKey("ServiceId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_service_id"),
                        r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_product_id"),
                        j =>
                        {
                            j.HasKey("ProductId", "ServiceId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("service_mapping");

                            j.HasIndex(new[] { "ServiceId" }, "fk_service_id_idx");

                            j.IndexerProperty<int>("ProductId").ValueGeneratedOnAdd().HasColumnName("product_id");

                            j.IndexerProperty<int>("ServiceId").HasColumnName("service_id");
                        });
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("store");

                entity.HasIndex(e => e.WardId, "fk_ward_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(11)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.WardId).HasColumnName("ward_id");

                entity.HasOne(d => d.Ward)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.WardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ward_id");
            });

            modelBuilder.Entity<StoreCategory>(entity =>
            {
                entity.ToTable("store_category");

                entity.HasIndex(e => e.Name, "name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.HasMany(d => d.Stores)
                    .WithMany(p => p.StoreCategories)
                    .UsingEntity<Dictionary<string, object>>(
                        "StoreCategoryStore",
                        l => l.HasOne<Store>().WithMany().HasForeignKey("StoreId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_store"),
                        r => r.HasOne<StoreCategory>().WithMany().HasForeignKey("StoreCategoryId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_store_category"),
                        j =>
                        {
                            j.HasKey("StoreCategoryId", "StoreId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("store_category_store");

                            j.HasIndex(new[] { "StoreId" }, "fk_store_idx");

                            j.IndexerProperty<int>("StoreCategoryId").HasColumnName("store_category_id");

                            j.IndexerProperty<int>("StoreId").HasColumnName("store_id");
                        });
            });

            modelBuilder.Entity<Ward>(entity =>
            {
                entity.ToTable("ward");

                entity.HasIndex(e => e.AreaId, "fk_area_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AreaId).HasColumnName("area_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Wards)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_area_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

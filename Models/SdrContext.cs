using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sedra_0sman.Models;

public partial class SdrContext : DbContext
{
    public SdrContext()
    {
    }

    public SdrContext(DbContextOptions<SdrContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BuyNow> BuyNow { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<ContactU> ContactUs { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=SDR;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BuyNow>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BuyNow");

            entity.Property(e => e.Iban).HasColumnName("IBAN");
            entity.Property(e => e.name).HasColumnName("name");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.ToTable("cart");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<ContactU>(entity =>
        {
            entity.ToTable("contactUs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("product");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Product)
                .HasForeignKey<Product>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_cart");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

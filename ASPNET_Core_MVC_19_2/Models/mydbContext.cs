using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ASPNET_Core_MVC_19_2.Models
{
    public partial class mydbContext : DbContext
    {
        public mydbContext()
        {
        }

        public mydbContext(DbContextOptions<mydbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<UserM> UserMs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MSI\\tanya;Database=mydb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Logo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("logo");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.IdPhone).HasColumnName("id_phone");

                entity.Property(e => e.IdUser).HasColumnName("id_user");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.ToTable("Favorite");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdPhone).HasColumnName("id_phone");

                entity.Property(e => e.IdUser).HasColumnName("id_user");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.ToTable("Phone");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Brand).HasColumnName("brand");

                entity.Property(e => e.Camera)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("camera");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Cpu)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("cpu");

                entity.Property(e => e.Images)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("images");

                entity.Property(e => e.Memory)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("memory");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Ram)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ram");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<UserM>(entity =>
            {
                entity.ToTable("UserM");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("login");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

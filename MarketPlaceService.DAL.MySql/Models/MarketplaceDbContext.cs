using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MarketPlaceService.DAL.MySql.Models
{
    public partial class MarketplaceDbContext : DbContext
    {
        public MarketplaceDbContext()
        {
        }

        public MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProcessingStatus> ProcessingStatus { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<PublishedProducts> PublishedProducts { get; set; }
        public virtual DbSet<PublishedProductsHistory> PublishedProductsHistory { get; set; }
        public virtual DbSet<PublishedProductsQueue> PublishedProductsQueue { get; set; }
        public virtual DbSet<PublishedStatus> PublishedStatus { get; set; }
        public virtual DbSet<Publisher> Publisher { get; set; }
        public virtual DbSet<Site> Site { get; set; }
        public virtual DbSet<Subscriber> Subscriber { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=Dev15;user=sa;password=;database=MarketplaceDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProcessingStatus>(entity =>
            {
                entity.Property(e => e.ProcessingStatusId).ValueGeneratedNever();

                entity.Property(e => e.ProcessingStatusName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.Property(e => e.ProductTypeId).ValueGeneratedNever();

                entity.Property(e => e.ProductTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PublishedProducts>(entity =>
            {
                entity.HasKey(e => e.PublishedProductId);

                entity.Property(e => e.PublishedProductId).ValueGeneratedNever();

                entity.Property(e => e.ProcessedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProcessedOn).HasColumnType("datetime");

                entity.Property(e => e.ProcessingNote)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ProductData).IsRequired();

                entity.HasOne(d => d.ProcessingStatus)
                    .WithMany(p => p.PublishedProducts)
                    .HasForeignKey(d => d.ProcessingStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PublishedProducts_ProcessingStatus");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.PublishedProducts)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PublishedProducts_ProductType");

                entity.HasOne(d => d.PublishedStatus)
                    .WithMany(p => p.PublishedProducts)
                    .HasForeignKey(d => d.PublishedStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PublishedProducts_PublishedStatus");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.PublishedProducts)
                    .HasForeignKey(d => d.PublisherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PublishedProducts_Publisher");
            });

            modelBuilder.Entity<PublishedProductsHistory>(entity =>
            {
                entity.HasKey(e => e.PublishedProductHistoryId);

                entity.Property(e => e.PublishedProductHistoryId).ValueGeneratedNever();

                entity.Property(e => e.ProcessedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProcessedOn).HasColumnType("datetime");

                entity.Property(e => e.ProductData)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.PublishedProduct)
                    .WithMany(p => p.PublishedProductsHistory)
                    .HasForeignKey(d => d.PublishedProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PublishedProductsHistory_PublishedProducts");
            });

            modelBuilder.Entity<PublishedProductsQueue>(entity =>
            {
                entity.HasKey(e => e.PublishedProductQueueId);

                entity.Property(e => e.PublishedProductQueueId).ValueGeneratedNever();

                entity.Property(e => e.ProcessingNote).HasMaxLength(50);

                entity.HasOne(d => d.ProcessingStatus)
                    .WithMany(p => p.PublishedProductsQueue)
                    .HasForeignKey(d => d.ProcessingStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PublishedProductsQueue_ProcessingStatus");

                entity.HasOne(d => d.PublishedProduct)
                    .WithMany(p => p.PublishedProductsQueue)
                    .HasForeignKey(d => d.PublishedProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PublishedProductsQueue_PublishedProducts");

                entity.HasOne(d => d.PublishedProductType)
                    .WithMany(p => p.PublishedProductsQueue)
                    .HasForeignKey(d => d.PublishedProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PublishedProductsQueue_ProductType");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.PublishedProductsQueue)
                    .HasForeignKey(d => d.PublisherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PublishedProductsQueue_Publisher");
            });

            modelBuilder.Entity<PublishedStatus>(entity =>
            {
                entity.HasKey(e => e.PublishStatusId);

                entity.Property(e => e.PublishStatusId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.Property(e => e.PublisherId).ValueGeneratedNever();

                entity.Property(e => e.PublisherName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.Publisher)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Publisher_Site");
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.Property(e => e.SiteName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Subscriber>(entity =>
            {
                entity.Property(e => e.SubscriberId).ValueGeneratedNever();

                entity.Property(e => e.SubscriberName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.Subscriber)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subscriber_Site");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

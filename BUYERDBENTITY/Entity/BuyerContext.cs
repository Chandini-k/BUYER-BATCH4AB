using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BUYERDBENTITY.Entity
{
    public partial class BuyerContext : DbContext
    {
        public BuyerContext()
        {
        }

        public BuyerContext(DbContextOptions<BuyerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Purchasehistory> Purchasehistory { get; set; }
        public virtual DbSet<SubCategory> SubCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-UJ5GD8G0\\SQLEXPRESS;Initial Catalog=Buyer;User ID=sa;Password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.HasKey(e => e.Bid)
                    .HasName("PK__Buyer__DE90ADE7B9288F08");

                entity.Property(e => e.Bid)
                    .HasColumnName("bid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Datetime)
                    .HasColumnName("datetime")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mobileno)
                    .IsRequired()
                    .HasColumnName("mobileno")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bid).HasColumnName("bid");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Imagename)
                    .HasColumnName("imagename")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Itemid).HasColumnName("itemid");

                entity.Property(e => e.Itemname)
                    .IsRequired()
                    .HasColumnName("itemname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnName("price")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Stockno).HasColumnName("stockno");

                entity.Property(e => e.Subcategoryid).HasColumnName("subcategoryid");

                entity.HasOne(d => d.B)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.Bid)
                    .HasConstraintName("FK__Cart__bid__20C1E124");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("FK__Cart__categoryid__1ED998B2");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.Itemid)
                    .HasConstraintName("FK__Cart__itemid__21B6055D");

                entity.HasOne(d => d.Subcategory)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.Subcategoryid)
                    .HasConstraintName("FK__Cart__subcategor__1FCDBCEB");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__Category__D837D05FB41C3976");

                entity.Property(e => e.Cid)
                    .HasColumnName("cid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cdetails)
                    .HasColumnName("cdetails")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cname)
                    .IsRequired()
                    .HasColumnName("cname")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Imagename)
                    .HasColumnName("imagename")
                    .HasColumnType("image");

                entity.Property(e => e.Itemname)
                    .IsRequired()
                    .HasColumnName("itemname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnName("price")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Stockno).HasColumnName("stockno");

                entity.Property(e => e.Subcategoryid).HasColumnName("subcategoryid");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("FK__Items__categoryi__173876EA");

                entity.HasOne(d => d.Subcategory)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Subcategoryid)
                    .HasConstraintName("FK__Items__subcatego__182C9B23");
            });

            modelBuilder.Entity<Purchasehistory>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bid).HasColumnName("bid");

                entity.Property(e => e.Datetime)
                    .HasColumnName("datetime")
                    .HasColumnType("date");

                entity.Property(e => e.Itemid).HasColumnName("itemid");

                entity.Property(e => e.Noofitems).HasColumnName("noofitems");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Transactionstatus)
                    .HasColumnName("transactionstatus")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Transactiontype)
                    .IsRequired()
                    .HasColumnName("transactiontype")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.B)
                    .WithMany(p => p.Purchasehistory)
                    .HasForeignKey(d => d.Bid)
                    .HasConstraintName("FK__Purchasehis__bid__1B0907CE");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Purchasehistory)
                    .HasForeignKey(d => d.Itemid)
                    .HasConstraintName("FK__Purchaseh__itemi__1BFD2C07");
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.HasKey(e => e.Subid)
                    .HasName("PK__SubCateg__B0F1D5B3AC3B2CAD");

                entity.Property(e => e.Subid)
                    .HasColumnName("subid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Cname)
                    .HasColumnName("cname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gst).HasColumnName("gst");

                entity.Property(e => e.Sdetails)
                    .HasColumnName("sdetails")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Subname)
                    .IsRequired()
                    .HasColumnName("subname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.C)
                    .WithMany(p => p.SubCategory)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("FK__SubCategory__cid__145C0A3F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

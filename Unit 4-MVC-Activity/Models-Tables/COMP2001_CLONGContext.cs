using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Unit_4_MVC_Activity.Models-Tables
{
    public partial class COMP2001_CLONGContext : DbContext
    {
        public COMP2001_CLONGContext()
        {
        }

        public COMP2001_CLONGContext(DbContextOptions<COMP2001_CLONGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerBooking> CustomerBookings { get; set; }
        public virtual DbSet<CustomerContact> CustomerContacts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<PubAttendance> PubAttendances { get; set; }
        public virtual DbSet<PubHour> PubHours { get; set; }
        public virtual DbSet<PubTable> PubTables { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SalesPerCustomer> SalesPerCustomers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=socem1.uopnet.plymouth.ac.uk;Database=COMP2001_CLONG;User Id=CLong; Password=XqlC535+");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Name");
            });

            modelBuilder.Entity<CustomerBooking>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK__Customer__73951ACD685F137A");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.BookingDate).HasColumnType("date");

                entity.Property(e => e.PartySize)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TableId).HasColumnName("TableID");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.CustomerBookings)
                    .HasForeignKey(d => d.TableId)
                    .HasConstraintName("FK__CustomerB__Table__25518C17");
            });

            modelBuilder.Entity<CustomerContact>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Customer__A4AE64B893F60ADC");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.CustomerContacts)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__CustomerC__Booki__282DF8C2");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_Customers");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__OrderDet__C3905BCF9A6E691E");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.LineTotal)
                    .HasColumnType("money")
                    .HasColumnName("Line_Total");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__Produ__01D345B0");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductDetails)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Product_Details");
            });

            modelBuilder.Entity<PubAttendance>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PubAttendance");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PubHour>(entity =>
            {
                entity.HasKey(e => e.DayId)
                    .HasName("PK__PubHours__BF3DD8259872F552");

                entity.HasIndex(e => e.Dow, "UQ__PubHours__C03580EA3208B14B")
                    .IsUnique();

                entity.Property(e => e.DayId)
                    .ValueGeneratedNever()
                    .HasColumnName("DayID");

                entity.Property(e => e.Dow)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("DOW");

                entity.Property(e => e.PubStatus)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PubTable>(entity =>
            {
                entity.HasKey(e => e.TableId)
                    .HasName("PK__PubTable__7D5F018E674786B2");

                entity.Property(e => e.TableId).HasColumnName("TableID");

                entity.Property(e => e.NumOfSeats)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Sales");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Name");
            });

            modelBuilder.Entity<SalesPerCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SalesPerCustomer");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Name");

                entity.Property(e => e.LineTotal)
                    .HasColumnType("money")
                    .HasColumnName("Line_Total");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

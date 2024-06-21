using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class HotelDatabaseContext : DbContext
    {
        public HotelDatabaseContext()
        {
        }

        public HotelDatabaseContext(DbContextOptions<HotelDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<BookingDetail> BookingDetails { get; set; } = null!;
        public virtual DbSet<Checkin> Checkins { get; set; } = null!;
        public virtual DbSet<ClassifyRoom> ClassifyRooms { get; set; } = null!;
        public virtual DbSet<Dichvu> Dichvus { get; set; } = null!;
        public virtual DbSet<HinhAnh> HinhAnhs { get; set; } = null!;
        public virtual DbSet<HoaDon> HoaDons { get; set; } = null!;
        public virtual DbSet<InformRoom> InformRooms { get; set; } = null!;
        public virtual DbSet<KhachHang> KhachHangs { get; set; } = null!;
        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; } = null!;
        public virtual DbSet<NhanVien> NhanViens { get; set; } = null!;
        public virtual DbSet<Phong> Phongs { get; set; } = null!;
        public virtual DbSet<QldichvuPhong> QldichvuPhongs { get; set; } = null!;
        public virtual DbSet<TienIchPhong> TienIchPhongs { get; set; } = null!;
        public virtual DbSet<TienNghi> TienNghis { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("workstation id=HotelDatabase.mssql.somee.com;packet size=4096;user id=Eastern1306_SQLLogin_1;pwd=k7nczxuaff;data source=HotelDatabase.mssql.somee.com;persist security info=False;initial catalog=HotelDatabase;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.MaBooking);

                entity.ToTable("Booking");

                entity.Property(e => e.DatCoc)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.NgayIn)
                    .HasMaxLength(10)
                    .HasColumnName("NgayIN")
                    .IsFixedLength();

                entity.Property(e => e.NgayOut)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SlKh).HasColumnName("Sl_Kh");

                entity.Property(e => e.TrangThai)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_KhachHang");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.MaNv)
                    .HasConstraintName("FK_Booking_NhanVien");
            });

            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.ToTable("BookingDetail");

                entity.HasOne(d => d.MaBookingNavigation)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.MaBooking)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_BookingID");

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.MaLoai)
                    .HasConstraintName("fk_LoaiPhongID");
            });

            modelBuilder.Entity<Checkin>(entity =>
            {
                entity.ToTable("Checkin");

                entity.Property(e => e.NvPv)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeIn)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TrangThai)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaBookingNavigation)
                    .WithMany(p => p.Checkins)
                    .HasForeignKey(d => d.MaBooking)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Checkin_Booking");

                entity.HasOne(d => d.MaPhongNavigation)
                    .WithMany(p => p.Checkins)
                    .HasForeignKey(d => d.MaPhong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Checkin_Phong");
            });

            modelBuilder.Entity<ClassifyRoom>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("classify_room");

                entity.Property(e => e.Ten)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TenPhong)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TrangThai)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dichvu>(entity =>
            {
                entity.HasKey(e => e.MaDv);

                entity.ToTable("Dichvu");

                entity.Property(e => e.TenDv)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<HinhAnh>(entity =>
            {
                entity.HasKey(e => e.MaHinhAnh);

                entity.ToTable("HinhAnh");

                entity.Property(e => e.Hinh).HasMaxLength(100);

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.HinhAnhs)
                    .HasForeignKey(d => d.MaLoai)
                    .HasConstraintName("FK_HinhAnh_LoaiPhong");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHd);

                entity.ToTable("HoaDon");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.MaQldv).HasColumnName("MaQLDv");
            });

            modelBuilder.Entity<InformRoom>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("inform_room");

                entity.Property(e => e.KhachHangDaiDien)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NgayIn)
                    .HasMaxLength(10)
                    .HasColumnName("NgayIN")
                    .IsFixedLength();

                entity.Property(e => e.NgayOut)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Ten)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TenPhong)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TrangThai)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKh);

                entity.ToTable("KhachHang");

                entity.Property(e => e.TenKh)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LoaiPhong>(entity =>
            {
                entity.HasKey(e => e.MaLoai);

                entity.ToTable("LoaiPhong");

                entity.Property(e => e.Gia)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Mota).HasMaxLength(400);

                entity.Property(e => e.Soluong)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Ten)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv);

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.Chucvu)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenNv)
                    .HasMaxLength(50)
                    .HasColumnName("TenNV");
            });

            modelBuilder.Entity<Phong>(entity =>
            {
                entity.HasKey(e => e.MaPhong);

                entity.ToTable("Phong");

                entity.Property(e => e.TenPhong)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.Phongs)
                    .HasForeignKey(d => d.MaLoai)
                    .HasConstraintName("FK_Phong_LoaiPhong");
            });

            modelBuilder.Entity<QldichvuPhong>(entity =>
            {
                entity.ToTable("QLdichvu_phong");

                entity.HasIndex(e => e.MaDv, "IX_QLdichvu_phong_MaDv");

                entity.HasIndex(e => e.MaPhong, "IX_QLdichvu_phong_MaPhong");

                entity.Property(e => e.Soluong)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Sotien)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.MaDvNavigation)
                    .WithMany(p => p.QldichvuPhongs)
                    .HasForeignKey(d => d.MaDv)
                    .HasConstraintName("FK_QLdichvu_phong_Dichvu");

                entity.HasOne(d => d.MaPhongNavigation)
                    .WithMany(p => p.QldichvuPhongs)
                    .HasForeignKey(d => d.MaPhong)
                    .HasConstraintName("FK_QLdichvu_phong_Phong1");
            });

            modelBuilder.Entity<TienIchPhong>(entity =>
            {
                entity.HasKey(e => new { e.MaLoai, e.MaTn });

                entity.ToTable("TienIchPhong");

                entity.Property(e => e.MaTn).HasColumnName("MaTN");

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.TienIchPhongs)
                    .HasForeignKey(d => d.MaLoai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TienIchPhong_LoaiPhong");

                entity.HasOne(d => d.MaTnNavigation)
                    .WithMany(p => p.TienIchPhongs)
                    .HasForeignKey(d => d.MaTn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TienIchPhong_TienNghi");
            });

            modelBuilder.Entity<TienNghi>(entity =>
            {
                entity.HasKey(e => e.MaTn);

                entity.ToTable("TienNghi");

                entity.Property(e => e.MaTn).HasColumnName("MaTN");

                entity.Property(e => e.Den)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Gia)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Ten).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        internal object Entry(object hinhAnh)
        {
            throw new NotImplementedException();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

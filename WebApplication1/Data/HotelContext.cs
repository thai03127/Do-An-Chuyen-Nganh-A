using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using mvcblog.Models;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public partial class HotelContext : IdentityDbContext<AppUser>
    {
        public HotelContext()
        {
        }

        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        {
        }



        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Checkin> Checkins { get; set; } = null!;
        public virtual DbSet<DichVu> DichVus { get; set; } = null!;
        public virtual DbSet<HinhAnh> HinhAnhs { get; set; } = null!;
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
                optionsBuilder.UseSqlServer("Server=MSI;Database=Hotel;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.MaBooking);

                entity.ToTable("Booking");

                entity.Property(e => e.MaBooking).ValueGeneratedNever();

                entity.Property(e => e.DatCoc)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Gia)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.GiaGiam)
                    .HasMaxLength(10)
                    .HasColumnName("Gia Giam")
                    .IsFixedLength();

                entity.Property(e => e.GiaGoc)
                    .HasMaxLength(10)
                    .HasColumnName("Gia Goc")
                    .IsFixedLength();

                entity.Property(e => e.MaNv)
                    .HasMaxLength(10)
                    .HasColumnName("MaNV")
                    .IsFixedLength();

                entity.Property(e => e.NgayIn)
                    .HasMaxLength(10)
                    .HasColumnName("NgayIN")
                    .IsFixedLength();

                entity.Property(e => e.NgayOut)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TrangThai)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.MaLoai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_LoaiPhong");
            });

            modelBuilder.Entity<Checkin>(entity =>
            {
                entity.HasNoKey();

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
                    .WithMany()
                    .HasForeignKey(d => d.MaBooking)
                    .HasConstraintName("FK_Checkin_Booking");

                entity.HasOne(d => d.MaPhongNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaPhong)
                    .HasConstraintName("FK_Checkin_Phong");
            });

            modelBuilder.Entity<DichVu>(entity =>
            {
                entity.HasKey(e => e.MaDv);

                entity.ToTable("Dich vu");

                entity.Property(e => e.MaDv).ValueGeneratedNever();

                entity.Property(e => e.TenDv)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<HinhAnh>(entity =>
            {
                entity.HasKey(e => e.MaHinhAnh);

                entity.ToTable("HinhAnh");

                entity.Property(e => e.MaHinhAnh).ValueGeneratedNever();

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.HinhAnhs)
                    .HasForeignKey(d => d.MaLoai)
                    .HasConstraintName("FK_HinhAnh_LoaiPhong");
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

                entity.Property(e => e.MaLoai).ValueGeneratedNever();

                entity.Property(e => e.Gia)
                    .HasMaxLength(10)
                    .IsFixedLength();

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

                entity.Property(e => e.Chucvu)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenNv)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Phong>(entity =>
            {
                entity.HasKey(e => e.MaPhong);

                entity.ToTable("Phong");

                entity.Property(e => e.TenPhong)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QldichvuPhong>(entity =>
            {
                entity.ToTable("QLdichvu_phong");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Soluong)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Sotien)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.MaDvNavigation)
                    .WithMany(p => p.QldichvuPhongs)
                    .HasForeignKey(d => d.MaDv)
                    .HasConstraintName("FK_QLdichvu_phong_Dich vu");

                entity.HasOne(d => d.MaPhongNavigation)
                    .WithMany(p => p.QldichvuPhongs)
                    .HasForeignKey(d => d.MaPhong)
                    .HasConstraintName("FK_QLdichvu_phong_Phong");
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

                entity.Property(e => e.MaTn)
                    .ValueGeneratedNever()
                    .HasColumnName("MaTN");

                entity.Property(e => e.Gia)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Đền)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

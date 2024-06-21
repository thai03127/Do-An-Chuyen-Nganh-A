using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public partial class AppDBContext : IdentityDbContext<AppUser>
{
    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.MaBooking);

            entity.ToTable("Booking");

            entity.Property(e => e.DatCoc)
                .HasMaxLength(10)
                .IsFixedLength();

            //entity.Property(e => e.Gia)
            //    .HasMaxLength(10)
            //    .IsFixedLength();

            //entity.Property(e => e.GiaGiam)
            //    .HasMaxLength(10)
            //    .HasColumnName("Gia Giam")
            //    .IsFixedLength();

            //entity.Property(e => e.GiaGoc)
            //    .HasMaxLength(10)
            //    .HasColumnName("Gia Goc")
            //    .IsFixedLength();

            entity.Property(e => e.MaNv).HasColumnName("MaNV");

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

            entity.HasOne(d => d.MaKhNavigation)
                .WithMany(p => p.Bookings)
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking_KhachHang");

            //entity.HasOne(d => d.MaLoaiNavigation)
            //    .WithMany(p => p.Bookings)
            //    .HasForeignKey(d => d.MaLoai)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Booking_LoaiPhong");

            entity.HasOne(d => d.MaNvNavigation)
                .WithMany(p => p.Bookings)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking_NhanVien");
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

        modelBuilder.Entity<Dichvu>(entity =>
        {
            entity.HasKey(e => e.MaDv);

            entity.ToTable("Dich vu");

            entity.Property(e => e.TenDv)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<HinhAnh>(entity =>
        {
            entity.HasKey(e => e.MaHinhAnh);

            entity.ToTable("HinhAnh");

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

            entity.Property(e => e.MaNv).HasColumnName("MaNV");

            entity.Property(e => e.Chucvu)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.TenNv)
                .HasMaxLength(50)
                .IsUnicode(false)
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

            entity.Property(e => e.Soluong)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.Property(e => e.Sotien)
                .HasMaxLength(10)
                .IsFixedLength();

            //entity.HasOne(d => d.MaDvNavigation)
            //    .WithMany(p => p.QldichvuPhongs)
            //    .HasForeignKey(d => d.MaDv)
            //    .HasConstraintName("FK_QLdichvu_phong_Dich vu");

            //entity.HasOne(d => d.MaPhongNavigation)
            //    .WithMany(p => p.QldichvuPhongs)
            //    .HasForeignKey(d => d.MaPhong)
            //    .HasConstraintName("FK_QLdichvu_phong_Phong1");
            // Định nghĩa quan hệ với Dichvu
            entity.HasOne(d => d.MaDvNavigation)
                .WithMany(p => p.QldichvuPhongs)
                .HasForeignKey(d => d.MaDv)
                .HasConstraintName("FK_QLdichvu_phong_Dich vu");

            // Định nghĩa quan hệ với Phong
            entity.HasOne(d => d.MaPhongNavigation)
                .WithMany(p => p.QldichvuPhongs)
                .HasForeignKey(d => d.MaPhong)
                .HasConstraintName("FK_QLdichvu_phong_Phong1");
        });

        modelBuilder.Entity<TienIchPhong>(entity =>
        {
            entity.HasKey(e => new { e.MaLoai, e.MaTn });

            entity.ToTable("TienIchPhong");

            entity.Property(e => e.MaLoai).ValueGeneratedOnAdd();

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
        });

        OnModelCreatingPartial(modelBuilder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public virtual DbSet<Booking> Bookings { get; set; } = null!;
    public virtual DbSet<Checkin> Checkins { get; set; } = null!;
    public virtual DbSet<Dichvu> DichVus { get; set; } = null!;
    public virtual DbSet<HinhAnh> HinhAnhs { get; set; } = null!;
    public virtual DbSet<KhachHang> KhachHangs { get; set; } = null!;
    public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; } = null!;
    public virtual DbSet<NhanVien> NhanViens { get; set; } = null!;
    public virtual DbSet<Dichvu> Phongs { get; set; } = null!;
    public virtual DbSet<QldichvuPhong> QldichvuPhongs { get; set; } = null!;
    public virtual DbSet<TienIchPhong> TienIchPhongs { get; set; } = null!;
    public virtual DbSet<TienNghi> TienNghis { get; set; } = null!;
 
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class DBFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dichvu",
                columns: table => new
                {
                    MaDv = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDv = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dichvu", x => x.MaDv);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    MaHD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKh = table.Column<int>(type: "int", nullable: false),
                    MaBooking = table.Column<int>(type: "int", nullable: false),
                    MaLoai = table.Column<int>(type: "int", nullable: false),
                    MaDv = table.Column<int>(type: "int", nullable: false),
                    MaQLDv = table.Column<int>(type: "int", nullable: false),
                    MaNv = table.Column<int>(type: "int", nullable: false),
                    ThanhTien = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.MaHD);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKh = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Passport = table.Column<int>(type: "int", nullable: true),
                    Cancuoc = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKh);
                });

            migrationBuilder.CreateTable(
                name: "LoaiPhong",
                columns: table => new
                {
                    MaLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Gia = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    GiaGoc = table.Column<double>(type: "float", nullable: true),
                    GiaGiam = table.Column<double>(type: "float", nullable: true),
                    DanhGia = table.Column<double>(type: "float", nullable: true),
                    Soluong = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    GiaTreEm = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiPhong", x => x.MaLoai);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNV = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Chucvu = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Cancuoc = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.MaNV);
                });

            migrationBuilder.CreateTable(
                name: "TienNghi",
                columns: table => new
                {
                    MaTN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLoai = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Den = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TienNghi", x => x.MaTN);
                });

            migrationBuilder.CreateTable(
                name: "HinhAnh",
                columns: table => new
                {
                    MaHinhAnh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLoai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhAnh", x => x.MaHinhAnh);
                    table.ForeignKey(
                        name: "FK_HinhAnh_LoaiPhong",
                        column: x => x.MaLoai,
                        principalTable: "LoaiPhong",
                        principalColumn: "MaLoai");
                });

            migrationBuilder.CreateTable(
                name: "Phong",
                columns: table => new
                {
                    MaPhong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhong = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MaLoai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phong", x => x.MaPhong);
                    table.ForeignKey(
                        name: "FK_Phong_LoaiPhong",
                        column: x => x.MaLoai,
                        principalTable: "LoaiPhong",
                        principalColumn: "MaLoai");
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    MaBooking = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKh = table.Column<int>(type: "int", nullable: false),
                    MaLoai = table.Column<int>(type: "int", nullable: false),
                    NgayIN = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    NgayOut = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Gia = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    GiaGoc = table.Column<string>(name: "Gia Goc", type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    GiaGiam = table.Column<string>(name: "Gia Giam", type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    MaNV = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    DatCoc = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.MaBooking);
                    table.ForeignKey(
                        name: "FK_Booking_KhachHang",
                        column: x => x.MaKh,
                        principalTable: "KhachHang",
                        principalColumn: "MaKh");
                    table.ForeignKey(
                        name: "FK_Booking_LoaiPhong",
                        column: x => x.MaLoai,
                        principalTable: "LoaiPhong",
                        principalColumn: "MaLoai");
                    table.ForeignKey(
                        name: "FK_Booking_NhanVien",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateTable(
                name: "TienIchPhong",
                columns: table => new
                {
                    MaLoai = table.Column<int>(type: "int", nullable: false),
                    MaTN = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TienIchPhong", x => new { x.MaLoai, x.MaTN });
                    table.ForeignKey(
                        name: "FK_TienIchPhong_LoaiPhong",
                        column: x => x.MaLoai,
                        principalTable: "LoaiPhong",
                        principalColumn: "MaLoai");
                    table.ForeignKey(
                        name: "FK_TienIchPhong_TienNghi",
                        column: x => x.MaTN,
                        principalTable: "TienNghi",
                        principalColumn: "MaTN");
                });

            migrationBuilder.CreateTable(
                name: "QLdichvu_phong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhong = table.Column<int>(type: "int", nullable: true),
                    MaDv = table.Column<int>(type: "int", nullable: true),
                    Sotien = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Soluong = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QLdichvu_phong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QLdichvu_phong_Dichvu",
                        column: x => x.MaDv,
                        principalTable: "Dichvu",
                        principalColumn: "MaDv");
                    table.ForeignKey(
                        name: "FK_QLdichvu_phong_Phong1",
                        column: x => x.MaPhong,
                        principalTable: "Phong",
                        principalColumn: "MaPhong");
                });

            migrationBuilder.CreateTable(
                name: "Checkin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaBooking = table.Column<int>(type: "int", nullable: false),
                    TimeIn = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    MaPhong = table.Column<int>(type: "int", nullable: false),
                    NvPv = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TrangThai = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    MaNv = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkin_Booking",
                        column: x => x.MaBooking,
                        principalTable: "Booking",
                        principalColumn: "MaBooking");
                    table.ForeignKey(
                        name: "FK_Checkin_Phong",
                        column: x => x.MaPhong,
                        principalTable: "Phong",
                        principalColumn: "MaPhong");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_MaKh",
                table: "Booking",
                column: "MaKh");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_MaLoai",
                table: "Booking",
                column: "MaLoai");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_MaNV",
                table: "Booking",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_Checkin_MaBooking",
                table: "Checkin",
                column: "MaBooking");

            migrationBuilder.CreateIndex(
                name: "IX_Checkin_MaPhong",
                table: "Checkin",
                column: "MaPhong");

            migrationBuilder.CreateIndex(
                name: "IX_HinhAnh_MaLoai",
                table: "HinhAnh",
                column: "MaLoai");

            migrationBuilder.CreateIndex(
                name: "IX_Phong_MaLoai",
                table: "Phong",
                column: "MaLoai");

            migrationBuilder.CreateIndex(
                name: "IX_QLdichvu_phong_MaDv",
                table: "QLdichvu_phong",
                column: "MaDv");

            migrationBuilder.CreateIndex(
                name: "IX_QLdichvu_phong_MaPhong",
                table: "QLdichvu_phong",
                column: "MaPhong");

            migrationBuilder.CreateIndex(
                name: "IX_TienIchPhong_MaTN",
                table: "TienIchPhong",
                column: "MaTN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checkin");

            migrationBuilder.DropTable(
                name: "HinhAnh");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "QLdichvu_phong");

            migrationBuilder.DropTable(
                name: "TienIchPhong");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Dichvu");

            migrationBuilder.DropTable(
                name: "Phong");

            migrationBuilder.DropTable(
                name: "TienNghi");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "LoaiPhong");
        }
    }
}

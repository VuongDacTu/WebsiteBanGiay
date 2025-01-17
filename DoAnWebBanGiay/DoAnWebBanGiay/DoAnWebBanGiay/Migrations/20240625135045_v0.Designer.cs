﻿// <auto-generated />
using System;
using DoAnWebBanGiay.Models.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoAnWebBanGiay.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240625135045_v0")]
    partial class v0
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DoAnWebBanGiay.Models.Entities.AnhSP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Anh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdSanPham")
                        .HasColumnType("int");

                    b.Property<string>("Mota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiTao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdSanPham");

                    b.ToTable("AnhSPs");
                });

            modelBuilder.Entity("DoAnWebBanGiay.Models.Entities.Banner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Anh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("DoAnWebBanGiay.Models.Entities.ChiTietDonHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("Gia")
                        .HasColumnType("float");

                    b.Property<string>("IdDonHang")
                        .HasColumnType("nvarchar(37)");

                    b.Property<int?>("IdSanPham")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdDonHang");

                    b.HasIndex("IdSanPham");

                    b.ToTable("ChiTietDonHangs");
                });

            modelBuilder.Entity("DoAnWebBanGiay.Models.Entities.DonHang", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(37)
                        .HasColumnType("nvarchar(37)");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdNguoiDung")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("IdThanhToan")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayMua")
                        .HasColumnType("datetime2");

                    b.Property<double?>("PhiVanChuyen")
                        .HasColumnType("float");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("TongTien")
                        .HasColumnType("float");

                    b.Property<bool?>("TrangThaiDonHang")
                        .HasColumnType("bit");

                    b.Property<bool?>("TrangThaiThanhToan")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdNguoiDung");

                    b.HasIndex("IdThanhToan");

                    b.ToTable("DonHangs");
                });

            modelBuilder.Entity("DoAnWebBanGiay.Models.Entities.LienHe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaceBook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TikTok")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LienHes");
                });

            modelBuilder.Entity("DoAnWebBanGiay.Models.Entities.LoaiSP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoaiSPs");
                });

            modelBuilder.Entity("DoAnWebBanGiay.Models.Entities.NguoiDung", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Anh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("GioiTinh")
                        .HasColumnType("bit");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaiKhoan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NguoiDungs");
                });

            modelBuilder.Entity("DoAnWebBanGiay.Models.Entities.PhanHoi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IdNguoiDung")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("TrangThaiXem")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdNguoiDung");

                    b.ToTable("PhanHois");
                });

            modelBuilder.Entity("DoAnWebBanGiay.Models.Entities.PhuongThucThanhToan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PhuongThucThanhToans");
                });

            modelBuilder.Entity("DoAnWebBanGiay.Models.Entities.SanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("Gia")
                        .HasColumnType("float");

                    b.Property<double?>("GiaNhap")
                        .HasColumnType("float");

                    b.Property<double?>("GiamGia")
                        .HasColumnType("float");

                    b.Property<int?>("IdLoaiSP")
                        .HasColumnType("int");

                    b.Property<int?>("IdThuongHieu")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Mau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiCapNhat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NguoiTao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdLoaiSP");

                    b.HasIndex("IdThuongHieu");

                    b.ToTable("SanPhams");
                });

            modelBuilder.Entity("DoAnWebBanGiay.Models.Entities.ThuongHieu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ThuongHieus");
                });

            modelBuilder.Entity("DoAnWebBanGiay.Models.Entities.TinTuc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Anh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayDang")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TieuDe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TinTucs");
                });

            modelBuilder.Entity("DoAnWebBanGiay.Models.Entities.AnhSP", b =>
                {
                    b.HasOne("DoAnWebBanGiay.Models.Entities.SanPham", "sanPham")
                        .WithMany()
                        .HasForeignKey("IdSanPham");

                    b.Navigation("sanPham");
                });

            modelBuilder.Entity("DoAnWebBanGiay.Models.Entities.ChiTietDonHang", b =>
                {
                    b.HasOne("DoAnWebBanGiay.Models.Entities.DonHang", "donHang")
                        .WithMany()
                        .HasForeignKey("IdDonHang");

                    b.HasOne("DoAnWebBanGiay.Models.Entities.SanPham", "sanPham")
                        .WithMany()
                        .HasForeignKey("IdSanPham");

                    b.Navigation("donHang");

                    b.Navigation("sanPham");
                });

            modelBuilder.Entity("DoAnWebBanGiay.Models.Entities.DonHang", b =>
                {
                    b.HasOne("DoAnWebBanGiay.Models.Entities.NguoiDung", "nguoiDung")
                        .WithMany()
                        .HasForeignKey("IdNguoiDung");

                    b.HasOne("DoAnWebBanGiay.Models.Entities.PhuongThucThanhToan", "phuongThucThanhToan")
                        .WithMany()
                        .HasForeignKey("IdThanhToan");

                    b.Navigation("nguoiDung");

                    b.Navigation("phuongThucThanhToan");
                });

            modelBuilder.Entity("DoAnWebBanGiay.Models.Entities.PhanHoi", b =>
                {
                    b.HasOne("DoAnWebBanGiay.Models.Entities.NguoiDung", "nguoiDung")
                        .WithMany()
                        .HasForeignKey("IdNguoiDung");

                    b.Navigation("nguoiDung");
                });

            modelBuilder.Entity("DoAnWebBanGiay.Models.Entities.SanPham", b =>
                {
                    b.HasOne("DoAnWebBanGiay.Models.Entities.LoaiSP", "loaiSP")
                        .WithMany()
                        .HasForeignKey("IdLoaiSP");

                    b.HasOne("DoAnWebBanGiay.Models.Entities.ThuongHieu", "thuongHieu")
                        .WithMany()
                        .HasForeignKey("IdThuongHieu");

                    b.Navigation("loaiSP");

                    b.Navigation("thuongHieu");
                });
#pragma warning restore 612, 618
        }
    }
}

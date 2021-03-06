USE [master]
GO
/****** Object:  Database [QL_SieuThiDienTu]    Script Date: 6/26/2021 9:46:18 AM ******/
CREATE DATABASE [QL_SieuThiDienTu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QL_PhuKienDienThoai', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QL_PhuKienDienThoai.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QL_PhuKienDienThoai_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QL_PhuKienDienThoai_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QL_SieuThiDienTu] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QL_SieuThiDienTu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QL_SieuThiDienTu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET ARITHABORT OFF 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET RECOVERY FULL 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET  MULTI_USER 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QL_SieuThiDienTu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QL_SieuThiDienTu] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QL_SieuThiDienTu', N'ON'
GO
USE [QL_SieuThiDienTu]
GO
/****** Object:  Table [dbo].[tb_CTHDB]    Script Date: 6/26/2021 9:46:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_CTHDB](
	[mahdb] [nvarchar](10) NOT NULL,
	[masp] [nvarchar](10) NOT NULL,
	[soluong] [int] NULL,
	[dongia] [float] NULL,
	[thanhtien] [float] NULL,
 CONSTRAINT [PK_tb_CTHDB] PRIMARY KEY CLUSTERED 
(
	[mahdb] ASC,
	[masp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_CTHDN]    Script Date: 6/26/2021 9:46:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_CTHDN](
	[mahdn] [nvarchar](10) NOT NULL,
	[masp] [nvarchar](10) NOT NULL,
	[soluong] [int] NULL,
	[dongia] [float] NULL,
	[thanhtien] [float] NULL,
 CONSTRAINT [PK_tb_CTHDN] PRIMARY KEY CLUSTERED 
(
	[mahdn] ASC,
	[masp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_HDB]    Script Date: 6/26/2021 9:46:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_HDB](
	[mahdb] [nvarchar](10) NOT NULL,
	[makhh] [nvarchar](10) NULL,
	[manv] [nvarchar](10) NULL,
	[ngayban] [date] NULL,
	[tongtien] [float] NULL,
 CONSTRAINT [PK_tb_HDB] PRIMARY KEY CLUSTERED 
(
	[mahdb] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_HDN]    Script Date: 6/26/2021 9:46:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_HDN](
	[mahdn] [nvarchar](10) NOT NULL,
	[manv] [nvarchar](10) NULL,
	[ngaynhap] [date] NULL,
	[tongtien] [float] NULL,
 CONSTRAINT [PK_tb_HDN] PRIMARY KEY CLUSTERED 
(
	[mahdn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_Khachhang]    Script Date: 6/26/2021 9:46:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Khachhang](
	[makh] [nvarchar](10) NOT NULL,
	[tenkh] [nvarchar](50) NULL,
	[gioitinh] [nvarchar](10) NULL,
	[sdt] [nvarchar](12) NULL,
	[diachi] [nvarchar](max) NULL,
 CONSTRAINT [PK_tb_Khachhang] PRIMARY KEY CLUSTERED 
(
	[makh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_Loaihang]    Script Date: 6/26/2021 9:46:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Loaihang](
	[maloai] [nvarchar](10) NOT NULL,
	[tenloai] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_Loaihang] PRIMARY KEY CLUSTERED 
(
	[maloai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_NCC]    Script Date: 6/26/2021 9:46:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_NCC](
	[mancc] [nvarchar](10) NOT NULL,
	[tenncc] [nvarchar](50) NULL,
	[sdt] [nvarchar](12) NULL,
	[email] [nvarchar](50) NULL,
	[diachi] [nvarchar](max) NULL,
 CONSTRAINT [PK_tb_NCC] PRIMARY KEY CLUSTERED 
(
	[mancc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_Nhanvien]    Script Date: 6/26/2021 9:46:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Nhanvien](
	[manv] [nvarchar](10) NOT NULL,
	[tennv] [nvarchar](25) NULL,
	[ngaysinh] [date] NULL,
	[sdt] [nvarchar](11) NULL,
	[diachi] [nvarchar](max) NULL,
 CONSTRAINT [PK_tb_Nhanvien] PRIMARY KEY CLUSTERED 
(
	[manv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_Sanpham]    Script Date: 6/26/2021 9:46:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Sanpham](
	[masp] [nvarchar](10) NOT NULL,
	[tensp] [nvarchar](50) NULL,
	[mancc] [nvarchar](10) NULL,
	[maloai] [nvarchar](10) NULL,
	[gianhap] [float] NULL,
	[giaban] [float] NULL,
	[soluong] [int] NULL,
 CONSTRAINT [PK_tb_Sanpham] PRIMARY KEY CLUSTERED 
(
	[masp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_User]    Script Date: 6/26/2021 9:46:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_User](
	[username] [nvarchar](10) NOT NULL,
	[password] [nvarchar](10) NOT NULL,
	[loaitaikhoan] [nvarchar](10) NULL,
	[manv] [nvarchar](10) NULL
) ON [PRIMARY]

GO
INSERT [dbo].[tb_CTHDB] ([mahdb], [masp], [soluong], [dongia], [thanhtien]) VALUES (N'70001', N'40001', 4, 1500000, 6000000)
INSERT [dbo].[tb_CTHDN] ([mahdn], [masp], [soluong], [dongia], [thanhtien]) VALUES (N'600001', N'40001', 9, 1000000, 9000000)
INSERT [dbo].[tb_HDB] ([mahdb], [makhh], [manv], [ngayban], [tongtien]) VALUES (N'70001', N'50001', N'10001', CAST(N'2021-06-19' AS Date), 6000000)
INSERT [dbo].[tb_HDN] ([mahdn], [manv], [ngaynhap], [tongtien]) VALUES (N'600001', N'10001', CAST(N'2021-06-19' AS Date), 9000000)
INSERT [dbo].[tb_Khachhang] ([makh], [tenkh], [gioitinh], [sdt], [diachi]) VALUES (N'50001', N'Nguyễn Văn A', N'Nam', N'09999999', N'Thái Bình')
INSERT [dbo].[tb_Loaihang] ([maloai], [tenloai]) VALUES (N'20001', N'Phụ Kiện Ip')
INSERT [dbo].[tb_Loaihang] ([maloai], [tenloai]) VALUES (N'20002', N'Phụ Kiện Samsung')
INSERT [dbo].[tb_Loaihang] ([maloai], [tenloai]) VALUES (N'20003', N'Phụ Kiện Xiaomi')
INSERT [dbo].[tb_NCC] ([mancc], [tenncc], [sdt], [email], [diachi]) VALUES (N'30001', N'Cửa Hàng Long Thành', N'0987776521', N'longthanh20@gmail.com', N'Thái Bình')
INSERT [dbo].[tb_Nhanvien] ([manv], [tennv], [ngaysinh], [sdt], [diachi]) VALUES (N'10001', N'Bùi Đức Bình', CAST(N'2000-07-27' AS Date), N'098777771', N'Thái Bình')
INSERT [dbo].[tb_Nhanvien] ([manv], [tennv], [ngaysinh], [sdt], [diachi]) VALUES (N'10002', N'Đỗ Thanh Tùng', CAST(N'2021-06-19' AS Date), N'0999999', N'Thái Bình')
INSERT [dbo].[tb_Sanpham] ([masp], [tensp], [mancc], [maloai], [gianhap], [giaban], [soluong]) VALUES (N'40001', N'Màn Hình Iphone 8', N'30001', N'20001', 1000000, 1200000, 100)
INSERT [dbo].[tb_User] ([username], [password], [loaitaikhoan], [manv]) VALUES (N'admin', N'admin', N'Admin', N'10002')
INSERT [dbo].[tb_User] ([username], [password], [loaitaikhoan], [manv]) VALUES (N'admin1', N'admin', N'User', N'10001')
ALTER TABLE [dbo].[tb_CTHDB]  WITH CHECK ADD  CONSTRAINT [FK_tb_CTHDB_tb_HDB] FOREIGN KEY([mahdb])
REFERENCES [dbo].[tb_HDB] ([mahdb])
GO
ALTER TABLE [dbo].[tb_CTHDB] CHECK CONSTRAINT [FK_tb_CTHDB_tb_HDB]
GO
ALTER TABLE [dbo].[tb_CTHDN]  WITH CHECK ADD  CONSTRAINT [FK_tb_CTHDN_tb_HDN] FOREIGN KEY([mahdn])
REFERENCES [dbo].[tb_HDN] ([mahdn])
GO
ALTER TABLE [dbo].[tb_CTHDN] CHECK CONSTRAINT [FK_tb_CTHDN_tb_HDN]
GO
ALTER TABLE [dbo].[tb_CTHDN]  WITH CHECK ADD  CONSTRAINT [FK_tb_CTHDN_tb_Sanpham] FOREIGN KEY([masp])
REFERENCES [dbo].[tb_Sanpham] ([masp])
GO
ALTER TABLE [dbo].[tb_CTHDN] CHECK CONSTRAINT [FK_tb_CTHDN_tb_Sanpham]
GO
ALTER TABLE [dbo].[tb_HDB]  WITH CHECK ADD  CONSTRAINT [FK_tb_HDB_tb_Khachhang] FOREIGN KEY([makhh])
REFERENCES [dbo].[tb_Khachhang] ([makh])
GO
ALTER TABLE [dbo].[tb_HDB] CHECK CONSTRAINT [FK_tb_HDB_tb_Khachhang]
GO
ALTER TABLE [dbo].[tb_HDB]  WITH CHECK ADD  CONSTRAINT [FK_tb_HDB_tb_Nhanvien] FOREIGN KEY([manv])
REFERENCES [dbo].[tb_Nhanvien] ([manv])
GO
ALTER TABLE [dbo].[tb_HDB] CHECK CONSTRAINT [FK_tb_HDB_tb_Nhanvien]
GO
ALTER TABLE [dbo].[tb_HDN]  WITH CHECK ADD  CONSTRAINT [FK_tb_HDN_tb_Nhanvien] FOREIGN KEY([manv])
REFERENCES [dbo].[tb_Nhanvien] ([manv])
GO
ALTER TABLE [dbo].[tb_HDN] CHECK CONSTRAINT [FK_tb_HDN_tb_Nhanvien]
GO
ALTER TABLE [dbo].[tb_Sanpham]  WITH CHECK ADD  CONSTRAINT [FK_tb_Sanpham_tb_Loaihang] FOREIGN KEY([maloai])
REFERENCES [dbo].[tb_Loaihang] ([maloai])
GO
ALTER TABLE [dbo].[tb_Sanpham] CHECK CONSTRAINT [FK_tb_Sanpham_tb_Loaihang]
GO
ALTER TABLE [dbo].[tb_Sanpham]  WITH CHECK ADD  CONSTRAINT [FK_tb_Sanpham_tb_NCC] FOREIGN KEY([mancc])
REFERENCES [dbo].[tb_NCC] ([mancc])
GO
ALTER TABLE [dbo].[tb_Sanpham] CHECK CONSTRAINT [FK_tb_Sanpham_tb_NCC]
GO
USE [master]
GO
ALTER DATABASE [QL_SieuThiDienTu] SET  READ_WRITE 
GO

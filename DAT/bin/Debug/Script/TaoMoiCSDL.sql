
ALTER DATABASE [QLHS] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLHS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLHS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLHS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLHS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLHS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLHS] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLHS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLHS] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QLHS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLHS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLHS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLHS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLHS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLHS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLHS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLHS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLHS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLHS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLHS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLHS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLHS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLHS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLHS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLHS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLHS] SET RECOVERY FULL 
GO
ALTER DATABASE [QLHS] SET  MULTI_USER 
GO
ALTER DATABASE [QLHS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLHS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLHS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLHS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLHS', N'ON'
GO
USE [QLHS]
GO
/****** Object:  StoredProcedure [dbo].[ChonKhoiLop]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[ChonKhoiLop]
	@MaKhoiLop nvarchar(20)
as
begin
	select * from KHOILOP
	where MaKhoiLop = @MaKhoiLop
end


GO
/****** Object:  StoredProcedure [dbo].[DanhSachBangDiem]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DanhSachBangDiem]
	@MaNamHoc nchar(10)
AS
BEGIN
	SELECT * from BANGDIEM
	inner join QUATRINHHOC on BANGDIEM.MaQuaTrinhHoc = QUATRINHHOC.MaQuaTrinhHoc
	inner join HOCKY on QUATRINHHOC.MaHocKy = HOCKY.MaHocky
	inner join NAMHOC on NAMHOC.MaNam = HOCKY.MaNam
	where NAMHOC.MaNam = @MaNamHoc
END


GO
/****** Object:  StoredProcedure [dbo].[DanhSachBaoCaoHocKy]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DanhSachBaoCaoHocKy]
	@MaHocKy nvarchar(50)
AS
BEGIN
	SELECT LOP.TenLop, LOP.SiSo, TONGKETHOCKY.SoLuongDat, TONGKETHOCKY.TiLeDat
	FROM LOP INNER JOIN TONGKETHOCKY
	ON LOP.MaLop = TONGKETHOCKY.MaLop
	INNER JOIN QUATRINHHOC ON QUATRINHHOC.MaLop = LOP.MaLop
	WHERE QUATRINHHOC.MaHocKy = @MaHocKy
END


GO
/****** Object:  StoredProcedure [dbo].[DanhSachBaoCaoMon]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DanhSachBaoCaoMon]
	@MaNam nvarchar(50)
AS
BEGIN
	SELECT LOP.TenLop, LOP.SiSo, CT_TONGKETMONHOC.SoLuongDat, CT_TONGKETMONHOC.TiLeDat
	FROM 
		LOP INNER JOIN CT_TONGKETMONHOC
			ON LOP.MaLop = CT_TONGKETMONHOC.MaLop
			INNER JOIN TONGKETMONHOC
			ON CT_TONGKETMONHOC.MaTongKetMonHoc = CT_TONGKETMONHOC.MaTongKetMonHoc
			INNER JOIN KHOILOP
			ON LOP.MaKhoiLop = KHOILOP.MaKhoiLop
	WHERE KHOILOP.MaNam = @MaNam
		
END


GO
/****** Object:  StoredProcedure [dbo].[DanhSachDiemTBHK]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[DanhSachDiemTBHK]
	@MaLop nvarchar(50),
	@MaHocKy nvarchar(50)
as
begin
	select QUATRINHHOC.DiemTBHK 
	from QUATRINHHOC inner join LOP on QUATRINHHOC.MaLop = LOP.MaLop
	where LOP.MaLop = @MaLop and QUATRINHHOC.MaHocKy = @MaHocKy
end


GO
/****** Object:  StoredProcedure [dbo].[DanhSachGioiTinh]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[DanhSachGioiTinh]
as
begin
	select * from GIOITINH
end


GO
/****** Object:  StoredProcedure [dbo].[DanhSachHocSinhChuyenLop]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DanhSachHocSinhChuyenLop]
	@MaLop1 nvarchar(20),
	@MaLop2 nvarchar(20)
AS
BEGIN
	SELECT DISTINCT HOCSINH.MaHocSinh, HOCSINH.TenHocSinh
	FROM HOCSINH INNER JOIN QUATRINHHOC
	ON QUATRINHHOC.MaHocSinh = HOCSINH.MaHocSinh
	WHERE QUATRINHHOC.MaLop = @MaLop1 and HOCSINH.MaHocSinh not in
	(SELECT DISTINCT HOCSINH.MaHocSinh
	FROM HOCSINH INNER JOIN QUATRINHHOC
	ON QUATRINHHOC.MaHocSinh = HOCSINH.MaHocSinh
	WHERE QUATRINHHOC.MaLop = @MaLop2);
END


GO
/****** Object:  StoredProcedure [dbo].[DanhSachHocSinhDaChuyen]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DanhSachHocSinhDaChuyen]
	@MaLop nvarchar(20)
AS
BEGIN
	SELECT DISTINCT HOCSINH.MaHocSinh, HOCSINH.TenHocSinh
	FROM HOCSINH INNER JOIN QUATRINHHOC
	ON QUATRINHHOC.MaHocSinh = HOCSINH.MaHocSinh
	WHERE QUATRINHHOC.MaLop = @MaLop;
END


GO
/****** Object:  StoredProcedure [dbo].[DanhSachHS]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DanhSachHS]
	@NamHoc nvarchar(50)
AS
BEGIN
	SELECT HOCSINH.TenHocSinh, LOP.TenLop, QUATRINHHOC.DiemTBHK, HOCKY.TenHocKy 
	FROM HOCSINH INNER JOIN QUATRINHHOC
		ON HOCSINH.MaHocSinh = QUATRINHHOC.MaHocSinh
		INNER JOIN LOP
		ON LOP.MaLop = QUATRINHHOC.MaLop
		INNER JOIN HOCKY
		ON QUATRINHHOC.MaHocKy = HOCKY.MaHocky
		INNER JOIN NAMHOC
		ON HOCKY.MaNam = NAMHOC.MaNam
	WHERE NAMHOC.MaNam = @NamHoc
END


GO
/****** Object:  StoredProcedure [dbo].[DanhSachHSTheoLop]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DanhSachHSTheoLop]
	@MaLop nvarchar(20)
AS
BEGIN
	SELECT DISTINCT HOCSINH.TenHocSinh, HOCSINH.GioiTinh, HOCSINH.NgaySinh, HOCSINH.DiaChi
	FROM HOCSINH INNER JOIN QUATRINHHOC
	ON QUATRINHHOC.MaHocSinh = HOCSINH.MaHocSinh
	WHERE QUATRINHHOC.MaLop = @MaLop;
END


GO
/****** Object:  StoredProcedure [dbo].[DanhSachLop]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DanhSachLop]
	@NamHoc nvarchar(50)
as
begin
	Select LOP.MaLop, LOP.SiSo, LOP.TenLop from LOP
	inner join KHOILOP on LOP.MaKhoiLop = KHOILOP.MaKhoiLop
	where KHOILOP.MaNam = @NamHoc
end


GO
/****** Object:  StoredProcedure [dbo].[DanhSachLopTheoKhoiLop]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DanhSachLopTheoKhoiLop]
	@MaKhoiLop nvarchar(50)
as
begin
	select MaLop, TenLop, SiSo
	from LOP
	where MaKhoiLop = @MaKhoiLop
end


GO
/****** Object:  StoredProcedure [dbo].[DanhSachMonHoc]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DanhSachMonHoc]
	@NamHoc nvarchar(20)
AS
BEGIN
	SELECT MaMonHoc, TenMonHoc FROM MONHOC
	WHERE NamHoc = @NamHoc
END


GO
/****** Object:  StoredProcedure [dbo].[DanhSachMonHocTheoKhoiLop]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[DanhSachMonHocTheoKhoiLop]
	@MaKhoiLop nvarchar(50)
as
begin
	select MaMonHoc
	from CHUONGTRINHHOC
	where MaKhoiLop = @MaKhoiLop
end


GO
/****** Object:  StoredProcedure [dbo].[DanhSachMonHocTheoLop]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DanhSachMonHocTheoLop]
	@MaLop nvarchar(20)
as
begin
	select MONHOC.MaMonHoc, MONHOC.TenMonHoc
	from MONHOC inner join CHUONGTRINHHOC on MONHOC.MaMonHoc = CHUONGTRINHHOC.MaMonHoc
	inner join KHOILOP on KHOILOP.MaKhoiLop = CHUONGTRINHHOC.MaKhoiLop
	inner join LOP on KHOILOP.MaKhoiLop = LOP.MaKhoiLop
	where MaLop = @MaLop
end


GO
/****** Object:  StoredProcedure [dbo].[DanhSachNamHoc]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DanhSachNamHoc]
as
begin
	select MaNam from NAMHOC order by NamBatDau desc
end


GO
/****** Object:  StoredProcedure [dbo].[DanhSachNguoiDung]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[DanhSachNguoiDung]
as
begin
	select TenDangNhap, LoaiNguoiDung
	from NGUOIDUNG
end


GO
/****** Object:  StoredProcedure [dbo].[DanhSachThamSo]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[DanhSachThamSo]
as
begin
	select * from THAMSO
end


GO
/****** Object:  StoredProcedure [dbo].[DanhSachTongKetMon]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DanhSachTongKetMon]
	@MaHocKy nvarchar(50)
as
begin
	select * from TONGKETMONHOC
	where MaHocKy = @MaHocKy
end

GO
/****** Object:  StoredProcedure [dbo].[DoiMatKhau]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DoiMatKhau]
	@TenDangNhap nchar(20),
	@MatKhau nchar(20)
AS
BEGIN
	UPDATE NGUOIDUNG
	SET MatKhau = @MatKhau
	WHERE TenDangNhap = @TenDangNhap;
END


GO
/****** Object:  StoredProcedure [dbo].[HeSoDiem]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[HeSoDiem]
	@MaLoaiDiem nchar(10)
AS
BEGIN
	SELECT HeSo FROM LOAIDIEM
	WHERE MaLoaiDiem = @MaLoaiDiem
END


GO
/****** Object:  StoredProcedure [dbo].[HeSoMonHoc]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[HeSoMonHoc]
	@MaLop nvarchar(50),
	@MaMonHoc nvarchar(50)
AS
BEGIN
	SELECT CHUONGTRINHHOC.HeSo
	from MONHOC inner join CHUONGTRINHHOC on MONHOC.MaMonHoc = CHUONGTRINHHOC.MaMonHoc
	inner join KHOILOP on KHOILOP.MaKhoiLop = CHUONGTRINHHOC.MaKhoiLop
	inner join LOP on KHOILOP.MaKhoiLop = LOP.MaKhoiLop
	where MaLop = @MaLop AND MONHOC.MaMonHoc = @MaMonHoc
END


GO
/****** Object:  StoredProcedure [dbo].[HoSoHSTheoLop]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[HoSoHSTheoLop]
	@MaLop nvarchar(10)
AS
BEGIN
	SELECT DISTINCT HOCSINH.MAHOCSINH, HOCSINH.TenHocSinh, HOCSINH.GioiTinh, HOCSINH.NgaySinh, HOCSINH.Email, HOCSINH.DiaChi
	FROM HOCSINH INNER JOIN QUATRINHHOC
	ON QUATRINHHOC.MaHocSinh = HOCSINH.MaHocSinh
	WHERE QUATRINHHOC.MaLop = @MaLop;
END

GO
/****** Object:  StoredProcedure [dbo].[KiemTraNguoiDung]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[KiemTraNguoiDung]
	@TenDangNhap nchar(10)
as
begin
	select TenDangNhap from NGUOIDUNG
	where TenDangNhap = @TenDangNhap
end


GO
/****** Object:  StoredProcedure [dbo].[MaHSTheoLop]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[MaHSTheoLop]
	@MaLop nvarchar(20)
AS
BEGIN
	SELECT DISTINCT HOCSINH.MaHocSinh
	FROM HOCSINH INNER JOIN QUATRINHHOC
	ON QUATRINHHOC.MaHocSinh = HOCSINH.MaHocSinh
	WHERE QUATRINHHOC.MaLop = @MaLop;
END

GO
/****** Object:  StoredProcedure [dbo].[NamMoiNhat]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[NamMoiNhat]
as
begin
	select top 1 *
	from NAMHOC order by NamBatDau desc
end


GO
/****** Object:  StoredProcedure [dbo].[SuaChuongTrinhHoc]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SuaChuongTrinhHoc]
	@MaKhoiLop nvarchar(20),
	@MaMonHoc nvarchar(20),
	@HeSo float
AS
BEGIN
	UPDATE CHUONGTRINHHOC
	SET HeSo = @HeSo
	WHERE MaKhoiLop = @MaKhoiLop AND MaMonHoc = @MaMonHoc
END


GO
/****** Object:  StoredProcedure [dbo].[SuaCTBangDiem]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SuaCTBangDiem]
	@MaBangDiem nvarchar(50),
	@MaLoaiDiem nvarchar(10),
	@Diem float
as
begin
	update CT_BANGDIEM
	set Diem = @Diem
	where MaBangDiem = @MaBangDiem and MaLoaiDiem = @MaLoaiDiem
end


GO
/****** Object:  StoredProcedure [dbo].[SuaDiemTB]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SuaDiemTB]
	@MaBangDiem nvarchar(50),
	@DiemTB float
as
begin
	update BANGDIEM
	set DiemTB = @DiemTB
	where MaBangDiem = @MaBangDiem
end 


GO
/****** Object:  StoredProcedure [dbo].[SuaDiemTBHK]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[SuaDiemTBHK]
	@MaQTH nvarchar(50),
	@DiemTBHK  float
as
begin
	update QUATRINHHOC
	set DiemTBHK = @DiemTBHK
	where MaQuaTrinhHoc = @MaQTH
end 


GO
/****** Object:  StoredProcedure [dbo].[SuaHeSo]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SuaHeSo]
	@MaLoaiDiem nvarchar(50),
	@HeSo float
as
begin
	update LOAIDIEM
	set HeSo = @HeSo
	where MaLoaiDiem = @MaLoaiDiem
end


GO
/****** Object:  StoredProcedure [dbo].[SuaHS]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SuaHS]
	@MaHS nvarchar(20),
	@TenHS nvarchar(50),
	@GioiTinh nvarchar(20),
	@NgaySinh date,
	@DiaChi nvarchar(100),
	@Email nvarchar(50)
AS
BEGIN
	UPDATE HOCSINH
	SET TenHocSinh = @TenHS,
		GioiTinh = @GioiTinh,
		NgaySinh = @NgaySinh,
		DiaChi = @DiaChi,
		Email = @Email
	WHERE MaHocSinh = @MaHS;
END


GO
/****** Object:  StoredProcedure [dbo].[SuaLop]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[SuaLop]
	@MaLop nvarchar(20),
	@MaLopMoi nvarchar(20),
	@TenLop nvarchar(20),
	@MaKhoiLop nvarchar(20)
as
begin
	update LOP
	set MaLop = @MaLopMoi, TenLop = @TenLop, MaKhoiLop = @MaKhoiLop
	where MaLop = @MaLop
end


GO
/****** Object:  StoredProcedure [dbo].[SuaLopQuaTrinh]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[SuaLopQuaTrinh]
	@MaHS nchar(10),
	@MaLop nchar(10),
	@MaLopMoi nchar(10)
as
begin
	update QUATRINHHOC
	set MaLop = @MaLopMoi
	where MaLop = @MaLop and MaHocSinh = @MaHS
end


GO
/****** Object:  StoredProcedure [dbo].[SuaNamHoc]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[SuaNamHoc]
	@MaNamHoc nchar(10),
	@NamBatDau int,
	@NamKetThuc int
as
begin
	update NAMHOC
	set NamBatDau = @NamBatDau, NamKetThuc = @NamKetThuc
	where MaNam = @MaNamHoc
end


GO
/****** Object:  StoredProcedure [dbo].[SuaTenMonHoc]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SuaTenMonHoc]
	@MaMonHoc nvarchar(20),
	@MaMonMoi nvarchar(20),
	@TenMonHoc nvarchar(50)
as
begin
	update MONHOC
	set TenMonHoc = @TenMonHoc, MaMonHoc = @MaMonMoi
	where MaMonHoc = @MaMonHoc
end


GO
/****** Object:  StoredProcedure [dbo].[TangSiSo]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[TangSiSo]
	@MaLop nvarchar(20)
as
begin
	update LOP set SiSo = SiSo + 1
	where MaLop =  @MaLop
end


GO
/****** Object:  StoredProcedure [dbo].[ThayDoiKhoiLop]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[ThayDoiKhoiLop]
	@MaKhoiLop nvarchar(20),
	@MaKhoiLopMoi nvarchar(20),
	@TenKhoiLop nvarchar(20)
as
begin
	update KHOILOP
	set MaKhoiLop = @MaKhoiLopMoi, TenKhoiLop = @TenKhoiLop
	where MaKhoiLop = @MaKhoiLop
end


GO
/****** Object:  StoredProcedure [dbo].[ThayDoiThamSo]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ThayDoiThamSo]
	@Ten nvarchar(50),
	@GiaTri float
AS
BEGIN
	UPDATE THAMSO 
	SET GiaTriThamSo = @GiaTri
	WHERE TenThamSo = @Ten;
END


GO
/****** Object:  StoredProcedure [dbo].[ThemBangDiem]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ThemBangDiem]
	@MaBangDiem nvarchar(50),
	@MaQuaTrinh nvarchar(50),
	@MaMonHoc nvarchar(50),
	@DiemTB float
AS
BEGIN
	INSERT INTO BANGDIEM
	VALUES(@MaBangDiem, @MaQuaTrinh, @MaMonHoc, @DiemTB)
END


GO
/****** Object:  StoredProcedure [dbo].[ThemBaoCaoHocKy]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[ThemBaoCaoHocKy]
	@MaTongKetHocKy nvarchar(50),
	@MaHocKy nvarchar(50),
	@MaLop nvarchar(50),
	@SoLuongDat int,
	@TiLeDat float
as
begin
	insert into TONGKETHOCKY
	values(@MaTongKetHocKy, @MaHocKy, @MaLop, @SoLuongDat, @TiLeDat)
end


GO
/****** Object:  StoredProcedure [dbo].[ThemBaoCaoMonHoc]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[ThemBaoCaoMonHoc]
	@MaTongKetMonHoc nvarchar(50),
	@MaMonHoc nvarchar(50), 
	@MaHocKy nvarchar(50)
as
begin
	insert into TongKetMonHoc
	values(@MaTongKetMonHoc, @MaMonHoc, @MaHocKy)
end


GO
/****** Object:  StoredProcedure [dbo].[ThemChuongTrinhHoc]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ThemChuongTrinhHoc]
	@MaKhoiLop nvarchar(20),
	@MaMonHoc nvarchar(20),
	@HeSo float
AS
BEGIN
	INSERT INTO CHUONGTRINHHOC
	VALUES(@MaKhoiLop, @MaMonHoc, @HeSo)
END


GO
/****** Object:  StoredProcedure [dbo].[ThemCTBangDiem]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ThemCTBangDiem]
	@MaBangDiem nvarchar(50),
	@MaLoaiDiem nvarchar(50),
	@Diem float
AS
BEGIN
	INSERT INTO CT_BANGDIEM
	VALUES(@MaBangDiem, @MaLoaiDiem, @Diem)
END


GO
/****** Object:  StoredProcedure [dbo].[ThemCTBaoCaoMonHoc]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[ThemCTBaoCaoMonHoc]
	@MaCTTongKetMonHoc nvarchar(50),
	@MaTongKetMonHoc nvarchar(50),
	@MaLop nvarchar(50),
	@SoLuongDat int,
	@TiLeDat float
as
begin
	insert into CT_TONGKETMONHOC
	values(@MaCTTongKetMonHoc, @MaTongKetMonHoc, @MaLop, @SoLuongDat, @TiLeDat)
end


GO
/****** Object:  StoredProcedure [dbo].[ThemHocKy]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[ThemHocKy]
	@MaHocKy nchar(10),
	@TenHocKy nvarchar(20),
	@MaNam nchar(10)
as
begin
	insert into HOCKY
	values(@MaHocKy, @TenHocKy, @MaNam)
end


GO
/****** Object:  StoredProcedure [dbo].[ThemHS]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ThemHS]
	@MaHS nvarchar(20),
	@TenHS nvarchar(50),
	@GioiTinh nvarchar(10),
	@NgaySinh date,
	@DiaChi nvarchar(100),
	@Email nvarchar(50)
AS
BEGIN
	INSERT INTO HOCSINH(MaHocSinh, TenHocSinh, GioiTinh, NgaySinh, DiaChi, Email) 
	VALUES(@MaHS, @TenHS, @GioiTinh, @NgaySinh, @Diachi, @Email);
END


GO
/****** Object:  StoredProcedure [dbo].[ThemKhoiLop]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ThemKhoiLop]
	@MaKhoiLop nvarchar(20),
	@TenKhoiLop nvarchar(20),
	@MaNam nvarchar(20)
AS
BEGIN
	INSERT INTO KHOILOP
	VALUES(@MaKhoiLop, @TenKhoiLop, @MaNam, 0);
END


GO
/****** Object:  StoredProcedure [dbo].[ThemLop]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ThemLop]
	@MaLop nvarchar(20),
	@TenLop nvarchar(20),
	@Khoi nvarchar(20)
AS
BEGIN
	INSERT INTO LOP(MaLop, TenLop, SiSo, MaKhoiLop)
	VALUES(@MaLop, @TenLop, 0, @Khoi);
	Update KHOILOP
	set SoLop = SoLop + 1
	where MaKhoiLop = @Khoi
END


GO
/****** Object:  StoredProcedure [dbo].[ThemMonHoc]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ThemMonHoc]
	@MaMonHoc nvarchar(20),
	@TenMonHoc nvarchar(50),
	@NamHoc nvarchar(20)
AS
BEGIN
	INSERT INTO MONHOC
	VALUES(@MaMonHoc, @TenMonHoc, @NamHoc);
END


GO
/****** Object:  StoredProcedure [dbo].[ThemNamHoc]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ThemNamHoc]
	@MaNam nchar(10),
	@NamBatDau int,
	@NamKetThuc int
AS
BEGIN
	INSERT INTO NAMHOC
	VALUES(@MaNam, @NamBatDau, @NamKetThuc);
END


GO
/****** Object:  StoredProcedure [dbo].[ThemNguoiDung]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ThemNguoiDung]
	@TenDangNhap nvarchar(20),
	@MatKhau nvarchar(256),
	@LoaiNguoiDung nvarchar(20)
AS
BEGIN
	INSERT INTO NGUOIDUNG VALUES(@TenDangNhap, @MatKhau, @LoaiNguoiDung);
END


GO
/****** Object:  StoredProcedure [dbo].[ThemQuaTrinhHoc]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[ThemQuaTrinhHoc]
	@MaQuaTrinhHoc nvarchar(20),
	@MaHS nvarchar(20),
	@MaLop nvarchar(20),
	@MaHocKy nvarchar(20),
	@DiemTBHK float
as
begin
	insert into QUATRINHHOC
	values(@MaQuaTrinhHoc, @MaHS, @MaLop, @MaHocKy, @DiemTBHK)
end


GO
/****** Object:  StoredProcedure [dbo].[TimBangDiem]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[TimBangDiem]
	@MaLop nvarchar(50),
	@MaMon nvarchar(50),
	@MaHocKy nvarchar(50)
AS
BEGIN
	SELECT BANGDIEM.MaBangDiem, HOCSINH.MaHocSinh, HOCSINH.TenHocSinh, CT_BANGDIEM.Diem, CT_BANGDIEM.MaLoaiDiem, BANGDIEM.DiemTB
	FROM HOCSINH INNER JOIN QUATRINHHOC 
					ON HOCSINH.MaHocSinh = QUATRINHHOC.MaHocSinh 
				 INNER JOIN BANGDIEM 
					ON BANGDIEM.MaQuaTrinhHoc = QUATRINHHOC.MaQuaTrinhHoc
				 INNER JOIN CT_BANGDIEM
					ON BANGDIEM.MaBangDiem = CT_BANGDIEM.MaBangDiem
	WHERE QUATRINHHOC.MaLop = @MaLop AND BANGDIEM.MaMonHoc = @MaMon AND QUATRINHHOC.MaHocKy = @MaHocKy;
END


GO
/****** Object:  StoredProcedure [dbo].[TimBaoCaoHocKy]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[TimBaoCaoHocKy]
	@HocKy nvarchar(50)
AS
BEGIN
	SELECT LOP.TenLop, LOP.SiSo, TONGKETHOCKY.SoLuongDat, TONGKETHOCKY.TiLeDat
	FROM LOP INNER JOIN TONGKETHOCKY
	ON LOP.MaLop = TONGKETHOCKY.MaLop
	WHERE TONGKETHOCKY.MaHocKy = @HocKy;
END


GO
/****** Object:  StoredProcedure [dbo].[TimBaoCaoMon]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[TimBaoCaoMon]
	@Mon nvarchar(50),
	@HocKy nvarchar(50)
AS
BEGIN
	SELECT LOP.TenLop, LOP.SiSo, CT_TONGKETMONHOC.SoLuongDat, CT_TONGKETMONHOC.TiLeDat
	FROM 
		LOP INNER JOIN CT_TONGKETMONHOC
			ON LOP.MaLop = CT_TONGKETMONHOC.MaLop
			INNER JOIN TONGKETMONHOC
			ON CT_TONGKETMONHOC.MaTongKetMonHoc = TONGKETMONHOC.MaTongKetMonHoc
	WHERE TONGKETMONHOC.MaMonHoc = @Mon AND TONGKETMONHOC.MaHocKy = @HocKy;
END


GO
/****** Object:  StoredProcedure [dbo].[TimChuongTrinhHoc]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[TimChuongTrinhHoc]
	@MaKhoiLop nvarchar(20)
as
begin
	select MONHOC.MaMonHoc, MONHOC.TenMonHoc, CHUONGTRINHHOC.HeSo
	from MONHOC inner join CHUONGTRINHHOC on MONHOC.MaMonHoc = CHUONGTRINHHOC.MaMonHoc
	where CHUONGTRINHHOC.MaKhoiLop = @MaKhoiLop
end


GO
/****** Object:  StoredProcedure [dbo].[TimChuongTrinhHocChuaCo]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[TimChuongTrinhHocChuaCo]
	@NamHoc nvarchar(20),
	@MaKhoiLop nvarchar(20)
as
begin
	select MaMonHoc, TenMonHoc
	from MONHOC
	where NamHoc = @NamHoc and MaMonHoc not in (select MaMonHoc from CHUONGTRINHHOC where MaKhoiLop = @MaKhoiLop)
end


GO
/****** Object:  StoredProcedure [dbo].[TimDiemTBHocKy]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[TimDiemTBHocKy]
	@MaQuaTrinh	nvarchar(20)
as
begin
	select DiemTBHK from QUATRINHHOC
	where MaQuaTrinhHoc = @MaQuaTrinh
end


GO
/****** Object:  StoredProcedure [dbo].[TimDiemTBMon]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[TimDiemTBMon]
	@MaMonHoc nvarchar(50),
	@MaQuaTrinh nvarchar(50)
as
begin
	select DiemTB from BANGDIEM
	where MaMonHoc = @MaMonHoc and MaQuaTrinhHoc = @MaQuaTrinh
end


GO
/****** Object:  StoredProcedure [dbo].[TimGiaTriThamSo]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[TimGiaTriThamSo]
	@TenThamSo nvarchar(50)
as
begin
	select GiaTriThamSo from THAMSO
	where TenThamSo = @TenThamSo
end


GO
/****** Object:  StoredProcedure [dbo].[TimHocKy]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[TimHocKy]
	@MaNam nvarchar(20)
AS
BEGIN
	SELECT MaHocKy, TenHocKy FROM HOCKY WHERE MaNam = @MaNam;
END


GO
/****** Object:  StoredProcedure [dbo].[TimHocSinh]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TimHocSinh]
	@TenHocSinh nvarchar(50),
	@Lop nchar(10)
AS
BEGIN
	SELECT HOCSINH.TenHocSinh, LOP.TenLop, QUATRINHHOC.DiemTBHK
	FROM HOCSINH INNER JOIN QUATRINHHOC
		ON HOCSINH.MaHocSinh = QUATRINHHOC.MaHocSinh
		INNER JOIN LOP
		ON LOP.MaLop = QUATRINHHOC.MaLop
	WHERE CHARINDEX(@TenHocSinh, HOCSINH.TenHocSinh) > 0 AND LOP.MaLop = @Lop
END


GO
/****** Object:  StoredProcedure [dbo].[TimKhoiLop]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[TimKhoiLop]
	@NamHoc nvarchar(20)
as
begin
	select MaKhoiLop, TenKhoiLop, SoLop
	from KHOILOP
	where MaNam = @NamHoc
end


GO
/****** Object:  StoredProcedure [dbo].[TimLop]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TimLop]
	@MaLop nvarchar(10)
AS
BEGIN
	SELECT TenLop, SiSo FROM LOP
	WHERE MaLop = @MaLop
END


GO
/****** Object:  StoredProcedure [dbo].[TimLopTheoMon]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[TimLopTheoMon]
	@MaMonHoc nvarchar(50)
as
begin
	select LOP.MaLop, LOP.SiSo from LOP inner join
	KHOILOP on KHOILOP.MaKhoiLop = LOP.MaKhoiLop inner join
	CHUONGTRINHHOC on CHUONGTRINHHOC.MaKhoiLop = KHOILOP.MaKhoiLop
	where CHUONGTRINHHOC.MaMonHoc = @MaMonHoc
end


GO
/****** Object:  StoredProcedure [dbo].[TimMaBangDiem]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[TimMaBangDiem]
	@MaQuaTrinhHoc nchar(10),
	@MaMonHoc nchar(10)
as
begin
	select MaBangDiem from BANGDIEM
	where MaQuaTrinhHoc = @MaQuaTrinhHoc and MaMonHoc = @MaMonHoc
end


GO
/****** Object:  StoredProcedure [dbo].[TimMaQuaTrinhHoc]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[TimMaQuaTrinhHoc]
	@MaLop nchar(10),
	@MaHocSinh nchar(10),
	@MaHocKy nchar(10)
as
begin
	select QUATRINHHOC.MaQuaTrinhHoc
	from QUATRINHHOC inner join LOP
		on LOP.MaLop = QUATRINHHOC.MaLop
		inner join HOCSINH
		on QUATRINHHOC.MaHocSinh = HOCSINH.MaHocSinh
	where LOP.MaLop = @MaLop and HOCSINH.MaHocSinh = @MaHocSinh and QUATRINHHOC.MaHocKy = @MaHocKy
end


GO
/****** Object:  StoredProcedure [dbo].[TimMonHoc]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[TimMonHoc]
	@MaMon nvarchar(20)
as
begin
	select * from MONHOC
	where MaMonHoc = @MaMon
end


GO
/****** Object:  StoredProcedure [dbo].[TimMonHocTrongChuongTrinhHoc]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[TimMonHocTrongChuongTrinhHoc]
	@MaMon nvarchar(20)
as
begin
	select * from CHUONGTRINHHOC
	where MaMonHoc = @MaMon
end


GO
/****** Object:  StoredProcedure [dbo].[TimNamBatDau]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[TimNamBatDau]
	@NamBatDau int
as
begin
	select NamBatDau from NAMHOC
	where NamBatDau = @NamBatDau
end


GO
/****** Object:  StoredProcedure [dbo].[TimNamHoc]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[TimNamHoc]
	@NamBatDau int,
	@NamKetThuc int
as
begin
	select MaNam from NAMHOC
	where NamBatDau = @NamBatDau and NamKetThuc = @NamKetThuc
end


GO
/****** Object:  StoredProcedure [dbo].[TimNguoiDung]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[TimNguoiDung]
	@TenDangNhap nchar(20),
	@MatKhau nchar(256)
as
begin
	select TenDangNhap, LoaiNguoiDung from NGUOIDUNG
	where TenDangNhap = @TenDangNhap and MatKhau = @MatKhau
end


GO
/****** Object:  StoredProcedure [dbo].[TimSoHocSinh]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[TimSoHocSinh]
	@NamHoc nvarchar(20)
as
begin
	select distinct COUNT(HOCSINH.MaHoCSinh)
	from HOCSINH INNER JOIN QUATRINHHOC
	ON HOCSINH.MaHocSinh = QUATRINHHOC.MaHocSinh
	INNER JOIN HOCKY ON QUATRINHHOC.MaHocKy = HOCKY.MaHocky
	INNER JOIN NAMHOC ON NAMHOC.MaNam = HOCKY.MaNam
    WHERE NAMHOC.MaNam = @NamHoc
end


GO
/****** Object:  StoredProcedure [dbo].[XoaBangDiem]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[XoaBangDiem]
	@MaBangDiem nvarchar(50)
as
begin
	delete BANGDIEM
	where MaBangDiem = @MaBangDiem
end


GO
/****** Object:  StoredProcedure [dbo].[XoaBaoCaoHocKy]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[XoaBaoCaoHocKy]
	@MaHocKy nvarchar(50)
as
begin
	delete TONGKETHOCKY
	where MaHocKy = @MaHocKy
end


GO
/****** Object:  StoredProcedure [dbo].[XoaBaoCaoMon]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[XoaBaoCaoMon]
	@MaNam nvarchar(50)
as
begin
	delete CT_TONGKETMONHOC
	from CT_TONGKETMONHOC inner join TONGKETMONHOC on CT_TONGKETMONHOC.MaTongKetMonHoc = TONGKETMONHOC.MaTongKetMonHoc
	inner join HOCKY on TONGKETMONHOC.MaHocKy = HOCKY.MaHocky
	where HOCKY.MaNam = @MaNam

	delete TONGKETMONHOC
	from TONGKETMONHOC inner join HOCKY on TONGKETMONHOC.MaHocKy = HOCKY.MaHocky
	where HOCKY.MaNam = @MaNam
end


GO
/****** Object:  StoredProcedure [dbo].[XoaChuongTrinhHoc]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[XoaChuongTrinhHoc]
	@MaKhoiLop nvarchar(20),
	@MaMonHoc nvarchar(20)
as
begin
	delete CHUONGTRINHHOC
	where MaKhoiLop = @MaKhoiLop and MaMonHoc = @MaMonHoc
end


GO
/****** Object:  StoredProcedure [dbo].[XoaHS]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[XoaHS]
	@MaHS nvarchar(10)
AS
BEGIN
	UPDATE LOP
	SET LOP.SiSo = LOP.SiSo - 1
	FROM LOP INNER JOIN QUATRINHHOC
		ON LOP.MaLop = QUATRINHHOC.MaLop
	WHERE QUATRINHHOC.MaHocSinh = @MaHS
	DELETE HOCSINH
	WHERE MaHocSinh = @MaHS;
END


GO
/****** Object:  StoredProcedure [dbo].[XoaKhoiLop]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[XoaKhoiLop]
	@MaKhoiLop nvarchar(20)
as
begin
	delete KHOILOP
	where MaKhoiLop = @MaKhoiLop
end


GO
/****** Object:  StoredProcedure [dbo].[XoaLop]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[XoaLop]
	@MaLop nvarchar(20)
AS
BEGIN
	DELETE LOP
	WHERE MaLop = @MaLop;
	update KHOILOP
	set SoLop = SoLop - 1
	from KHOILOP inner join LOP on KHOILOP.MaKhoiLop = LOP.MaKhoiLop
	where LOP.MaLop = @MaLop 
END


GO
/****** Object:  StoredProcedure [dbo].[XoaMonHoc]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[XoaMonHoc]
	@MaMonHoc nchar(10)
AS
BEGIN
	DELETE MONHOC
	WHERE MaMonHoc = @MaMonHoc;
END


GO
/****** Object:  StoredProcedure [dbo].[XoaNguoiDung]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[XoaNguoiDung]
	@TenDangNhap nchar(20)
AS
BEGIN
	DELETE NGUOIDUNG
	WHERE TenDangNhap = @TenDangNhap;
END


GO
/****** Object:  StoredProcedure [dbo].[XoaQuaTrinhHoc]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[XoaQuaTrinhHoc]
	@MaQuaTrinh nvarchar(20)
as
begin
	delete QuaTrinhHoc
	where MaQuaTrinhHoc = @MaQuaTrinh
	end


GO
/****** Object:  Table [dbo].[BANGDIEM]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BANGDIEM](
	[MaBangDiem] [nvarchar](50) NOT NULL,
	[MaQuaTrinhHoc] [nvarchar](50) NULL,
	[MaMonHoc] [nvarchar](50) NULL,
	[DiemTB] [float] NULL,
 CONSTRAINT [PK__BANGDIEM__9D44FE482426DF02] PRIMARY KEY CLUSTERED 
(
	[MaBangDiem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CHUONGTRINHHOC]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHUONGTRINHHOC](
	[MaKhoiLop] [nvarchar](20) NOT NULL,
	[MaMonHoc] [nvarchar](50) NOT NULL,
	[HeSo] [float] NULL,
 CONSTRAINT [PK_CHUONGTRINHHOC] PRIMARY KEY CLUSTERED 
(
	[MaKhoiLop] ASC,
	[MaMonHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CT_BANGDIEM]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_BANGDIEM](
	[MaBangDiem] [nvarchar](50) NOT NULL,
	[MaLoaiDiem] [nvarchar](50) NOT NULL,
	[Diem] [float] NULL,
 CONSTRAINT [PK_CT_BANGDIEM] PRIMARY KEY CLUSTERED 
(
	[MaBangDiem] ASC,
	[MaLoaiDiem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CT_TONGKETMONHOC]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_TONGKETMONHOC](
	[MaCT_TongKetMonHoc] [nvarchar](50) NOT NULL,
	[MaTongKetMonHoc] [nvarchar](50) NULL,
	[MaLop] [nvarchar](20) NULL,
	[SoLuongDat] [int] NULL,
	[TiLeDat] [float] NULL,
 CONSTRAINT [PK__CT_TONGK__DD28ECE00BD6AF30] PRIMARY KEY CLUSTERED 
(
	[MaCT_TongKetMonHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GIOITINH]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GIOITINH](
	[GioiTinh] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GioiTinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HOCKY]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOCKY](
	[MaHocky] [nvarchar](20) NOT NULL,
	[TenHocKy] [nvarchar](20) NULL,
	[MaNam] [nvarchar](20) NULL,
 CONSTRAINT [PK__HOCKY__1EB26D086DF3CCA6] PRIMARY KEY CLUSTERED 
(
	[MaHocky] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HOCSINH]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOCSINH](
	[MaHocSinh] [nvarchar](20) NOT NULL,
	[TenHocSinh] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[NgaySinh] [datetime] NULL,
	[DiaChi] [nvarchar](100) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK__HOCSINH__90BD01E06C5F592E] PRIMARY KEY CLUSTERED 
(
	[MaHocSinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KHOILOP]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHOILOP](
	[MaKhoiLop] [nvarchar](20) NOT NULL,
	[TenKhoiLop] [nvarchar](20) NULL,
	[MaNam] [nvarchar](20) NULL,
	[SoLop] [int] NULL,
 CONSTRAINT [PK__KHOILOP__ACB753A2ADEE3449] PRIMARY KEY CLUSTERED 
(
	[MaKhoiLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LOAIDIEM]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIDIEM](
	[MaLoaiDiem] [nvarchar](50) NOT NULL,
	[TenLoaiDiem] [nvarchar](10) NULL,
	[HeSo] [float] NULL,
 CONSTRAINT [PK__LOAIDIEM__77BE9E4AC31552FE] PRIMARY KEY CLUSTERED 
(
	[MaLoaiDiem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LOP]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOP](
	[MaLop] [nvarchar](20) NOT NULL,
	[TenLop] [nvarchar](20) NULL,
	[SiSo] [int] NULL,
	[MaKhoiLop] [nvarchar](20) NULL,
 CONSTRAINT [PK__LOP__3B98D2734F4CD223] PRIMARY KEY CLUSTERED 
(
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MONHOC]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MONHOC](
	[MaMonHoc] [nvarchar](50) NOT NULL,
	[TenMonHoc] [nvarchar](50) NULL,
	[NamHoc] [nvarchar](20) NULL,
 CONSTRAINT [PK__MONHOC__4127737FE749383F] PRIMARY KEY CLUSTERED 
(
	[MaMonHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NAMHOC]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NAMHOC](
	[MaNam] [nvarchar](20) NOT NULL,
	[NamBatDau] [int] NULL,
	[NamKetThuc] [int] NULL,
 CONSTRAINT [PK__NAMHOC__3A19812C8543EFCB] PRIMARY KEY CLUSTERED 
(
	[MaNam] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NGUOIDUNG]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NGUOIDUNG](
	[TenDangNhap] [nvarchar](10) NOT NULL,
	[MatKhau] [nvarchar](256) NULL,
	[LoaiNguoiDung] [nvarchar](20) NULL,
 CONSTRAINT [PK__NGUOIDUN__55F68FC17AE81F89] PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QUATRINHHOC]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUATRINHHOC](
	[MaQuaTrinhHoc] [nvarchar](50) NOT NULL,
	[MaHocSinh] [nvarchar](20) NULL,
	[MaLop] [nvarchar](20) NULL,
	[MaHocKy] [nvarchar](20) NULL,
	[DiemTBHK] [float] NULL,
 CONSTRAINT [PK__QUATRINH__724E13700C17A641] PRIMARY KEY CLUSTERED 
(
	[MaQuaTrinhHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[THAMSO]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THAMSO](
	[TenThamSo] [nvarchar](50) NULL,
	[GiaTriThamSo] [float] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TONGKETHOCKY]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TONGKETHOCKY](
	[MaTongKetHocKy] [nvarchar](50) NOT NULL,
	[MaHocKy] [nvarchar](20) NULL,
	[MaLop] [nvarchar](20) NULL,
	[SoLuongDat] [int] NULL,
	[TiLeDat] [float] NULL,
 CONSTRAINT [PK__TONGKETH__6F6C275B56CEC7F2] PRIMARY KEY CLUSTERED 
(
	[MaTongKetHocKy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TONGKETMONHOC]    Script Date: 04/06/2015 22:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TONGKETMONHOC](
	[MaTongKetMonHoc] [nvarchar](50) NOT NULL,
	[MaMonHoc] [nvarchar](50) NULL,
	[MaHocKy] [nvarchar](20) NULL,
 CONSTRAINT [PK__TONGKETM__5A7CB8C94C6555D2] PRIMARY KEY CLUSTERED 
(
	[MaTongKetMonHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[BANGDIEM]  WITH CHECK ADD  CONSTRAINT [FK__BANGDIEM__MaMonH__2B3F6F97] FOREIGN KEY([MaMonHoc])
REFERENCES [dbo].[MONHOC] ([MaMonHoc])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BANGDIEM] CHECK CONSTRAINT [FK__BANGDIEM__MaMonH__2B3F6F97]
GO
ALTER TABLE [dbo].[BANGDIEM]  WITH CHECK ADD  CONSTRAINT [FK__BANGDIEM__MaQuaT__2A4B4B5E] FOREIGN KEY([MaQuaTrinhHoc])
REFERENCES [dbo].[QUATRINHHOC] ([MaQuaTrinhHoc])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BANGDIEM] CHECK CONSTRAINT [FK__BANGDIEM__MaQuaT__2A4B4B5E]
GO
ALTER TABLE [dbo].[CHUONGTRINHHOC]  WITH CHECK ADD  CONSTRAINT [FK__CHUONGTRI__MaKho__1FCDBCEB] FOREIGN KEY([MaKhoiLop])
REFERENCES [dbo].[KHOILOP] ([MaKhoiLop])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CHUONGTRINHHOC] CHECK CONSTRAINT [FK__CHUONGTRI__MaKho__1FCDBCEB]
GO
ALTER TABLE [dbo].[CHUONGTRINHHOC]  WITH CHECK ADD  CONSTRAINT [FK__CHUONGTRI__MaMon__20C1E124] FOREIGN KEY([MaMonHoc])
REFERENCES [dbo].[MONHOC] ([MaMonHoc])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CHUONGTRINHHOC] CHECK CONSTRAINT [FK__CHUONGTRI__MaMon__20C1E124]
GO
ALTER TABLE [dbo].[CT_BANGDIEM]  WITH CHECK ADD  CONSTRAINT [FK__CT_BANGDI__MaBan__2E1BDC42] FOREIGN KEY([MaBangDiem])
REFERENCES [dbo].[BANGDIEM] ([MaBangDiem])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CT_BANGDIEM] CHECK CONSTRAINT [FK__CT_BANGDI__MaBan__2E1BDC42]
GO
ALTER TABLE [dbo].[CT_BANGDIEM]  WITH CHECK ADD  CONSTRAINT [FK__CT_BANGDI__MaLoa__2F10007B] FOREIGN KEY([MaLoaiDiem])
REFERENCES [dbo].[LOAIDIEM] ([MaLoaiDiem])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CT_BANGDIEM] CHECK CONSTRAINT [FK__CT_BANGDI__MaLoa__2F10007B]
GO
ALTER TABLE [dbo].[CT_TONGKETMONHOC]  WITH CHECK ADD  CONSTRAINT [FK__CT_TONGKE__MaLop__36B12243] FOREIGN KEY([MaLop])
REFERENCES [dbo].[LOP] ([MaLop])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CT_TONGKETMONHOC] CHECK CONSTRAINT [FK__CT_TONGKE__MaLop__36B12243]
GO
ALTER TABLE [dbo].[CT_TONGKETMONHOC]  WITH CHECK ADD  CONSTRAINT [FK__CT_TONGKE__MaTon__35BCFE0A] FOREIGN KEY([MaTongKetMonHoc])
REFERENCES [dbo].[TONGKETMONHOC] ([MaTongKetMonHoc])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CT_TONGKETMONHOC] CHECK CONSTRAINT [FK__CT_TONGKE__MaTon__35BCFE0A]
GO
ALTER TABLE [dbo].[HOCKY]  WITH CHECK ADD  CONSTRAINT [FK__HOCKY__MaNam__1B0907CE] FOREIGN KEY([MaNam])
REFERENCES [dbo].[NAMHOC] ([MaNam])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HOCKY] CHECK CONSTRAINT [FK__HOCKY__MaNam__1B0907CE]
GO
ALTER TABLE [dbo].[HOCSINH]  WITH CHECK ADD  CONSTRAINT [gt_fk] FOREIGN KEY([GioiTinh])
REFERENCES [dbo].[GIOITINH] ([GioiTinh])
GO
ALTER TABLE [dbo].[HOCSINH] CHECK CONSTRAINT [gt_fk]
GO
ALTER TABLE [dbo].[KHOILOP]  WITH CHECK ADD  CONSTRAINT [FK__KHOILOP__MaNam__15502E78] FOREIGN KEY([MaNam])
REFERENCES [dbo].[NAMHOC] ([MaNam])
GO
ALTER TABLE [dbo].[KHOILOP] CHECK CONSTRAINT [FK__KHOILOP__MaNam__15502E78]
GO
ALTER TABLE [dbo].[LOP]  WITH CHECK ADD  CONSTRAINT [FK__LOP__MaKhoiLop__182C9B23] FOREIGN KEY([MaKhoiLop])
REFERENCES [dbo].[KHOILOP] ([MaKhoiLop])
GO
ALTER TABLE [dbo].[LOP] CHECK CONSTRAINT [FK__LOP__MaKhoiLop__182C9B23]
GO
ALTER TABLE [dbo].[MONHOC]  WITH CHECK ADD  CONSTRAINT [fk] FOREIGN KEY([NamHoc])
REFERENCES [dbo].[NAMHOC] ([MaNam])
GO
ALTER TABLE [dbo].[MONHOC] CHECK CONSTRAINT [fk]
GO
ALTER TABLE [dbo].[QUATRINHHOC]  WITH CHECK ADD  CONSTRAINT [FK__QUATRINHH__MaHoc__239E4DCF] FOREIGN KEY([MaHocSinh])
REFERENCES [dbo].[HOCSINH] ([MaHocSinh])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QUATRINHHOC] CHECK CONSTRAINT [FK__QUATRINHH__MaHoc__239E4DCF]
GO
ALTER TABLE [dbo].[QUATRINHHOC]  WITH CHECK ADD  CONSTRAINT [FK__QUATRINHH__MaHoc__25869641] FOREIGN KEY([MaHocKy])
REFERENCES [dbo].[HOCKY] ([MaHocky])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QUATRINHHOC] CHECK CONSTRAINT [FK__QUATRINHH__MaHoc__25869641]
GO
ALTER TABLE [dbo].[QUATRINHHOC]  WITH CHECK ADD  CONSTRAINT [FK__QUATRINHH__MaLop__24927208] FOREIGN KEY([MaLop])
REFERENCES [dbo].[LOP] ([MaLop])
GO
ALTER TABLE [dbo].[QUATRINHHOC] CHECK CONSTRAINT [FK__QUATRINHH__MaLop__24927208]
GO
ALTER TABLE [dbo].[TONGKETHOCKY]  WITH CHECK ADD  CONSTRAINT [FK__TONGKETHO__MaHoc__398D8EEE] FOREIGN KEY([MaHocKy])
REFERENCES [dbo].[HOCKY] ([MaHocky])
GO
ALTER TABLE [dbo].[TONGKETHOCKY] CHECK CONSTRAINT [FK__TONGKETHO__MaHoc__398D8EEE]
GO
ALTER TABLE [dbo].[TONGKETHOCKY]  WITH CHECK ADD  CONSTRAINT [FK__TONGKETHO__MaLop__3A81B327] FOREIGN KEY([MaLop])
REFERENCES [dbo].[LOP] ([MaLop])
GO
ALTER TABLE [dbo].[TONGKETHOCKY] CHECK CONSTRAINT [FK__TONGKETHO__MaLop__3A81B327]
GO
ALTER TABLE [dbo].[TONGKETMONHOC]  WITH CHECK ADD  CONSTRAINT [FK__TONGKETMO__MaHoc__32E0915F] FOREIGN KEY([MaHocKy])
REFERENCES [dbo].[HOCKY] ([MaHocky])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TONGKETMONHOC] CHECK CONSTRAINT [FK__TONGKETMO__MaHoc__32E0915F]
GO
ALTER TABLE [dbo].[TONGKETMONHOC]  WITH CHECK ADD  CONSTRAINT [FK__TONGKETMO__MaMon__31EC6D26] FOREIGN KEY([MaMonHoc])
REFERENCES [dbo].[MONHOC] ([MaMonHoc])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TONGKETMONHOC] CHECK CONSTRAINT [FK__TONGKETMO__MaMon__31EC6D26]
GO
USE [master]
GO
ALTER DATABASE [QLHS] SET  READ_WRITE 
GO

USE [QLHS]
---------------THAMSO--------------------------
INSERT INTO THAMSO VALUES('TuoiToithieu', 15)
INSERT INTO THAMSO VALUES('TuoiToiDa', 20)
INSERT INTO THAMSO VALUES('SiSoToiDa', 40)
INSERT INTO THAMSO VALUES('DiemToiThieu', 0)
INSERT INTO THAMSO VALUES('DiemToiDa', 10)
INSERT INTO THAMSO VALUES('DiemDat', 5)
INSERT INTO THAMSO VALUES('DiemDatMon', 5)

------------------NAMHOC----------------------
INSERT INTO NAMHOC VALUES('2015-2016',2015,2016)

-----------------MONHOC-----------------------
INSERT INTO MONHOC VALUES('TOAN2015',N'Toán','2015-2016')
INSERT INTO MONHOC VALUES('VATLY2015',N'Vật Lý','2015-2016')
INSERT INTO MONHOC VALUES('HOAHOC2015',N'Hóa Học','2015-2016')
INSERT INTO MONHOC VALUES('SINHHOC2015',N'Sinh Học','2015-2016')
INSERT INTO MONHOC VALUES('LICHSU2015',N'Lịch Sử','2015-2016')
INSERT INTO MONHOC VALUES('DIALY2015',N'Địa Lý','2015-2016')
INSERT INTO MONHOC VALUES('NGUVAN2015',N'Ngữ Văn','2015-2016')
INSERT INTO MONHOC VALUES('DAODUC2015',N'Đạo Đức','2015-2016')
INSERT INTO MONHOC VALUES('THEDUC2015',N'Thể Dục','2015-2016')

-------------------LOAIDIEM-------------------------
INSERT INTO LOAIDIEM VALUES('15Phut',N'15 phút',1)
INSERT INTO LOAIDIEM VALUES('1T',N'1 tiết',2)

--------------------KHOILOP----------------------------
INSERT INTO KHOILOP VALUES('K102015','K10','2015-2016',0)
INSERT INTO KHOILOP VALUES('K112015','K11','2015-2016',0)
INSERT INTO KHOILOP VALUES('K122015','K12','2015-2016',0)

----------------------LOP------------------------------
INSERT INTO LOP VALUES('10A12015','10A1',0,'K102015')
INSERT INTO LOP VALUES('10A22015','10A2',0,'K102015')
INSERT INTO LOP VALUES('10A32015','10A3',0,'K102015')
INSERT INTO LOP VALUES('10A42015','10A4',0,'K102015')

INSERT INTO LOP VALUES('11A12015','11A1',0,'K112015')
INSERT INTO LOP VALUES('11A22015','11A2',0,'K112015')
INSERT INTO LOP VALUES('11A32015','11A3',0,'K112015')

INSERT INTO LOP VALUES('12A12015','12A1',0,'K122015')
INSERT INTO LOP VALUES('12A22015','12A2',0,'K122015')

-----------------------GIOITINH-----------------------
INSERT INTO GIOITINH VALUES(N'Nam')
INSERT INTO GIOITINH VALUES(N'Nữ')

-----------------------HOCKY-------------------------
INSERT INTO HOCKY VALUES('15-16-1','1','2015-2016')
INSERT INTO HOCKY VALUES('15-16-2','2','2015-2016')
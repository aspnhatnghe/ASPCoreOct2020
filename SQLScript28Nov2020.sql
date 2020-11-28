USE eStore20;
--Viết hàm tính doanh thu theo khách hàng
CREATE FUNCTION DoanhThuTheoKhachHang
(
	@MaKH nvarchar(20)
)
RETURNS float
AS BEGIN
	DECLARE @Tong float

	SELECT @Tong = SUM(SoLuong * DonGia)
	FROM ChiTietHD cthd JOIN HoaDon hd
			ON cthd.MaHD = hd.MaHD
	WHERE hd.MaKH = @MaKH

	RETURN @Tong
END

--Sử dụng
SELECT dbo.DoanhThuTheoKhachHang('ANTON')

SELECT MaKH, HoTen, 
	dbo.DoanhThuTheoKhachHang(MaKH) as DoanhThu
FROM KhachHang 
WHERE dbo.DoanhThuTheoKhachHang(MaKH) IS NOT NULL

--VD: Hàm trả về doanh thu theo khách hàng
CREATE FUNCTION DoanhThuKhachHang
(
	@Nam int, @Thang int
)
RETURNS TABLE
AS RETURN
	SELECT kh.MaKH, kh.HoTen, 
		SUM(SoLuong * DonGia) DoanhThu
	FROM ChiTietHD cthd JOIN HoaDon hd
			ON cthd.MaHD = hd.MaHD
		JOIN KhachHang kh ON kh.MaKH = hd.MaKH
	WHERE YEAR(NgayDat) = @Nam AND MONTH(NgayDat) = @Thang
	GROUP BY kh.MaKH, kh.HoTen
--Demo
SELECT * FROM dbo.DoanhThuKhachHang(1996, 11)

--Doanh thu theo loại
CREATE FUNCTION DoanhThuTheoLoai
(
	@Nam int
)
RETURNS @tmp TABLE(
		MaLoai int,
		TenLoai nvarchar(50),
		DoanhThu float
	)
AS BEGIN
	INSERT INTO @tmp
	SELECT lo.MaLoai, lo.TenLoai,
		SUM(SoLuong * cthd.DonGia)
	FROM ChiTietHD cthd JOIN HangHoa hh 
			ON cthd.MaHH = hh.MaHH
		JOIN Loai lo ON lo.MaLoai = hh.MaLoai
		JOIN HoaDon hd ON hd.MaHD = cthd.MaHD
	WHERE YEAR(hd.NgayDat) = @Nam
	GROUP BY lo.MaLoai, lo.TenLoai

	RETURN
END

SELECT * FROM dbo.DoanhThuTheoLoai(1996)

---------------
SELECT MaHH, TenHH, SoLuong
FROM HangHoa

UPDATE HangHoa
SET SoLuong = RAND()*(39-5)+5
WHERE MaHH % 2 = 1

--Tạo trigger để tự động cập nhật số lượng hàng tồn
--khi thêm mới chi tiết hóa đơn
ALTER TRIGGER trgCapNhatHangTon ON ChiTietHD
AFTER INSERT
AS BEGIN
	DECLARE @MaHH int
	DECLARE @SoLuongBan int
	DECLARE @SoLuongTon int

	--Lấy thông tin mã HH + sp61 lượng vừa thêm vào bảng ChiTietHD
	SELECT @MaHH = MaHH, @SoLuongBan = SoLuong
	FROM inserted

	--Lấy số lượng tồn hiện có
	SELECT @SoLuongTon = SoLuong FROM HangHoa
	WHERE MaHH = @MaHH

	IF @SoLuongBan <= @SoLuongTon
	BEGIN
		-- Cập nhật tồn
		UPDATE HangHoa SET SoLuong = SoLuong - @SoLuongBan
		WHERE MaHH = @MaHH
	END
	ELSE
	BEGIN
		ROLLBACK --Hủy thao tác
	END
END

--Demo
DECLARE @MaHD int = 11109
DECLARE @MaHH int = 1002
SELECT * FROM ChiTietHD WHERE MaHD = @MaHD
SELECT MaHH, TenHH, SoLuong FROM HangHoa WHERE MaHH = @MaHH

INSERT INTO ChiTietHD(MaHD, MaHH, DonGia, SoLuong, GiamGia)
VALUES(@MaHD, @MaHH, 109, 8, 0)

SELECT MaHH, TenHH, SoLuong FROM HangHoa WHERE MaHH = @MaHH
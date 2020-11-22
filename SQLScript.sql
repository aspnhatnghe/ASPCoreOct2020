--Chọn database làm việc
USE NhatNgheDB

--Thêm mới một đơn vị
INSERT INTO DON_VI(TEN_DV, MA_DV)
	VALUES(N'Phòng Kinh doanh', 'PKD00')

--Thêm mới nhân viên
INSERT INTO NHAN_VIEN(TEN_NV, LUONG, CMND, MA_DV)
	VALUES(N'Lê Ni La', '2000', '022033066', 'PKD00')

--Tăng lương 5% cho nhân viên trên 30 tuổi
UPDATE NHAN_VIEN SET LUONG = LUONG * 1.05
	WHERE YEAR(GETDATE()) - YEAR(NGAY_SINH) > 30

--xóa nhân viên chưa có CMND
DELETE FROM NHAN_VIEN WHERE CMND IS NULL
select GETDATE(), GETUTCDATE()

-----
USE eStore20

--Truy vấn
SELECT MaKH, HoTen, NgaySinh, DienThoai,
	YEAR(GETDATE()) - YEAR(NgaySinh) Tuoi
FROM KhachHang
WHERE HoTen LIKE N'%an%'

SELECT * FROM HangHoa
WHERE DonGia BETWEEN 50 AND 899

SELECT hh.MaLoai, TenLoai, ncc.MaNCC, ncc.TenCongTy,
	MAX(DonGia) as GiaLonNhat,
	AVG(DonGia) GiaTrungBinh
FROM HangHoa hh JOIN Loai lo 
			ON hh.MaLoai = lo.MaLoai
		JOIN NhaCungCap ncc
			ON ncc.MaNCC = hh.MaNCC
GROUP BY hh.MaLoai, TenLoai, ncc.MaNCC, ncc.TenCongTy
HAVING AVG(DonGia) > 100

----DEMO VIEW
CREATE VIEW vHangHoa AS
SELECT hh.*, TenLoai, TenCongTy as NhaCungCap
FROM HangHoa hh JOIN Loai lo 
			ON hh.MaLoai = lo.MaLoai
		JOIN NhaCungCap ncc
			ON ncc.MaNCC = hh.MaNCC

--Sử dụng
SELECT * FROM vHangHoa
SELECT MaHH, TenHH, TenLoai, NhaCungCap
FROM vHangHoa WHERE DonGia BETWEEN 50 AND 200

--Tạo view chi tiết háo đơn
CREATE VIEW vChiTietHoaDon AS
SELECT cthd.*, TenHH, hh.Hinh,
	TenLoai, TenCongTy as NhaCC
FROM ChiTietHD cthd JOIN HangHoa hh
				ON cthd.MaHH = hh.MaHH
		JOIN Loai lo 
			ON hh.MaLoai = lo.MaLoai
		JOIN NhaCungCap ncc
			ON ncc.MaNCC = hh.MaNCC

SELECT * FROM vChiTietHoaDon WHERE MaHD = 10248

--DEMO STORE PROC
CREATE PROC LayHangHoa
	@MaLoai int,
	@MaNCC nvarchar(50)
AS BEGIN
	SELECT * FROM vHangHoa
	WHERE MaLoai = @MaLoai AND MaNCC = @MaNCC
END

--demo gọi
EXEC LayHangHoa 1001, 'AP'
EXECUTE LayHangHoa 1002, 'NK'

--Thêm loại
CREATE PROC spThemLoai
	@MaLoai int output,
	@TenLoai nvarchar(50),
	@MoTa nvarchar(max),
	@Hinh nvarchar(50)
AS BEGIN
	--Thêm loại
	INSERT INTO Loai(TenLoai, Hinh, MoTa)
		VALUES (@TenLoai, @Hinh, @MoTa)
	--Lấy giá trị mã loại vừa thêm
	SELECT @MaLoai = @@IDENTITY
END

DECLARE @Ma int
DECLARE @Ten nvarchar(50)
SELECT @Ten = N'Điện Máy xanh'
EXEC spThemLoai @Ma output, @Ten, NULL, NULL
PRINT CONCAT(N'Vừa thêm loại có mã ', @Ma, ' - ', @Ten)
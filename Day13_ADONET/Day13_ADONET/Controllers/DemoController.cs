using ASPCore.ADONETLab.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Day13_ADONET.Controllers
{
    public class DemoController : Controller
    {
        string ChuoiKetNoi = @"Data Source=.;Initial Catalog=eStore20;Integrated Security=True";

        public IActionResult DocDuLieu()
        {
            var connection = new SqlConnection(ChuoiKetNoi);

            var sql = "SELECT MaHH, TenHH, DonGia FROM HangHoa";

            SqlDataAdapter da = new SqlDataAdapter(sql, connection);

            var dtHangHoa = new DataTable();
            da.Fill(dtHangHoa);

            //Xử lý hiển thị dữ liệu
            var dataString = new StringBuilder();
            foreach(DataRow hhRow in dtHangHoa.Rows)
            {
                var tmp = $"{hhRow["MaHH"]} = {hhRow["TenHH"]} : {hhRow["DonGia"]}";
                dataString.AppendLine(tmp);
            }

            return Content(dataString.ToString());
        }

        public IActionResult DocHoaDon()
        {
            var connection = new SqlConnection(ChuoiKetNoi);

            var sql = @"SELECT hd.MaHD, SUM(SoLuong * DonGia) TongTien
                FROM HoaDon hd JOIN ChiTietHD cthd 
                    ON cthd.MaHd = hd.MaHd
                GROUP BY hd.MaHD";
            var dtHangHoa = DataProvider.TruyVan_LayDuLieu(sql);

            //Xử lý hiển thị dữ liệu
            var dataString = new StringBuilder();
            foreach (DataRow hhRow in dtHangHoa.Rows)
            {
                var tmp = $"{hhRow["MaHD"]} : {hhRow["TongTien"]}";
                dataString.AppendLine(tmp);
            }

            return Content(dataString.ToString());
        }

        public IActionResult ThemLoai()
        {
            try
            {
                var sqlThemLoai = "INSERT INTO Loai(TenLoai, MoTa) VALUES(N'Nước giải khát', N'Uống nhiều cho mát')";

                var connection = new SqlConnection(ChuoiKetNoi);
                connection.Open();
                var command = new SqlCommand(sqlThemLoai, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return Content("Thành công");
            }
            catch(Exception ex)
            {
                return Content($"Lỗi: {ex.Message}");
            }
        }
    }
}
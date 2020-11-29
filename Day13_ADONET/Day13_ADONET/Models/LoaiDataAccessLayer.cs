
using ASPCore.ADONETLab.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Day13_ADONET.Models
{
    public class LoaiDataAccessLayer
    {
        public List<Loai> GetAll()
        {
            var result = new List<Loai>();

            var dtLoai = DataProvider.SelectData("spLayTatCaLoai", CommandType.StoredProcedure, null);

            foreach (DataRow loai in dtLoai.Rows)
            {
                var temp = new Loai
                {
                    MaLoai = int.Parse(loai["MaLoai"].ToString()),
                    TenLoai = loai["TenLoai"].ToString(),
                    MoTa = loai["MoTa"].ToString(),
                    Hinh = loai["Hinh"].ToString(),
                };
                result.Add(temp);
            }

            return result;
        }

        public int? AddLoai(Loai lo)
        {
            SqlParameter[] pa = new SqlParameter[4];
            pa[0] = new SqlParameter("MaLoai", SqlDbType.Int);
            pa[0].Direction = ParameterDirection.Output;
            pa[1] = new SqlParameter("TenLoai", lo.TenLoai);
            pa[2] = new SqlParameter("MoTa", lo.MoTa);
            pa[3] = new SqlParameter("Hinh", lo.Hinh);
            try
            {
                DataProvider.ExcuteNonQuery("spThemLoai", CommandType.StoredProcedure, pa);
                return Convert.ToInt32(pa[0].Value);
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateLoai(Loai lo)
        {
            try
            {
                SqlParameter[] pa = new SqlParameter[4];
                pa[0] = new SqlParameter("MaLoai", lo.MaLoai);
                pa[1] = new SqlParameter("TenLoai", lo.TenLoai);
                pa[2] = new SqlParameter("MoTa", lo.MoTa ?? "");
                pa[3] = new SqlParameter("Hinh", lo.Hinh  ?? "");
                DataProvider.ExcuteNonQuery("spSuaLoai", CommandType.StoredProcedure, pa);
                return true;
            }
            catch(Exception ex)
            {
                //xử lý lưu Exception
                return false;
            }
        }

        public Loai GetLoai(int maLoai)
        {
            var pa = new SqlParameter[1];
            pa[0] = new SqlParameter("MaLoai", maLoai);

            var dtLoai = DataProvider.SelectData("spLayLoai", CommandType.StoredProcedure, pa);
            if (dtLoai.Rows.Count == 0)
            {
                return null;
            }
            return new Loai
            {
                MaLoai = maLoai,
                TenLoai = dtLoai.Rows[0]["TenLoai"].ToString(),
                MoTa = dtLoai.Rows[0]["MoTa"].ToString(),
                Hinh = dtLoai.Rows[0]["Hinh"].ToString()
            };
        }

        public bool RemoveLoai(int maLoai)
        {
            var pa = new SqlParameter[1];
            pa[0] = new SqlParameter("MaLoai", maLoai);
            try
            {
                DataProvider.ExcuteNonQuery("spXoaLoai", CommandType.StoredProcedure, pa);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLy.Model
{
    class Nhanvien
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public string NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public int Luong { get; set; }
        public Nhanvien() { }
        public Nhanvien(string ten, string ns, string dc, string gt, int l)
        {
            TenNV = ten;
            NgaySinh = ns;
            DiaChi = dc;
            GioiTinh = gt;
            Luong = l;
        }
        public static Nhanvien GetObjFromRow(DataRow dr)
        {
            return new Nhanvien()
            {
                MaNV = int.Parse(dr["MaNV"].ToString()),
                TenNV = dr["TenNV"].ToString(),
                NgaySinh = dr["NgaySinh"].ToString(),
                DiaChi = dr["DiaChi"].ToString(),
                GioiTinh = dr["GioiTinh"].ToString(),
                Luong = int.Parse(dr["Luong"].ToString())
            };
        }
    }
}
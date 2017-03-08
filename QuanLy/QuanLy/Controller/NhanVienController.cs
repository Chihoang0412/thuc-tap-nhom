using QuanLy.Helper;
using QuanLy.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLy.Controller
{
    class NhanVienController
    {
        private List<Model.Nhanvien> lstNV = new List<Model.Nhanvien>();
        public List<Model.Nhanvien> DSNV { get { return lstNV; } }
        public void SeachFullData()
        {
            DataTable dt = DataAccess.ExecQuery("select * from Nhanvien");
            Convertor(dt);
        }
        public void Insert(Nhanvien nv)
        {
            string str = string.Format("insert into Nhanvien values(N'{0}',N'{1}',N'{2}',N'{3}',{4})", nv.TenNV, nv.NgaySinh, nv.DiaChi, nv.GioiTinh, nv.Luong);
            DataAccess.ExecNonQuery(str);
        }
        public void Update(Nhanvien nv)
        {
            string str = string.Format("update Nhanvien set TenNV=N'{0}',NgaySinh=N'{1}',DiaChi=N'{2}',GioiTinh=N'{3}',Luong='{4}' where MaNV={5}", nv.TenNV, nv.NgaySinh, nv.DiaChi, nv.GioiTinh, nv.Luong,nv.MaNV);
            DataAccess.ExecNonQuery(str);
        }
        public void Delete(int Ma)
        {
            string str = string.Format("delete from Nhanvien where MaNV={0}", Ma);
            DataAccess.ExecNonQuery(str);
        }
        private void Convertor(DataTable dt)
        {
            lstNV.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                Nhanvien nv = Nhanvien.GetObjFromRow(dr);
                lstNV.Add(nv);
            }
        }
    }
}

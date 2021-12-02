using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SieuThiDienTu.DataAccess;
using SieuThiDienTu.Business.EntitiesClass;

namespace SieuThiDienTu.DataAccess
{
    class SQL_tb_NhanVien
    {
        ConnectDB cn = new ConnectDB();
        public bool kiemtranv(string manv)
        {
            return cn.kiemtra("select count(*) from [tb_Nhanvien] where manv=N'" + manv + "'");
        }
        public void themmoinv(EC_tb_NhanVien nv)
        {
            string sql = @"INSERT INTO tb_Nhanvien
                      (manv, tennv, ngaysinh, diachi, sdt)
                        VALUES   (N'" + nv.MANV + "',N'" + nv.TENNV + "',N'"+nv.Ngaysinh+"',N'" + nv.DIACHI + "',N'" + nv.SDT + "')";
            cn.ExcuteNonQuery(sql);
        }
        public void xoanv(EC_tb_NhanVien nv)
        {
            cn.ExcuteNonQuery("DELETE FROM [tb_Nhanvien] WHERE manv=N'" + nv.MANV + "'");
        }

        public void suanv(EC_tb_NhanVien nv)
        {
            string sql = (@"UPDATE    tb_Nhanvien
                    SET tennv =N'" + nv.TENNV + "', ngaysinh=N'"+nv.Ngaysinh+"', diachi =N'" + nv.DIACHI+ "', sdt =N'" + nv.SDT + "'  where manv=N'" + nv.MANV + "'");
            cn.ExcuteNonQuery(sql);
        }
    }
}

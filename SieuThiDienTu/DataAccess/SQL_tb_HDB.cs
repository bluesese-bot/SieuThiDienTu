using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SieuThiDienTu.DataAccess;
using SieuThiDienTu.Business.EntitiesClass;
using System.Windows.Forms;

namespace SieuThiDienTu.DataAccess
{
    class SQL_tb_HDB
    {
        ConnectDB cn = new ConnectDB();
        public bool kiemtraHDN(string mahdn)
        {
            return cn.kiemtra("select count(*) from [tb_HDB] where mahdb =N'" + mahdn + "'");
        }
        public void themmoiHDN(EC_tb_HDB hdn)
        {
            cn.ExcuteNonQuery(@"INSERT INTO tb_HDB
                      (mahdb,makhh, manv,ngayban, tongtien) VALUES   (N'" + hdn.Mahd + "',N'"+hdn.Makh+"' ,N'" + hdn.Manv + "',N'" + hdn.Ngaynhap + "',N'" + hdn.Tongtien + "')");
        }
        public void xoaHDN(EC_tb_HDB hdn)
        {
            cn.ExcuteNonQuery("DELETE FROM [tb_HDB] WHERE [mahdb] = N'" + hdn.Mahd + "'");
        }

        public void suaHDN(EC_tb_HDB hdn)
        {
            string sql = (@"UPDATE tb_HDB
            SET manv =N'" + hdn.Manv + "',ngayban =N'" + hdn.Ngaynhap + "', makhh=N'"+hdn.Makh+"' where  mahdb =N'" + hdn.Mahd + "'");
            cn.ExcuteNonQuery(sql);
        }
        //load mã nhà cung cấp
        public void loadmanv(ComboBox macc)
        {
            cn.LoadLenCombobox(macc, "SELECT     tennv FROM tb_Nhanvien", 0);
        }
        public string Loadtennv(string tencc, string manv)
        {
            tencc = cn.LoadLable("SELECT [manv] From [tb_Nhanvien] where tennv= N'" + manv + "'");
            return tencc;
        }
    }
}

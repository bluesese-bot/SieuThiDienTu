using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SieuThiDienTu.Business.EntitiesClass;
using System.Windows.Forms;

namespace SieuThiDienTu.DataAccess
{
    class SQL_tb_CTHDN
    {
        ConnectDB cn = new ConnectDB();
        public bool kiemtratb_CTHDN(string mahdn, string masp)
        {
            return cn.kiemtra("select count(*) from [tb_CTHDN] where mahdn=N'" + mahdn + "'and masp=N'" + masp + "'");
        }
        public void themmoicthdb(EC_tb_CTHDN cthdb)
        {
            cn.ExcuteNonQuery(@"INSERT INTO tb_CTHDN
                      (mahdn, masp, soluong, dongia,thanhtien) VALUES   (N'" + cthdb.Mahdn + "',N'" + cthdb.Masp + "',N'" + cthdb.Sl + "',N'" + cthdb.Dongia + "',N'"+cthdb.Thanhtien+"')");
        }
        public void xoacthdb(EC_tb_CTHDN cthdb)
        {
            cn.ExcuteNonQuery("DELETE FROM [tb_CTHDN] WHERE  mahdn=N'" + cthdb.Mahdn + "' and masp =N'" + cthdb.Masp + "' ");
        }

        public void suacthdb(EC_tb_CTHDN cthdb)
        {
            string sql = (@"UPDATE tb_CTHDN
            SET soluong =N'" + cthdb.Sl + "', dongia = N'" + cthdb.Dongia + "', thanhtien = N'" + cthdb.Thanhtien + "' where  mahdn=N'" + cthdb.Mahdn + "' and masp=N'" + cthdb.Masp + "'");
            cn.ExcuteNonQuery(sql);
        }
        //load sp
        public void loadmasp(ComboBox masp)
        {
            cn.LoadLenCombobox(masp, "SELECT masp FROM tb_Sanpham", 0);
        }
        public string Loadtenhang(string tenhang, string masp)
        {
            tenhang = cn.LoadLable("SELECT [tensp] From [tb_Sanpham] where masp= N'" + masp + "'");
            return tenhang;
        }
        //load THD
        public void loadmahd(ComboBox mahdn)
        {
            cn.LoadLenCombobox(mahdn, "SELECT     mahdn FROM tblHoaDonNhap", 0);
        }
        //load đơn giá bán
        public string Loaddgb(string dg, string masp)
        {
            dg = cn.LoadLable("SELECT [gianhap] From [tb_Sanpham] where masp= N'" + masp + "'");
            return dg;
        }
    }
}

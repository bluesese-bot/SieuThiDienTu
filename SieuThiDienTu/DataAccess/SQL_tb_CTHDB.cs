using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SieuThiDienTu.Business.EntitiesClass;

namespace SieuThiDienTu.DataAccess
{
    class SQL_tb_CTHDB
    {
        ConnectDB cn = new ConnectDB();
        public bool kiemtratb_CTHDN(string mahdn, string masp)
        {
            return cn.kiemtra("select count(*) from [tb_CTHDB] where mahdb =N'" + mahdn + "'and masp =N'" + masp + "'");
        }
        public void themmoicthdb(EC_tb_CTHDB cthdb)
        {
            cn.ExcuteNonQuery(@"INSERT INTO tb_CTHDB
                      (mahdb, masp, soluong, dongia,thanhtien) VALUES   (N'" + cthdb.Mahd + "',N'" + cthdb.Masp + "',N'" + cthdb.Sl + "',N'" + cthdb.Dongia + "',N'" + cthdb.Thanhtien + "')");
        }
        public void xoacthdb(EC_tb_CTHDB cthdb)
        {
            cn.ExcuteNonQuery("DELETE FROM [tb_CTHDB] WHERE  mahdb =N'" + cthdb.Mahd + "' and masp=N'" + cthdb.Masp + "' ");
        }

        public void suacthdb(EC_tb_CTHDB cthdb)
        {
            string sql = (@"UPDATE tb_CTHDB
            SET soluong =N'" + cthdb.Sl + "', dongia = N'" + cthdb.Dongia + "', thanhtien = N'" + cthdb.Thanhtien + "' where  mahdb =N'" + cthdb.Mahd + "' and masp=N'" + cthdb.Masp + "'");
            cn.ExcuteNonQuery(sql);
        }
        //load sp
        public void loadmasp(ComboBox masp)
        {
            cn.LoadLenCombobox(masp, "SELECT     masp FROM tb_Sanpham", 0);
        }
        public string Loadtenhang(string tenhang, string masp)
        {
            tenhang = cn.LoadLable("SELECT [tensp] From [tb_Sanpham] where masp= N'" + masp + "'");
            return tenhang;
        }
        //load đơn giá bán
        public void Loaddgb(TextBox dg, string masp)
        {
            cn.LoadTextBox(dg,"SELECT [giaban] From [tb_Sanpham] where masp= N'" + masp + "'");

        }
    }
}

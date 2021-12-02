using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SieuThiDienTu.Business.EntitiesClass;
using System.Windows.Forms;

namespace SieuThiDienTu.DataAccess
{
    class SQL_tb_HDN
    {
        ConnectDB cn = new ConnectDB();
        public bool kiemtraHDN(string mahdn)
        {
            return cn.kiemtra("select count(*) from [tb_HDN] where mahdn =N'" + mahdn + "'");
        }
        public void themmoiHDN(EC_tb_HDN hdn)
        {
            cn.ExcuteNonQuery(@"INSERT INTO tb_HDN
                      (mahdn, ngaynhap,manv , tongtien) VALUES   (N'" + hdn.Mahd + "',N'" + hdn.Ngaynhap + "',N'" + hdn.Manv + "',N'" + hdn.Tongtien + "')");
        }
        public void xoaHDN(EC_tb_HDN hdn)
        {
            cn.ExcuteNonQuery("DELETE FROM [tb_HDN] WHERE [mahdn] = N'" + hdn.Mahd + "'");
        }

        public void suaHDN(EC_tb_HDN hdn)
        {
            string sql = (@"UPDATE tb_HDN
            SET  ngaynhap =N'" + hdn.Ngaynhap + "',manv =N'" + hdn.Manv + "' where  mahdn =N'" + hdn.Mahd + "'");
            cn.ExcuteNonQuery(sql);
        }
        //load mã nhà cung cấp
        public void loadmancc(ComboBox macc)
        {
            cn.LoadLenCombobox(macc, "SELECT  mancc FROM tb_NCC", 0);
        }
        public string Loadtenncc(string tencc, string macc)
        {
            tencc = cn.LoadLable("SELECT [tenncc] From [tb_NCC] where mancc= N'" + macc + "'");
            return tencc;
        }
    }
}

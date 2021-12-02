using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SieuThiDienTu.DataAccess;
using SieuThiDienTu.Business.EntitiesClass;
using System.Windows.Forms;
using System.Data;

namespace SieuThiDienTu.DataAccess
{
    class SQL_tb_User
    {
        ConnectDB cn = new ConnectDB();

        public bool Kiemtrauser(EC_tb_User user)
        {
            string sql = "select count(*) from tb_User where username ='" + user.USERNAME + "' and password = '" + user.PASSWORD + "'";
            return cn.KiemtraUsername(sql);
        }

        public void themmoinv(EC_tb_User nv)
        {
            string sql = @"INSERT INTO dbo.tb_User (username,password,loaitaikhoan,manv) VALUES   (N'" + nv.USERNAME + "',N'" + nv.PASSWORD + "',N'" + nv.Loaitk + "',N'" + nv.Manv + "')";
            cn.ExcuteNonQuery(sql);
        }
        public void xoanv(EC_tb_User nv)
        {
            cn.ExcuteNonQuery("DELETE FROM [tb_User] WHERE username=N'" + nv.USERNAME + "'");
        }

        public void suanv(EC_tb_User nv)
        {
            string sql = (@"UPDATE    tb_User
                    SET  password =N'" + nv.PASSWORD + "', loaitaikhoan =N'" + nv.Loaitk + "', manv =N'" + nv.Manv + "' where username =N'" + nv.USERNAME + "'");
            cn.ExcuteNonQuery(sql);
        }
        public void suaMK(EC_tb_User mk,string MK)
        {
            string sql = (@"UPDATE dbo.tb_User SET password = N'" + mk.PASSWORD + "'WHERE username = N'" + mk.USERNAME + "' AND password =N'" + MK+"'");
            cn.ExcuteNonQuery(sql);
        }
        public void loadTKMK(TextBox tk, TextBox mk, string TK)
        {
            tk.Text = TK;
            cn.LoadTextBox(mk, @"SELECT password FROM dbo.tb_User WHERE username = N'" + TK + "'");
        }
        public List<EC_tb_User> GetTb_Menus(string Username, string pass)
        {
            List<EC_tb_User> listmenu = new List<EC_tb_User>();
            DataTable data = cn.taobang("select * from tb_User where username = N'" + Username + "' and password = N'" + pass + "'");
            foreach (DataRow item in data.Rows)
            {
                EC_tb_User menu = new EC_tb_User(item);
                listmenu.Add(menu);
            }
            return listmenu;
        }
    }
}

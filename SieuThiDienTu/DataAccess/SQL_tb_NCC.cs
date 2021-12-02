using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SieuThiDienTu.Business.EntitiesClass;

namespace SieuThiDienTu.DataAccess
{
    class SQL_tb_NCC
    {
        ConnectDB cn = new ConnectDB();
        public bool kiemtrancc(string mancc)
        {
            return cn.kiemtra("select count(*) from [tb_NCC] where mancc=N'" + mancc + "'");
        }
        public void themmoincc(EC_tb_NCC ncc)
        {
            cn.ExcuteNonQuery(@"INSERT INTO dbo.tb_NCC (mancc,tenncc,sdt,email,diachi ) VALUES (N'" + ncc.Mancc + "',N'" + ncc.Tenncc + "',N'" + ncc.Sdt + "',N'"+ncc.Email+"',N'" + ncc.Diachi + "')");
        }
        public void xoancc(EC_tb_NCC ncc)
        {
            cn.ExcuteNonQuery("DELETE FROM [tb_NCC] WHERE mancc=N'" + ncc.Mancc + "'");
        }

        public void suancc(EC_tb_NCC ncc)
        {
            string sql = (@"UPDATE  tb_NCC SET tenncc =N'" + ncc.Tenncc + "', diachi =N'" + ncc.Diachi + "', sdt =N'" + ncc.Sdt + ",email=N'"+ncc.Email+"'  where mancc=N'" + ncc.Mancc + "'");
            cn.ExcuteNonQuery(sql);
        }
    }
}

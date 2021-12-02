using SieuThiDienTu.Business.EntitiesClass;


namespace SieuThiDienTu.DataAccess
{
    class SQL_tb_Khachhang
    {
        ConnectDB cn = new ConnectDB();
        public bool kiemtranv(string manv)
        {
            return cn.kiemtra("select count(*) from [tb_Khachhang] where makh=N'" + manv + "'");
        }
        public void themmoinv(EC_tb_Khachhang nv)
        {
            string sql = @"INSERT INTO tb_Khachhang
                      (makh, tenkh, gioitinh, sdt, diachi)
                        VALUES   (N'" + nv.Makh + "',N'" + nv.Tenkh + "',N'" + nv.Gioitinh + "',N'" + nv.Sdt + "',N'" + nv.Diachi + "')";
            cn.ExcuteNonQuery(sql);
        }
        public void xoanv(EC_tb_Khachhang nv)
        {
            cn.ExcuteNonQuery("DELETE FROM [tb_Khachhang] WHERE makh=N'" + nv.Makh + "'");
        }

        public void suanv(EC_tb_Khachhang nv)
        {
            string sql = (@"UPDATE    tb_Khachhang
                    SET tenkh =N'" + nv.Tenkh + "', gioitinh=N'" + nv.Gioitinh + "', diachi =N'" + nv.Diachi + "', sdt =N'" + nv.Sdt + "'  where makh=N'" + nv.Makh + "'");
            cn.ExcuteNonQuery(sql);
        }
    }
}

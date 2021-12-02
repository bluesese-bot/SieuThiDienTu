using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SieuThiDienTu.Business.EntitiesClass;

namespace SieuThiDienTu.DataAccess
{
    class SQL_tb_Sanpham
    {
        ConnectDB cn = new ConnectDB();
        public bool kiemtraHang(string mahang)
        {
            return cn.kiemtra("select count(*) from [tb_Sanpham] where masp=N'" + mahang + "'");
        }
        public void themmoiHang(EC_tb_Sanpham hang)
        {
            SqlConnection con = cn.getcon();
            try
            {

                con.Open();
                string sql = @"INSERT INTO tb_Sanpham  (masp, tensp,mancc,maloai,gianhap,giaban,soluong) VALUES (N'"+hang.MASP+"',N'"+hang.TENSP+"',N'"+hang.Mancc+"',N'"+hang.Maloai+"',N'"+hang.GIANHAP+"',N'"+hang.GIABAN+"',N'"+hang.SOLUONG+"')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void xoaHang(EC_tb_Sanpham hang)
        {
            cn.ExcuteNonQuery("DELETE FROM [tb_Sanpham] WHERE  masp=N'"+hang.MASP+"'");
        }

        public void suaHang(EC_tb_Sanpham hang)
        {
            SqlConnection con = cn.getcon();
            try
            {
                con.Open();
                string sql = @"UPDATE    tb_Sanpham
                SET  tensp =N'"+hang.TENSP+"', giaban =N'"+hang.GIABAN+"', soluong =N'"+hang.SOLUONG+"',mancc =N'"+hang.Mancc+"', maloai=N'"+hang.Maloai+"' where masp=N'"+hang.MASP+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}

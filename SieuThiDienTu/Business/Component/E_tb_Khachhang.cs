
using SieuThiDienTu.Business.EntitiesClass;
using SieuThiDienTu.DataAccess;
using System.Windows.Forms;

namespace SieuThiDienTu.Business.Component
{
    class E_tb_Khachhang
    {
        ConnectDB cn = new ConnectDB();
        SQL_tb_Khachhang nvsql = new SQL_tb_Khachhang();

        public void themoinv(EC_tb_Khachhang nv)
        {
            if (!nvsql.kiemtranv(nv.Makh))
            {
                nvsql.themmoinv(nv);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void suanv(EC_tb_Khachhang nv)
        {
            nvsql.suanv(nv);
        }
        public void xoanv(EC_tb_Khachhang nv)
        {
            nvsql.xoanv(nv);
        }
    }
}

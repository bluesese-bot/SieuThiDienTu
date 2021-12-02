﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SieuThiDienTu.Business.EntitiesClass;
using SieuThiDienTu.DataAccess;
using System.Windows.Forms;

namespace SieuThiDienTu.Business.Component
{
    class E_tb_Sanpham
    {
        SQL_tb_Sanpham spsql = new SQL_tb_Sanpham();
        public void themoi(EC_tb_Sanpham lg)
        {
            if (!spsql.Equals(lg.MASP))
            {
                spsql.themmoiHang(lg);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void sua(EC_tb_Sanpham lg)
        {
            spsql.suaHang(lg);
        }
        public void xoa(EC_tb_Sanpham lg)
        {
            spsql.xoaHang(lg);
        }
    }
}

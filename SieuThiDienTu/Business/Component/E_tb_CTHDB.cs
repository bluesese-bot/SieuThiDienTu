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
    class E_tb_CTHDB
    {
        SQL_tb_CTHDB cthdnsql = new SQL_tb_CTHDB();
        public void themoicthdn(EC_tb_CTHDB cthdn)
        {
            if (!cthdnsql.kiemtratb_CTHDN(cthdn.Mahd, cthdn.Masp))
            {
                cthdnsql.themmoicthdb(cthdn);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void suacthdn(EC_tb_CTHDB cthdn)
        {
            cthdnsql.suacthdb(cthdn);
        }
        public void xoacthdn(EC_tb_CTHDB cthdn)
        {
            cthdnsql.xoacthdb(cthdn);
        }
        
        //load mã sản phẩm

        public void loadmasp(ComboBox cbsp)
        {
            cthdnsql.loadmasp(cbsp);
        }
        public string loadtensp(string Tensp, string Masp)
        {
            Tensp = cthdnsql.Loadtenhang(Tensp, Masp);
            return Tensp;
        }
        public void loadDG(TextBox dg,string masp)
        {
            cthdnsql.Loaddgb(dg, masp);
        }
    }
}

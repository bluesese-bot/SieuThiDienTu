using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieuThiDienTu.Business.EntitiesClass
{
    class EC_tb_HDB
    {
        private string mahd;
        private string manv;
        private string makh;
        private string ngaynhap;
        private string tongtien;

        public string Mahd { get => mahd; set => mahd = value; }
        public string Manv { get => manv; set => manv = value; }
        public string Ngaynhap { get => ngaynhap; set => ngaynhap = value; }
        public string Tongtien { get => tongtien; set => tongtien = value; }
        public string Makh { get => makh; set => makh = value; }
    }
}

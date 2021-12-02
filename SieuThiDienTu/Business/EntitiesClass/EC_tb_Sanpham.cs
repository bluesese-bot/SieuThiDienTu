using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieuThiDienTu.Business.EntitiesClass
{
    class EC_tb_Sanpham
    {
        private string masp;
        private string tensp;
        private string mancc;
        private string maloai;
        private string gianhap;
        private string giaban;
        private string soluong;
        public string MASP
        {
            get
            {
                return masp;
            }
            set
            {
                masp = value;
                if (masp == "")
                {
                    throw new Exception("Mã không để trống");
                }
            }
        }
        public string TENSP
        {
            get
            {
                return tensp;
            }
            set
            {
                tensp = value;
            }
        }
        public string GIANHAP
        {
            get
            {
                return gianhap;
            }
            set
            {
                gianhap = value;
            }
        }
        public string GIABAN
        {
            get
            {
                return giaban;
            }
            set
            {
                giaban = value;
            }
        }
        public string SOLUONG
        {
            get
            {
                return soluong;
            }
            set
            {
                soluong = value;
            }
        }

        public string Mancc { get => mancc; set => mancc = value; }
        public string Maloai { get => maloai; set => maloai = value; }
    }
}

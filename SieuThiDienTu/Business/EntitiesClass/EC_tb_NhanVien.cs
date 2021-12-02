using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SieuThiDienTu.Business.EntitiesClass
{
    class EC_tb_NhanVien
    {
        private string manv;
        private string tennv;
        private string diachi;
        private string ngaysinh;
        private string sdt;

        public EC_tb_NhanVien()
        {

        }
        public EC_tb_NhanVien(DataRow row)
        {
            this.manv = row[0].ToString();
            this.tennv = row[1].ToString();
            this.ngaysinh = row[2].ToString();
            this.diachi = row[3].ToString();
            this.sdt = row[4].ToString();
        }
        public string MANV
        {
            get
            {
                return manv;
            }
            set
            {
                manv = value;
                if (manv == "")
                {
                    throw new Exception("Mã không để trống");
                }
            }
        }
        public string TENNV
        {
            get
            {
                return tennv;
            }
            set
            {
                tennv = value;
            }
        }
        public string DIACHI
        {
            get
            {
                return diachi;
            }
            set
            {
                diachi = value;
            }
        }
        public string SDT
        {
            get
            {
                return sdt;
            }
            set
            {
                sdt = value;
            }
        }

        public string Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
    }
}

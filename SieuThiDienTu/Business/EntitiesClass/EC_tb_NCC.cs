using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieuThiDienTu.Business.EntitiesClass
{
    class EC_tb_NCC
    {
        private string mancc;
        private string tenncc;
        private string sdt;
        private string email;
        private string diachi;

        public string Mancc
        {
            get
            {
                return mancc;
            }
            set
            {
                mancc = value;
                if (mancc == "")
                {
                    throw new Exception("Mã nhà cung cấp không được để trống");
                }
            }
        }
        public string Tenncc { get => tenncc; set => tenncc = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }
        public string Diachi { get => diachi; set => diachi = value; }
    }
}

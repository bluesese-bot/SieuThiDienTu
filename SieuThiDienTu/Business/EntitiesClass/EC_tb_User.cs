using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SieuThiDienTu.Business.EntitiesClass
{
    class EC_tb_User
    {
        private string username;
        private string password;
        private string loaitk;
        private string manv;

        public EC_tb_User()
        {
        }

        public EC_tb_User(DataRow row)
        {
            this.username = row[0].ToString();
            this.password = row[1].ToString();
            this.loaitk = row[2].ToString();
            this.manv = row[3].ToString();
        }

        public string USERNAME
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                if (username == "")
                {
                    throw new Exception("Tên Đăng Nhập Không Được Để Trống !");
                }
            }
        }
        public string PASSWORD
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                if (password == "")
                {
                    throw new Exception("Mật Khẩu Không Được Để Trống !");
                }
            }
        }

        public string Loaitk { get => loaitk; set => loaitk = value; }
        public string Manv { get => manv; set => manv = value; }
    }
}

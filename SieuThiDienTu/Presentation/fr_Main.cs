using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SieuThiDienTu.Presentation
{
    public partial class fr_Main : Form
    {
        string username = "", pass = "", loaitk = "", manv = "";
        private Form activeForm;
        public void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnMain.Controls.Add(childForm);
            this.pnMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public void ThreadProc()
        {
            fr_DangNhap fr = new fr_DangNhap();
            Application.Run(fr);
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
            t.Start();
            this.Close();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_Info));
            if (frm != null)
                frm.Activate();
            else
            {
                OpenChildForm(new fr_Info(manv));
            }
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_DoiMk));
            if (frm != null)
                frm.Activate();
            else
            {
                OpenChildForm(new fr_DoiMk(username));
            }
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_TaiKhoan));
            if (frm != null)
                frm.Activate();
            else
            {
                OpenChildForm(new fr_TaiKhoan());
            }
        }

        private void nhânSựToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_NhanVien));
            if (frm != null)
                frm.Activate();
            else
            {
                OpenChildForm(new fr_NhanVien());
            }
        }

        private void mặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_Sanpham));
            if (frm != null)
                frm.Activate();
            else
            {
                OpenChildForm(new fr_Sanpham());
            }
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_NCC));
            if (frm != null)
                frm.Activate();
            else
            {
                OpenChildForm(new fr_NCC());
            }
        }



        private void nhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_HDN));
            if (frm != null)
                frm.Activate();
            else
            {
                OpenChildForm(new fr_HDN());
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_HDB));
            if (frm != null)
                frm.Activate();
            else
            {
                OpenChildForm(new fr_HDB());
            }
        }



        private void xuấtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_BC_HDB));
            if (frm != null)
                frm.Activate();
            else
            {
                OpenChildForm(new fr_BC_HDB());
            }
        }

        private void nhậpHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_BC_HDN));
            if (frm != null)
                frm.Activate();
            else
            {
                OpenChildForm(new fr_BC_HDN());
            }
        }

        private void tồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_BC_SP));
            if (frm != null)
                frm.Activate();
            else
            {
                OpenChildForm(new fr_BC_SP());
            }
        }

        private void fr_Main_Load(object sender, EventArgs e)
        {
            if (loaitk == "User")
            {
                quảnLýToolStripMenuItem.Visible = false;
            }
        }



        private void loạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_Loai));
            if (frm != null)
                frm.Activate();
            else
            {
                OpenChildForm(new fr_Loai());
            }
        }

        private void chiTiếtNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_CTHDN));
            if (frm != null)
                frm.Activate();
            else
            {
                OpenChildForm(new fr_CTHDN());
            }
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_KhachHang));
            if (frm != null)
                frm.Activate();
            else
            {
                OpenChildForm(new fr_KhachHang());
            }
        }

        public fr_Main()
        {
            InitializeComponent();
        }
        public fr_Main(string TenDanghap, string MatKhau, string LoaiTaiKhoan, string Manv)
        {
            InitializeComponent();
            this.username = TenDanghap;
            this.pass = MatKhau;
            this.loaitk = LoaiTaiKhoan;
            this.manv = Manv;
        }
        private Form kiemtratontai(Type formtype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == formtype)
                    return f;
            }
            return null;
        }
    }
}

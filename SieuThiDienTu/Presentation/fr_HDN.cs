using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SieuThiDienTu.Business.Component;
using SieuThiDienTu.Business.EntitiesClass;
using SieuThiDienTu.DataAccess;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace SieuThiDienTu.Presentation
{
    public partial class fr_HDN : Form
    {
        public fr_HDN()
        {
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();
        E_tb_HDN thucthi1 = new E_tb_HDN();
        E_tb_HDB thucthi = new E_tb_HDB();
        EC_tb_HDN ck1 = new EC_tb_HDN();
        bool themmoi;
        int dong = 0;


        public void setnull()
        {
            txtMHD.Text = "";
            dtNhap.Text = DateTime.Now.ToShortTimeString();
            cbNCC.SelectedIndex = -1;
            txtTongTien.Text = "0";
        }
        void locktext()
        {
            txtMHD.Enabled = false;

            cbNCC.Enabled = false;
            dtNhap.Enabled = false;

            btluu.Enabled = false;
            btmoi.Enabled = true;
            btsua.Enabled = true;
            btxoa.Enabled = true;
        }
        void unLocktext()
        {
            txtMHD.Enabled = true;

            cbNCC.Enabled = true;
            dtNhap.Enabled = true;


            btluu.Enabled = true;
            btmoi.Enabled = false;
            btsua.Enabled = false;
            btxoa.Enabled = false;
        }
        public void khoitaoluoi()
        {
            //Khởi Tạo Lưới Cho Hóa Đơn Nhập
            msds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].HeaderText = "Mã HDN";
            msds.Columns[0].Frozen = true;
            msds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].Width = 100;
            msds.Columns[1].HeaderText = "Mã Nhân Viên";
            msds.Columns[1].Width = 100;
            msds.Columns[2].HeaderText = "Ngày Nhập";
            msds.Columns[2].Width = 80;;
            msds.Columns[3].HeaderText = "Tổng Tiền";
            msds.Columns[3].Width = 100;

        }

        public void hienthi()
        {
            string sql = "SELECT * FROM tb_HDN";
            msds.DataSource = cn.taobang(sql);
            SqlConnection con = cn.getcon();
            con.Open();
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void fr_HDN_Load(object sender, EventArgs e)
        {
            locktext();
            hienthi();
            khoitaoluoi();
        }

        private void btmoi_Click(object sender, EventArgs e)
        {
            themmoi = true;
            unLocktext();
            setnull();
            txtMHD.Enabled = true;
            txtMHD.Focus();
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            if (txtMHD.Text != "")
            {

                    if (cbNCC.Text != "")
                    {
                        if (themmoi == true)
                        {
                            try
                            {
                            ck1.Mahd = txtMHD.Text;
                            ck1.Manv = cbNCC.Text;
                            ck1.Ngaynhap = dtNhap.Text;
                            ck1.Tongtien = txtTongTien.Text;

                            thucthi1.themoihdn(ck1);
                            locktext();
                            hienthi();
                            MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fr_CTHDN fr = new fr_CTHDN();
                                fr.Mahdn = ck1.Mahd;
                            this.Close();
                            fr.Show();
                        }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                            try
                            {
                            ck1.Mahd = txtMHD.Text;
                            ck1.Manv = cbNCC.Text;
                            ck1.Ngaynhap = dtNhap.Text;
                            ck1.Tongtien = txtTongTien.Text;

                            thucthi1.suahdn(ck1);
                               MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fr_CTHDN fr = new fr_CTHDN();
                            fr.Mahdn = ck1.Mahd;
                            this.Close();
                            fr.Show();
                        }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        txtMHD.Enabled = true;
                        locktext();
                        hienthi();
                    }
                    else
                    {
                        MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        cbNCC.Focus();
                    }
            }
            else
            {
                MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                txtMHD.Focus();
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            unLocktext();
            txtMHD.ReadOnly = true;
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck1.Mahd = txtMHD.Text;

                    thucthi1.xoahdn(ck1);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienthi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }

        private void msds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            txtMHD.Text = msds.Rows[dong].Cells[0].Value.ToString();
            dtNhap.Text = msds.Rows[dong].Cells[2].Value.ToString();
            cbNCC.Text = msds.Rows[dong].Cells[1].Value.ToString();
            txtTongTien.Text = msds.Rows[dong].Cells[3].Value.ToString();
            lbNCC.Text = thucthi.loadtennv(lbNCC.Text, cbNCC.Text);
            locktext();
        }
        private void msds_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            fr_CTHDN fr = new fr_CTHDN();
            fr.Mahdn = msds.Rows[dong].Cells[0].Value.ToString();
            fr.ShowDialog();
            hienthi();
        }

        private void cbNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbNCC.Text = thucthi.loadtennv(lbNCC.Text, cbNCC.Text);
            if (cbNCC.SelectedIndex == -1)
            {
                lbNCC.Text = "---";
            }
        }
    }
}

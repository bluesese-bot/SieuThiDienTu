using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SieuThiDienTu.Business.Component;
using SieuThiDienTu.Business.EntitiesClass;
using SieuThiDienTu.DataAccess;

namespace SieuThiDienTu.Presentation
{
    public partial class fr_HDB : Form
    {
        public fr_HDB()
        {
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();

        E_tb_HDB thucthi1 = new E_tb_HDB();
        EC_tb_HDB ck1 = new EC_tb_HDB();
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
            txtMKH.Enabled = false;

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
            txtMKH.Enabled = true;

            cbNCC.Enabled = true;;
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
            msds.Columns[0].HeaderText = "Mã HDB";
            msds.Columns[0].Frozen = true;
            msds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].Width = 100;
            msds.Columns[1].HeaderText = "Mã Khách Hàng";
            msds.Columns[1].Width = 80; ;
            msds.Columns[2].HeaderText = "Mã Nhân Viên";
            msds.Columns[2].Width = 80; ;
            msds.Columns[3].HeaderText = "Ngày Bán";
            msds.Columns[3].Width = 100;
            msds.Columns[4].HeaderText = "Tổng Tiền";
            msds.Columns[4].Width = 100;

        }
        public void hienthi()
        {
            string sql = "SELECT * FROM tb_HDB";
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
        private void fr_HDB_Load(object sender, EventArgs e)
        {
            locktext();
            thucthi1.loadmanv(cbNCC);
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
                            ck1.Manv = lbNCC.Text;
                            ck1.Ngaynhap = dtNhap.Value.ToString();
                            ck1.Tongtien = txtTongTien.Text;
                            ck1.Makh = txtMKH.Text;
                            thucthi1.themoihdn(ck1);
                            locktext();
                            hienthi();
                            MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fr_CTHDB fr = new fr_CTHDB();
                            fr.Mahdb = ck1.Mahd;
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
                            ck1.Manv = lbNCC.Text;
                            ck1.Ngaynhap = dtNhap.Text;
                            ck1.Tongtien = txtTongTien.Text;
                            ck1.Makh = txtMKH.Text;
                            thucthi1.suahdn(ck1);
                            MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fr_CTHDB fr = new fr_CTHDB();
                            fr.Mahdb = ck1.Mahd;
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
            cbNCC.Text = msds.Rows[dong].Cells[2].Value.ToString();
            txtMKH.Text = msds.Rows[dong].Cells[1].Value.ToString();
            dtNhap.Text = msds.Rows[dong].Cells[3].Value.ToString();
            txtTongTien.Text = msds.Rows[dong].Cells[4].Value.ToString();
            lbNCC.Text = thucthi1.loadtennv(lbNCC.Text, cbNCC.Text);
            locktext();
        }

        private void cbNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbNCC.Text = thucthi1.loadtennv(lbNCC.Text, cbNCC.Text);
            if (cbNCC.SelectedIndex == -1)
            {
                lbNCC.Text = "---";
            }
        }

        private void msds_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            fr_CTHDB fr = new fr_CTHDB();
            fr.Mahdb = msds.Rows[dong].Cells[0].Value.ToString();
            fr.ShowDialog();
            hienthi();
        }
    }
}

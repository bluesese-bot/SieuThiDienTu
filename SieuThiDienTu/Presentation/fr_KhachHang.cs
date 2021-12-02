﻿using SieuThiDienTu.Business.Component;
using SieuThiDienTu.Business.EntitiesClass;
using SieuThiDienTu.DataAccess;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SieuThiDienTu.Presentation
{
    public partial class fr_KhachHang : Form
    {
        public fr_KhachHang()
        {
            InitializeComponent();
        }


        E_tb_Khachhang thucthi = new E_tb_Khachhang();
        ConnectDB cn = new ConnectDB();
        EC_tb_Khachhang ck = new EC_tb_Khachhang();
        bool themmoi;
        int dong = 0;

        public void setnull()
        {
            txtma.Text = "";
            txtten.Text = "";
            txtdt.Text = "";
            txtdc.Text = "";
            cbGT.SelectedIndex = -1;
        }
        public void locktext()
        {
            txtma.Enabled = false;
            txtten.Enabled = false;
            txtdc.Enabled = false;
            txtdt.Enabled = false;
            cbGT.Enabled = false;


            btmoi.Enabled = true;
            btluu.Enabled = false;
            btsua.Enabled = true;
            btxoa.Enabled = true;
        }
        public void un_locktext()
        {
            txtma.Enabled = true;
            txtten.Enabled = true;
            txtdc.Enabled = true;
            txtdt.Enabled = true;
            cbGT.Enabled = true;

            btmoi.Enabled = false;
            btluu.Enabled = true;
            btsua.Enabled = false;
            btxoa.Enabled = false;
        }
        public void khoitaoluoi()
        {
            msds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].HeaderText = "Mã Khách Hàng";
            msds.Columns[0].Frozen = true;
            msds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].Width = 100;
            msds.Columns[1].HeaderText = "Tên Khách Hàng";
            msds.Columns[1].Width = 150;
            msds.Columns[2].HeaderText = "Giới Tính";
            msds.Columns[2].Width = 150;
            msds.Columns[3].HeaderText = "SDT";
            msds.Columns[3].Width = 100;
            msds.Columns[4].HeaderText = "Địa Chỉ";
            msds.Columns[4].Width = 100;
        }
        public void hienthi()
        {
            string sql = "SELECT * FROM tb_Khachhang";
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
        private void msds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            txtma.Text = msds.Rows[dong].Cells[0].Value.ToString();
            txtten.Text = msds.Rows[dong].Cells[1].Value.ToString();
            cbGT.Text = msds.Rows[dong].Cells[2].Value.ToString();
            txtdc.Text = msds.Rows[dong].Cells[4].Value.ToString();
            txtdt.Text = msds.Rows[dong].Cells[3].Value.ToString();
            locktext();
        }

        private void btmoi_Click(object sender, EventArgs e)
        {
            themmoi = true;
            un_locktext();
            setnull();
            txtma.Enabled = true;
            txtma.Focus();
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txtma.Enabled = false;
            txtten.Focus();
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            if (txtma.Text != "")
            {
                if (themmoi == true)
                {
                    try
                    {
                        ck.Makh = txtma.Text;
                        ck.Tenkh = txtten.Text;
                        ck.Gioitinh = cbGT.Text;
                        ck.Sdt = txtdt.Text;
                        ck.Diachi = txtdc.Text;
                        thucthi.themoinv(ck);
                        locktext();
                        hienthi();
                        MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    try
                    {
                        ck.Makh = txtma.Text;
                        ck.Tenkh = txtten.Text;
                        ck.Gioitinh = cbGT.Text;
                        ck.Sdt = txtdt.Text;
                        ck.Diachi = txtdc.Text;

                        thucthi.suanv(ck);
                        MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                txtma.Enabled = true;
                locktext();
                hienthi();
            }
            else
            {
                MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                txtma.Focus();
            }
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.Makh = txtma.Text;

                    thucthi.xoanv(ck);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienthi();
                    setnull();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }

        private void fr_KhachHang_Load(object sender, EventArgs e)
        {
            locktext();
            hienthi();
            khoitaoluoi();
        }
    }
}

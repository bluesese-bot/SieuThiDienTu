using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SieuThiDienTu.Business.Component;
using SieuThiDienTu.Business.EntitiesClass;
using SieuThiDienTu.DataAccess;
using System.IO;
using System.Data.SqlClient;

namespace SieuThiDienTu.Presentation
{
    public partial class fr_Sanpham : Form
    {
        public fr_Sanpham()
        {
            InitializeComponent();
        }
        E_tb_Sanpham thucthi = new E_tb_Sanpham();
        ConnectDB cn = new ConnectDB();
        EC_tb_Sanpham ck = new EC_tb_Sanpham();
        bool themmoi;
        int dong = 0;

        public void setnull()
        {
            txtma.Text = "";
            txtten.Text = "";
            txtdgb.Text = "0";
            txtdgn.Text = "0";
            txtsl.Text = "0";
            cbNCC.SelectedIndex = -1;
            cbLoai.SelectedIndex = -1;

        }
        public void locktext()
        {
            txtma.Enabled = false;
            txtten.Enabled = false;
            txtsl.Enabled = false;
            cbNCC.Enabled = false;
            cbLoai.Enabled = false;
            txtdgb.Enabled = false;
            txtdgn.Enabled = false;

            btmoi.Enabled = true;
            btluu.Enabled = false;
            btsua.Enabled = true;
            btxoa.Enabled = true;
        }
        public void un_locktext()
        {
            txtma.Enabled = true;
            txtten.Enabled = true;
            txtdgb.Enabled = true;
            txtsl.Enabled = true;
            cbNCC.Enabled = true;
            cbLoai.Enabled = true;
            txtdgn.Enabled = true;

            btmoi.Enabled = false;
            btluu.Enabled = true;
            btsua.Enabled = false;
            btxoa.Enabled = false;
        }
        public void khoitaoluoi()
        {
            //RepositoryItemPictureEdit image = msds.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
            msds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].HeaderText = "Mã Sản Phẩm";
            msds.Columns[0].Frozen = true;
            msds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].Width = 80;

            msds.Columns[1].HeaderText = "Tên Sản Phẩm";
            msds.Columns[1].Width = 150;

            msds.Columns[2].HeaderText = "Mã Nhà Cung Cấp";
            msds.Columns[2].Width = 150;

            msds.Columns[3].HeaderText = "Mã Loại";
            msds.Columns[3].Width = 150;

            msds.Columns[4].HeaderText = "Giá Nhập";
            msds.Columns[4].Width = 80;

            msds.Columns[5].HeaderText = "Giá Bán";
            msds.Columns[5].Width = 80;

            msds.Columns[6].HeaderText = "số Lượng";
            msds.Columns[6].Width = 80;

        }
        public void hienthi()
        {
            string sql = "SELECT * FROM tb_Sanpham";
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
        private void btmoi_Click(object sender, EventArgs e)
        {
            themmoi = true;
            un_locktext();
            setnull();
            txtma.Enabled = true;
            txtma.Focus();
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            if (txtma.Text != "" || txtten.Text !="" || txtsl.Text !="" || cbLoai.SelectedIndex != -1 || cbNCC.SelectedIndex != -1)
            {
                if (themmoi == true)
                    {
                        try
                        {
                            ck.MASP = txtma.Text;
                            ck.TENSP = txtten.Text;
                            ck.GIABAN = txtdgb.Text;
                            ck.GIANHAP = txtdgn.Text;
                            ck.SOLUONG = txtsl.Text;
                            ck.Mancc = lbNCC.Text;
                            ck.Maloai = lbLoai.Text;
                            
                            thucthi.themoi(ck);
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
                            ck.MASP = txtma.Text;
                            ck.TENSP = txtten.Text;
                            ck.GIABAN = txtdgb.Text;
                            ck.GIANHAP = txtdgn.Text;
                            ck.SOLUONG = txtsl.Text;
                            ck.Mancc = lbNCC.Text;
                            ck.Maloai = lbLoai.Text;

                        thucthi.sua(ck);
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
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txtma.Enabled = false;
            txtten.Focus();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.MASP = txtma.Text;

                    thucthi.xoa(ck);
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

        private void fr_Sanpham_Load(object sender, EventArgs e)
        {
            locktext();
            cn.LoadLenCombobox(cbNCC, "SELECT tenncc FROM tb_NCC", 0);
            cn.LoadLenCombobox(cbLoai, "SELECT tenloai FROM tb_Loaihang", 0);
            hienthi();
            khoitaoluoi();
        }

        private void msds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            txtma.Text = msds.Rows[dong].Cells[0].Value.ToString();
            txtten.Text = msds.Rows[dong].Cells[1].Value.ToString();
            lbNCC.Text = msds.Rows[dong].Cells[2].Value.ToString();
            lbLoai.Text = msds.Rows[dong].Cells[3].Value.ToString();
            txtdgn.Text = msds.Rows[dong].Cells[4].Value.ToString();
            txtdgb.Text = msds.Rows[dong].Cells[5].Value.ToString();
            txtsl.Text = msds.Rows[dong].Cells[6].Value.ToString();
            cbNCC.Text= cn.LoadLable(@"select tenncc from tb_NCC where mancc = N'" + lbNCC.Text + "'");
            cbLoai.Text = cn.LoadLable(@"select tenloai from tb_LoaiHang where maloai = N'" + lbLoai.Text + "'");
            locktext();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbNCC.Text = cn.LoadLable(@"select mancc from tb_NCC where tenncc = N'"+cbNCC.Text+"'");
            if (cbNCC.SelectedIndex == -1)
            {
                lbNCC.Text = "---";
            }
        }

        private void cbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbLoai.Text = cn.LoadLable(@"select maloai from tb_Loaihang where tenloai = N'" + cbLoai.Text + "'");
            if (cbLoai.SelectedIndex == -1)
            {
                lbLoai.Text = "---";
            }
        }
    }
}

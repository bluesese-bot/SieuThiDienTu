using SieuThiDienTu.Business.Component;
using SieuThiDienTu.Business.EntitiesClass;
using SieuThiDienTu.DataAccess;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SieuThiDienTu.Presentation
{
    public partial class fr_CTHDN : Form
    {
        private string mahdn;

        public fr_CTHDN()
        {
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();
        E_tb_CTHDN thucthi = new E_tb_CTHDN();
        EC_tb_CTHDN ck = new EC_tb_CTHDN();
        bool themmoi;
        int dong = 0;

        public string Mahdn { get => mahdn; set => mahdn = value; }

        public void setnull()
        {
            txtTT.Text = "0";
            cbMatHang.SelectedIndex = -1;
            lbMatHang.Text = "---";
            numSL.Value = 1;
            txtDongia.Text = "0";
        }
        void locktext()
        {
            txtMHD1.Enabled = false;
            txtDongia.Enabled = false;

            cbMatHang.Enabled = false;
            numSL.Enabled = false;

            btluu.Enabled = false;
            btmoi.Enabled = true;
            btsua.Enabled = true;
            btxoa.Enabled = true;
        }
        void unLocktext()
        {
            txtMHD1.Enabled = true;
            txtDongia.Enabled = true;

            cbMatHang.Enabled = true;
            numSL.Enabled = true;

            btluu.Enabled = true;
            btmoi.Enabled = false;
            btsua.Enabled = false;
            btxoa.Enabled = false;
        }
        public void khoitaoluoi()
        {

            //Khởi Tạo Lưới Cho Chi Tiết Hóa Đơn Nhập
            msds1.Columns[0].HeaderText = "Mã HDN";
            msds1.Columns[1].HeaderText = "Mã Sản Phẩm";
            msds1.Columns[2].HeaderText = "Số Lượng";
            msds1.Columns[3].HeaderText = "Đơn Giá";
            msds1.Columns[4].HeaderText = "Thành Tiền";
        }

        private void hienthi1(string sohdb)
        {
            string sql = "SELECT * FROM tb_CTHDN where mahdn = N'" + sohdb + "'";
            msds1.DataSource = cn.taobang(sql);
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
            txtMHD1.Text = mahdn;
            locktext();
            thucthi.loadmasp(cbMatHang);
            hienthi1(txtMHD1.Text);
            khoitaoluoi();
        }



        private void btnMoi1_Click(object sender, EventArgs e)
        {
            themmoi = true;
            unLocktext();
            txtMHD1.Enabled = false;
            setnull();
        }

        private void btnLuu1_Click(object sender, EventArgs e)
        {
            if (cbMatHang.Text != "")
            {
                if (themmoi == true)
                {
                    try
                    {
                        float tt = (float.Parse(numSL.Text) * float.Parse(txtDongia.Text));

                        ck.Mahdn = txtMHD1.Text;
                        ck.Masp = cbMatHang.Text;
                        ck.Sl = numSL.Text;
                        ck.Dongia = txtDongia.Text;
                        ck.Thanhtien = tt.ToString();

                        thucthi.themoicthdn(ck);
                        locktext();
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
                        float tt = (float.Parse(numSL.Text) * float.Parse(txtDongia.Text));
                        ck.Mahdn = txtMHD1.Text;
                        ck.Masp = cbMatHang.Text;
                        ck.Sl = numSL.Text;
                        ck.Dongia = txtDongia.Text;
                        ck.Thanhtien = tt.ToString();

                        thucthi.suacthdn(ck);
                        MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                float gn = float.Parse(txtDongia.Text);
                string upsl = "UPDATE tb_Sanpham SET soluong =soluong + '" + numSL.Text + "' where masp='" + cbMatHang.Text + "'";
                string upsl1 = "UPDATE tb_Sanpham SET gianhap ='" + txtDongia.Text + "' where masp ='" + cbMatHang.Text + "'";
                string uptt = "update tb_HDN set tongtien=(SELECT sum(thanhtien) FROM tb_CTHDN WHERE tb_CTHDN.mahdn = tb_HDN.mahdn) where mahdn='" + txtMHD1.Text + "'";
                cn.ExcuteNonQuery(uptt);
                cn.ExcuteNonQuery(upsl);
                cn.ExcuteNonQuery(upsl1);

                hienthi1(mahdn);
                locktext();
                float t1 = (float.Parse(numSL.Text) * float.Parse(txtDongia.Text));
                txtTT.Text = t1.ToString();
            }
            else
            {
                MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                cbMatHang.Focus();
            }
        }

        private void btnSua1_Click(object sender, EventArgs e)
        {
            txtMHD1.ReadOnly = true;
            themmoi = false;
            unLocktext();
        }

        private void btnXoa1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.Mahdn = txtMHD1.Text;
                    ck.Masp = lbMatHang.Text;

                    thucthi.xoacthdn(ck);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }

        private void msds1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            txtMHD1.Text = msds1.Rows[dong].Cells[0].Value.ToString();
            cbMatHang.Text = msds1.Rows[dong].Cells[1].Value.ToString();
            numSL.Text = msds1.Rows[dong].Cells[2].Value.ToString();
            txtDongia.Text = msds1.Rows[dong].Cells[3].Value.ToString();
            txtTT.Text = msds1.Rows[dong].Cells[4].Value.ToString();
            locktext();
        }

        private void cbMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.LoadTextBox(txtDongia, "select gianhap FROM dbo.tb_Sanpham WHERE masp= N'" + cbMatHang.Text + "'");
            lbMatHang.Text = cn.LoadLable("SELECT tensp FROM dbo.tb_Sanpham WHERE masp=N'" + cbMatHang.Text + "'");
            txtTT.Text = (double.Parse(numSL.Text) * double.Parse(txtDongia.Text)).ToString();
            if (cbMatHang.SelectedIndex == -1)
            {
                txtDongia.Text = "0";
                lbMatHang.Text = "---";
            }
        }


        private void numSL_Click(object sender, EventArgs e)
        {
            txtTT.Text = (double.Parse(numSL.Text) * double.Parse(txtDongia.Text)).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

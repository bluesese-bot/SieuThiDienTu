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

namespace SieuThiDienTu.Presentation
{
    public partial class fr_NCC : Form
    {
        public fr_NCC()
        {
            InitializeComponent();
        }
        E_tb_NCC thucthi = new E_tb_NCC();
        ConnectDB cn = new ConnectDB();
        EC_tb_NCC ck = new EC_tb_NCC();
        bool themmoi;
        int dong = 0;

        public void setnull()
        {
            txtma.Text = "";
            txtten.Text = "";
            txtdc.Text = "";
            txtdt.Text = "";
            txtEmail.Text = "";

        }
        public void locktext()
        {
            txtma.Enabled = false;
            txtten.Enabled = false;
            txtdc.Enabled = false;
            txtdt.Enabled = false;
            txtEmail.Enabled = false;


            btmoi.Enabled = true;
            btluu.Enabled = false;
            btsua.Enabled = true;
            btxoa.Enabled = true;
        }
        public void un_locktext()
        {
            txtma.Enabled = false;
            txtten.Enabled = true;
            txtdc.Enabled = true;
            txtdt.Enabled = true;
            txtEmail.Enabled = true;


            btmoi.Enabled = false;
            btluu.Enabled = true;
            btsua.Enabled = false;
            btxoa.Enabled = false;
        }
        public void khoitaoluoi()
        {
            msds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].HeaderText = "Mã NCC";
            msds.Columns[0].Frozen = true;
            msds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].Width = 100;
            msds.Columns[1].HeaderText = "Tên NCC";
            msds.Columns[1].Width = 100;
            msds.Columns[2].HeaderText = "Điện Thoại";
            msds.Columns[2].Width = 100;
            msds.Columns[3].HeaderText = "Email";
            msds.Columns[3].Width = 100;
            msds.Columns[4].HeaderText = "Địa Chỉ";
            msds.Columns[4].Width = 100;
        }
        public void hienthi()
        {
            string sql = "SELECT * FROM dbo.tb_NCC";
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
            if (txtma.Text != "")
            {
                if (themmoi == true)
                {
                    try
                    {
                        ck.Mancc = txtma.Text;
                        ck.Tenncc = txtten.Text;
                        ck.Diachi = txtdc.Text;
                        ck.Sdt = txtdt.Text;
                        ck.Email = txtEmail.Text;

                        thucthi.themoincc(ck);
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
                        ck.Mancc = txtma.Text;
                        ck.Tenncc = txtten.Text;
                        ck.Diachi = txtdc.Text;
                        ck.Sdt = txtdt.Text;
                        ck.Email = txtEmail.Text;

                        thucthi.suancc(ck);
                        MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                locktext();
                hienthi();
            }
            else
            {
                MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                txtma.Focus();
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txtten.Focus();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.Mancc = txtma.Text;

                    thucthi.xoancc(ck);
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

        private void msds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            txtma.Text = msds.Rows[dong].Cells[0].Value.ToString();
            txtten.Text = msds.Rows[dong].Cells[1].Value.ToString();
            txtdt.Text = msds.Rows[dong].Cells[2].Value.ToString();
            txtEmail.Text = msds.Rows[dong].Cells[3].Value.ToString();
            txtdc.Text = msds.Rows[dong].Cells[4].Value.ToString();
            locktext();
        }

        private void fr_NCC_Load(object sender, EventArgs e)
        {
            
            locktext();
            hienthi();
            khoitaoluoi();
        }
    }
}

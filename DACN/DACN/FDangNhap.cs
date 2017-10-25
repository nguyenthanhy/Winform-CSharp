using DACN.BUL;
using DACN.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DACN
{
    public partial class FDangNhap : Form
    {
        BUL_QuanLyTaiKhoan qltk = new BUL_QuanLyTaiKhoan();
        public FDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DTO_QuanLyTaiKhoan dn = new DTO_QuanLyTaiKhoan(txtTaiKhoan.Text, txtMatKhau.Text);
            if (qltk.DangNhap(dn))
            {
                if (MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK) == DialogResult.OK)

                {
                    FHome f = new FHome();
                    this.Hide();
                    f.ShowDialog();
                    this.Close();
                   
                }
            }
            else
                MessageBox.Show("Đăng nhập thất bại");
        }
    }
}

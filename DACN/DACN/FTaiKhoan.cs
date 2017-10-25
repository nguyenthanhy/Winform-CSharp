using DACN.BUL;
using DACN.DAL;
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
    public partial class FTaiKhoan : Form
    {

        BUL_QuanLyTaiKhoan qltk = new BUL_QuanLyTaiKhoan();
        public FTaiKhoan()
        {
            InitializeComponent();
        }
        #region Tái sử dụng
        public void Show(bool b)
        {
            btnNew.Enabled = !b;
            btnUpdate.Enabled = !b;
            btnSave.Enabled = b;
            btnCancel.Enabled = b;
            btnDelete.Enabled = !b;
            txtTaiKhoan.Enabled = b;
            txtMatKhau.Enabled = b;
            txtId.Enabled = !b;
            
            gridTaiKhoan.Enabled = !b;
        
        }
        public void Space()
        {
            txtMatKhau.Clear();
            txtTaiKhoan.Clear();
  
            txtFind.Clear();
        }
        public void getData()
        {
            string query = "Select * from dbo.Account";
            DataProvider provider = new DataProvider();
            gridTaiKhoan.DataSource = provider.Load(query);
            gridTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridTaiKhoan.Columns[0].Width = 30;
            gridTaiKhoan.Columns[3].Width = 40;
            gridTaiKhoan.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        #endregion
        #region event
        private void btnNew_Click(object sender, EventArgs e)
        {
            object Max;
            DataTable dt = gridTaiKhoan.DataSource as DataTable;
            Max = dt.Compute("Max(id)", "");
            int ma = int.Parse(Max.ToString());
            int maa = ma + 1;
            txtId.Text = maa.ToString();
            Space();
            Show(true);
            txtId.Enabled = false;
         
        }


        private void FTaiKhoan_Load(object sender, EventArgs e)
        {
            getData();
            Show(false);
            cboQuyen.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Show(false);
            Space();
            txtId.Clear();
            getData();

        }

        private void gridTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = gridTaiKhoan.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtTaiKhoan.Text = row.Cells[1].Value.ToString();
            txtMatKhau.Text = row.Cells[2].Value.ToString();
            cboQuyen.Text = row.Cells[3].Value.ToString();
            Show(false);
            btnCancel.Enabled = true;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int q = int.Parse(cboQuyen.SelectedItem.ToString());
            int id = int.Parse(txtId.Text); 
            DTO_QuanLyTaiKhoan them = new DTO_QuanLyTaiKhoan(id, txtTaiKhoan.Text, txtMatKhau.Text, q);
            if (txtTaiKhoan.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin dầy đủ", "Cảnh báo");
            }
            else if (KtId(txtId.Text)==true)
            {
                qltk.Sua(them);
                MessageBox.Show("Sửa thành công");
            }

            else if (KtId(txtId.Text) == false)
            {
                if (Ktlogin(txtTaiKhoan.Text) == false)
                {
                    qltk.Them(them);
                    MessageBox.Show("Thêm thành công");
                }
                else
                    MessageBox.Show("Trùng");
            }

            getData();
            Space();
            txtId.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {


            Show(true);
            txtId.ReadOnly = true;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);

            if (qltk.Xoa(id) == true)
            {

            }
            MessageBox.Show("Đã xóa");
            Space();
            txtId.Clear();
            getData();

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string query = ("select * from dbo.Account where login like N'%" + txtFind.Text + "%'");
            DataProvider provider = new DataProvider();
            gridTaiKhoan.DataSource = provider.Load(query);
            gridTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridTaiKhoan.Columns[0].Width = 30;
            gridTaiKhoan.Columns[3].Width = 40;
            gridTaiKhoan.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            btnCancel.Enabled = true;
        }
        private void btnOut_Click(object sender, EventArgs e)
        {

            FTaiKhoan.ActiveForm.Close();

        }
#endregion
        #region Hàm kiểm tra trùng
        public bool Ktlogin(string login) //kiểm tra tài khoản trùng
        {
            try
            {
                for (int j = 1; j <= gridTaiKhoan.Rows.Count; j++)
                {
                    string x = login;
                    string g = gridTaiKhoan.Rows[j].Cells[1].Value.ToString();
                    if (x == g)
                    {
                        return true;
                    }
                }
            }
            catch
            {

            }
           
                return false;
            
        }
        public bool KtId(string id) //kiểm tra id 
        {
            try
            {
                for (int j = 1; j <= gridTaiKhoan.Rows.Count; j++)
                {
                    string x = id;
                    string g = gridTaiKhoan.Rows[j].Cells[0].Value.ToString();
                    if (x == g)
                    {
                        return true;
                    }
                }
            }
            catch
            {

            }

            return false;

        }
        #endregion

        
        
    }
}

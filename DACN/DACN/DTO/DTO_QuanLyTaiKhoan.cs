using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACN.DTO
{
    public class DTO_QuanLyTaiKhoan
    {
        private int id;
        private string taikhoan;
        private string matkhau;
        private int status;

        public int Id { get => id; set => id = value; }
        public string Taikhoan { get => taikhoan; set => taikhoan = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
        public int Status { get => status; set => status = value; }
        public DTO_QuanLyTaiKhoan()
        {

        }
        public DTO_QuanLyTaiKhoan(string t)
        {
            taikhoan = t;
        }
        public DTO_QuanLyTaiKhoan(int i,string t, string m, int q)
        {
            id = i;
            taikhoan = t;
            matkhau = m;
            status = q;
        }
        public DTO_QuanLyTaiKhoan(string t, string m)
        {
            taikhoan = t;
            matkhau = m;

        }
    }
}

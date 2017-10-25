using DACN.DAL;
using DACN.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACN.BUL
{
    public class BUL_QuanLyTaiKhoan
    {
        DAL_QuanLyTaiKhoan qltk = new DAL_QuanLyTaiKhoan();
        public bool DangNhap(DTO_QuanLyTaiKhoan dn)
        {
            return qltk.DangNhap(dn);
        }
        public bool Them(DTO_QuanLyTaiKhoan them)
        {
            return qltk.Them(them);
        }
        public bool Sua(DTO_QuanLyTaiKhoan sua)
        {
            return qltk.Sua(sua);
        }

        public bool Xoa(int xoa)
        {
            return qltk.Xoa(xoa);
        }
        public bool Tim(DTO_QuanLyTaiKhoan tim)
        {
            return qltk.Tim(tim);
        }
    }
}

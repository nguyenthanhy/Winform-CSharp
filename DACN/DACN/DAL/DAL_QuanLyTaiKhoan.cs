using DACN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACN.DAL
{
    public class DAL_QuanLyTaiKhoan:DataProvider
    {
        
        public bool DangNhap(DTO_QuanLyTaiKhoan dn)
        {
            
            try
            {


                conn.Open();
                string sql = " SELECT *FROM dbo.Account WHERE login='" + dn.Taikhoan + "' AND pass='" + dn.Matkhau + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dtr = cmd.ExecuteReader();
                if (dtr.Read())
                    return true;


            }
            catch (Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public bool Them(DTO_QuanLyTaiKhoan them)
        {
            string query = string.Format("INSERT INTO dbo.Account( id, login, pass ,status)VALUES  ("+them.Id+", N'" + them.Taikhoan + "', N'" + them.Matkhau + "' ," + them.Status + " )");
            DataProvider provider = new DataProvider();
            provider.Processing(query);
            return false;
        }
        public bool Sua(DTO_QuanLyTaiKhoan sua)
        {
            
            string query = string.Format("UPDATE dbo.Account SET login=N'" + sua.Taikhoan + "' , pass =N'" + sua.Matkhau + "', status =" + sua.Status + " WHERE id=" + sua.Id + "");
            DataProvider provider = new DataProvider();
            provider.Processing(query);
            return false;
        }
        public bool Xoa(int xoa)
        {
            string query = string.Format("DELETE FROM dbo.Account WHERE id='" + xoa + "'");
            DataProvider provider = new DataProvider();
            provider.Processing(query);
            return false;
        }
        public bool Tim(DTO_QuanLyTaiKhoan tim)
        {
            string query = string.Format("select * from dbo.Account where login like N'%"+tim.Taikhoan+"%'");
            DataProvider provider = new DataProvider();
            provider.Processing(query);
            return false;
        }
    }
}

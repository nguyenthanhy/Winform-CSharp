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
    public class DataProvider
    {
        protected SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=DACNBLBH;Integrated Security=True");
     
        public DataTable Load(string query)
        {
           
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable data = new DataTable();
            SqlDataAdapter dtr = new SqlDataAdapter(cmd);
            dtr.Fill(data);
            conn.Close();
            return data;
        }
        public bool Processing(string query)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                if(cmd.ExecuteNonQuery()>0)
                {
                    return true;
                }
            }
            catch(Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return false;
        }
    }
}

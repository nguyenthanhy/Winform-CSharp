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
    public partial class FHome : Form
    {
        public FHome()
        {
            InitializeComponent();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
   
            FTaiKhoan f = new FTaiKhoan();
            f.ShowDialog();


        }

        private void FHome_Load(object sender, EventArgs e)
        {

        }
    }
}

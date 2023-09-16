using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom5_BaiTapNhom1
{
    public partial class Sua : Form
    {
        public Sua()
        {
            InitializeComponent();
        }

        // chỉ được nhập chữ và space ở họ tên
        private void txbHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) && !Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tsbDTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !(e.KeyChar == '.') && !Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private RadioButton GetRadioButtonValue(GroupBox groupBox)
        {
            foreach (RadioButton radioButton in groupBox.Controls)
            {
                if (radioButton.Checked) return radioButton;
            }
            return null;
        }

        private bool isNone()
        {
            if (txbHoTen.Text == "" || txbDTB.Text == "" || GetRadioButtonValue(grbGioiTinh) == null) return true; return false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (isNone())
            {
                lblOutput.Text = "Dữ liệu đưa vào còn thiếu";
            }
            else
            {
                string hoTen = txbHoTen.Text;
                float dtb = float.Parse(txbDTB.Text);
                string gioiTinh = GetRadioButtonValue(grbGioiTinh).Text;
                foreach (SinhVien sv in Program.listSinhVien)
                {
                    if (Program.FindFirstChecked(). == null)
                    {

                    }
                }
            }
        }
    }
}

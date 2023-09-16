using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom5_BaiTapNhom1
{
    public partial class Them : Form
    {
        public Them()
        {
            InitializeComponent();
        }

        // Chỉ nhập số ở MSSV
        private void txbMSSV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
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
            if (txbHoTen.Text == "" || txbMSSV.Text == "" || txbDTB.Text == "" || GetRadioButtonValue(grbGioiTinh) == null) return true; return false;
        }

        private bool isExist(SinhVien sinhVien, List<SinhVien> listSinhVien)
        {
            foreach (SinhVien sv in listSinhVien)
            {
                if (sv.Mssv.Equals(sinhVien.Mssv)) return true;
            }
            return false;
        }
        // bấm nút thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (isNone())
            {
                lblOutput.Text = "Dữ liệu đưa vào còn thiếu";
            }
            else
            {
                string mssv = txbMSSV.Text;
                string hoTen = txbHoTen.Text;
                float dtb = float.Parse(txbDTB.Text);
                string gioiTinh = GetRadioButtonValue(grbGioiTinh).Text;
                SinhVien tmp = new SinhVien(mssv, hoTen, gioiTinh, dtb);
                if (!isExist(tmp, Program.listSinhVien))
                {
                    Program.listSinhVien.Add(tmp);
                    lblOutput.Text = "Thêm thành công sinh viên:\n" + tmp.HoTen;
                }
                else
                {
                    lblOutput.Text = "Sinh viên này đã tồn tại";
                }
            }
        }
    }
}

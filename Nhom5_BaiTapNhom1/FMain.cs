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
    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();
        }

        private void LoadListView(List<SinhVien> list)
        {
            ltvShow.Items.Clear();
            foreach (SinhVien sv in list)
            {
                ListViewItem item = new ListViewItem();
                item.Text = sv.Mssv;
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = sv.HoTen });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = sv.GioiTinh });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = sv.Dtb.ToString() });
                ltvShow.Items.Add(item);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them them = new Them();
            if (them.ShowDialog() == DialogResult.Cancel)
            {
                LoadListView(Program.listSinhVien);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Tạo một danh sách tạm thời
            List<SinhVien> listSinhVienToRemove = new List<SinhVien>();

            // Duyệt qua danh sách sinh viên cần xóa
            foreach (ListViewItem item in ltvShow.Items)
            {
                if (item.Checked)
                {
                    // Lấy sinh viên cần xóa
                    SinhVien tmp = Program.listSinhVien.Find(sv => sv.Mssv == item.Text);

                    // Thêm sinh viên đó vào danh sách tạm thời
                    listSinhVienToRemove.Add(tmp);
                }
            }

            // Xóa các sinh viên khỏi danh sách gốc
            foreach (SinhVien sv in listSinhVienToRemove)
            {
                Program.listSinhVien.Remove(sv);
            }

            // Load lại listview
            LoadListView(Program.listSinhVien);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace Nhom5_BaiTapNhom1
{
    internal class SinhVien
    {
        private string mssv;
        private string hoTen;
        private string gioiTinh;
        private float dtb;


        public SinhVien() { }
        public SinhVien(string mssv, string hoTen, string gioiTinh, float dtb)
        {
            this.mssv = mssv;
            this.hoTen = hoTen.ToLower().Trim().Replace("  ", " ").Replace("   ", " ").Replace("    ", " ").Replace("     ", " ");
            this.gioiTinh = gioiTinh;
            this.dtb = dtb;
        }

        public string Mssv { get => mssv; set => mssv = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public float Dtb { get => dtb; set => dtb = value; }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab02_Baitap3
{
    struct MatHang
    {
        public int MaMH;
        public string TenMH;
        public int SoLuong;
        public float DonGia;

        public MatHang(int MaMH, string TenMH, int SoLuong, float DonGia)
        {
            this.MaMH = MaMH;
            this.TenMH = TenMH;
            this.SoLuong = SoLuong;
            this.DonGia = DonGia;
        }

        public float ThanhTien()
        {
            return SoLuong * DonGia;
        }

        public void XuatThongTin()
        {
            Console.WriteLine($"Ma MH: {MaMH,-5} | Ten MH: {TenMH,-15} | So luong: {SoLuong,-5} | Don gia: {DonGia,-8} | Thanh tien: {ThanhTien()}");
        }
    }
    internal class Program
    {
        static void ThemMatHang(Hashtable danhsach, MatHang m)
        {
            if (danhsach.ContainsKey(m.MaMH))
            {
                Console.WriteLine($"Ma mat hang {m.MaMH} da ton tai trong danh sach!");
            }
            else
            {
                danhsach.Add(m.MaMH, m);
            }
        }

        // Hàm tìm một mặt hàng dựa vào mã mặt hàng
        static bool TimMatHang(Hashtable danhsach, int MaMH)
        {
            return danhsach.ContainsKey(MaMH);
        }

        // Hàm xóa mặt hàng dựa vào mã mặt hàng
        static void XoaMatHang(Hashtable danhsach, int MaMH)
        {
            if (TimMatHang(danhsach, MaMH))
            {
                danhsach.Remove(MaMH);
                Console.WriteLine($"Da xoa thanh cong mat hang co ma: {MaMH}");
            }
            else
            {
                Console.WriteLine($"Khong tim thay mat hang co ma: {MaMH} de xoa.");
            }
        }

        // Hàm xuất danh sách mặt hàng
        static void XuatDanhSach(Hashtable danhsach)
        {
            if (danhsach.Count == 0)
            {
                Console.WriteLine("Danh sach mat hang trong!");
                return;
            }

            Console.WriteLine("\n--- DANH SÁCH MAT HANG ---");
            foreach (DictionaryEntry item in danhsach)
            {
                MatHang mh = (MatHang)item.Value;
                mh.XuatThongTin();
            }
            Console.WriteLine("---------------------------\n");
        }
        static void Main(string[] args)
        {
            Hashtable danhsachMatHang = new Hashtable();
            string tiepTuc = "y";

            // 1. Nhập danh sách mặt hàng
            Console.WriteLine("=== NHAP DANH SACH MAT HANG ===");
            while (tiepTuc.ToLower() == "y")
            {
                Console.Write("Nhap ma mat hang (so nguyen): ");
                int ma = int.Parse(Console.ReadLine());

                Console.Write("Nhap ten mat hang: ");
                string ten = Console.ReadLine();

                Console.Write("Nhap so luong: ");
                int soLuong = int.Parse(Console.ReadLine());

                Console.Write("Nhap don gia: ");
                float donGia = float.Parse(Console.ReadLine());

                MatHang mh = new MatHang(ma, ten, soLuong, donGia);
                ThemMatHang(danhsachMatHang, mh);

                Console.Write("Ban co muon tiep tuc nhap? (yes/no): ");
                tiepTuc = Console.ReadLine();
                Console.WriteLine();
            }

            // 2. Xuất danh sách các mặt hàng
            XuatDanhSach(danhsachMatHang);

            // 3. Tìm kiếm và xóa mặt hàng
            Console.Write("Nhap ma mat hang can tim va xoa: ");
            int maCanXoa = int.Parse(Console.ReadLine());

            if (TimMatHang(danhsachMatHang, maCanXoa))
            {
                Console.WriteLine($"Tim thay mat hang co ma {maCanXoa}. Tien hanh xoa...");
                XoaMatHang(danhsachMatHang, maCanXoa);

                // Xuất lại danh sách sau khi xóa
                Console.WriteLine("\nDanh sach mat hang sau khi xoa:");
                XuatDanhSach(danhsachMatHang);
            }
            else
            {
                Console.WriteLine($"Khong tim thay mat hang co ma {maCanXoa}!");
            }

            Console.ReadLine();
        }
    }
}

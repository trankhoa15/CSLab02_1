using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab02_Baitap2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("Nhap so luong phan tu n (n > 0): ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Vui long nhap mot so nguyen duong n > 0: ");
            }
            List<int> numbers = new List<int>();
            Random rnd = new Random();

            // n số ngẫu nhiên
            for (int i = 0; i < n; i++)
            {
                numbers.Add(rnd.Next(100)); // số ngẫu nhiên từ 0 đến 99
            }

            // xuất danh sách ban đầu
            Console.WriteLine("\nDay so ngau nhien ban dau:");
            XuatList(numbers);

            // sắp xếp danh sách tăng dần
            numbers.Sort();

            // xuất danh sách sau khi sắp xếp
            Console.WriteLine("\nDay so sau khi sap xep tang dan:");
            XuatList(numbers);

            Console.ReadLine();
        }

        static void XuatList(List<int> list)
        {
            foreach (int item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}

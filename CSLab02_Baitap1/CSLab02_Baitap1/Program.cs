using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab02_Baitap1
{
    class NotNegativeException : Exception
    {
        public NotNegativeException() : base("Gia tri duoi dau can < 0") { }
        public NotNegativeException(string message) : base(message) { }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Nhap x = ");
                int x = int.Parse(Console.ReadLine());

                Console.Write("Nhap y = ");
                int y = int.Parse(Console.ReadLine());

                // Kiểm tra chia cho 0
                if (2 * x - y == 0)
                {
                    throw new DivideByZeroException("Mau so bang 0 (2x - y = 0)");
                }

                double mauSo = 2 * x - y;
                double tuSo = 3 * x + 2 * y;
                double bieuThuc = tuSo / mauSo;

                // Kiểm tra giá trị dưới dấu căn < 0
                if (bieuThuc < 0)
                {
                    throw new NotNegativeException();
                }

                double H = Math.Sqrt(bieuThuc);
                Console.WriteLine($"Gia tri bieu thuc H = {H}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Loi: Sai format, vui long nhap so nguyen!");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Loi chia cho 0: {ex.Message}");
            }
            catch (NotNegativeException ex)
            {
                Console.WriteLine($"Loi ngoai le tu dinh nghia: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Loi khac: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}

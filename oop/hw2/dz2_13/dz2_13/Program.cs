using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace dz2_13
{
    public class Program
    {
        static double segment1(double x)
        {
            double y = x + 3;
            return y;
        }
        static double segment2(double x, double r)
        {
            double y = Math.Sqrt(Math.Pow(r,2) - Math.Pow(x, 2));
            return y;
        }
        static double segment3(double x)
        {
            double y = -0.5 * x + 3;
            return y;
        }
        static double segment4(double x)
        {
            return x - 6;
        }
        
        public static void Main(string[] args)
        {
            double r;
            while(true)
            {
                Console.WriteLine("Введите r");
                if (double.TryParse(Console.ReadLine(), out r))
                {
                    if (r > 0) break;
                    else Console.WriteLine("Введите неотрицательное r");
                }
                else Console.WriteLine("Введите r числом");
            }
            for (double x = -5; x < 9.1; x = x + 0.2)
            {
                if (x < -3) Console.WriteLine(string.Format("{0:0.00}: {1:0.00}", x, segment1(x)));
                else if (x < 0) Console.WriteLine(string.Format("{0:0.00}: {1:0.00}", x, segment2(x,r)));
                else if (x < 6) Console.WriteLine(string.Format("{0:0.00}: {1:0.00}", x, segment3(x)));
                else Console.WriteLine(string.Format("{0:0.00}: {1:0.00}", x, segment4(x)));
            }
            while (true)
            {
                double x;
                while (true)
                {
                    Console.WriteLine("Введите x или 123 для выхода");
                    if (double.TryParse(Console.ReadLine(), out x))
                    {
                        if ((x > -5.1 && x < 9.1) || x==123) break;
                        else Console.WriteLine("Введите x из ипромежутка [-5,9]");
                    }
                    else Console.WriteLine("Введите x числом");
                }
                if (x == 123) break;
                if (x < -3) Console.WriteLine(string.Format("{0:0.00}: {1:0.00}", x, segment1(x)));
                else if (x < 0) Console.WriteLine(string.Format("{0:0.00}: {1:0.00}", x, segment2(x, r)));
                else if (x < 6) Console.WriteLine(string.Format("{0:0.00}: {1:0.00}", x, segment3(x)));
                else Console.WriteLine(string.Format("{0:0.00}: {1:0.00}", x, segment4(x)));
            }
        }
    }
}
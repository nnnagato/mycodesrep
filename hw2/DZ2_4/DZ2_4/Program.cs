using System;

namespace lab1
{
    class Program
    {

        static double segment1(double x)
        {
            double k = -0.5;
            double b = -3;
            double y = k * x + b;
            return y;
        }

        static double segment2(double x, double r)
        {
            double y = Math.Sqrt(Math.Pow(r, 2) - Math.Pow(x, 2));
            return -y;
        }

        static double segment3(double x, double r)
        {
            double a = 6;
            double y = Math.Sqrt(Math.Pow(r, 2) - Math.Pow(x - a, 2));
            return y;
        }

        static void choise(double x, double r)
        {
            if (x < 0)
            {
                Console.WriteLine("y({0:0.00})={1:0.00}",x,segment1(x));
            }
            else if (x < 3)
            {
                Console.WriteLine("y({0:0.00})={1:0.00}",x,segment2(x,r));
            }
            else if (x < 6)
            {
                Console.WriteLine("y({0:0.00})={1:0.00}",x,segment3(x,r));
            }

        }
        static void Main(string[] args)
        {

            Console.WriteLine("Введите чиловое значение r.");
            double r = double.Parse(Console.ReadLine());
            if (r < 3)
            {
                Console.WriteLine("Указанное значение меньше искомого(R=3),возможны разрывы(не число)");
            }
            if (r < 0)
            {
                Console.WriteLine($"Радиус не может быть меньше нуля. В таком случае r={-r}");
                r = (-1)*r;
            }


            for (double x = -10; x <= 6; x += 0.2)
            {
                choise(x, r);
            }

            Console.WriteLine("Укажите собственное значение x из промежутка [-10;6].\n Для выхода из программы напишите '666'");
            while (true)
            {
                Console.WriteLine("x=");
                double customx = double.Parse(Console.ReadLine());
                if (customx <= 6 && customx >= -10)
                {
                    choise(customx, r);
                }
                else if (customx != 666)
                {
                    Console.WriteLine("Неверное значение параметра x, введите другое");

                }
                else if (customx == 666)
                {
                    break;
                }
            }
        }
    }
}
using System;

namespace DZ2_4
{
    class Program
    {

        static double segment1(double x,double r)
        {
            double a = -6;
            double y = Math.Sqrt(Math.Pow(r, 2) - Math.Pow((x - a), 2));
            return -y;
        }

        static double segment2(double x)
        {
            double k = 1;
            double b = 3;
            double y = k * x + b;
            return y;
        }

        static double segment3(double x, double r)
        {
            double y = Math.Sqrt(Math.Pow(r, 2) - Math.Pow(x, 2));
            return y;
        }

        static double segment4(double x)
        {
            double k = -1;
            double b = 3;
            double y = k * x + b;
            return y;
        }

        static double segment5(double x)
        {
            double k = 0.5;
            double b = -1.5;
            double y = k * x + b;
            return y;
        }



        static void choise(double x, double r)
        {
            if (x < -6)
            {
                Console.WriteLine("y({0:0.00}) = {1:0.00}", x, segment1(x, r));
            }
            else if (x < -3)
            {
                Console.WriteLine("y({0:0.00}) = {1:0.00}", x, segment2(x));
            }
            else if (x < 0)
            {
                Console.WriteLine("y({0:0.00}) = {1:0.00}", x, segment3(x, r));
            }
            else if (x < 3)
            {
                Console.WriteLine("y({0:0.00}) = {1:0.00}", x, segment4(x));
            }
            else if (x < 9)
            {
                Console.WriteLine("y({0:0.00}) = {1:0.00}", x, segment5(x));
            }

        }
        static void Main(string[] args)
        {
            double r = 0;
            string r0 = "";
            while (true)
            {
                Console.WriteLine("Введите чиловое значение r");
                r0 = Console.ReadLine();
                if (double.TryParse(r0, out r))
                {
                    break;
                }
            }
            if (r < 3)
            {
                Console.WriteLine("Указанное значение меньше искомого(R=3),возможны разрывы(в консоли выводится 'не число')");
            }
            if (r < 0)
            {
                Console.WriteLine($"Радиус не может быть отрицательным. В таком случае r={-r}");
                r = (-1) * r;
            }
            if (r < 0 && r > -3)
            {
                Console.WriteLine($"Радиус не может быть отрицательным. В таком случае r={-r}\n Заданное значение меньше искомого(R=3), возможны разрывы(не число)");
                r = (-1) * r;
            }


            for (double x = -9; x <= 9; x += 0.2)
            {
                choise(x, r);
            }

            Console.WriteLine("Укажите собственное значение x из промежутка [-9;9].\n Для выхода из программы напишите 'exit'");
            while (true)
            {
                Console.WriteLine("x=");
                string x2 = Console.ReadLine();
                if (x2 == "exit")
                {
                    break;
                }

                else
                {
                    double x22 = 0;
                    if (double.TryParse(x2, out x22))
                    {
                        if (x22 <= 9 && x22 >= -9)
                        {
                            choise(x22, r);
                        }
                        else
                        {
                            Console.WriteLine("Неверное значение x, выберите значение из промежутка[-9;9]");

                        }
                    }
                }
            }
        }
    }
}
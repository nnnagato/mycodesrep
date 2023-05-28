using System;

namespace lab1
{
    class Program
    {
        static double segment1(double x)
        {
            double y = 1;
            return y;
        }
        static double segment2(double x)
        {
            double k = -0.5;
            double b = -4;
            double y = k * x + b;
            return y;
        }
        static double segment3(double x,double r2)
        {

            double a = -2;
            double y = Math.Sqrt(Math.Pow(r2, 2) - Math.Pow(x - a,2));
            return y;
        }
        static double segment4(double x, double r1)
        {
            double a = 1;
            double y = Math.Sqrt(Math.Pow(r1, 2) - Math.Pow(x - a, 2));
            return - y;
        }
        static double segment5(double x)
        {
            double k = -1;
            double b = 2;
            double y = k * x + b;
            return y;
        }
        static void choise(double x,double r1,double r2)
        {
            if (x <= -6)
            {
                Console.WriteLine($"x: {x:0.00}; y: {segment1(x):0.00}");
            }
            else if (x <= -4)
            {
                Console.WriteLine($"x: {x:0.00}; y: {segment2(x):0.00}");
            }
            else if (x <= 0)
            {
                Console.WriteLine($"x: {x:0.00}; y: {segment3(x, r2):0.00}");
            }
            else if (x <= 2)
            {
                Console.WriteLine($"x: {x:0.00}; y: {segment4(x, r1):0.00}");
            }
            else if (x <= 3)
            {
                Console.WriteLine($"x: {x:0.00}; y: {segment5(x):0.00}");
            }
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Введите R1");
            double r1 = double.Parse(Console.ReadLine());
            if (r1 < 1)
            {
                Console.WriteLine("Указанное значение меньше искомого,возможны разрывы");
            }
            if(r1 < 0)
            {
                Console.WriteLine("А вы уверены что радиус может быть меньше нуля?.. В таком случае R1=1");
                r1 = 1;
            }      

            Console.WriteLine("Введите R2");
            double r2 = double.Parse(Console.ReadLine());
            if (r2 < 2)
            {
                Console.WriteLine("Указанное значение меньше искомого,возможны разрывы");
            }
            if (r2 < 0)
            {
                Console.WriteLine("А вы уверены что радиус может быть меньше нуля?.. В таком случае R=2");
                r2 = 2;
            }
            
            for (double x=-7; x <= 3; x += 0.2)
            {
                choise(x, r1, r2);
            }
            Console.WriteLine("Укажите собственное значение x из промежутка [-7;3].\n Для выхода из программы напишите '123'");
            while(true)
            {
                Console.WriteLine("x=");
                double customx = double.Parse(Console.ReadLine());
                if (customx <= 3 && customx >= -7)
                {
                    choise(customx, r1, r2);
                }
                else if(customx != 123)
                {
                    Console.WriteLine("Неверное значение параметра x, введите другое");

                }
                else if(customx == 123)
                {
                    break;
                }
            }
            
        }
    }
}
using System;
using System.Security.Cryptography;

namespace dz4_15
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            Console.WriteLine("Укажите размерность маccива N");
            int n = 0;
            while (true)
            {
                
                if (int.TryParse(Console.ReadLine(), out n))//считывание размерности массива с проверкой
                {
                    if (n > 0)
                    {
                        break;
                    }
                    else Console.WriteLine("Вывод должен быть целым, положительным числом");
                }
                else Console.WriteLine("Ввод должен быть целым числом");
            }
            double[] a = new double[n];
            double c = 0;
            Console.WriteLine("Укажите С");
            while(true)
            {
                if (double.TryParse(Console.ReadLine(), out c))
                {
                    break;
                }
                else Console.WriteLine("Ввод должен быть вещественным числом");
            }

            for(int i=0; i<n; i++)
            {
                a[i] = rand.Next(0, 100) - 50 - rand.NextDouble();
            }

            int maxindex = 0;
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(a[i]) > Math.Abs(a[maxindex]))
                    maxindex = i;
                if(a[i] > c)
                    count++;
            }
            Console.WriteLine($"Произведение элементов больше С: {count}");
            double proizved = 1;
            for(int i=maxindex;i<n; i++)
            {
                proizved *= a[i];
            }

            Console.WriteLine("Исходный массив:");
            for(int i = 0; i<n; i++)
            {
                Console.Write($"{a[i]:0.00}  ");
            }

            Console.WriteLine("\nПреобразованный массив: ");
            for(int j=0; j<2; j++)
            {
                for(int i=0; i<n; i++)
                {
                    if(j==0 && a[i] < 0)
                    {
                        Console.Write($"{a[i]:0.00}  ");
                    }
                    if(j==1 && a[i] > -0.1)
                    {
                        Console.Write($"{a[i]:0.00}  ");
                    }
                }
            }

            

        }
    }
}
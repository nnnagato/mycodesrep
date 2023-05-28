using System;
using System.Security.Cryptography;

namespace hw4_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            Console.WriteLine("Укажите размерность матрицы N");
            int n = 0;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out n))//считывание размерности массива с проверкой
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ввод должен быть целым числом");
                }
            }
            int[,] arr = new int[n,n];
            int[] s = new int[2 * n];

            int i, j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    arr[i,j] = rnd.Next(0, 100) - 10;//заполнение массива int от -10 до 90
                    Console.Write($"  {arr[i,j]}  ");//вывод массива

                }
                Console.WriteLine();
            }
            int pr=1;
            Boolean check=true;
            for(i=0; i < n; i++)
            {
                pr = 1;
                check = true;
                for(j=0; j < n; j++)
                {
                    if(arr[i,j] > 0)
                    {
                        pr = pr * arr[i, j];
                    }
                    else
                    {
                        check = false;
                    }
                }
                if (check == true)
                {
                    Console.WriteLine($"Строка {i}, произведение: {pr}");
                }
            }

            int[] sum = new int[2*n];
            for(int k=0; k < n; k++)
            {
                j = k;
                while(j<n)
                {
                    i = 0;
                    sum[k] = sum[k] + arr[i, j];
                    j++;
                    i++;
                }                                                                           //
            }
            for(int k = 0; k < n-1; k++)                                                    // НУЖНА ДОРАБОТКА - НЕ ПАШЕТ
            {                                                                               //
                i = k + 1;
                while(i<n)
                {
                    j = 0;
                    sum[k+n] = sum[k+n] + arr[i, j];
                    i++;
                    j++;
                }
            }
            Console.WriteLine($"\n\nМаксимальная сумма: {s.Max()}");

            
        }
    }
}
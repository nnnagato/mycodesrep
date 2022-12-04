using System;
using System.Security.Cryptography;

namespace dz4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            Console.WriteLine("Укажите размерность матрицы N1");
            int n1 = 0;
            while (true)
            {

                if (int.TryParse(Console.ReadLine(), out n1))//считывание размерности массива с проверкой
                {
                    if (n1 > 0)
                    {
                        break;
                    }
                    else Console.WriteLine("Вывод должен быть целым, положительным числом");
                }
                else Console.WriteLine("Ввод должен быть целым числом");
            }
            Console.WriteLine("Укажите размерность матрицы N2");
            int n2 = 0;
            while (true)
            {

                if (int.TryParse(Console.ReadLine(), out n2))//считывание размерности массива с проверкой
                {
                    if (n2 > 0)
                    {
                        break;
                    }
                    else Console.WriteLine("Вывод должен быть целым, положительным числом");
                }
                else Console.WriteLine("Ввод должен быть целым числом");
            }
            int[,] array = new int[n1,n2];
            Console.Write("\n\nИсходный массив: \n");
            for(int i = 0; i < n1; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    array[i,j] = rand.Next(0, 200) - 100;
                    Console.Write($"{array[i,j]}  ");
                }
                Console.WriteLine();
            }

            int k = 0;
            bool nal = false;
            for(int j=0; j<n2; j++)
            {
                nal = false;
                for (int i = 0; i < n1; i++)
                {
                    if (array[i, j] == 0)
                    {
                        nal = true;

                    }
                }
                if(nal==false)
                {
                    k++;
                }
            }
            
            
            if(k==0)
            {
                Console.WriteLine("Нет ни одного столбца удовлетворяющего условию");

            }
            else
            {
                Console.WriteLine($"В матрице {k} столбцов удовлетворяющих условию");
            }


            int[] sums = new int[n1];
            int[] strs = new int[n1];

            for(int i =0; i<n1; i++)
            {
                strs[i] = i;
                for(int j=0; j<n2; j++)
                {
                    if (array[i, j] > 0 && array[i, j] % 2 == 0)
                    sums[i] += array[i, j];
                }
            }


            int temp;
            for(int i=0; i<n1; i++)
            {
                for(int j= i + 1; j < n1; j++)
                {
                    if (sums[i] > sums[j])
                    {
                        temp = sums[j];
                        sums[j] = sums[i];
                        sums[i] = temp;
                        temp = strs[j];
                        strs[j] = strs[i];
                        strs[i] = temp;
                    }
                }
            }

            Console.WriteLine("отсортированный массив: ");
            for(int i = 0; i < n1; i++)
            {
                for(int j = 0; j<n2; j++)
                {
                    Console.Write($"{array[strs[i], j]}  ");
                }
                Console.WriteLine(/*$"  {sums[i]}  "*/);
            }

        }
    }
}
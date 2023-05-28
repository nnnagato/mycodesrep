using System;
using System.Security.Cryptography;

namespace dz4_2
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
            double[] array = new double[n];

            for(int i=0; i<array.Length; i++)
            {
                array[i] = rand.Next(0, 200) - 100 - rand.NextDouble();
            }

            int indmax = 0;
            int indmin = 0;
            double summa = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] > 0)
                    summa += array[i];
                if (Math.Abs(array[i]) > Math.Abs(array[indmax]))
                    indmax = i;
                if (Math.Abs(array[i]) < Math.Abs(array[indmin]))
                    indmin = i;

            }
            Console.WriteLine($"Сумма положительных элементов : {summa:0.00}");


            double pr = 1;
            
            if (indmax > indmin)
            {
                for (int i = indmin + 1; i < indmax; i++)
                {
                    pr *= array[i];
                }
                Console.WriteLine($"Произведение элементов между {indmin} и {indmax} равно: {pr:0.00}");
            }
            else
            {
                for(int i = indmax + 1; i < indmin; i++)
                {
                    pr *= array[i];
                }
                Console.WriteLine($"Произведение элементов между {indmax} и {indmin} равно: {pr:0.00}");
            }

            Console.WriteLine("Исходный массив:\n");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{array[i]:0.00}  ");
            }

            Console.WriteLine("\nПреобразованный массив: ");
            double temp;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[i])
                    {
                        temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                    }
                }
            }
            Console.WriteLine();
            for(int i = 0; i<n; i++)
            {
                Console.Write($"{array[i]:0.00}  ");
            }

        }
    }
}
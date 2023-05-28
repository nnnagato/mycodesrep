using System;
using System.Security.Cryptography;

namespace DZ4_15
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            Console.WriteLine("Укажите размерность массива N");
            int n = 0;
            while (true)
            {
                n = int.Parse(console.ReadLine());
                if (int.TryParse(Console.ReadLine(), out n && (n>0)))//считывание размерности массива с проверкой
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ввод должен быть целым положительным числом");
                }
            }
            
            double c = 0;
            Console.WriteLine("Укажите С")
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out c))//считывание размерности массива с проверкой
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ввод должен быть вещественным числом");
                }
            }

            int i;
            double[] arr= new double[n];

            for(i=0; i < arr.Length; i++)
            {
                arr[i]=rnd.Next(0,200)-100-rnd.NextDouble();//заполнение массива double от -100 до 100
                Console.WriteLine($"{i}: {arr[i]:0.00}");//вывод массива
            }


            double sum=0;
            for(i=1; i<arr.Length;)
            {
                sum = sum + arr[i];
                i = i + 2;
            }
            Console.WriteLine($"\n\n Сумма нечётных элементов: \n {sum:0.00}");


            int ind1 = 0;
            for(i = 0; i < arr.Length; i++)//поиск первого отр. элемента
            {
                if (arr[i]<0)
                {
                    ind1= i;
                    break;
                }
            }
            int ind2 = 0;
            for(i=arr.Length-1;i>=0;i--)//поиск последнего отр. элемента
            {
                if(arr[i]<0)
                {
                    ind2 = i;
                    break;
                }
            }


            double sum2=0;
            for(i=ind1+1;i<ind2+1;i++)
            {
                sum2 = arr[i] + sum2;
            }

            Console.WriteLine($"\n\n Сумма элементов между {ind1} и {ind2} элементами: \n {sum2:0.00}");
        }
    }
}
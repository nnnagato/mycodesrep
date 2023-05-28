using System;
using System.Security.Cryptography;

namespace dz4_15
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            Console.WriteLine("Укажите размерность матрицы N1(количество строк)");
            int n1 = 0;
            int n2 = 0;
            while (true)
            {

                if (int.TryParse(Console.ReadLine(), out n1))
                {
                    if (n1 > 0)
                    {
                        break;
                    }
                    else Console.WriteLine("Вывод должен быть целым, положительным числом");
                }
                else Console.WriteLine("Ввод должен быть целым числом");
            }
            Console.WriteLine("Укажите размерность матрицы N2(количество столбцов)");
            while (true)
            {

                if (int.TryParse(Console.ReadLine(), out n2))
                {
                    if (n2 > 0)
                    {
                        break;
                    }
                    else Console.WriteLine("Вывод должен быть целым, положительным числом");
                }
                else Console.WriteLine("Ввод должен быть целым числом");
            }
            int[,] b = new int[n1,n2];

            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    Console.Write($"{b[i,j] = rand.Next(0, 100) - 50} ");
                }
                Console.WriteLine();
            }


            int count=0;
            for(int j=0; j<n2; j++)
            {
                
                    for(int i=0; i<n1;i++)
                    {
                        if (b[i,j]==0)
                        {
                            count++;
                            break;
                        }
                    }
            }
            if(count==0)
            {
                Console.WriteLine("Столбов с нулевыми элементами нет");
            }
            else Console.WriteLine($"В матрице {count} столбцов с нулевыми элементами");

            int[] str = new int[n1];
            int[] sum = new int[n1];
            
            
            for(int i=0;i<n1;i++)
            {
                str[i] = i;
                for(int j=0; j<n2; j++)
                {
                    if ((b[i,j]<0) && (b[i,j] % 2 == 0))
                    {
                        sum[i] += b[i,j];
                    }
                }
            }

            int temp;
            for(int i=0;i<n1;i++)
            {
                for(int j = i+1; j < n1;j++)
                {
                    if (sum[i] > sum[j])
                    {
                        temp = sum[i];
                        sum[i] = sum[j];
                        sum[j] = temp;
                        temp = str[i];
                        str[i] = str[j];
                        str[j] = temp;
                    }
                }
            }

            Console.WriteLine("преобразованная матрица");
            for(int i=0; i<n1; i++)
            {
                for( int j=0; j<n2; j++)
                {
                    Console.Write($"{b[str[i],j]}  ");
                }
                Console.WriteLine();
            }
            //for(int i=0; i<n1; i++)
            //{
            //    Console.WriteLine($"{str[i]}   {sum[i]}");
            //}

        }
    }
}
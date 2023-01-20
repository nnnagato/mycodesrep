using System;
namespace hw4_9
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random(DateTime.Now.Second);
            int n = 10;
            double[] nums = new double[n];
            Console.WriteLine();
            int max1 = -1;
            int max2 = -1;
            int globalmax = -10;
            for(int i = 0; i < n; i++)
            {
                nums[i] = rand.Next(0, 21) - rand.NextDouble()-10;
                Console.WriteLine(string.Format("{0:0.00}   ", nums[i]));
                if(max1 == -1 && nums[i]>0)
                {
                    max1 = i;
                }
                if(max2 == -1 && max1 != -1 && nums[i]>0)
                {
                    max2 = i;
                }
                if (Math.Abs(nums[i]) > Math.Abs(nums[globalmax])) globalmax = i;
            }
            Console.WriteLine($"\n\nМаксимальный по модулю элемент: {nums[globalmax]}");
            double sum=0;
            if (max1 == -1 || max2 == -1)
            {
                Console.WriteLine("В массиве нет двух положительных элементов");
            }
            else
            {
                for (int i = Math.Min(max1, max2); i < Math.Max(max1, max2); i++)
                {
                    sum += nums[i];
                }
                Console.WriteLine($"Сумма между первым и вторым положительными элементами: {sum}");
            }
        }
    }
}
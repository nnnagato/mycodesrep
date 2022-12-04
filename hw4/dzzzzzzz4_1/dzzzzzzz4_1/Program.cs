

using System.Runtime.InteropServices;

namespace dzzzzzzz4_1
{
    class program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Введите N");
            while(true)
            {
                if (int.TryParse(Console.ReadLine(), out n))
                {
                    if (n > 0) break;
                    else Console.WriteLine("Введите положительное N");
                }
                else Console.WriteLine("Введите N числом");
            }
            double[] array = new double[n];
            Random rand = new Random();
            for(int i=0; i<n; i++)
            {
                Console.Write($"{array[i] = rand.Next(0,200)-100+rand.NextDouble():0.00}  ");
            }
            int indmin = 0;
            int indmax = 0;
            double min=100;
            double max=-100;
            double sum = 0;
            for(int i=0; i<n; i++)
            {
                if (array[i] < 0) sum += array[i];
                if (array[i] > max)
                {
                    max = array[i];
                    indmax = i;
                }
                if (array[i] < min)
                {
                    min = array[i];
                    indmax = i;
                }
            }
            Console.WriteLine($"\n\nСумма отрицательных элементов: {sum:0.00}");
            double pr = 1;
            if (indmin < indmax)
            {
                for (int i =indmin+1; i < indmax; i++)
                {
                    pr *= array[i];
                }
            }
            else
            {
                for (int i = indmax + 1; i < indmin; i++)
                {
                    pr *= array[i];
                }
            }
            Console.WriteLine($"\n\nПроизведение элементов между максимумом и минимумом: {pr:0.00}");
            double temp;
            for(int i=0; i<n; i++)
            {
                for(int j=i+1; j<n; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                    }
                }
            }
            Console.Write("\n\nИзменённый массив: ");
            for (int i = 0; i < n; i++) Console.Write($"{array[i]:0.00}  ");
        }
    }
}
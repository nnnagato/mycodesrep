namespace dzzzzzzz4_1
{
    class program
    {
        static void Main(string[] args)
        {
            int n1;
            Console.WriteLine("Введите N1");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out n1))
                {
                    if (n1 > 0) break;
                    else Console.WriteLine("Введите положительное N");
                }
                else Console.WriteLine("Введите N числом");
            }
            int n2;
            Console.WriteLine("Введите N2");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out n2))
                {
                    if (n2 > 0) break;
                    else Console.WriteLine("Введите положительное N");
                }
                else Console.WriteLine("Введите N числом");
            }
            Random rnd = new Random();
            int[,] array = new int[n1, n2];
            for(int i=0; i<n1; i++)
            {
                for(int j=0; j<n2; j++)
                {
                    Console.Write($"{array[i,j] = rnd.Next(0,200)-100}  ");
                }
                Console.WriteLine();
            }
            int count=0;
            bool nal = false;
            for(int i =0; i<n1; i++)
            {
                for(int j=0; j<n2; j++)
                {
                    if (array[i, j] == 0) break;
                    else nal=true;
                }
                if(nal==true)
                {
                    count++;
                    nal = false;
                }
            }
            Console.WriteLine($"Количество строк без нулевых элементов: {count}");
            int max = -100;
            for(int i1=0; i1<n1;i1++)
            {
                for(int j1=0;j1<n2;j1++)
                {
                    for(int i2=0; i2<n1;i2++)
                    {
                        for(int j2=0; j2<n2; j2++)
                        {
                            if ((array[i1,j1] == array[i2,j2]) && (i1!=i2) && (j1!=j2))
                            {
                                if (array[i1,j1] > max)
                                {
                                    max = array[i1,j1];
                                }
                            }
                        }
                    }
                }
            }
            if(max==-100)
            {
                Console.WriteLine("нет элементов которые встречаются более 1 раза");
            }
            else
            {
                Console.WriteLine($"максимальный элемент, встречающийся более 1 раза: {max}");
            }
        }
    }
}
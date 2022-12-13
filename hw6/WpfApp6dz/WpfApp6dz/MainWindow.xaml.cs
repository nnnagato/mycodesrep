using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp6dz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public abstract class triangle //базовый класс для треугольника
    {
        public int a;
        public int b;
        public int alpha;
        public abstract double square();
        public abstract double perimetr();
        public int a_side { get { return a; } set { a = value; } }
        public int b_side { get { return b; } set { b = value; } }
        public int alph { get { return alpha; } set { alpha = value; } }

    }

    public class twoSides : triangle//класс для равнобедренного треугольника
    {
        //public int a;
        //public int b;
        //public int alpha;
        //public override int a_side { get { return a; } set { a = value; } }
        //public override int b_side { get { return b; } set { b = value; } }
        //public override int alph { get { return alpha; } set { alpha = value; } }
        public twoSides(int a1, int b1, int alpha1)
        {
            a = a1;
            b = b1;
            alpha = alpha1;
        }
        public override double perimetr()
        {
            double sum = a + a + b;
            return sum;
        }
        public override double square()
        {
            double h = Math.Sqrt(Math.Pow(a, 2) - Math.Pow(b, 2) / 4);
            double squar = (b * h) / 2;
            return squar;
        }
    }

    public class threeSides : triangle//класс для равностороннего треугольника
    {
        //public int a;
        //public int b;
        //public int alpha;
        //public override int a_side { get { return a; } set { a = value; } }
        //public override int b_side { get { return b; } set { b = value; } }
        //public override int alph { get { return alpha; } set { alpha = value; } }
        public override double perimetr()
        {
            double sum = 3 * a;
            return sum;
        }
        public override double square()
        {
            double squar = (Math.Sqrt(3) * Math.Pow(a, 2)) / 4;
            return squar;
        }
        public threeSides(int a1)
        {
            a = a1;
        }
    }

    public class rightAlpha : triangle//класс для прямоугольного треугольника
    {
        //public int a;
        //public int b;
        //public int alpha;
        //public override int a_side { get { return a; } set { a = value; } }
        //public override int b_side { get { return b; } set { b = value; } }
        //public override int alph { get { return alpha; } set { alpha = value; } }
        public override double perimetr()
        {
            double ugol = alpha * Math.PI / 180;
            double sum = a + b + Math.Sin(ugol) * b;
            return sum;
        }
        public override double square()
        {
            double ugol = alpha * Math.PI / 180;
            double c = Math.Sin(ugol) * b;
            double squar = 0.5 * c * a;
            return squar;
        }
        public rightAlpha(int a1, int b1, int alpha1)
        {
            a = a1;
            b = b1;
            alpha = alpha1;
        }
    }

    public partial class MainWindow : Window
    {
        public void update()
        {
            Label[] list = new Label[7];
            list[0] = numLabel; list[1] = aLabel; list[2] = bLabel; list[3] = alphaLabel; list[4] = perimetrLabel; list[5] = squareLabel; list[6] = typeLabel;
            for (int i = 0; i < 7; i++) list[i].Content = string.Format("");
            for (int i = 0; i < col2; i++)
            {
                list[0].Content += string.Format("\n{0}", (i + 1));
                list[1].Content += string.Format("\n{0}", twos[i].a_side);
                list[2].Content += string.Format("\n{0}", twos[i].b_side);
                list[3].Content += string.Format("\n{0}", twos[i].alph);
                list[4].Content += string.Format("\n{0}", twos[i].perimetr());
                list[5].Content += string.Format("\n{0:0.00}", twos[i].square());
                list[6].Content += string.Format("\nРавнобедренный");
            }
            for (int i = 0; i < col3; i++)
            {
                list[0].Content += string.Format("\n{0}", i + 1 + col2);
                list[1].Content += string.Format("\n{0}", tres[i].a_side);
                list[2].Content += string.Format("\n---");
                list[3].Content += string.Format("\n60");
                list[4].Content += string.Format("\n{0}", tres[i].perimetr());
                list[5].Content += string.Format("\n{0:.00}", tres[i].square());
                list[6].Content += string.Format("\nРавносторонний");
            }
            for (int i = 0; i < col90; i++)
            {
                list[0].Content += string.Format("\n{0}", i + 1 + col2 + col3);
                list[1].Content += string.Format("\n{0}", rights[i].a_side);
                list[2].Content += string.Format("\n{0}", rights[i].b_side);
                list[3].Content += string.Format("\n{0}", rights[i].alph);
                list[4].Content += string.Format("\n{0}", rights[i].perimetr());
                list[5].Content += string.Format("\n{0:0.00}", rights[i].square());
                list[6].Content += string.Format("\nПрямоугольный");
            }
        }

        static int col2 = 3;
        static int col3 = 3;
        static int col90 = 3;
        twoSides[] twos = new twoSides[col2];
        threeSides[] tres = new threeSides[col3];
        rightAlpha[] rights = new rightAlpha[col90];
        public MainWindow()
        {
            InitializeComponent();
            //twoSides[] twos = new twoSides[col2];
            //threeSides[] tres = new threeSides[col3];
            //rightAlpha[] rights = new rightAlpha[col90];
            for (int i = 0; i < 3; i++)
            {
                twos[i] = new twoSides(10, 5, 30);
                tres[i] = new threeSides(20);
                rights[i] = new rightAlpha(5, 15, 30);
            }
            update();
        }

        private void AddingButton_Click(object sender, RoutedEventArgs e)
        {
            addingWindow window = new addingWindow();
            window.Owner = this;
            window.ShowDialog();
            //MessageBox.Show(string.Format("{0}",window.DialogResult));
            if (window.DialogResult == true)
            {
                switch (window.choseBox.SelectedIndex)
                { 
                    case 0:
                        col2++;
                        Array.Resize(ref twos, col2);
                        twos[col2 - 1] = new twoSides(window.a, window.b, window.alpha);
                        if(twos[col2 - 1].a_side < 0 || twos[col2 - 1].b_side < 0 || twos[col2 - 1].alph < 0)
                        {
                            MessageBox.Show("Все введённые отрицательные значения заменены на положительные");
                            twos[col2 - 1].a_side = Math.Abs(twos[col2 - 1].a_side);
                            twos[col2 - 1].b_side = Math.Abs(twos[col2 - 1].b_side);
                            twos[col2 - 1].alph = Math.Abs(twos[col2 - 1].alph);
                        }
                        break;
                    case 1:
                        col3++;
                        Array.Resize(ref tres, col3);
                        tres[col3 - 1] = new threeSides(window.a);
                        if (tres[col3 - 1].a_side < 0)
                        {
                            MessageBox.Show("Все введённые отрицательные значения заменены на положительные");
                            tres[col3 - 1].a_side = Math.Abs(tres[col3 - 1].a_side);
                        }
                        break;
                    case 2:
                        col90++;
                        Array.Resize(ref rights, col90);
                        rights[col90 - 1] = new rightAlpha(window.a, window.b, window.alpha);
                        if (rights[col90 - 1].a_side < 0 || rights[col90 - 1].b_side < 0 || rights[col90 - 1].alph < 0)
                        {
                            MessageBox.Show("Все введённые отрицательные значения заменены на положительные");
                            rights[col90 - 1].a_side = Math.Abs(rights[col90 - 1].a_side);
                            rights[col90 - 1].b_side = Math.Abs(rights[col90 - 1].b_side);
                            rights[col90 - 1].alph = Math.Abs(rights[col90 - 1].alph);
                        }
                        break;
                }
                update();
            }

        }

        private void RemovingButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("");
            int remnum;
            try
            {
                remnum = int.Parse(numberBox.Text);
                if (remnum < 1 || remnum > col90 + col2 + col3) throw new System.FormatException();
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Введите номер записи целым числом в пределах количества записей");
                return;
            }
            if(remnum < col2+1)
            {
                for(int i = remnum-1; i<col2-1; i++)
                {
                    twos[i] = twos[i + 1];
                }
                col2--;
                Array.Resize(ref twos, col2);
            }
            if(remnum < col3+col2+1 && remnum > col2)
            {
                for (int i = remnum - 1 - col2; i < col3 - 1; i++)
                {
                    tres[i] = tres[i + 1];
                }
                col3--;
                Array.Resize(ref tres, col3);
            }
            if (remnum > col3 + col2 + 1 && remnum < col2+col3+col90)
            {
                for (int i = remnum - col2-col3 - 1; i < col90 - 1; i++)
                {
                    rights[i] = rights[i + 1];
                }
                col90--;
                Array.Resize(ref rights, col90);
            }
            update();
        }
    }
}

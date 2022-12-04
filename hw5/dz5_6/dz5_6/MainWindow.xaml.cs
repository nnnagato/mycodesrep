using System;
using System.Collections.Generic;
using System.Linq;
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

namespace dz5_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public class circle
    {
        static public int rad;
        static public int x;
        static public int y;

        public circle(int r, int X, int Y)
        {
            rad = r;
            x = X;
            y= Y;
        }
        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public int R
        {
            get { return rad; }
        }
    }
    

    public partial class MainWindow : Window
    {
        public int get_value(int ind)
        {
            int rezult;
            TextBox box = LengthBox;
            switch(ind)
            {
                case 1:
                    {
                        box = radiusbox;
                        break;
                    }
                case 2:
                    {
                        box = xbox;
                        break;
                    }
                case 3:
                    {
                        box = ybox;
                        break;
                    }
            }
            if(int.TryParse(box.Text, out rezult))
            {
                if(rezult<0)
                {
                    MessageBox.Show("Укажите положительные значения во всех строках");
                    throw new Exception("Некорректное значение");
                }
            }
            else
            {
                MessageBox.Show("Укажите во всех строках данные числами");
                throw new Exception("Некорректное значение");
            }
            return rezult;
        }
        public double Square()
        {
            double result = 0.0;
            result = Math.PI * circle.rad * circle.rad;
            return result;
        }
        public double Length()
        {
            double result = 0.0;
            result = Math.PI * circle.rad * 2;
            return result;
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        public bool Popad()
        {
            return ((Math.Pow(circle.x, 2) + Math.Pow(circle.y, 2)) <= Math.Pow(circle.rad, 2));
        }

        private void check_Click(object sender, RoutedEventArgs e)//check engine хехехе
        {
            circle ob = new circle(get_value(1), get_value(2), get_value(3));
            LengthBox.Text = String.Format("{0}", Length());
            SquareBox.Text = String.Format("{0}", Square());
            if (Popad() == true)
            {
                includelabel1.Visibility = Visibility.Visible;
                includelabel2.Visibility = Visibility.Hidden;
            }
            else
            {
                includelabel1.Visibility = Visibility.Hidden;
                includelabel2.Visibility = Visibility.Visible;
            }
        }
    }
}

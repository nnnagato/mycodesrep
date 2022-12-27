using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace lab2_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int a;
        int b;
        int c;

        private double descriminant(int a, int b, int c)
        {
            double d = Math.Pow(b, 2) - 4 * a * c;
            return d;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int a = int.Parse(abox.Text);
            int b = int.Parse(bbox.Text);
            int c = int.Parse(cbox.Text);

            double d = descriminant(a,b, c);
            if(d > 0)
            {
                double x1 = (-b + Math.Sqrt(d)) / (2 * a);
                double x2 = (-b - Math.Sqrt(d)) / (2 * a);
                maintence.Visibility = Visibility.Visible;
                maintence.Content = string.Format("Уравнение вида ({0})x^2+({1})x+({2}) = 0  имеет 2 корня:", a, b, c);
                x1label.Visibility = Visibility.Visible;
                x2label.Visibility = Visibility.Visible;
                box1.Visibility = Visibility.Visible;
                box1.Text = string.Format($"{x1}");
                box2.Visibility = Visibility.Visible;
                box2.Text = string.Format($"{x2}");
            }
            else if(d == 0)
            {
                double x = (-b)/(2* a);
                maintence.Visibility = Visibility.Visible;
                maintence.Content = string.Format("Уравнение вида ({0})x^2+({1})x+({2}) = 0  имеет 1 корень:", a, b, c);
                x1label.Visibility = Visibility.Visible;
                x2label.Visibility = Visibility.Hidden;
                box1.Visibility = Visibility.Visible;
                box1.Text = string.Format($"{x}");
                box2.Visibility = Visibility.Hidden;
            }
            else if (d<0)
            {
                maintence.Visibility = Visibility.Visible;
                maintence.Content = string.Format("Уравнение вида ({0})x^2+({1})x+({2}) = 0  не имеет корней", a, b, c);
                x1label.Visibility = Visibility.Hidden;
                x2label.Visibility = Visibility.Hidden;
                box1.Visibility = Visibility.Hidden;
                box2.Visibility = Visibility.Hidden;
            }

        }
    }
}

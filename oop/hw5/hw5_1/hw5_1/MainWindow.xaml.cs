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

namespace hw5_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public class Counter
    {
        int highBorder;
        int lowBorder;
        int current;

        public Counter(int highCount = 10, int lowCount = 0)
        {
            highBorder = highCount;
            lowBorder = lowCount;
            current = 5;
        }

        public int Current
        {
            get { return current; }
            set { current = value; }
        }
        public int HighBorder
        {
            set { highBorder = value; }
            get { return highBorder; }
        }
        public int LowBorder
        {
            set { lowBorder = value; }
            get { return lowBorder; }
        }
        public int current_upscale()
        {
            if(current < HighBorder)
            {
                current++;
                return current;
                
            }
            else
            {
                MessageBox.Show("Счётчик достиг верхней границы");
                return current;
            }

        }
        public int current_downscale()
        {
            if (current > LowBorder)
            {
                current--;
                return current;

            }
            else
            {
                MessageBox.Show("Счётчик достиг нижней границы");
                return current;
            }
        }

    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LowBorder.Text = counter.LowBorder.ToString();
            HighBorder.Text = counter.HighBorder.ToString();
            CurrentLabel.Content = counter.Current.ToString();
        }

        Counter counter = new Counter();
        private void LowBorder_TextChanged(object sender, TextChangedEventArgs e)
        {
            int buf;
            try
            {
                int.TryParse(LowBorder.Text, out buf);
            }
            catch(System.FormatException)
            {
                MessageBox.Show("Введите границу целым числом");
                LowBorder.Text = counter.LowBorder.ToString();
                return;
            }
            
            
            if(buf < counter.HighBorder && buf < counter.Current)
            {
                counter.LowBorder = buf;
            }
            else
            {
                MessageBox.Show("Укажите значение меньше текущего и меньше верхней границы");
                LowBorder.Text = counter.LowBorder.ToString();
                return;
            }
        }

        private void HighBorder_TextChanged(object sender, TextChangedEventArgs e)
        {
            int buf;
            try
            {
                int.TryParse(HighBorder.Text, out buf);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Введите границу целым числом");
                HighBorder.Text = counter.HighBorder.ToString();
                return;
            }


            if (buf > counter.LowBorder && buf > counter.Current)
            {
                counter.HighBorder = buf;
            }
            else
            {
                MessageBox.Show("Укажите значение больше текущего и больше нижней границы");
                HighBorder.Text = counter.HighBorder.ToString();
                return;
            }
        }

        private void downscaleButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentLabel.Content = counter.current_downscale();
        }

        private void upscaleButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentLabel.Content = counter.current_upscale();
        }
    }
}

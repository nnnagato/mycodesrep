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
using System.Windows.Shapes;

namespace hw6_1
{
    /// <summary>
    /// Логика взаимодействия для Adding_Window.xaml
    /// </summary>
    public partial class Adding_Window : Window
    {
        public Adding_Window()
        {
            InitializeComponent();
        }

        private void Selection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(Selection.SelectedIndex)
            {
                case 2:
                    h_box.Visibility = Visibility.Visible;
                    h_label.Visibility = Visibility.Visible;
                    break;
                default:
                    h_box.Visibility = Visibility.Collapsed;
                    h_label.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void deny_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        public int a;
        public int h;
        private void apply_Click(object sender, RoutedEventArgs e)
        {
            switch(Selection.SelectedIndex)
            {
                case 2:
                    try
                    {
                        int.TryParse(a_box.Text, out a);
                        int.TryParse(h_box.Text, out h);

                    }
                    catch(System.FormatException)
                    {
                        MessageBox.Show("Укажите величины при помощи чисел");
                        return;
                    }
                    break;
                default:
                    try
                    {
                        int.TryParse(a_box.Text, out a);

                    }
                    catch (System.FormatException)
                    {
                        MessageBox.Show("Укажите величины при помощи чисел");
                        return;
                    }
                    break;
            }
            this.DialogResult = true;

        }
    }
}

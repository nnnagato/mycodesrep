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

namespace WpfApp6dz
{
    /// <summary>
    /// Логика взаимодействия для addingWindow.xaml
    /// </summary>
    public partial class addingWindow : Window
    {
        public addingWindow()
        {
            InitializeComponent();
        }

        private void denyButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (choseBox.SelectedIndex)
            {
                case 0:
                    aLabel.Content = string.Format("Ребро");
                    bLabel.Content = string.Format("Основание");
                    alphaLabel.Content = string.Format("Угол альфа");
                    bLabel.Visibility = Visibility.Visible;
                    bBox.Visibility = Visibility.Visible;
                    alphaLabel.Visibility = Visibility.Visible;
                    alphaBox.Visibility = Visibility.Visible;
                    break;
                case 1:
                    aLabel.Content = string.Format("Сторона а");
                    bLabel.Visibility = Visibility.Collapsed;
                    bBox.Visibility = Visibility.Collapsed;
                    alphaLabel.Visibility = Visibility.Collapsed;
                    alphaBox.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    aLabel.Content = string.Format("Катет а");
                    bLabel.Content = string.Format("Гипотенуза б");
                    alphaLabel.Content = string.Format("Угол альфа");
                    bLabel.Visibility = Visibility.Visible;
                    bBox.Visibility = Visibility.Visible;
                    alphaLabel.Visibility = Visibility.Visible;
                    alphaBox.Visibility = Visibility.Visible;
                    break;
            }
        }
        public int a;
        public int b;
        public int alpha;

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            if (choseBox.SelectedIndex == 0 || choseBox.SelectedIndex == 2)
            {
                try
                {
                    a = int.Parse(aBox.Text);
                    b = int.Parse(bBox.Text);
                    alpha = int.Parse(alphaBox.Text);
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("все данные должны быть в виде целых чисел");
                    return;
                }
                //finally
                //{
                //    DialogResult = true;

                //}
            }
            else
            {
                try 
                {
                    a = int.Parse(aBox.Text);
                }
                catch(System.FormatException)
                {
                    MessageBox.Show("Число а должно быть целым");
                    return;
                }
            }
            this.DialogResult = true;

        }
    }
}

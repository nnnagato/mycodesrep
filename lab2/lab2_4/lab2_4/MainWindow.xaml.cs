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

namespace lab2_4
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

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            double start;
            if(double.TryParse(startcount.Text, out start) == false)
            {
                MessageBox.Show("Укажите температуру числом, целым или дробным");
                return;
            }
            double buf;
            switch(startscale.SelectedIndex)
            {
                case 0:
                    buf = start;
                    break;
                case 1:
                    buf = start-17.2;
                    break;
                case 2:
                    buf = start - 273;
                    break;
                default:
                    MessageBox.Show("Выберите начальную величину");
                    return;

            }
            double fin;
            switch(finishscale.SelectedIndex)
            {
                case 0:
                    fin = start;
                    break;
                case 1:
                    fin = buf + 17.2;
                    break;
                case 2:
                    fin = buf + 273;
                    break;
                default:
                    MessageBox.Show("Укажитк конечную величину");
                    return;

            }
            finishcount.Text = String.Format("{0}", fin);
            Reslabel.Content = String.Format("{0} {1} в {2} равно",start,startscale.Text, finishscale.Text);
        }
    }
}

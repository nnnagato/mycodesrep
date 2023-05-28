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

namespace dz5_2
{
    /// <summary>
    /// Логика взаимодействия для changeWindow.xaml
    /// </summary>
    public partial class changeWindow : Window
    {
        public changeWindow()
        {
            InitializeComponent();
        }
        public int number;
        public string country;
        public string region;
        public string city;
        public string street;
        public int house;
        public int index;
        public bool error = false;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
                if (int.TryParse(numberBox.Text, out number))
                {
                    if (number > 0)
                    {
                    numbererrorLabel.Visibility = Visibility.Hidden;
                    error = false;
                    }
                }
                else
                {
                    numbererrorLabel.Visibility = Visibility.Visible;
                    error = true;
                }
                country = countryBox.Text;
                region = regionBox.Text;
                city = cityBox.Text;
                street = streetBox.Text;
                if (int.TryParse(houseBox.Text, out house))
                {
                if (house > 0)
                {
                    errorhouseLabel.Visibility = Visibility.Hidden;
                    error = false;
                }
                }
                else
                {
                    errorhouseLabel.Visibility = Visibility.Visible;
                    error = true;
                }
            if (indexBox.Text.Length==6 && int.TryParse(indexBox.Text, out index))
            {
                if (index > 0)
                {
                    errorindexLabel.Visibility = Visibility.Hidden;
                    error = false;
                }
            }
            else
            {
                errorindexLabel.Visibility = Visibility.Visible;
                error = true;
            }
            if(error==false)
            {
                
                this.Close();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }
        
    }
}

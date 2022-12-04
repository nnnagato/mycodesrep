using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace dz5_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class pochta
    {
        string country;
        string region;
        string city;
        string street;
        int house;
        int index;

        public pochta(string country, string region, string city, string street, int house, int index)
        {
            this.country = country;
            this.region = region;
            this.city = city;
            this.street = street;
            if (house > 0) this.house = house;
            else throw new Exception("Номер дома должен быть положительным");
            if (index.ToString().Length == 6 && index > 0) this.index = index;
            else throw new Exception("Индекс должен состоять из 6 цифр и быть положительным");

        }

        public string SetCountry
        {
            set { country = value; }
        }
        public string SetRegion
        {
            set { region = value; }
        }
        public string SetCity
        {
            set { city = value; }
        }
        public string SetStreet
        {
            set { street = value; }
        }
        public int SetHouse
        {
            set 
            {
                if (house > 0) house = value; 
                else throw new Exception("Номер дома должен быть положительным");
            }
        }
        public int SetIndex
        {
            set
            {
                if (index.ToString().Length == 6 && index > 0) index = value;
                else throw new Exception("Индекс должен состоять из 6 цифр и быть положительным");
            }
        }

        public string getCountry()
        {
            return country; 
        }
        public string getRegion()
        {
            return region;
        }
        public string getCity()
        {
            return city;
        }
        public string getStreet()
        {
            return street;
        }
        public int getHouse()
        {
            return house;
        }
        public int getIndex()
        {
            return index;
        }
    }
    
    public partial class MainWindow : Window
    {
        static int nomer = 5;
        static pochta[] company = new pochta[nomer];
        
        public MainWindow()
        {
            InitializeComponent();
            company[0] = new pochta("Россия","Московская обл","москва","Земляной вал",1,123456);
            company[1] = new pochta("США", "Миссури", "Канзас", "5-ая", 3, 654321);
            company[2] = new pochta("Казахстан", "Алма - атинская обл.", "Алматы", "Ленина", 2, 123456);
            company[3] = new pochta("Узбекистан", "Бешкекская обл.", "Бешкек", "Бешбармачная", 6, 456789);
            company[4] = new pochta("Приднестровье", "Бендеровская область", "Бендеры", "Богдана Хмельницкого", 5, 741852);
            update();
        }

        
        private void update()
        {
            CountryLabel.Content = string.Format("");
            RegionLabel.Content = string.Format("");
            CityLabel.Content = string.Format("");
            StreetLabel.Content = string.Format("");
            HouseLabel.Content = string.Format("");
            IndexLabel.Content = string.Format("");
            for(int i=0; i<nomer; i++)
            {
                CountryLabel.Content += string.Format("\n{0}", company[i].getCountry());
                RegionLabel.Content += string.Format("\n{0}", company[i].getRegion());
                CityLabel.Content += string.Format("\n{0}", company[i].getCity());
                StreetLabel.Content += string.Format("\n{0}", company[i].getStreet());
                HouseLabel.Content += string.Format("\n{0}", company[i].getHouse());
                IndexLabel.Content += string.Format("\n{0}", company[i].getIndex());
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new changeWindow();
            window.Owner = this;
            window.ShowDialog();
            company[window.number - 1].SetCountry = window.country;
            company[window.number - 1].SetRegion = window.region;
            company[window.number - 1].SetCity = window.city;
            company[window.number - 1].SetStreet = window.street;
            company[window.number - 1].SetHouse = window.house;
            company[window.number - 1].SetIndex = window.index;
            update();
        }

    }
}

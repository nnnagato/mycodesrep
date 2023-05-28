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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dz3_13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string alp = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        public char[] alphabet = new char[33];
        public MainWindow()
        {
            InitializeComponent();
            for(int i = 0; i < alp.Length; i++)
            {
                alphabet[i] = alp[i];
            }
        }


        public string message;
        public int rotor;
        public string result;
        
        public bool get_values()
        {
            
            int buf;
            message = messageBox.Text;
            if (int.TryParse(SdvigBox.Text, out buf))
            {
                rotor = buf;
                return true;
            }
            else
            {
                MessageBox.Show("Введите численный ротор");
                return false;
            }
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (get_values() == true) break;
            }
            result = "";
            for(int i = 0; i < message.Length; i++)
            {
                
                //message = message.ToString();
                if (char.IsUpper(message[i]))
                {
                    result += alphabet[(Array.IndexOf(alphabet, message[i]) + rotor) % 33];
                }
                else
                {
                    result += message[i];
                }
            }
            ResultBox.Text = result;
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (get_values() == true) break;
            }
            result = "";
            for (int i = 0; i < message.Length; i++)
            {

                //message = message.ToString();
                if (char.IsUpper(message[i]))
                {
                    result += alphabet[(Array.IndexOf(alphabet, message[i]) - rotor + 33) % 33];
                }
                else
                {
                    result += message[i];
                }
            }
            ResultBox.Text = result;
        }
    }
}

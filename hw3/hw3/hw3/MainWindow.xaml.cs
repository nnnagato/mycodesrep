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

namespace hw3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int[] tex = { };
        int[] key = { };
        //String buf1 = "";
        //String buf2 = "";
        //int apred =122;
        //int Apred =90;
        //int bpred =1103;
        //int Bpred =1071;

        private void encode(int[] tex,int[] key, int i)
        {
            tex[i] = tex[i] + key[i];
        }
        private void decode(int[] tex, int[] key, int i)
        {
            tex[i] = tex[i] - key[i];
        }

        private void keychange(int[] key)
        {
            for (int i = 0; i < key.Length; i++)
            {
                if ((key[i] >= 97) && (key[i] <= 122))//буква ключа латинская маленькая
                {
                    key[i] = key[i] - 96;
                }
                if ((key[i] >= 65) && (key[i] <= 92))//буква ключа латинская большая
                {
                    key[i] = key[i] - 64;
                }
                if ((key[i] >= 1072) && (key[i] <= 1103))//буква ключа кирилицей маленькая
                {
                    key[i] = key[i] - 1071;
                }
                if ((key[i] >= 1040) && (key[i] <= 1071))//буква ключа кириллицей большая
                {
                    key[i] = key[i] - 1039;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Array.Clear(tex);
            Array.Clear(key);
            resbox.Text = "";
            String buf1 = vvodbox.Text;            
            String buf2 = keybox.Text;
            int j = 0;
            for (int i = 0; i < buf1.Length; i++)
            { 
                     Array.Resize(ref tex, tex.Length + 1);
                     tex[j]=((int)buf1[i]);
                     j++;
            }
            j = 0;
            for (int i = 0; i < buf2.Length; i++)
            {
                if (char.IsLetter(buf2[i]))
                {
                    Array.Resize(ref key, key.Length + 1);
                    key[j] = ((int)buf2[i]);
                    j++;
                }
            }
            if(key.Length<tex.Length)
            {
                int baza = key.Length;
                int i = 0;
                while(key.Length<tex.Length)
                {                    
                    Array.Resize(ref key, key.Length + 1);
                    if(i<baza)
                    {
                        key[key.Length-1] = key[i];
                        i++;
                    }
                    else
                    {
                        i = 0;
                        key[key.Length-1] = key[i];
                        i++;
                    }
                }
            }
            keychange(key);
            if (code_mode.SelectedIndex == 0)
            {
                for (int i = 0; i < tex.Length; i++)
                {
                    if (Char.IsLetter((char)tex[i]))
                    {
                        if ((tex[i] >= 97) && (tex[i] <= 122))//буква латинская маленькая
                        {
                            tex[i] = tex[i] - 96;
                            encode(tex, key, i);
                            tex[i] = tex[i] % 26;
                            tex[i] = tex[i] + 96;   
                        }


                        if ((tex[i] >= 65) && (tex[i] <= 90))//буква латинская большая
                        {

                            tex[i] = tex[i] - 64;
                            encode(tex, key, i);
                            tex[i] = tex[i] % 26;
                            tex[i] = tex[i] + 64;
                        }

                        if ((tex[i] >= 1072) && (tex[i] <= 1103))//буква кириллица маленькая
                        {

                            tex[i] = tex[i] - 1071;
                            encode(tex, key, i);
                            tex[i] = tex[i] % 33;
                            tex[i] = tex[i] + 1071;
                        }

                        if ((tex[i] >= 1040) && (tex[i] <= 1071))//буква кириллица большая
                        {

                            tex[i] = tex[i] - 1039;
                            encode(tex, key, i);
                            tex[i] = tex[i] % 33;
                            tex[i] = tex[i] + 1039;
                        }
                    }
                }
            }
            else if(code_mode.SelectedIndex == 1)
            {
                for (int i = 0; i < tex.Length; i++)
                {
                    if (Char.IsLetter((char)tex[i]))
                    {
                        if ((tex[i] >= 97) && (tex[i] <= 122))//буква латинская маленькая
                        {
                            tex[i] = tex[i] - 96 + 26;
                            decode(tex, key, i);
                            tex[i] = tex[i] % 26;
                            tex[i] = tex[i] + 96;
                        }


                        if ((tex[i] >= 65) && (tex[i] <= 90))//буква латинская большая
                        {
                            tex[i] = tex[i] - 64 + 26;
                            decode(tex, key, i);
                            tex[i] = tex[i] % 26;
                            tex[i] = tex[i] + 64;
                        }

                        if ((tex[i] >= 1072) && (tex[i] <= 1103))//буква кириллица маленькая
                        {
                            tex[i] = tex[i] - 1071+33;
                            decode(tex, key, i);
                            tex[i] = tex[i] % 33;
                            tex[i] = tex[i] + 1071;
                        }

                        if ((tex[i] >= 1040) && (tex[i] <= 1070))//буква кириллица большая
                        {
                            tex[i] = tex[i] - 1039 + 33;
                            decode(tex, key, i);
                            tex[i] = tex[i] % 33;
                            tex[i] = tex[i] + 1039;
                        }
                    }
                }
            }
            for (int i = 0; i < tex.Length; i++)
            {
                resbox.Text += (char)tex[i];
            }
            resbox.Visibility = Visibility.Visible;
        }
    }
}

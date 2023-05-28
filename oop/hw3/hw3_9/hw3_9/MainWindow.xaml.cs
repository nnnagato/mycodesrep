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

namespace hw3_9
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

        public string origin;
        public int count;
        private void calcButton_Click(object sender, RoutedEventArgs e)
        {
            origin = originalBox.Text;
            count = 0;
            for(int i = 2; i < origin.Length; i++)
            {
                if (origin[i]=='.' || origin[i] == '?' || origin[i] == '!')
                {
                    if (origin[i]=='!' && origin[i-1] == '?')
                    {
                        continue;
                    }
                    if (origin[i]=='.' && origin[i-1]=='.' && origin[i-2]=='.')
                    {
                        count -= 2;
                    }
                }
            }
            countLabel.Content = string.Format("Количество предложений: {0}",count);
        }
    }
}

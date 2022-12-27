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
using Microsoft.Win32;
using System.IO;


namespace lab4_1
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }
        private void menuOpen_Click(object sender, RoutedEventArgs e)
        {
            if (tb3.Text == "1")
            {
                MessageBox.Show("Предупреждение, файл был изменен после последней операции сохранения");
            }
            // создаем объект диалога открытия
            var dialog = new OpenFileDialog();
            // устанавливаем фильтр файлов
            dialog.Filter = "Текстовые файлы | *.txt";
            // показываем диалог
            var result = dialog.ShowDialog();

            //если диалог закрыли кнопкой "Открыть", 
            // то result будет равен true, 
            //если закрыли крестиком или кнопкой "Отмена"
            // то result будет равен false
            if (result == true)
            {
                //Метод ReadAllText - открывает текстовый файл
                //и возвращает его содержимое
                tb.Text = File.ReadAllText(dialog.FileName);
                tb1.Text = dialog.FileName;
            }
            tb3.Text = "0";
        }
        private void menuSave_Click(object sender, RoutedEventArgs e)
        {
            if (tb3.Text == "1")
            {
                MessageBox.Show("Предупреждение, файл был изменен после последней операции сохранения");
            }
            // создаем объект диалога сохранения
            var dialog = new SaveFileDialog();
            // устанавливаем фильтр файлов
            dialog.Filter = "Текстовые файлы | *.txt";
            // показываем диалог
            var result = dialog.ShowDialog();

            //если диалог закрыли кнопкой "Сохранить", 
            // то result будет равен true, 
            //если закрыли крестиком или кнопкой "Отмена"
            // то result будет равен false
            if (result == true)
            {
                // Метод WriteAllText - записывает указанный текст
                // в файл с выбранным в диалоге именем
                File.WriteAllText(dialog.FileName, tb.Text);
            }
            tb3.Text = "0";
        }
        private void menuSave1_Click(object sender, System.EventArgs e)
        {
            if (tb3.Text == "1")
            {
                MessageBox.Show("Предупреждение, файл был изменен после последней операции сохранения");
            }
            // создаем объект диалога сохранения
            var dialog = new SaveFileDialog();
            // устанавливаем фильтр файлов
            if (tb1.Text != "")
            {
                dialog.FileName = tb1.Text;
                File.WriteAllText(dialog.FileName, tb.Text);
            }
            else
            {
                MessageBox.Show("Ошибка. Вы не можете сохранить файл, не открыв его.");
            }
            tb3.Text = "0";
        }
        private void menuCreate_Click(object sender, RoutedEventArgs e)
        {
            tb.Text = "";
        }
        private void MenuUndo_Click(object sender, RoutedEventArgs e)
        {
            tb.Undo();
            tb3.Text = "0";
        }

        private void MenuRedo_Click(object sender, RoutedEventArgs e)
        {
            tb.Redo();
        }


        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            // создаем новое окно
            var about = new Window1();

            // и показываем его на экране
            about.Show();

        }

        private void tb3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            tb3.Text = "1";
            int h = 0;
            string g = tb.Text;
            for (int i = 0; i < g.Length - 1; i++)
            {
                if (g[i] == ' ' && g[i + 1] != ' ')
                {
                    h++;
                }
            }
            h++;
            Word.Text = h.ToString();
        }
    }
}


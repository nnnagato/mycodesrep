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

namespace hw6_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    abstract public class Body
    {
        public double a;
        public double b;
        public double h;
        abstract public double square();
        abstract public double volume();
    }
    public class Qube:Body
    {
        public Qube(double side)
        {
            a = side;
            b = side;
            h = side;
        }
        public override double square()
        {
            double s = 6 * Math.Pow(a, 2);
            return s;
        }
        public override double volume()
        {
            double v = Math.Pow(a, 3);
            return v;
        }
    }

    public class Sphere:Body
    {
        public Sphere(double radius)
        {
            a = radius;
            b = radius;
            h = radius;
        }
        public override double square()
        {
            double s = 4 * Math.PI * Math.Pow(a, 2);
            return s;
        }
        public override double volume()
        {
            double v = 4 / 3 * Math.PI * Math.Pow(a, 3);
            return v;
        }
    }

    public class Cone:Body
    {
        public Cone(double radius, double height)
        {
            a = radius;
            h = height;
            b = Math.Sqrt(Math.Pow(a,2)+Math.Pow(h,2));
        }
        public override double square()
        {
            double s = Math.PI * a * b + Math.PI * Math.Pow(a, 2);
            return s;
        }
        public override double volume()
        {
            double v = 1 / 3 * Math.PI * Math.Pow(a, 2) * h;
            return v;
        }
    }

    public partial class MainWindow : Window
    {
        public void clear_fields()
        {
            Qube_Num.Content = "";
            Qube_a.Content = "";
            Qube_Square.Content = "";
            Qube_Volume.Content = "";
            Sphere_Num.Content = "";
            Sphere_a.Content = "";
            Sphere_Square.Content = "";
            Sphere_Volume.Content = "";
            Cone_Num.Content = "";
            Cone_a.Content = "";
            Cone_b.Content = "";
            Cone_h.Content = "";
            Cone_Square.Content = "";
            Cone_Volume.Content = "";
        }
        public void update_fields()
        {
            clear_fields();
            for (int i = 0; i < Qube_Count; i++)
            {
                Qube_Num.Content += String.Format("{0}",i+1);
                Qube_a.Content += String.Format("{0.00}", qubes[i].a);
                Qube_Square.Content += String.Format("{0.00", qubes[i].square());
                Qube_Volume.Content += String.Format("{0.00", qubes[i].volume());

            }
            for (int i = 0; i < Sphere_Count; i++)
            {
                Sphere_Num.Content += String.Format("{0}", i + 1);
                Sphere_a.Content += String.Format("{0.00}", spheres[i].a);
                Sphere_Square.Content += String.Format("{0.00", spheres[i].square());
                Sphere_Volume.Content += String.Format("{0.00", spheres[i].volume());

            }
            for (int i = 0; i < Cone_Count; i++)
            {
                Cone_Num.Content += String.Format("{0}", i + 1);
                Cone_a.Content += String.Format("{0.00}", cones[i].a);
                Cone_Square.Content += String.Format("{0.00", cones[i].square());
                Cone_Volume.Content += String.Format("{0.00", cones[i].volume());
                Cone_b.Content += String.Format("{0.00}", cones[i].b);
                Cone_h.Content += String.Format("{0.00}", cones[i].h);

            }
        }
        public static int Qube_Count = 3;
        public static int Cone_Count = 3;
        public static int Sphere_Count = 3;
        Qube[] qubes = new Qube[Qube_Count];
        Sphere[] spheres = new Sphere[Sphere_Count];
        Cone[] cones = new Cone[Cone_Count];

        public MainWindow()
        {
            InitializeComponent();
            for(int i = 0; i < Qube_Count; i++)
            {
                qubes[i] = new Qube(5);
                spheres[i] = new Sphere(3);
                cones[i] = new Cone(1, 3);
            }
            update_fields();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            int buf;
            try
            {
                int.TryParse(RemoveBox.Text,out buf);
                if (buf < 1) throw new System.FormatException();

            }
            catch(System.FormatException)
            {
                MessageBox.Show("Укажите в качестве номера удаляемой записи корректное число");
                return;
            }
            switch(Remove_category.SelectedIndex)
            {
                case 1:
                    if(buf>Qube_Count)
                    {
                        MessageBox.Show("Нет записи с таким номером");
                        return;
                    }
                    for(int i = buf;i < Qube_Count; i++)
                    {
                        qubes[i - 1] = qubes[i];
                    }
                    Qube_Count--;
                    Array.Resize(ref qubes, Qube_Count);
                    break;
                case 2:
                    if (buf > Sphere_Count)
                    {
                        MessageBox.Show("Нет записи с таким номером");
                        return;
                    }
                    for (int i = buf; i < Sphere_Count; i++)
                    {
                        spheres[i - 1] = spheres[i];
                    }
                    Sphere_Count--;
                    Array.Resize(ref spheres, Sphere_Count);
                    break;
                case 3:
                    if (buf > Cone_Count)
                    {
                        MessageBox.Show("Нет записи с таким номером");
                        return;
                    }
                    for (int i = buf; i < Cone_Count; i++)
                    {
                        cones[i - 1] = cones[i];
                    }
                    Cone_Count--;
                    Array.Resize(ref cones, Cone_Count);
                    break;
            }
            update_fields();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var window = new Adding_Window();
            window.ShowDialog();
            if(window.DialogResult == true)
            {
                switch(window.Selection.SelectedIndex)
                {
                    case 0:
                        Qube_Count++;
                        Array.Resize(ref qubes, Qube_Count);
                        qubes[Qube_Count-1] = new Qube(window.a);
                        break;
                    case 1:
                        Sphere_Count++;
                        Array.Resize(ref spheres, Sphere_Count);
                        spheres[Sphere_Count-1] = new Sphere(window.a);
                        break;
                    case 2:
                        Cone_Count++;
                        Array.Resize(ref cones, Cone_Count);
                        cones[Cone_Count - 1] = new Cone(window.a, window.h);
                        break;

                }
                update_fields();
            }

        }
    }
}

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

namespace dz6_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    abstract class weapon //создаём абстрактный обобщённый класс со свойствами для всех видов оружия
    {
        public abstract string Vid { get; set; }
        public abstract string Name { get; set; }//название
        public abstract int Radius { get; set; }//радиус поражения
        public abstract int attackSpeed { get; set; }//скорострельность
        public abstract int ReloadSpeed { get; set; }//скорость перезарядки

    }

    class cold : weapon
    {
        public override string Vid
        {
            get { return Vid; }
            set { Vid = value; }

        }
        public override string Name
        {
            get { return Name; }
            set { Name = value; }
        }
        public override int Radius
        {
            get { return Radius; }
            set { Radius = value; }
        }
        public override int attackSpeed
        {
            get { return attackSpeed; }
            set { attackSpeed = value; }
        }
        public override int ReloadSpeed
        {
            get { return ReloadSpeed; }
            set { ReloadSpeed = value; }
        }
    }
    class fire : weapon
    {
        public override string Vid
        {
            get { return Vid; }
            set { Vid = value; }

        }
        public override string Name
        {
            get { return Name; }
            set { Name = value; }
        }
        public override int Radius
        {
            get { return Radius; }
            set { Radius = value; }
        }
        public override int attackSpeed
        {
            get { return attackSpeed; }
            set { attackSpeed = value; }
        }
        public override int ReloadSpeed
        {
            get { return ReloadSpeed; }
            set { ReloadSpeed = value; }
        }
    }
    class nuke : weapon
    {
        public override string Vid
        {
            get { return Vid; }
            set { Vid = value; }

        }
        public override string Name
        {
            get { return Name; }
            set { Name = value; }
        }
        public override int Radius
        {
            get { return Radius; }
            set { Radius = value; }
        }
        public override int attackSpeed
        {
            get { return attackSpeed; }
            set { attackSpeed = value; }
        }
        public override int ReloadSpeed
        {
            get { return ReloadSpeed; }
            set { ReloadSpeed = value; }
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}

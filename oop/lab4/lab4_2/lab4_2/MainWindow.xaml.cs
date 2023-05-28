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

namespace lab4_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    enum DrawMode
    {
        PEN,
        LINE,
        ELLIPSE,
        RECTANGLE
    }
    

    public partial class MainWindow : Window
    {
        DrawMode mode;
        Point startPoint;
        Line line;
        Ellipse ellipse;
        Color color;
        Color fillColor;
        Rectangle rectangle;


        public MainWindow()
        {
            InitializeComponent();
            mode = DrawMode.LINE;
            color = Colors.Black;//Задаём цвета по умолчанию
            fillColor = Colors.White;
        }     

        private void PenButoon_Click(object sender, RoutedEventArgs e)
        {
            mode = DrawMode.PEN;
        }

        private void LineButton_Click(object sender, RoutedEventArgs e)
        {
            mode = DrawMode.LINE;

        }

        private void EllipseButton_Click(object sender, RoutedEventArgs e)
        {
            mode = DrawMode.ELLIPSE;

        }
        private void RectangleButton_Click(object sender, RoutedEventArgs e)
        {
            mode = DrawMode.RECTANGLE;
        }

        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //запоминаем координаты начала отрезка
            // метод GetPosition возвращает координаты мыши в данный момент
            // относительно элемента canvas
            startPoint = e.GetPosition(canvas);
            // в зависимости от режима действуем по разному
            switch (mode)
            {
                case DrawMode.PEN:
                    startPoint = e.GetPosition(canvas);
                    break;
                case DrawMode.LINE:
                    line = new Line();
                    line.Stroke = new SolidColorBrush(color);
                    line.X1 = startPoint.X;
                    line.X2 = startPoint.X;
                    line.Y1 = startPoint.Y;
                    line.Y2 = startPoint.Y;
                    canvas.Children.Add(line);
                    break;
                case DrawMode.ELLIPSE:
                    ellipse = new Ellipse();
                    ellipse.Stroke = new SolidColorBrush(color);
                    ellipse.Fill = new SolidColorBrush(fillColor);
                    canvas.Children.Add(ellipse);
                    Canvas.SetTop(ellipse, startPoint.Y);
                    Canvas.SetLeft(ellipse, startPoint.X);
                    ellipse.Width = 0;
                    ellipse.Height = 0;
                    break;
                case DrawMode.RECTANGLE:
                    rectangle = new Rectangle();
                    rectangle.Stroke = new SolidColorBrush(color);
                    rectangle.Fill = new SolidColorBrush(fillColor);
                    canvas.Children.Add(rectangle);
                    Canvas.SetTop(rectangle, startPoint.Y);
                    Canvas.SetLeft(rectangle, startPoint.X);
                    rectangle.Width = 0;
                    rectangle.Height = 0;
                    break;
            }

        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            //обрабатываем движения мыши только если нажата левая кнопка
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point curPoint = e.GetPosition(canvas);
                double width = curPoint.X - startPoint.X;
                double height = curPoint.Y - startPoint.Y;
                switch (mode)
                {
                    case DrawMode.PEN:
                        var currentPoint = e.GetPosition(canvas);
                        line = new Line();
                        line.Stroke = new SolidColorBrush(color);
                        line.X1 = startPoint.X;
                        line.Y1 = startPoint.Y;
                        line.X2 = currentPoint.X;
                        line.Y2 = currentPoint.Y;
                        canvas.Children.Add(line);
                        startPoint = currentPoint;
                        break;
                    case DrawMode.LINE:
                        //обновляем координаты второго конца отрезка
                        line.X2 = e.GetPosition(canvas).X;
                        line.Y2 = e.GetPosition(canvas).Y;
                        break;
                    case DrawMode.ELLIPSE:
                        //Point curPoint = e.GetPosition(canvas);
                        //double width = curPoint.X - startPoint.X;
                        //double height = curPoint.Y - startPoint.Y;

                        if (width < 0)
                        {
                            width = -width;
                            Canvas.SetLeft(ellipse, curPoint.X);
                        }
                        if (height < 0)
                        {
                            height = -height;
                            Canvas.SetTop(ellipse, curPoint.Y);
                        }
                        ellipse.Width = width;
                        ellipse.Height = height;
                        break;
                    case DrawMode.RECTANGLE:
                        //Point curPoint = e.GetPosition(canvas);
                        //double width = curPoint.X - startPoint.X;
                        //double height = curPoint.Y - startPoint.Y;

                        if (width < 0)
                        {
                            width = -width;
                            Canvas.SetLeft(rectangle, curPoint.X);
                        }
                        if (height < 0)
                        {
                            height = -height;
                            Canvas.SetTop(rectangle, curPoint.Y);
                        }
                        rectangle.Width = width;
                        rectangle.Height = height;
                        break;
                }
            }
        }
        private void Lbl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                color = ((SolidColorBrush)((Label)sender).Background).Color;
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                fillColor = ((SolidColorBrush)((Label)sender).Background).Color;
            }
        }

    }
}

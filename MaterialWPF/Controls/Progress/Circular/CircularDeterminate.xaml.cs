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

namespace MaterialWPF
{
    /// <summary>
    /// Interaction logic for circularDeterminate.xaml
    /// </summary>
    public partial class CircularDeterminate : UserControl
    {
        double ma = 30;

        public double Max
        {
            get { return (double)base.GetValue(MaxProperty); }
            set { base.SetValue(MaxProperty, value); }
        }

        public static DependencyProperty MaxProperty =
          DependencyProperty.Register("Max", typeof(double), typeof(CircularDeterminate), null);


        public Brush Color
        {
            get { return (Brush)base.GetValue(ColorProperty); }
            set { base.SetValue(ColorProperty, value); }
        }

        public static DependencyProperty ColorProperty =
          DependencyProperty.Register("Color", typeof(Brush), typeof(CircularDeterminate), null);

        public double Size
        {
            get { return (double)base.GetValue(SizeProperty); }
            set { base.SetValue(SizeProperty, value); }
        }

        public static DependencyProperty SizeProperty =
          DependencyProperty.Register("Size", typeof(double), typeof(CircularDeterminate), null);


        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == ColorProperty)
            {
                ellipse.Stroke = Color;
            }
            if (e.Property == SizeProperty)
            {
                ellipse.StrokeThickness = Size;
            }
            if (e.Property == MaxProperty)
            {
                ma = Max;
                ellipse.StrokeDashArray[0] = ma;
            }
        }

        public CircularDeterminate()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public DoubleCollection x()
        {
            return ellipse.StrokeDashArray;
        }


        public double getProcent()
        {
            var x = ellipse.StrokeDashArray[0];
            return procentX(ma, x);
        }

        public void setProcent(double procent)
        {
            var i = intX(ma, procent);
            var x = ellipse.StrokeDashArray[0];
            var y = ellipse.StrokeDashArray[1];
            var z = ellipse.StrokeDashArray[2];
            x = i;

            int iz = Convert.ToInt32(i);

            if (iz == 10)
            {
                y = y + 1;
            }
            if (iz == 9)
            {
                y = y + 2;
            }
            if (iz == 8)
            {
                y = y + 3;
            }
            if (iz == 7)
            {
                y = y + 4;
            }
            if (iz == 6)
            {
                y = y + 5;
            }
            if (iz == 5)
            {
                y = y + 6;
            }
            if (iz == 6 || i == 5 || iz == 4)
            {
                y = y + 7;
            }
            if (iz == 3)
            {
                y = y + 8;
            }
            if (iz == 2)
            {
                y = y + 9;
            }
            if (iz == 1)
            {
                y = y + 10;
            }
            if (iz == 0)
            {
                ellipse.Visibility = Visibility.Hidden;
            }
            if (iz != 0)
            {
                ellipse.Visibility = Visibility.Visible;
            }
            ellipse.StrokeDashArray = new DoubleCollection() { x, y, z };
        }



        public static double intX(double max, double i)
        {
            return (max * i) / 100;
        }
        public static double procentX(double max, double p)
        {
            if ((p * 100) / max >= 100)
            {
                return 100;
            }
            if (((p * 100) / max) <= 0)
            {
                return 0;
            }
            return (p * 100) / max;
        }

        public void rotate(RotateTransform x)
        {
            grid.RenderTransform = x;
        }
    }
}

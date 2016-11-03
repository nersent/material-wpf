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
    /// Interaction logic for CircularInDeterminate.xaml
    /// </summary>
    public partial class CircularInDeterminate : UserControl
    {
        double r = 0;
        bool h = true;

        double ma = 25;

        System.Windows.Threading.DispatcherTimer rotationTimer = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer hideTimer = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer showTimer = new System.Windows.Threading.DispatcherTimer();

        public double Max
        {
            get { return (double)base.GetValue(MaxProperty); }
            set { base.SetValue(MaxProperty, value); }
        }

        public static DependencyProperty MaxProperty =
          DependencyProperty.Register("Max", typeof(double), typeof(CircularInDeterminate), null);


        public Brush Color
        {
            get { return (Brush)base.GetValue(ColorProperty); }
            set { base.SetValue(ColorProperty, value); }
        }

        public static DependencyProperty ColorProperty =
          DependencyProperty.Register("Color", typeof(Brush), typeof(CircularInDeterminate), null);

        public double Size
        {
            get { return (double)base.GetValue(SizeProperty); }
            set { base.SetValue(SizeProperty, value); }
        }

        public static DependencyProperty SizeProperty =
          DependencyProperty.Register("Size", typeof(double), typeof(CircularInDeterminate), null);


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
            }
        }


        public CircularInDeterminate()
        {
            InitializeComponent();
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            rotationTimer.Tick += rotationTimer_Tick;
            rotationTimer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            rotationTimer.Start();

            hideTimer.Tick += hideTimer_Tick;
            hideTimer.Interval = new TimeSpan(0, 0, 0, 0, 25);
            hideTimer.Start();

            showTimer.Tick += showTimer_Tick;
            showTimer.Interval = new TimeSpan(0, 0, 0, 0, 35);
            showTimer.Start();
        }

        private void hideTimer_Tick(object sender, EventArgs e)
        {
            if (h)
            {
                DoubleCollection array = ellipse.StrokeDashArray;
                double x = array[0];
                double y = array[1];
                double z = array[2];

                rotationTimer.Interval = new TimeSpan(0, 0, 0, 0, 30);
                if (x > 2)
                {
                    x = x - 1;
                }
                if (x < 11)
                {
                    y = y + 1;
                }
                if (x == 2 || x < 3)
                {
                    h = false;
                }
                ellipse.StrokeDashArray = new DoubleCollection() { x, y, z };
            }


        }

        private void showTimer_Tick(object sender, EventArgs e)
        {
            if (!h)
            {
                DoubleCollection array = ellipse.StrokeDashArray;
                double x = array[0];
                double y = array[1];
                double z = array[2];

                rotationTimer.Interval = new TimeSpan(0, 0, 0, 0, 25);
                if (x < ma || x != ma)
                {
                    x = x + 1;
                }
                if (x > ma || x == ma)
                {
                    h = true;
                }
                if (x > 11 && x < 2)
                {
                    y = y + 1;
                }
                ellipse.StrokeDashArray = new DoubleCollection() { x, y, z };
            }
        }

        private void rotationTimer_Tick(object sender, EventArgs e)
        {
            r = r + 20;
            if (r == 360)
            {
                r = 0;
            }
            RotateTransform rt = new RotateTransform(r);
            grid.RenderTransform = rt;
        }

        public Grid getMainGrid()
        {
            return grid;
        }

        public Ellipse getEllipse()
        {
            return ellipse;
        }
    }
}

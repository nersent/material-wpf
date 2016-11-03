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
    /// Interaction logic for CircularHalf.xaml
    /// </summary>
    public partial class CircularHalf : UserControl
    {
        public System.Windows.Threading.DispatcherTimer rotationTimer = new System.Windows.Threading.DispatcherTimer();

        public int RotationTime
        {
            get
            {
                return (int)base.GetValue(RotationTimeProperty);
            }
            set { base.SetValue(RotationTimeProperty, value); }
        }

        public static DependencyProperty RotationTimeProperty =
          DependencyProperty.Register("RotationTime", typeof(int), typeof(CircularHalf), null);

        public Brush Color
        {
            get { return (Brush)base.GetValue(ColorProperty); }
            set { base.SetValue(ColorProperty, value); }
        }

        public static DependencyProperty ColorProperty =
          DependencyProperty.Register("Color", typeof(Brush), typeof(CircularHalf), null);

        public double Size
        {
            get { return (double)base.GetValue(SizeProperty); }
            set { base.SetValue(SizeProperty, value); }
        }

        public static DependencyProperty SizeProperty =
          DependencyProperty.Register("Size", typeof(double), typeof(CircularHalf), null);

        public DoubleCollection StrokeDataArrayProperty
        {
            get { return (DoubleCollection)base.GetValue(StrokeDataArrayPropertyP); }
            set { base.SetValue(StrokeDataArrayPropertyP, value); }
        }

        public static DependencyProperty StrokeDataArrayPropertyP =
          DependencyProperty.Register("StrokeDataArrayProperty", typeof(DoubleCollection), typeof(CircularHalf), null);


        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == RotationTimeProperty)
            {
                rotationTimer.Interval = new TimeSpan(0, 0, 0, 0, RotationTime);
            }
            if (e.Property == ColorProperty)
            {
                ellipse.Stroke = Color;
            }
            if (e.Property == SizeProperty)
            {
                ellipse.StrokeThickness = Size;
            }
            if (e.Property == StrokeDataArrayPropertyP)
            {
                ellipse.StrokeDashArray = StrokeDataArrayProperty;
            }
        }


        double r = 0;

        public CircularHalf()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (RotationTime == 0)
            {
                RotationTime = 35;
            }
            rotationTimer.Tick += rotationTimer_Tick;
            rotationTimer.Start();
        }


        public void rotationTimer_Tick(object sender, EventArgs e)
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

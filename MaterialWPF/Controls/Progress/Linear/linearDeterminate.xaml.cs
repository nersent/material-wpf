using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MaterialWPF
{
    /// <summary>
    /// Interaction logic for linearDeterminate.xaml
    /// </summary>
    public partial class linearDeterminate : UserControl
    {
        double width = 0;
        double progress = 0;
        double time = 0.2;
        double lasttime = 0;

        public Color BackgroundColor
        {
            get { return (Color)base.GetValue(BackgroundColorProperty); }
            set { base.SetValue(BackgroundColorProperty, value); }
        }
        public static DependencyProperty BackgroundColorProperty =
          DependencyProperty.Register("BackgroundColor", typeof(Color), typeof(linearDeterminate), null);

        public Color ProgressColor
        {
            get { return (Color)base.GetValue(ProgressColorProperty); }
            set { base.SetValue(ProgressColorProperty, value); }
        }
        public static DependencyProperty ProgressColorProperty =
          DependencyProperty.Register("ProgressColor", typeof(Color), typeof(linearDeterminate), null);

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == BackgroundColorProperty)
            {
                background.Background = new SolidColorBrush(BackgroundColor);

            }
            if (e.Property == ProgressColorProperty)
            {
                Divider.Background = new SolidColorBrush(ProgressColor);
            }
        }

        public linearDeterminate()
        {
            InitializeComponent();
            ProgressColor = colorConverter.convertToColor("#3d87f0");
            BackgroundColor = colorConverter.convertToColor("#c0d4e7");
        }

        public void SetMax(double max)
        {
            width = max;
            background.Width = max;
        }

        public void SetTime(double t)
        {
            time = t;
        }

        public double GetWidth()
        {
            return width;
        }

        public double GetProgressWidth()
        {
            return Procent.intX(width, progress);
        }

        public double GetProgressProcent()
        {
            return progress;
        }

        public void SetProgressWidth(double p)
        {
            progress = Procent.procentX(width, p);
            AnimateWidth();
        }

        public void SetProgressProcent(double p)
        {
            if (p < 100)
            {
                progress = p;
            }
            else
            {
                progress = 100;
            }
            AnimateWidth();
        }

        private void AnimateWidth()
        {
            double w = Procent.intX(width, progress);
            Animations.AnimateWidth(lasttime, w, Divider, time, 0, null);
            lasttime = w;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            width = ActualWidth;
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            width = ActualWidth;
            AnimateWidth();
        }

      


    }
}
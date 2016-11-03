using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MaterialWPF
{
    /// <summary>
    /// Interaction logic for ToolBarItem.xaml
    /// </summary>
    public partial class ToolBarItem : UserControl
    {
        bool ripple = true;
        double rippleOpacity = 0.25;
        double rippleFadeInTime = 0.2;
        double rippleFadeOutTime = 0.3;



        public Color RippleColor
        {
            get { return (Color)base.GetValue(RippleColorProperty); }
            set { base.SetValue(RippleColorProperty, value); }
        }
        public static DependencyProperty RippleColorProperty =
          DependencyProperty.Register("RippleColor", typeof(Color), typeof(ToolBarItem), null);

        public double RippleOpacity
        {
            get { return (double)base.GetValue(RippleOpacityProperty); }
            set { base.SetValue(RippleOpacityProperty, value); }
        }
        public static DependencyProperty RippleOpacityProperty =
          DependencyProperty.Register("RippleOpacity", typeof(double), typeof(ToolBarItem), null);

        public double RippleFadeInTime
        {
            get { return (double)base.GetValue(RippleFadeInTimeProperty); }
            set { base.SetValue(RippleFadeInTimeProperty, value); }
        }
        public static DependencyProperty RippleFadeInTimeProperty =
          DependencyProperty.Register("RippleFadeInTime", typeof(double), typeof(ToolBarItem), null);

        public double RippleFadeOutTime
        {
            get { return (double)base.GetValue(RippleFadeOutTimeProperty); }
            set { base.SetValue(RippleFadeOutTimeProperty, value); }
        }

        public static DependencyProperty RippleFadeOutTimeProperty =
            DependencyProperty.Register("RippleFadeOutTime", typeof(double), typeof(ToolBarItem), null);

        public ImageSource IconSource
        {
            get { return (ImageSource)base.GetValue(IconSourceProperty); }
            set { base.SetValue(IconSourceProperty, value); }
        }

        public static DependencyProperty IconSourceProperty =
            DependencyProperty.Register("IconSource", typeof(ImageSource), typeof(ToolBarItem), null);

        public double IconWidth
        {
            get { return (double)base.GetValue(IconWidthProperty); }
            set { base.SetValue(IconWidthProperty, value); }
        }

        public static DependencyProperty IconWidthProperty =
            DependencyProperty.Register("IconWidth", typeof(double), typeof(ToolBarItem), null);

        public double IconHeight
        {
            get { return (double)base.GetValue(IconHeightProperty); }
            set { base.SetValue(IconHeightProperty, value); }
        }

        public static DependencyProperty IconHeightProperty =
            DependencyProperty.Register("IconHeight", typeof(double), typeof(ToolBarItem), null);



        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == RippleColorProperty)
            {
                Ripple.Fill = colorConverter.convertToBrush(RippleColor);
            }
            if (e.Property == RippleOpacityProperty)
            {
                rippleOpacity = RippleOpacity;
            }
            if (e.Property == RippleFadeInTimeProperty)
            {
                rippleFadeInTime = RippleFadeInTime;
            }
            if (e.Property == RippleFadeOutTimeProperty)
            {
                rippleFadeOutTime = RippleFadeOutTime;
            }
            if (e.Property == IconSourceProperty)
            {
                image.Source = IconSource;
            }
            if (e.Property == IconWidthProperty)
            {
                image.Width = IconWidth;
            }
            if (e.Property == IconHeightProperty)
            {
                image.Height = IconHeight;
            }
        }


        public ToolBarItem()
        {
            InitializeComponent();
        }


        public void startRipple(Ellipse element, double fadeOpacity, double fadeInTime, double fadeOutTime, double width)
        {
            if (ripple)
            {
                Animations.AnimateFade(0, fadeOpacity, element, fadeInTime, 0, null);
                element.Height = 0;
                element.Width = 0;
                Animations.AnimateRipple(0, width, element, fadeInTime, true, fadeOutTime);
            }
        }

        private void MainGrid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
           startRipple(Ripple, rippleOpacity, rippleFadeInTime, rippleFadeOutTime, MainGrid.ActualWidth);
        }

        private void ToolBarItem_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            MainGrid.Width = this.ActualWidth;
            MainGrid.Height = this.ActualHeight;
        }
    }
}

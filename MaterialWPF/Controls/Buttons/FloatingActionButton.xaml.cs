using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MaterialWPF
{
    /// <summary>
    /// Interaction logic for FloatingActionButton.xaml
    /// </summary>
    public partial class FloatingActionButton : UserControl
    {
        Color colorLeave;


        public Color BackgroundColor
        {
            get { return (Color)base.GetValue(BackgroundColorProperty); }
            set { base.SetValue(BackgroundColorProperty, value); }
        }
        public static DependencyProperty BackgroundColorProperty =
          DependencyProperty.Register("BackgroundColor", typeof(Color), typeof(FloatingActionButton), null);

        public Color RippleColor
        {
            get { return (Color)base.GetValue(RippleColorProperty); }
            set { base.SetValue(RippleColorProperty, value); }
        }
        public static DependencyProperty RippleColorProperty =
          DependencyProperty.Register("RippleColor", typeof(Color), typeof(FloatingActionButton), null);

        public double RippleOpacity
        {
            get { return (double)base.GetValue(RippleOpacityProperty); }
            set { base.SetValue(RippleOpacityProperty, value); }
        }
        public static DependencyProperty RippleOpacityProperty =
          DependencyProperty.Register("RippleOpacity", typeof(double), typeof(FloatingActionButton), null);

        public double RippleFadeOutTime
        {
            get { return (double)base.GetValue(RippleFadeOutTimeProperty); }
            set { base.SetValue(RippleFadeOutTimeProperty, value); }
        }
        public static DependencyProperty RippleFadeOutTimeProperty =
          DependencyProperty.Register("RippleFadeOutTime", typeof(double), typeof(FloatingActionButton), null);

        public double RippleEffectTime
        {
            get { return (double)base.GetValue(RippleEffectTimeProperty); }
            set { base.SetValue(RippleEffectTimeProperty, value); }
        }
        public static DependencyProperty RippleEffectTimeProperty =
          DependencyProperty.Register("RippleEffectTime", typeof(double), typeof(FloatingActionButton), null);

        public bool RippleEnabled
        {
            get { return (bool)base.GetValue(RippleEnabledProperty); }
            set { base.SetValue(RippleEnabledProperty, value); }
        }
        public static DependencyProperty RippleEnabledProperty =
          DependencyProperty.Register("RippleEnabled", typeof(bool), typeof(FloatingActionButton), null);

        public ImageSource Source
        {
            get { return (ImageSource)base.GetValue(SourceProperty); }
            set { base.SetValue(SourceProperty, value); }
        }
        public static DependencyProperty SourceProperty =
          DependencyProperty.Register("Source", typeof(ImageSource), typeof(FloatingActionButton), null);



        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == BackgroundColorProperty)
            {
                colorLeave = BackgroundColor;
                background.Background = new SolidColorBrush(BackgroundColor);
            }
            if (e.Property == RippleColorProperty)
            {
                Ripple.Fill = new SolidColorBrush(RippleColor);
            }
            if (e.Property == SourceProperty)
            {
                img.Source = Source;
            }



        }

       
        public FloatingActionButton()
        {
            InitializeComponent();
            RippleColor = (Color) ColorConverter.ConvertFromString("#bababa");
            BackgroundColor = (Color)ColorConverter.ConvertFromString("#3498db");
            RippleOpacity = 0.4;
            RippleFadeOutTime = 0.3;
            RippleEffectTime = 0.2;
            RippleEnabled = true;
        }

        public Color ChangeLightness(Color color, float coef)
        {
            return Color.FromArgb(color.A, (byte)(color.R * coef), (byte)(color.G * coef),
                (byte)(color.B * coef));
        }

        private void hover(bool t)
        {
            //#cccccc
            double time = 0.2;

            if (t == true)
            {
                Animations.AnimateColor(colorLeave, ChangeLightness(colorLeave, 0.9f), background, time, "Background");
            }
            else
            {
                Animations.AnimateColor(ChangeLightness(colorLeave, 0.9f), colorLeave, background, time, "Background");
            }
        }

        private void background_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (RippleEnabled)
            {
                var targetWidth = Math.Max(ActualWidth, ActualHeight) * 2;
                Ripple.Width = 0;
                var mousePosition = (e as MouseButtonEventArgs).GetPosition(this);
                var startMargin = new Thickness(mousePosition.X, mousePosition.Y, 0, 0);
                Ripple.Margin = startMargin;

                Animations.AnimateFade(0, RippleOpacity, Ripple, 0, 0, null);

                Animations.AnimateRipple(0, targetWidth, Ripple, RippleFadeOutTime, startMargin, new Thickness(mousePosition.X - targetWidth / 2, mousePosition.Y - targetWidth / 2, 0, 0), true, RippleEffectTime);
            }

        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            hover(true);
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            hover(false);
        }

        private void img_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            Console.WriteLine("MaterialWPF: Can't load image in FAB");
        }
    }
}
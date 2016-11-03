using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MaterialWPF
{
    /// <summary>
    /// Interaction logic for RippleDecorator.xaml
    /// </summary>
    public partial class RippleDecorator : UserControl
    {


        public Color RippleColor
        {
            get { return (Color)base.GetValue(RippleColorProperty); }
            set { base.SetValue(RippleColorProperty, value); }
        }
        public static DependencyProperty RippleColorProperty =
          DependencyProperty.Register("RippleColor", typeof(Color), typeof(RippleDecorator), null);

        public double RippleOpacity
        {
            get { return (double)base.GetValue(RippleOpacityProperty); }
            set { base.SetValue(RippleOpacityProperty, value); }
        }
        public static DependencyProperty RippleOpacityProperty =
          DependencyProperty.Register("RippleOpacity", typeof(double), typeof(RippleDecorator), null);

        public double RippleDuration
        {
            get { return (double)base.GetValue(RippleDurationProperty); }
            set { base.SetValue(RippleDurationProperty, value); }
        }
        public static DependencyProperty RippleDurationProperty =
          DependencyProperty.Register("RippleDuration", typeof(double), typeof(RippleDecorator), null);

        public bool FadeOutAfterRipple
        {
            get { return (bool)base.GetValue(FadeOutAfterRippleProperty); }
            set { base.SetValue(FadeOutAfterRippleProperty, value); }
        }
        public static DependencyProperty FadeOutAfterRippleProperty =
          DependencyProperty.Register("FadeOutAfterRipple", typeof(bool), typeof(RippleDecorator), null);

        public double FadeOutDuration
        {
            get { return (double)base.GetValue(FadeOutDurationProperty); }
            set { base.SetValue(FadeOutDurationProperty, value); }
        }
        public static DependencyProperty FadeOutDurationProperty =
          DependencyProperty.Register("FadeOutDuration", typeof(double), typeof(RippleDecorator), null);

        public RippleDecorator()
        {
            InitializeComponent();
            RippleColor = Colors.White;
            RippleOpacity = 0.3;
            RippleDuration = 0.3;
            FadeOutDuration = 0.4;
            FadeOutAfterRipple = true;

            UpdateColors();
        }
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == RippleColorProperty)
            {
                Ripple.Fill = new SolidColorBrush(RippleColor);
            }
            if (e.Property == RippleOpacityProperty)
            {
                Ripple.Opacity = RippleOpacity;
            }


        }
        public void UpdateColors()
        {
            Ripple.Fill = new SolidColorBrush(RippleColor);
        }
        public void DoRipple()
        {
            Ripple.Visibility = Visibility.Visible;
            var targetWidth = Math.Max(ActualWidth, ActualHeight) * 2;
            Ripple.Width = 0;
            var mousePosition = Mouse.GetPosition(this);
            var startMargin = new Thickness(mousePosition.X, mousePosition.Y, 0, 0);
            Ripple.Margin = startMargin;
            Animations.AnimateFade(0, RippleOpacity, Ripple, 0, 0, null);
            Animations.AnimateRipple(0, targetWidth + 500, Ripple, RippleDuration, startMargin, new Thickness(mousePosition.X - (targetWidth + 500) / 2, mousePosition.Y - (targetWidth + 500) / 2, 0, 0), FadeOutAfterRipple, FadeOutDuration);
        }
     

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateColors();
        }
    }
}

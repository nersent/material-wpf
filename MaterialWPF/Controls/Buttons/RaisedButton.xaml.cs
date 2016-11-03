using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MaterialWPF
{ 
    /// <summary>
    /// Interaction logic for raisedButton.xaml
    /// </summary>
    public partial class raisedButton : UserControl
    {


        public Color FontColor
        {
            get { return (Color)base.GetValue(fontColorProperty); }
            set { base.SetValue(fontColorProperty, value); TextBlock.Foreground = new SolidColorBrush(value); }
        }
        public static DependencyProperty fontColorProperty =
          DependencyProperty.Register("FontColor", typeof(Color), typeof(raisedButton), null);

        public Color BackgroundColor
        {
            get { return (Color)base.GetValue(backgroundColorProperty); }
            set
            {
                base.SetValue(backgroundColorProperty, value); 
            }
        }
        public static DependencyProperty backgroundColorProperty =
          DependencyProperty.Register("BackgroundColor", typeof(Color), typeof(raisedButton), new PropertyMetadata(null));

        public Color RippleColor
        {
            get { return (Color)base.GetValue(rippleColorProperty); }
            set { base.SetValue(rippleColorProperty, value); Ripple.Fill = new SolidColorBrush(value); }
        }
        public static DependencyProperty rippleColorProperty =
          DependencyProperty.Register("RippleColor", typeof(Color), typeof(raisedButton), null);

        public enum States
        {
            Enabled = 1,
            Disabled = 0
        }

        public States RippleState
        {
            get { return (States)base.GetValue(rippleStateProperty); }
            set
            {
                base.SetValue(rippleStateProperty, value);
            }
        }
        public static DependencyProperty rippleStateProperty =
          DependencyProperty.Register("Ripple", typeof(States), typeof(raisedButton), null);


        public double RippleOpacity
        {
            get { return (double)base.GetValue(rippleOpacityProperty); }
            set
            {
                base.SetValue(rippleOpacityProperty, value);
            }
        }

        public static DependencyProperty rippleOpacityProperty =
          DependencyProperty.Register("RippleOpacity", typeof(double), typeof(raisedButton), null);

        public double RippleFadeOutTime
        {
            get { return (double)base.GetValue(RippleFadeOutTimeProperty); }
            set
            {
                base.SetValue(RippleFadeOutTimeProperty, value);
            }
        }
        public static DependencyProperty RippleFadeOutTimeProperty =
          DependencyProperty.Register("RippleFadeOutTime", typeof(double), typeof(raisedButton), null);

        public double RippleEffectTime
        {
            get { return (double)base.GetValue(RippleEffectTimeProperty); }
            set
            {
                base.SetValue(RippleEffectTimeProperty, value);
            }
        }
        public static DependencyProperty RippleEffectTimeProperty =
          DependencyProperty.Register("RippleEffectTime", typeof(double), typeof(raisedButton), null);


        public string Text
        {
            get { return (string)base.GetValue(TextProperty); }
            set
            {
                base.SetValue(TextProperty, value);
            }
        }
        public static DependencyProperty TextProperty =
          DependencyProperty.Register("Text", typeof(string), typeof(raisedButton), new PropertyMetadata(""));

        public bool AutoCaps
        {
            get { return (bool)base.GetValue(AutoCapsProperty); }
            set
            {
                base.SetValue(AutoCapsProperty, value);
                if (value)
                {
                    TextBlock.Typography.Capitals = FontCapitals.AllSmallCaps;
                }
                else
                {
                    TextBlock.Typography.Capitals = FontCapitals.Normal;
                }
            }
        }
        public static DependencyProperty AutoCapsProperty =
          DependencyProperty.Register("AutoCaps", typeof(bool), typeof(raisedButton), new PropertyMetadata(true));

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public double FontSize
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        {
            get { return (double)base.GetValue(FontSizeProperty1); }
            set
            {
                base.SetValue(FontSizeProperty1, value);
            }
        }
        public static DependencyProperty FontSizeProperty1 =
          DependencyProperty.Register("FontSize", typeof(double), typeof(raisedButton), null);

        public raisedButton()
        {
            InitializeComponent();
            RippleColor = (Color)ColorConverter.ConvertFromString("#757575");
            FontSize = 16;
            Text = "button";
            RippleEffectTime = 0.3;
            RippleFadeOutTime = 0.3;
            RippleOpacity = 0.3;
            RippleState = States.Enabled;
            FontColor = (Color)ColorConverter.ConvertFromString("#444");
            BackgroundColor = (Color) ColorConverter.ConvertFromString("#e0e0e0");


        }
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == backgroundColorProperty)
            {
                background.Background = new SolidColorBrush(BackgroundColor);
                colorLeave = BackgroundColor;
            }
            if (e.Property == TextProperty)
            {
                TextBlock.Text = Text;
            }
            if (e.Property == FontSizeProperty1)
            {
                TextBlock.FontSize = FontSize;
            }
            if (e.Property == rippleColorProperty)
            {
                Ripple.Fill = new SolidColorBrush(RippleColor);
            }
            if (e.Property == fontColorProperty)
            {
                TextBlock.Foreground = new SolidColorBrush(FontColor);
            }
            
        }

        public Color ChangeLightness(Color color, float coef)
        {
            return Color.FromArgb(color.A, (byte)(color.R * coef), (byte)(color.G * coef),
                (byte)(color.B * coef));
        }

        private Color colorLeave;

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
            if (RippleState == States.Enabled)
            {
                var targetWidth = Math.Max(ActualWidth, ActualHeight) * 2;
                Ripple.Width = 0;
                var mousePosition = (e as MouseButtonEventArgs).GetPosition(this);
                var startMargin = new Thickness(mousePosition.X, mousePosition.Y, 0, 0);
                Ripple.Margin = startMargin;

                Animations.AnimateFade(0, RippleOpacity, Ripple, 0, 0, null);

                Animations.AnimateRipple(0, targetWidth, Ripple, RippleEffectTime, startMargin, new Thickness(mousePosition.X - targetWidth / 2, mousePosition.Y - targetWidth / 2, 0, 0), true, RippleFadeOutTime);
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


       
    }
}
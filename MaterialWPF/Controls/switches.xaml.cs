using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MaterialWPF
{
    /// <summary>
    /// Interaction logic for switches.xaml
    /// </summary>
    public partial class Switches : UserControl
    {

        public Color ToggledOnColor
        {
            get { return (Color)base.GetValue(toggledOnColorProperty); }
            set { base.SetValue(toggledOnColorProperty, value); }
        }
        public static DependencyProperty toggledOnColorProperty =
          DependencyProperty.Register("ToggledOnColor", typeof(Color), typeof(Switches), null);

        public Color ToggledOffColor
        {
            get { return (Color)base.GetValue(ToggledOffColorProperty); }
            set { base.SetValue(ToggledOffColorProperty, value); }
        }
        public static DependencyProperty ToggledOffColorProperty =
          DependencyProperty.Register("ToggledOffColor", typeof(Color), typeof(Switches), null);

        public Color ToggledOnCircleColor
        {
            get { return (Color)base.GetValue(ToggledOnCircleProperty); }
            set { base.SetValue(ToggledOnCircleProperty, value); }
        }
        public static DependencyProperty ToggledOnCircleProperty =
          DependencyProperty.Register("ToggledOnCircle", typeof(Color), typeof(Switches), null);

        public Color ToggledOffCircleColor
        {
            get { return (Color)base.GetValue(ToggledOffCircleColorProperty); }
            set { base.SetValue(ToggledOffCircleColorProperty, value); }
        }
        public static DependencyProperty ToggledOffCircleColorProperty =
          DependencyProperty.Register("ToggledOffCircleColor", typeof(Color), typeof(Switches), null);

        public bool Checked
        {
            get { return (bool)base.GetValue(CheckedProperty); }
            set { base.SetValue(CheckedProperty, value); }
        }
        public static DependencyProperty CheckedProperty =
          DependencyProperty.Register("Checked", typeof(bool), typeof(Switches), null);

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == ToggledOffColorProperty)
            {
                bg.Background = new SolidColorBrush(ToggledOffColor);

            }
            if (e.Property == ToggledOffCircleColorProperty)
            {
                swichElipse.Fill = new SolidColorBrush(ToggledOffCircleColor);
            }
            if (e.Property == CheckedProperty)
            {
                AutoCheck();
            }
        }

        public Switches()
        {
            InitializeComponent(); 
            ToggledOnCircleColor = (Color)ColorConverter.ConvertFromString("#16a085");
            ToggledOnColor = (Color)ColorConverter.ConvertFromString("#1abc9c");
            ToggledOffCircleColor = (Color)ColorConverter.ConvertFromString("#fff");
            ToggledOffColor = (Color)ColorConverter.ConvertFromString("#818181");
            Checked = false;
            AutoCheck();
        }


        private void AutoCheck()
        {
            Thickness ton = new Thickness(0, 0, 17, 0);
            Thickness toff = new Thickness(17, 0, 0, 0);
            double time = 0.2;
            if (Checked)
            {
                Ripple.Fill = new SolidColorBrush(ToggledOnColor);
                Animations.AnimateFade(0, 0.2, Ripple, 0.1, 0, null);
                Ripple.Height = 0;
                Ripple.Width = 0;
                Animations.AnimateMargin(Ripple.Margin, new Thickness(16, 0, 0, 0), Ripple, 0.2, 0, null);
                Animations.AnimateRipple(0, 38, Ripple, 0.2, true, 0.3);


                Animations.AnimateMargin(swichElipse.Margin, toff, swichElipse, time, 0, null);
                Animations.AnimateColor(ToggledOffCircleColor, ToggledOnCircleColor, swichElipse, 0.2, "Fill");
                Animations.AnimateColor(ToggledOffColor, ToggledOnColor, bg, 0.2, "Background");
            }
            else
            {
                Ripple.Fill = new SolidColorBrush(ToggledOffColor);
                Animations.AnimateFade(0, 0.2, Ripple, 0.1, 0, null);
                Ripple.Height = 0;
                Ripple.Width = 0;
                Animations.AnimateMargin(Ripple.Margin, new Thickness(0, 0, 16, 0), Ripple, 0.2, 0, null);
                Animations.AnimateRipple(0, 38, Ripple, 0.2, true, 0.3);
                Animations.AnimateMargin(swichElipse.Margin, ton, swichElipse, time, 0, null);
                Animations.AnimateColor(ToggledOnCircleColor, ToggledOffCircleColor, swichElipse, 0.2, "Fill");
                Animations.AnimateColor(ToggledOnColor, ToggledOffColor, bg, 0.2, "Background");
            }
        }

        public void change()
        {
            Thickness ton = new Thickness(0, 0, 17, 0);
            Thickness toff = new Thickness(17, 0, 0, 0);
            double time = 0.2;
            if (!Checked)
            {
                Ripple.Fill = new SolidColorBrush(ToggledOnColor);
                Animations.AnimateFade(0, 0.2, Ripple, 0.1, 0, null);
                Ripple.Height = 0;
                Ripple.Width = 0;
                Animations.AnimateMargin(Ripple.Margin, new Thickness(16, 0, 0, 0), Ripple, 0.2, 0, null);
                Animations.AnimateRipple(0, 38, Ripple, 0.2, true, 0.3);


                Animations.AnimateMargin(swichElipse.Margin, toff, swichElipse, time, 0, null);
                Animations.AnimateColor(ToggledOffCircleColor, ToggledOnCircleColor, swichElipse, 0.2, "Fill");
                Animations.AnimateColor(ToggledOffColor, ToggledOnColor, bg, 0.2, "Background");
                Checked = true;
            }
            else
            {
                Ripple.Fill = new SolidColorBrush(ToggledOffColor);
                Animations.AnimateFade(0, 0.2, Ripple, 0.1, 0, null);
                Ripple.Height = 0;
                Ripple.Width = 0;
                Animations.AnimateMargin(Ripple.Margin, new Thickness(0, 0, 16, 0), Ripple, 0.2, 0, null);
                Animations.AnimateRipple(0, 38, Ripple, 0.2, true, 0.3);
                Animations.AnimateMargin(swichElipse.Margin, ton, swichElipse, time, 0, null);
                Animations.AnimateColor(ToggledOnCircleColor, ToggledOffCircleColor, swichElipse, 0.2, "Fill");
                Animations.AnimateColor(ToggledOnColor, ToggledOffColor, bg, 0.2, "Background");
                Checked = false;
            }
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            change();
        }
    }
}
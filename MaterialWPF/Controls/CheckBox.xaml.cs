using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MaterialWPF
{
    /// <summary>
    /// Interaction logic for CheckBox.xaml
    /// </summary>
    public partial class CheckBox : UserControl
    {
        public Color ToggledOnColor
        {
            get { return (Color)base.GetValue(toggledOnColorProperty); }
            set { base.SetValue(toggledOnColorProperty, value); }
        }
        public static DependencyProperty toggledOnColorProperty =
          DependencyProperty.Register("ToggledOnColor", typeof(Color), typeof(CheckBox), null);

        public Color ToggledOffColor
        {
            get { return (Color)base.GetValue(toggledOffColorProperty); }
            set { base.SetValue(toggledOffColorProperty, value); }
        }
        public static DependencyProperty toggledOffColorProperty =
          DependencyProperty.Register("ToggledOffColor", typeof(Color), typeof(CheckBox), null);

        public bool Checked
        {
            get { return (bool)base.GetValue(CheckedProperty); }
            set { base.SetValue(CheckedProperty, value); }
        }
        public static DependencyProperty CheckedProperty =
          DependencyProperty.Register("Checked", typeof(bool), typeof(CheckBox), null);

        public bool CheckOnMouseDown
        {
            get { return (bool)base.GetValue(CheckOnMouseDownProperty); }
            set { base.SetValue(CheckOnMouseDownProperty, value); }
        }
        public static DependencyProperty CheckOnMouseDownProperty =
          DependencyProperty.Register("CheckOnMouseDown", typeof(bool), typeof(CheckBox), null);

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == toggledOffColorProperty)
            {
                border.BorderBrush = new SolidColorBrush(ToggledOffColor);
            }
            if (e.Property == toggledOnColorProperty)
            {
                background.Background = new SolidColorBrush(ToggledOnColor);
                background2.Background = new SolidColorBrush(ToggledOnColor);
            }
            if (e.Property == CheckedProperty)
            {
                AutoCheck();
            }
        }

        public CheckBox()
        {
            InitializeComponent();
            CheckOnMouseDown = true;
            ToggledOffColor = colorConverter.convertToColor("#8c000000");
            ToggledOnColor = colorConverter.convertToColor("#1abc9c");
        }

        

        public void AutoCheck()
        {
            if (Checked)
            {
                background2.Margin = new Thickness(0);
                Ripple.Fill = new SolidColorBrush(ToggledOnColor);
                Animations.AnimateFade(0, 0.2, Ripple, 0.1, 0, null);
                Ripple.Height = 0;
                Ripple.Width = 0;
                Animations.AnimateRipple(0, this.ActualWidth, Ripple, 0.2, true, 0.3);
                Animations.AnimateFade(0, 1, background, 0.2, 0, null);
                Animations.AnimateScale(16, 16, 14, 14, border, 0.2, null);
                Animations.AnimateScale(14, 14, 16, 16, border, 0.2, null);
                Animations.AnimateScale(16, 16, 14, 14, background, 0.2, null);
                Animations.AnimateScale(14, 14, 16, 16, background, 0.2, null);
                Animations.AnimateFade(0, 1, background2, 0.2, 0, null);
                Animations.AnimateMargin(new Thickness(0, 0, 0, 0), new Thickness(16, 0, 0, 0), background2, 0.2, 0.2, null);
            }
            else
            {
                Ripple.Fill = new SolidColorBrush(ToggledOffColor);
                Animations.AnimateFade(0, 0.2, Ripple, 0.1, 0, null);
                Ripple.Height = 0;
                Ripple.Width = 0;
                Animations.AnimateRipple(0, this.ActualWidth, Ripple, 0.2, true, 0.3);
                Animations.AnimateFade(1, 0, background, 0.2, 0, null);
                Animations.AnimateScale(16, 16, 14, 14, border, 0.2, null);
                Animations.AnimateScale(14, 14, 16, 16, border, 0.2, null);
                Animations.AnimateScale(16, 16, 14, 14, background, 0.2, null);
                Animations.AnimateScale(14, 14, 16, 16, background, 0.2, null);
                Animations.AnimateFade(1, 0, background2, 0.2, 0, null);
                Animations.AnimateMargin(new Thickness(16, 0, 0, 0), new Thickness(0, 0, 0, 0), background2, 0.2, 0.2, null);
            }
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (CheckOnMouseDown) {    
                if (!Checked)
                {
                    background2.Margin = new Thickness(0);
                    Ripple.Fill = new SolidColorBrush(ToggledOnColor);
                    Animations.AnimateFade(0, 0.2, Ripple, 0.1, 0, null);
                    Ripple.Height = 0;
                    Ripple.Width = 0;
                    Animations.AnimateRipple(0, this.ActualWidth, Ripple, 0.2, true, 0.3);
                    Animations.AnimateFade(0, 1, background, 0.2, 0, null);
                    Animations.AnimateScale(16, 16, 14, 14, border, 0.2, null);
                    Animations.AnimateScale(14, 14, 16, 16, border, 0.2, null);
                    Animations.AnimateScale(16, 16, 14, 14, background, 0.2, null);
                    Animations.AnimateScale(14, 14, 16, 16, background, 0.2, null);
                    Animations.AnimateFade(0, 1, background2, 0.2, 0, null);
                    Animations.AnimateMargin(new Thickness(0, 0, 0, 0), new Thickness(16, 0, 0, 0), background2, 0.2, 0.2, null);
                    Checked = true;
                } else
                {
                    Ripple.Fill = new SolidColorBrush(ToggledOffColor);
                    Animations.AnimateFade(0, 0.2, Ripple, 0.1, 0, null);
                    Ripple.Height = 0;
                    Ripple.Width = 0;
                    Animations.AnimateRipple(0, this.ActualWidth, Ripple, 0.2, true, 0.3);
                    Animations.AnimateFade(1, 0, background, 0.2, 0, null);
                    Animations.AnimateScale(16, 16, 14, 14, border, 0.2, null);
                    Animations.AnimateScale(14, 14, 16, 16, border, 0.2, null);
                    Animations.AnimateScale(16, 16, 14, 14, background, 0.2, null);
                    Animations.AnimateScale(14, 14, 16, 16, background, 0.2, null);
                    Animations.AnimateFade(1, 0, background2, 0.2, 0, null);
                    Animations.AnimateMargin(new Thickness(16, 0, 0, 0), new Thickness(0, 0, 0, 0), background2, 0.2, 0.2, null);
                    Checked = false;
                }
            }
        }
    }
}

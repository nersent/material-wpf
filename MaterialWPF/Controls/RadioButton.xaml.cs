using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MaterialWPF
{
    /// <summary>
    /// Interaction logic for RadioButton.xaml
    /// </summary>
    public partial class RadioButton : UserControl
    {
        public Color ToggledOnColor
        {
            get { return (Color)base.GetValue(toggledOnColorProperty); }
            set { base.SetValue(toggledOnColorProperty, value); }
        }
        public static DependencyProperty toggledOnColorProperty =
          DependencyProperty.Register("ToggledOnColor", typeof(Color), typeof(RadioButton), null);

        public Color ToggledOffColor
        {
            get { return (Color)base.GetValue(toggledOffColorProperty); }
            set { base.SetValue(toggledOffColorProperty, value);  }
        }
        public static DependencyProperty toggledOffColorProperty =
          DependencyProperty.Register("ToggledOffColor", typeof(Color), typeof(RadioButton), null);

        public bool Checked
        {
            get { return (bool)base.GetValue(CheckedProperty); }
            set { base.SetValue(CheckedProperty, value); }
        }
        public static DependencyProperty CheckedProperty =
          DependencyProperty.Register("Checked", typeof(bool), typeof(RadioButton), null);

        Grid group;

        public RadioButton()
        {
            InitializeComponent();
            ToggledOffColor = colorConverter.convertToColor("#8c000000");
            ToggledOnColor = colorConverter.convertToColor("#1abc9c");
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == toggledOffColorProperty)
            {
                border.BorderBrush = new SolidColorBrush(ToggledOffColor);
                circle.Fill = new SolidColorBrush(ToggledOffColor);
            }
            if (e.Property == CheckedProperty)
            {
                AutoCheck();
            }
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Ripple.Fill = new SolidColorBrush(ToggledOnColor);
            Animations.AnimateFade(0, 0.2, Ripple, 0.1, 0, null);
            Ripple.Height = 0;
            Ripple.Width = 0;
            Animations.AnimateRipple(0, 42, Ripple, 0.2, true, 0.3);
            if (!Checked)
            {
                
                Animations.AnimateFade(0, 0.2, Ripple, 0.1, 0, null);
                Ripple.Height = 0;
                Ripple.Width = 0;
                Animations.AnimateRipple(0, 42, Ripple, 0.2, true, 0.3);
                group = this.Parent as Grid;
                foreach (UIElement ctrl in group.Children)
                {
                    if (ctrl.GetType() == typeof(RadioButton))
                    {
                        RadioButton rb = (ctrl as RadioButton);
                        rb.Checked = true;
                        rb.change();
                    }
                }

                change();
            } 
        }

        private void AutoCheck()
        {
            if (Checked)
            {
                Animations.AnimateColor(ToggledOffColor, ToggledOnColor, border, 0.2, "BorderBrush");
                Animations.AnimateColor(ToggledOffColor, ToggledOnColor, circle, 0.2, "Fill");
                Animations.AnimateScale(0, 0, 7.4999, 7.4999, circle, 0.2, null);
            }
            else
            {
                Animations.AnimateColor(ToggledOnColor, ToggledOffColor, border, 0.2, "BorderBrush");
                Animations.AnimateColor(ToggledOnColor, ToggledOffColor, circle, 0.2, "Fill");
                Animations.AnimateScale(circle.ActualHeight, circle.ActualHeight, 0, 0, circle, 0.2, null);
            }
        }
        public void change()
        {

            if (!Checked)
            {
                Animations.AnimateColor(ToggledOffColor, ToggledOnColor, border, 0.2, "BorderBrush");
                Animations.AnimateColor(ToggledOffColor, ToggledOnColor, circle, 0.2, "Fill");
                Animations.AnimateScale(0, 0, 7.4999, 7.4999, circle, 0.2, null);
                Checked = true;
            }
            else
            {
                Animations.AnimateColor(ToggledOnColor, ToggledOffColor, border, 0.2, "BorderBrush");
                Animations.AnimateColor(ToggledOnColor, ToggledOffColor, circle, 0.2, "Fill");
                Animations.AnimateScale(circle.ActualHeight, circle.ActualHeight, 0, 0, circle, 0.2, null);
                Checked = false;
            }
        }
    }
}
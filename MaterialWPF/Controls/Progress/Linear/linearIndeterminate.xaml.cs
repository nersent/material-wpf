using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace MaterialWPF
{
    /// <summary>
    /// Interaction logic for linearDeterminate.xaml
    /// </summary>
    public partial class linearIndeterminate : UserControl
    {

        public Color BackgroundColor
        {
            get { return (Color)base.GetValue(BackgroundColorProperty); }
            set { base.SetValue(BackgroundColorProperty, value); }
        }
        public static DependencyProperty BackgroundColorProperty =
          DependencyProperty.Register("BackgroundColor", typeof(Color), typeof(linearIndeterminate), null);

        public Color ProgressColor
        {
            get { return (Color)base.GetValue(ProgressColorProperty); }
            set { base.SetValue(ProgressColorProperty, value); }
        }
        public static DependencyProperty ProgressColorProperty =
          DependencyProperty.Register("ProgressColor", typeof(Color), typeof(linearIndeterminate), null);

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == BackgroundColorProperty)
            {
                background.Background = new SolidColorBrush(BackgroundColor);

            }
            if (e.Property ==  ProgressColorProperty)
            {
                DividerFast.Background = new SolidColorBrush(ProgressColor);
                Divider.Background = new SolidColorBrush(ProgressColor);
            }
        }

        PowerEase easingFunction;
        public linearIndeterminate()
        {
            InitializeComponent();
            ProgressColor = colorConverter.convertToColor("#3d87f0");
            BackgroundColor = colorConverter.convertToColor("#c0d4e7");
            easingFunction = new PowerEase();
            easingFunction.EasingMode = EasingMode.EaseInOut;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DividerFast.Width = ActualWidth / 2;
            Divider.Width = ActualWidth / 2;
            Animate();

        }
        private void Animate()
        {
            DividerFast.Margin = new Thickness(-1 * (ActualWidth + DividerFast.ActualWidth), 0, 2, 100);
            Animations.AnimateMargin(new Thickness(-1 * (ActualWidth), 0, 0, 0), new Thickness(-1 * (ActualWidth), 0, 0, 0), DividerFast, 0, 0, null);
            Animations.AnimateMargin(new Thickness(-1 * (ActualWidth), 0, 0, 0), new Thickness(ActualWidth, 0, 0, 0), Divider, 2, 0, easingFunction, null);
            Animations.AnimateMargin(new Thickness(-1*(ActualWidth), 0, 0, 0), new Thickness(ActualWidth, 0, 0, 0),
                DividerFast, 1.2, 1.5, easingFunction, Animate);
        }

    }
}
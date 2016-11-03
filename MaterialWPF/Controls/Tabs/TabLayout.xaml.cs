using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace MaterialWPF
{
    /// <summary>
    /// Interaction logic for TabLayout.xaml
    /// </summary>
    public partial class TabLayout : UserControl
    {
        public Color LineColor
        {
            get { return (Color)base.GetValue(LineColorProperty); }
            set { base.SetValue(LineColorProperty, value); }
        }
        public static DependencyProperty LineColorProperty =
          DependencyProperty.Register("LineColor", typeof(Color), typeof(TabLayout), null);

        public Color TabsBackground
        {
            get { return (Color)base.GetValue(TabsBackgroundProperty); }
            set { base.SetValue(TabsBackgroundProperty, value); }
        }
        public static DependencyProperty TabsBackgroundProperty =
          DependencyProperty.Register("TabsBackground", typeof(Color), typeof(TabLayout), null);

        public Color BackgroundColor
        {
            get { return (Color)base.GetValue(BackgroundColorProperty); }
            set { base.SetValue(BackgroundColorProperty, value); }
        }
        public static DependencyProperty BackgroundColorProperty =
          DependencyProperty.Register("BackgroundColor", typeof(Color), typeof(TabLayout), null);

        public Color TabsHover
        {
            get { return (Color)base.GetValue(TabsHoverProperty); }
            set { base.SetValue(TabsHoverProperty, value); }
        }
        public static DependencyProperty TabsHoverProperty =
          DependencyProperty.Register("TabsHover", typeof(Color), typeof(TabLayout), null);

        public Color RippleColor
        {
            get { return (Color)base.GetValue(RippleColorProperty); }
            set { base.SetValue(RippleColorProperty, value); }
        }
        public static DependencyProperty RippleColorProperty =
          DependencyProperty.Register("RippleColor", typeof(Color), typeof(TabLayout), null);

        public bool DropShadow
        {
            get { return (bool)base.GetValue(DropShadowProperty); }
            set { base.SetValue(DropShadowProperty, value); }
        }
        public static DependencyProperty DropShadowProperty =
          DependencyProperty.Register("DropShadow", typeof(bool), typeof(TabLayout), null);

        public double TabSize
        {
            get { return (double)base.GetValue(TabSizeProperty); }
            set { base.SetValue(TabSizeProperty, value); }
        }
        public static DependencyProperty TabSizeProperty =
          DependencyProperty.Register("TabSize", typeof(double), typeof(TabLayout), null);

        public Thickness TabBarPadding
        {
            get { return (Thickness)base.GetValue(TabBarPaddingProperty); }
            set { base.SetValue(TabBarPaddingProperty, value); }
        }
        public static DependencyProperty TabBarPaddingProperty =
          DependencyProperty.Register("TabBarPadding", typeof(Thickness), typeof(TabLayout), null);

        public enum States
        {
            Enabled = 1,
            Disabled = 0
        }

        public States TabDrag
        {
            get { return (States)base.GetValue(TabDragProperty); }
            set { base.SetValue(TabDragProperty, value); }
        }
        public static DependencyProperty TabDragProperty =
          DependencyProperty.Register("TabDrag", typeof(States), typeof(TabLayout), null);

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == LineColorProperty)
            {
                tabBar.Divider.Background = new SolidColorBrush(LineColor);
            }
            if (e.Property == BackgroundColorProperty)
            {
                tabBar.Background = new SolidColorBrush(BackgroundColor);
            }
            if (e.Property == TabsBackgroundProperty)
            {
                tabBar.TabsBackground = TabsBackground;
            }
            if (e.Property == TabBarPaddingProperty)
            {
                tabBar.canvas.Margin = TabBarPadding;
            }
            if (e.Property == DropShadowProperty)
            {
                tabBar.Effect = DropShadow ? new DropShadowEffect() { Direction = -90, BlurRadius = 7, ShadowDepth = 1, Opacity = 0.4} : null;
            }
        }

        public TabLayout()
        {
            InitializeComponent();
            TabsHover = (Color) ColorConverter.ConvertFromString("#3949AB");
            TabsBackground = (Color)ColorConverter.ConvertFromString("#3F51B5");
            BackgroundColor = (Color) ColorConverter.ConvertFromString("#3F51B5");
            LineColor = (Color) ColorConverter.ConvertFromString("#E91E63");
            RippleColor = Colors.White;
            TabDrag = States.Disabled;
            TabSize = 256;
            TabBarPadding = new Thickness(0);
            DropShadow = true;
        }
      
    }
}

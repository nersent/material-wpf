using System.Windows;
using System.Windows.Controls;

namespace MaterialWPF
{
    /// <summary>
    /// Interaction logic for tooltip.xaml
    /// </summary>
    public partial class Tooltip : UserControl
    {

        public string Text
        {
            get { return (string)base.GetValue(TextProperty); }
            set { base.SetValue(TextProperty, value); }
        }
        public static DependencyProperty TextProperty =
          DependencyProperty.Register("Text", typeof(string), typeof(Tooltip), null);


        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == TextProperty)
            {
                ContentText.Text = Text;
            }

        }

        private double marginTop;
        public Tooltip()
        {
            InitializeComponent();
            Text = "Tooltip";
            Loaded += Tooltip_Loaded;
        }

        private void Tooltip_Loaded(object sender, RoutedEventArgs e)
        {
            marginTop = Margin.Top;
            Visibility=Visibility.Hidden;
        }

        public void Show()
        {
            Visibility = Visibility.Visible;
            Animations.AnimateFade(0, 0.8, grid, 0.2, 0, null);
            Animations.AnimateMargin(new Thickness(Margin.Left, marginTop - 10, Margin.Right, Margin.Bottom), new Thickness(Margin.Left, marginTop, Margin.Right, Margin.Bottom), this, 0.2, 0, null);
        }

        public void Hide()
        {
            Animations.AnimateFade(0.8, 0, grid, 0.2, 0, null);
            Animations.AnimateMargin(new Thickness(Margin.Left, marginTop, Margin.Right, Margin.Bottom), new Thickness(Margin.Left, marginTop - 10, Margin.Right, Margin.Bottom), this, 0.2, 0, null);
        }
    }
}
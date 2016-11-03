using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace MaterialWPF
{
    /// <summary>
    /// Interaction logic for TextField.xaml
    /// </summary>
    public partial class Input : UserControl
    {
        public Color AccentColor
        {
            get { return (Color)base.GetValue(AccentColorProperty); }
            set { base.SetValue(AccentColorProperty, value); }
        }
        public static DependencyProperty AccentColorProperty =
          DependencyProperty.Register("AccentColor", typeof(Color), typeof(Input), null);

        public Color PrimaryColor
        {
            get { return (Color)base.GetValue(PrimaryColorProperty); }
            set { base.SetValue(PrimaryColorProperty, value); }
        }
        public static DependencyProperty PrimaryColorProperty =
          DependencyProperty.Register("PrimaryColor", typeof(Color), typeof(Input), null);

        public bool FloatingLabelEnabled
        {
            get { return (bool)base.GetValue(FloatingLabelEnabledProperty); }
            set { base.SetValue(FloatingLabelEnabledProperty, value); }
        }
        public static DependencyProperty FloatingLabelEnabledProperty =
          DependencyProperty.Register("FloatingLabelEnabled", typeof(bool), typeof(Input), null);

        public string FloatingLabelText
        {
            get { return (string)base.GetValue(FloatingLabelTextProperty); }
            set { base.SetValue(FloatingLabelTextProperty, value); }
        }
        public static DependencyProperty FloatingLabelTextProperty =
          DependencyProperty.Register("FloatingLabelText", typeof(string), typeof(Input), null);

        public string Text
        {
            get {
                  return (string)base.GetValue(TextProperty); 
                 // return Content.Text;
                }
            set { base.SetValue(TextProperty, value); }
        }
        public static DependencyProperty TextProperty =
          DependencyProperty.Register("Text", typeof(string), typeof(Input), null);

        public Color FontColor
        {
            get { return (Color)base.GetValue(FontColorProperty); }
            set { base.SetValue(FontColorProperty, value); }
        }
        public static DependencyProperty FontColorProperty =
          DependencyProperty.Register("FontColor", typeof(Color), typeof(Input), null);

        public FontFamily Font
        {
            get { return (FontFamily)base.GetValue(FontProperty); }
            set { base.SetValue(FontProperty, value); }
        }
        public static DependencyProperty FontProperty =
          DependencyProperty.Register("Font", typeof(FontFamily), typeof(Input), null);

        public bool Multiline
        {
            get { return (bool)base.GetValue(MultilineProperty); }
            set { base.SetValue(MultilineProperty, value); }
        }
        public static DependencyProperty MultilineProperty =
          DependencyProperty.Register("Multiline", typeof(bool), typeof(Input), null);

        public double TextSize
        {
            get { return (double)base.GetValue(TextSizeProperty); }
            set { base.SetValue(TextSizeProperty, value); }
        }
        public static DependencyProperty TextSizeProperty =
          DependencyProperty.Register("TextSize", typeof(double), typeof(Input), null);

        public TextAlignment TextAlignment
        {
            get { return (TextAlignment)base.GetValue(TextAlignmentProperty); }
            set { base.SetValue(TextAlignmentProperty, value); }
        }
        public static DependencyProperty TextAlignmentProperty =
          DependencyProperty.Register("TextAlignment", typeof(TextAlignment), typeof(Input), null);

        public bool ReadOnly
        {
            get { return (bool)base.GetValue(ReadOnlyProperty); }
            set { base.SetValue(ReadOnlyProperty, value); }
        }
        public static DependencyProperty ReadOnlyProperty =
          DependencyProperty.Register("ReadOnly", typeof(bool), typeof(Input), null);

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == AccentColorProperty)
            {
                Highlight.Background = new SolidColorBrush(AccentColor);
            }
            if (e.Property == PrimaryColorProperty)
            {
                BottomLine.Background = new SolidColorBrush(PrimaryColor);
                FloatingLabel.Foreground = new SolidColorBrush(PrimaryColor);
            }
            if (e.Property == FloatingLabelEnabledProperty)
            {
                FloatingLabel.Visibility = FloatingLabelEnabled ? Visibility.Visible : Visibility.Hidden;
            }
            if (e.Property == FloatingLabelTextProperty)
            {
                FloatingLabel.Text = FloatingLabelText;
            }
            if (e.Property == TextProperty)
            {
                if (!string.IsNullOrEmpty(Text))
                EnterAnimation();

                Content.Text = Text;
            }
            if (e.Property == FontProperty)
            {
                Content.FontFamily = Font;
            }
            if (e.Property == FontColorProperty)
            {
                Content.Foreground = new SolidColorBrush(FontColor);
            }
            if (e.Property == TextSizeProperty)
            {
                Content.FontSize = TextSize;
            }
            if (e.Property == MultilineProperty)
            {
                Content.AcceptsReturn = Multiline;
                Content.TextWrapping = Multiline ? TextWrapping.Wrap : TextWrapping.NoWrap;
            }
            if (e.Property == TextAlignmentProperty)
            {
                Content.TextAlignment = TextAlignment;
            }
            if (e.Property == ReadOnlyProperty)
            {
                Content.IsReadOnly = ReadOnly;
            }

        }


        public Input()
        {
            InitializeComponent();
            AccentColor = colorConverter.convertToColor("#1abc9c");
            PrimaryColor = colorConverter.convertToColor("#444");
            FloatingLabelText = "Floating label";
            FloatingLabelEnabled = true;
            Content.LostFocus += Content_LostFocus;
            Text = "";
            Font = new FontFamily(new Uri("pack://application:,,,/MaterialWPF;component/Fonts/Roboto/"), "./#Roboto");
            FontColor = colorConverter.convertToColor("#444");
            TextSize = 12;
            Multiline = false;
            TextAlignment = TextAlignment.Left;
            ReadOnly = false;
        }

        public void EnterAnimation()
        {
            Animations.AnimateWidth(Highlight.ActualWidth, this.ActualWidth, Highlight, 0.2, 0, () => Highlight.Width = double.NaN);
            Animations.AnimateMargin(FloatingLabel.Margin, new Thickness(2, 0, 2, 2), FloatingLabel, 0.2, 0, null);
            Animations.AnimateScale(scale.ScaleX, 0.75, FloatingLabel, 0.2, null);
            Animations.AnimateFade(FloatingLabel.Opacity, 1, FloatingLabel, 0.2, 0, null);
            var solidColorBrush = Highlight.Background as SolidColorBrush;
            if (solidColorBrush != null)
            {
                var colorBrush = FloatingLabel.Foreground as SolidColorBrush;
                if (colorBrush != null)
                    Animations.AnimateColor(colorBrush.Color, solidColorBrush.Color, FloatingLabel, 0.2, "Foreground");
            }

        }

        private void Content_LostFocus(object sender, RoutedEventArgs e)
        {
            Animations.AnimateWidth(Highlight.ActualWidth, 0, Highlight, 0.2, 0,
                           null);
            if (string.IsNullOrEmpty(Content.Text))
            {
                Animations.AnimateMargin(FloatingLabel.Margin, new Thickness(2, 14, 2, 2), FloatingLabel,
                    0.2, 0, null);
                Animations.AnimateScale(scale.ScaleX, 1, FloatingLabel, 0.2, null);

            }
            Animations.AnimateFade(FloatingLabel.Opacity, 0.5, FloatingLabel, 0.2, 0, null);
            var solidColorBrush = FloatingLabel.Foreground as SolidColorBrush;
            if (solidColorBrush != null)
            {
                Animations.AnimateColor(solidColorBrush.Color, PrimaryColor, FloatingLabel, 0.2,
                    "Foreground");
            }
           
        }

        public static Rect BoundsRelativeTo(FrameworkElement child, Visual parent)
        {
            GeneralTransform gt = child.TransformToAncestor(parent);
            return gt.TransformBounds(new Rect(0, 0, child.ActualWidth, child.ActualHeight));
        }

        private void Content_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EnterAnimation();
            Content.Focus();
        }

        private void Content_KeyUp(object sender, KeyEventArgs e)
        {
            Text = Content.Text;
        }
    }
}
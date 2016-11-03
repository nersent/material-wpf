using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MaterialWPF
{
    public partial class Dialog : UserControl
    {
        TextBlock header, body;

        public enum States
        {
           Enabled = 1,
           Disabled = 0 
        }
        private Grid _blurTarget;

        public string DarkTarget
        {
            get { return (string)base.GetValue(DarkTargetProperty); }
            set { base.SetValue(DarkTargetProperty, value); }
        }
        public static DependencyProperty DarkTargetProperty =
          DependencyProperty.Register("DarkTarget", typeof(string), typeof(Dialog), null);

        public string Body
        {
            get { return (string)base.GetValue(BodyProperty); }
            set { base.SetValue(BodyProperty, value); }
        }
        public static DependencyProperty BodyProperty =
          DependencyProperty.Register("Body", typeof(string), typeof(Dialog), null);

        public string Title
        {
            get { return (string)base.GetValue(TitleProperty); }
            set { base.SetValue(TitleProperty, value); }
        }
        public static DependencyProperty TitleProperty =
          DependencyProperty.Register("Title", typeof(string), typeof(Dialog), null);

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == BodyProperty)
            {
                if (body != null)
                body.Text = Body;
            }
            if (e.Property == TitleProperty)
            {
                if (header != null)
                    header.Text = Title;
            }
            if (e.Property == DarkTargetProperty)
            {
                if (Parent.GetType() == typeof(Grid))
                _blurTarget = (Parent as Grid);
            }


        }


        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            Arrange(new Rect(0, 0, this.DesiredSize.Height, this.DesiredSize.Height));
            header = new TextBlock()
            {

                FontFamily = new FontFamily(new Uri("pack://application:,,,/Fonts/Roboto/"), "./#Roboto"),
                FontSize = 20,
                Text = Title,
                Margin = new Thickness(16),
                Height = double.NaN,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            body = new TextBlock()
            {
                FontFamily = new FontFamily(new Uri("pack://application:,,,/Fonts/Roboto/"), "./#Roboto"),
                FontSize = 14,
                Text = Body,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000")),
                Opacity = 0.54,
                Margin = new Thickness(16, 48, 16, 16),
                Height = double.NaN,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                TextWrapping = TextWrapping.WrapWithOverflow,
                TextTrimming = TextTrimming.WordEllipsis,
                Width = double.NaN
            };




            Border border = new Border()
            {
                Background = new SolidColorBrush(Colors.White),
                CornerRadius = new CornerRadius(2),
                VerticalAlignment = System.Windows.VerticalAlignment.Stretch,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch
            };

            Grid grid = new Grid();

            ContentPresenter content = new ContentPresenter();
            content.Content = Content;
            ScaleTransform scale = new ScaleTransform(1.0, 1.0);
            this.RenderTransformOrigin = new Point(0.5, 0.5);
            this.RenderTransform = scale;
            grid.Children.Add(content);
            grid.Children.Add(header);
            grid.Children.Add(body);
            border.Child = grid;

            Content = border;

            Loaded += (sender, args) =>
            {
                if (!DesignerProperties.GetIsInDesignMode(this))
                {
                    Visibility = Visibility.Hidden;
                }
            };

        }
        private Grid grid;
        private int oldZIndex;
        public void Show()
        {
            this.Visibility = Visibility.Visible;
            Animations.AnimateFade(0, 1, this, 0.1, 0, null);
            Animations.AnimateScale(0, 1, this, 0.1, null);
             grid = new Grid()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Opacity = 0,
                Background = new SolidColorBrush(Colors.Black)
            };
            _blurTarget.Children.Add(grid);
            Animations.AnimateFade(0, 0.5, grid, 0.1, 0, null);
            oldZIndex = Panel.GetZIndex(this);
           Panel.SetZIndex(this, Int32.MaxValue);
        }
        public void Hide()
        {

            this.Visibility = Visibility.Visible;
            Animations.AnimateFade(1, 0, this, 0.1, 0, null);
            Animations.AnimateScale(1, 0, this, 0.1, null);
            Animations.AnimateFade(0.5, 0, grid, 0.1, 0, () =>
            {
                grid.Visibility = Visibility.Hidden;
                Panel.SetZIndex(this, oldZIndex);
            });
           

        }
    }
}

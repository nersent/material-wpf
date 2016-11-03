using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace MaterialWPF
{
    /// <summary>
    /// Interaction logic for Slider.xaml
    /// </summary>
    public partial class Slider : UserControl
    {
        public int Value
        {
            get { return (int)base.GetValue(ValueProperty); }
            set { base.SetValue(ValueProperty, value); }
        }

        public static DependencyProperty ValueProperty =
          DependencyProperty.Register("Value", typeof(int), typeof(Slider), null);

        public Color AccentColor
        {
            get { return (Color)base.GetValue(AccentColorProperty); }
            set { base.SetValue(AccentColorProperty, value); }
        }

        public static DependencyProperty AccentColorProperty =
          DependencyProperty.Register("AccentColor", typeof(Color), typeof(Slider), null);

        public bool ValueLabelEnabled
        {
            get { return (bool)base.GetValue(ValueLabelEnabledProperty); }
            set { base.SetValue(ValueLabelEnabledProperty, value); }
        }

        public static DependencyProperty ValueLabelEnabledProperty =
          DependencyProperty.Register("ValueLabelEnabled", typeof(bool), typeof(Slider), null);

        public Color BackgroundColor
        {
            get { return (Color)base.GetValue(BackgroundColorProperty); }
            set { base.SetValue(BackgroundColorProperty, value); }
        }

        public static DependencyProperty BackgroundColorProperty =
          DependencyProperty.Register("BackgroundColor", typeof(Color), typeof(Slider), null);

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == ValueProperty)
            {
                UpdateValues();
            }
            if (e.Property == AccentColorProperty)
            {
                TearPath.Fill = new SolidColorBrush(AccentColor);
                Thumb.Fill = new SolidColorBrush(AccentColor);
                Progress.Background = new SolidColorBrush(AccentColor);
            }
            if (e.Property == BackgroundColorProperty)
            {
                Bg.Background = new SolidColorBrush(BackgroundColor);
                
            }
            if (e.Property == ValueLabelEnabledProperty)
            {
                if (ValueLabelEnabled)
                {
                    ValueLabel.Visibility = Visibility.Visible;
                    ValueLabel.Opacity = 0;
                }
                else
                {
                    ValueLabel.Visibility = Visibility.Hidden;
                    ValueLabel.Opacity = 0;
                }
            }


        }

        private void UpdateValues()
        {
            Dispatcher.Invoke(() => {
                Progress.Width = Procent.intX(Bg.ActualWidth, Value);
                Animations.AnimateMargin(ValueLabel.Margin, new Thickness(Procent.intX(Bg.ActualWidth, Value) - Thumb.ActualWidth / 2, ValueLabel.Margin.Top, ValueLabel.Margin.Right, ValueLabel.Margin.Bottom), ValueLabel, 0,
    0, null);
                Val.Text = Value + "";
                ThumbMove.Margin = new Thickness(Procent.intX(Bg.ActualWidth, Value) - Thumb.ActualWidth / 2, 0, 0, 0);
            });
        }

        public Slider()
        {
            InitializeComponent();
            Value = 0;
            AccentColor = colorConverter.convertToColor("#1abc9c");
            BackgroundColor = colorConverter.convertToColor("#BDBDBD");
            Thumb.RenderTransformOrigin = new Point(0.5, 0.5);
            Ripple.RenderTransformOrigin = new Point(0.5, 0.5);
            ValueLabelEnabled = false;

            DispatcherTimer dt = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 0, 0, 1)
            };
            dt.Tick += Dt_Tick;
            dt.Start();
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            if (ValueLabelEnabled)
            {
                ValueLabel.Visibility = Visibility.Visible;
                ValueLabel.Opacity = 0;
            }
            else
            {
                ValueLabel.Visibility = Visibility.Hidden;
                ValueLabel.Opacity = 0;
            }
        }

        private bool isCaptured = false;
        private void Thumb_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (isCaptured)
                {
                    if (e.LeftButton == MouseButtonState.Pressed)
                    {
                        if (!(e.GetPosition(this).X - Thumb.ActualWidth / 2 >= Bg.ActualWidth - Thumb.ActualWidth / 2 + 26))
                        {
                            if (!(e.GetPosition(this).X - Thumb.ActualWidth / 2 <= 25 - Thumb.ActualWidth / 2 - 1))
                            {
                                ThumbMove.Margin = new Thickness(e.GetPosition(this).X - Thumb.ActualWidth / 2 - 25, 0, 0, 0);
                                Progress.Width = e.GetPosition(this).X + Thumb.ActualWidth / 2 - 25;
                                Animations.AnimateMargin(new Thickness(ValueLabel.Margin.Left, -4, 0, -2), new Thickness(e.GetPosition(this).X - Thumb.ActualWidth / 2 - 26, -4, 0, 4), ValueLabel, 0,
    0, null);
                                ValueLabel.Margin = new Thickness(e.GetPosition(this).X - Thumb.ActualWidth / 2 - 26, -4, 0, 4);
                                Panel.SetZIndex(Thumb, Int32.MaxValue);
                                Value = (int)Procent.procentX(Bg.ActualWidth, e.GetPosition(this).X - 25);
                                Val.Text = Value + "";
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void Thumb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isCaptured = true;
            
            Animations.AnimateScale(1, 1.2, Thumb, 0.1, null);
            if (ValueLabelEnabled)
            {
                Animations.AnimateMargin(new Thickness(ValueLabel.Margin.Left, -4, 0, -2),
                    new Thickness(ValueLabel.Margin.Left, -4, 0, 4), ValueLabel, 0.2,
                    0, null);
                Animations.AnimateFade(0, 1, ValueLabel, 0.2, 0, null);
            }
            Ripple.Fill = new SolidColorBrush(AccentColor);
            Animations.AnimateFade(0, 0.25, Ripple, 0, 0, null);
            Animations.AnimateScale(0, 1, Ripple, 0.2, null);
            Thumb.CaptureMouse();
        }

        private void Thumb_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            isCaptured = false;
            Thumb.ReleaseMouseCapture();
            Animations.AnimateScale(1.2, 1, Thumb, 0.1, null);
            if (ValueLabelEnabled)
            {
                Animations.AnimateMargin(new Thickness(ValueLabel.Margin.Left, -4, 0, 4),
                    new Thickness(ValueLabel.Margin.Left, -4, 0, -2), ValueLabel, 0.2,
                    0, null);
                Animations.AnimateFade(1, 0, ValueLabel, 0.2, 0, null);
            }
            Animations.AnimateFade(0.25, 0, Ripple, 0.3, 0, null);
        }

        private void Thumb_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            try
            {
                ThumbMove.Margin = new Thickness(Procent.intX(Bg.ActualWidth, Value) - Thumb.ActualWidth/2, 0, 0, 0);
                Progress.Width = Procent.intX(Bg.ActualWidth, Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}

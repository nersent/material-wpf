using MaterialWPF.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaterialWPF.Components.Ripple
{
    /// <summary>
    /// Interaction logic for Ripple.xaml
    /// </summary>
    public partial class Ripple : UserControl
    {

        public Color RippleColor
        {
            get { return (Color)base.GetValue(RippleColorProperty); }
            set { base.SetValue(RippleColorProperty, value); }
        }
        public static DependencyProperty RippleColorProperty =
          DependencyProperty.Register("RippleColor", typeof(Color), typeof(Ripple), null);

        public double RippleOpacity
        {
            get { return (double)base.GetValue(RippleOpacityProperty); }
            set { base.SetValue(RippleOpacityProperty, value); }
        }
        public static DependencyProperty RippleOpacityProperty =
          DependencyProperty.Register("RippleOpacity", typeof(double), typeof(Ripple), null);

        public double RippleDuration
        {
            get { return (double)base.GetValue(RippleDurationProperty); }
            set { base.SetValue(RippleDurationProperty, value); }
        }
        public static DependencyProperty RippleDurationProperty =
          DependencyProperty.Register("RippleDuration", typeof(double), typeof(Ripple), null);

        public double FadeOutDuration
        {
            get { return (double)base.GetValue(FadeOutDurationProperty); }
            set { base.SetValue(FadeOutDurationProperty, value); }
        }
        public static DependencyProperty FadeOutDurationProperty =
          DependencyProperty.Register("FadeOutDuration", typeof(double), typeof(Ripple), null);

        private List<Ellipse> ripples = new List<Ellipse>();

        public Ripple()
        {
            InitializeComponent();

            RippleColor = Colors.White;
            RippleOpacity = 0.3;
            RippleDuration = 0.3;
            FadeOutDuration = 0.4;
        }

        /// <summary>
        /// Starts animating ripple.
        /// </summary>

        public void CreateRipple()
        {
            Ellipse ripple = new Ellipse();
            var mousePosition = Mouse.GetPosition(this);
            var startMargin = new Thickness(mousePosition.X, mousePosition.Y, 0, 0);
            var endWidth = Math.Max(ActualWidth, ActualHeight) * 2.2;

            ripple.Width = 0;
            ripple.Height = 0;
            ripple.VerticalAlignment = VerticalAlignment.Top;
            ripple.HorizontalAlignment = HorizontalAlignment.Left;

            ripple.Fill = new SolidColorBrush(RippleColor);
            ripple.Opacity = RippleOpacity;

            ripple.Margin = startMargin;

            RippleContainer.Children.Add(ripple);

            Thickness endMargin = new Thickness(mousePosition.X - endWidth / 2, mousePosition.Y - endWidth / 2, 0, 0);

            Animations.AnimateRipple(0, endWidth, startMargin, endMargin, ripple, RippleDuration);

            ripples.Add(ripple);
        }

        /// <summary>
        /// Fades out ripple and removes it from RippleContainer.
        /// </summary>

        public void RemoveRipple()
        {
            foreach (var ripple in ripples)
            {
                Animations.AnimateOpacity(ripple.Opacity, 0, ripple, FadeOutDuration, ()=>
                {
                    RippleContainer.Children.Remove(ripple);
                });
            }
        }
    }
}

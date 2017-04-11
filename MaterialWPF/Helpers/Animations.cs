using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace MaterialWPF.Helpers
{
    class Animations
    {

        /// <summary>
        /// Animates opacity from value to value.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="control"></param>
        /// <param name="duration"></param>
        /// <param name="callback"></param>

        public static void AnimateOpacity(double from, double to, UIElement control, double duration, Action callback = null)
        {
            var opacityAnimation = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(duration)
            };

            Storyboard.SetTarget(opacityAnimation, control);
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));

            var sb = new Storyboard();
            sb.Children.Add(opacityAnimation);
            sb.Completed += (sender, args) => callback?.Invoke();
            sb.Begin();
        }

        /// <summary>
        /// Animates scale.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="control"></param>
        /// <param name="duration"></param>
        /// <param name="callback"></param>

        public static void AnimateScale(double from, double to, UIElement control, double duration, Action callback = null)
        {
            var scaleAnimationY = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(duration)

            };
            Storyboard.SetTarget(scaleAnimationY, control);
            Storyboard.SetTargetProperty(scaleAnimationY, new PropertyPath("RenderTransform.Children[0].ScaleY"));

            var scaleAnimationX = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(duration)
            };
            Storyboard.SetTarget(scaleAnimationX, control);
            Storyboard.SetTargetProperty(scaleAnimationX, new PropertyPath("RenderTransform.Children[0].ScaleX"));

            var sb = new Storyboard();
            sb.Children.Add(scaleAnimationY);
            sb.Children.Add(scaleAnimationX);
            sb.Completed += (sender, args) => callback?.Invoke();
            sb.Begin();
        }

        /// <summary>
        /// Animates ripple.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="fromPosition"></param>
        /// <param name="toPosition"></param>
        /// <param name="control"></param>
        /// <param name="duration"></param>
        /// <param name="callback"></param>

        public static void AnimateRipple(double from, double to, Thickness fromPosition, Thickness toPosition, UIElement control, double duration, Action callback = null)
        {
            var thicknessAnimation = new ThicknessAnimation
            {
                From = fromPosition,
                To = toPosition,
                Duration = TimeSpan.FromSeconds(duration)

            };
            var ease = new PowerEase()
            {
                EasingMode = EasingMode.EaseOut
            };
            thicknessAnimation.EasingFunction = ease;
            Storyboard.SetTarget(thicknessAnimation, control);
            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath(FrameworkElement.MarginProperty));

            var widthAnimation = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(duration)
            };
            widthAnimation.EasingFunction = ease;
            Storyboard.SetTarget(widthAnimation, control);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(FrameworkElement.WidthProperty));

            var heightAnimation = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(duration)
            };
            heightAnimation.EasingFunction = ease;
            Storyboard.SetTarget(heightAnimation, control);
            Storyboard.SetTargetProperty(heightAnimation, new PropertyPath(FrameworkElement.HeightProperty));

            var sb = new Storyboard();
            sb.Children.Add(heightAnimation);
            sb.Children.Add(widthAnimation);
            sb.Children.Add(thicknessAnimation);
            sb.Completed += (o, e) => callback?.Invoke();
            sb.Begin();
        }
    }
}

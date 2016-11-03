namespace MaterialWPF
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Animation;

    public static class Animations
    {
        public static void AnimateWidth(double from, double to, UIElement control, double duration, double startTime, Action completed)
        {
            var fade = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(duration),
                BeginTime = TimeSpan.FromSeconds(startTime)
            };
            Storyboard.SetTarget(fade, control);
            Storyboard.SetTargetProperty(fade, new PropertyPath(FrameworkElement.WidthProperty));


            var sb = new Storyboard();
            sb.Children.Add(fade);
            sb.Completed += (sender, args) => completed?.Invoke();
            sb.Begin();

        }
        public static void AnimateHeight(double from, double to, UIElement control, double duration, double startTime, Action completed)
        {
            var fade = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(duration),
                BeginTime = TimeSpan.FromSeconds(startTime)
            };
            Storyboard.SetTarget(fade, control);
            Storyboard.SetTargetProperty(fade, new PropertyPath(FrameworkElement.HeightProperty));


            var sb = new Storyboard();
            sb.Children.Add(fade);
            sb.Completed += (sender, args) => completed?.Invoke();
            sb.Begin();

        }
        public static void AnimateScale(double from, double to, UIElement control, double duration, Action completed)
        {
            var fade = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(duration)

            };
            Storyboard.SetTarget(fade, control);
            Storyboard.SetTargetProperty(fade, new PropertyPath("RenderTransform.ScaleY"));

            var fade2 = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(duration)
            };
            Storyboard.SetTarget(fade2, control);
            Storyboard.SetTargetProperty(fade2, new PropertyPath("RenderTransform.ScaleX"));


            var sb = new Storyboard();
            sb.Children.Add(fade2);
            sb.Children.Add(fade);
            sb.Completed += (sender, args) => completed?.Invoke();
            sb.Begin();


        }
        public static void AnimateScale(double fromX, double fromY, double toX,double toY, UIElement control, double duration, Action completed)
        {
            var fade = new DoubleAnimation
            {
                From = fromX,
                To = toX,
                Duration = TimeSpan.FromSeconds(duration)
            };
            Storyboard.SetTarget(fade, control);
            Storyboard.SetTargetProperty(fade, new PropertyPath(FrameworkElement.HeightProperty));

            var fade2 = new DoubleAnimation
            {
                From = fromY,
                To = toY,
                Duration = TimeSpan.FromSeconds(duration)
            };
            Storyboard.SetTarget(fade2, control);
            Storyboard.SetTargetProperty(fade2, new PropertyPath(FrameworkElement.WidthProperty));


            var sb = new Storyboard();
            sb.Children.Add(fade2);
            sb.Children.Add(fade);
            sb.Completed += (sender, args) => completed?.Invoke();
            sb.Begin();


        }

        public static void AnimateRipple(double from, double to, UIElement control, double duration, Thickness fromT, Thickness toT, bool fadeOut, double fadeOutTime)
        {
            var fade = new ThicknessAnimation
            {
                From = fromT,
                To = toT,
                Duration = TimeSpan.FromSeconds(duration)
            };
            Storyboard.SetTarget(fade, control);
            Storyboard.SetTargetProperty(fade, new PropertyPath(FrameworkElement.MarginProperty));


            var fade2 = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(duration)
            };
            Storyboard.SetTarget(fade2, control);
            Storyboard.SetTargetProperty(fade2, new PropertyPath(FrameworkElement.WidthProperty));


            var sb = new Storyboard();
            sb.Children.Add(fade2);
            sb.Children.Add(fade);
            if (fadeOut)
            {
                sb.Completed +=
        (o, e1) => { AnimateFade(control.Opacity, 0, control, fadeOutTime, 0, null); };
            }
            sb.Begin();
        }



        public static void AnimateRipple(double from, double to, UIElement control, double duration, bool fadeOut, double fadeOutTime)
        {
            var fade2 = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(duration)
            };
            Storyboard.SetTarget(fade2, control);
            Storyboard.SetTargetProperty(fade2, new PropertyPath(FrameworkElement.WidthProperty));

            var fade = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(duration)
            };
            Storyboard.SetTarget(fade, control);
            Storyboard.SetTargetProperty(fade, new PropertyPath(FrameworkElement.HeightProperty));


            var sb = new Storyboard();
            sb.Children.Add(fade2);
            sb.Children.Add(fade);
            if (fadeOut)
            {
                sb.Completed +=
        (o, e1) => { AnimateFade(control.Opacity, 0, control, fadeOutTime, 0, null); };
            }
            sb.Begin();
        }


        public static void AnimateMargin(Thickness from, Thickness to, UIElement control, double duration, double startTime, Action completed)
        {
            var fade = new ThicknessAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(duration),
                BeginTime = TimeSpan.FromSeconds(startTime)
            };
            Storyboard.SetTarget(fade, control);
            Storyboard.SetTargetProperty(fade, new PropertyPath(FrameworkElement.MarginProperty));

            var sb = new Storyboard();
            sb.Children.Add(fade);
            sb.Completed += (sender, args) =>
            {
                completed?.Invoke();
            };
            sb.Begin();



        }
        public static void AnimateMargin(Thickness from, Thickness to, UIElement control, double duration, double startTime, IEasingFunction es, Action completed)
        {
            var fade = new ThicknessAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(duration),
                BeginTime = TimeSpan.FromSeconds(startTime)
            };
            Storyboard.SetTarget(fade, control);
            Storyboard.SetTargetProperty(fade, new PropertyPath(FrameworkElement.MarginProperty));

            var sb = new Storyboard();
            fade.EasingFunction = es;
            sb.Children.Add(fade);
            sb.Completed += (sender, args) =>
            {
                completed?.Invoke();
            };
            sb.Begin();



        }
       
        public static void AnimateFade(double from, double to, UIElement control, double duration, double startTime, Action completed)
        {
            var fade = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(duration),
                BeginTime = TimeSpan.FromSeconds(startTime)
            };
            Storyboard.SetTarget(fade, control);
            Storyboard.SetTargetProperty(fade, new PropertyPath(UIElement.OpacityProperty));

            var sb = new Storyboard();
            sb.Children.Add(fade);
            sb.Completed += (sender, args) => completed?.Invoke();
            sb.Begin();

        }

        public static void AnimateRotate(double from, double to, UIElement control, double duration, double startTime, Action completed)
        {
            var fade = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(duration),
                BeginTime = TimeSpan.FromSeconds(startTime)
            };
            Storyboard.SetTarget(fade, control);
            Storyboard.SetTargetProperty(fade, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));

            var sb = new Storyboard();
            sb.Children.Add(fade);
            sb.Completed += (sender, args) => completed?.Invoke();
            sb.Begin();

        }


        public static void AnimateColor(System.Windows.Media.Color from, System.Windows.Media.Color to, UIElement control, double duration, string type)
        {
            /*
             * Typy:
             * BorderBrush - border
             * Fill - rectangle, ellipse itd
             * Background - wszystko inne
             */
            SolidColorBrush myBrush = new SolidColorBrush();
            myBrush.Color = from;
            ColorAnimation myColorAnimation = new ColorAnimation();
            myColorAnimation.From = from;
            myColorAnimation.To = to;
            myColorAnimation.Duration = new Duration(TimeSpan.FromSeconds(duration));
            myBrush.BeginAnimation(SolidColorBrush.ColorProperty, myColorAnimation);
            control.GetType().GetProperty(type).SetValue(control, myBrush);
        }
        public static void AnimateColor(SolidColorBrush from, SolidColorBrush to, UIElement control, double duration, string type)
        {
            /*
             * Typy:
             * BorderBrush - border
             * Fill - rectangle, ellipse itd
             * Background - wszystko inne
             */
            SolidColorBrush myBrush = new SolidColorBrush();
            myBrush = from;
            ColorAnimation myColorAnimation = new ColorAnimation();
            myColorAnimation.From = from.Color;
            myColorAnimation.To = to.Color;
            myColorAnimation.Duration = new Duration(TimeSpan.FromSeconds(duration));
            myBrush.BeginAnimation(SolidColorBrush.ColorProperty, myColorAnimation);
            control.GetType().GetProperty(type).SetValue(control, myBrush);
        }
       
    }
}
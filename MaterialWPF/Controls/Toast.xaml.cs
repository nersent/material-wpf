using System;
using System.Windows;
using System.Windows.Controls;

namespace MaterialWPF
{
    /// <summary>
    /// Interaction logic for Toast.xaml
    /// </summary>
    public partial class Toast : UserControl
    {
        Thickness defaultMargin;
        Thickness dMargin;
        System.Windows.Threading.DispatcherTimer fadeOutTimer = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer positionTimer = new System.Windows.Threading.DispatcherTimer();

        bool positionTimerb = false;
        int fadeOutTick = 0;

        public Toast()
        {
            InitializeComponent();
            this.Opacity = 0;
        }

        public void show(Grid grid, double height)
        {
            dMargin = this.Margin;
            defaultMargin = dMargin;
            defaultMargin.Top = ToastBrain.toastCount * (this.Height + 16);
            this.Margin = new Thickness(defaultMargin.Left, defaultMargin.Top + 24, defaultMargin.Right, defaultMargin.Bottom);

            ToastBrain.toastCount += 1;
            this.VerticalAlignment = VerticalAlignment.Top;
            this.HorizontalAlignment = HorizontalAlignment.Center;
            Animations.AnimateFade(0, 1, this, 0.3, 0, null);
            Animations.AnimateMargin(this.Margin, defaultMargin, this, 0.4, 0, null);

            fadeOutTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            fadeOutTimer.Tick += FadeOutTimer_Tick;
            fadeOutTimer.Start();
            positionTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            positionTimer.Tick += PositionTimer_Tick;
            //positionTimerb = true;

            positionTimer.Start();
            
            grid.Children.Add(this);
        }

        private void PositionTimer_Tick(object sender, EventArgs e)
        {
           if (positionTimerb)
            {
                if (ToastBrain.toastCount < 2)
                {
                    fadeOutTimer.Start();
                }
            }
        }

        public void hide()
        {
            Thickness fadeOutThickness = this.Margin;
            fadeOutThickness.Top = -60;
            Animations.AnimateMargin(this.Margin, fadeOutThickness, this, 0.4, 0, null);
            Animations.AnimateFade(1, 0, this, 0.3, 0, null);
            Animations.AnimateHeight(this.ActualHeight, 0, this, 0.5, 0, null);
            Animations.AnimateWidth(this.ActualWidth, 0, this, 0.5, 0, null);
            ToastBrain.toastCount -= 1;
            positionTimerb = false;
        }

        private void FadeOutTimer_Tick(object sender, EventArgs e)
        {
            if (fadeOutTick > 1500)
            {
                hide();
                fadeOutTimer.Stop();
            } else
            {
                fadeOutTick += 10;
            }
        }
    }
}

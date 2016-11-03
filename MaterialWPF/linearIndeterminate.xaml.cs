using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaterialWPF
{
    /// <summary>
    /// Interaction logic for linearDeterminate.xaml
    /// </summary>
    public partial class linearIndeterminate : UserControl
    {
        PowerEase easingFunction;
        public linearIndeterminate()
        {
            InitializeComponent();
            easingFunction = new PowerEase();
            easingFunction.EasingMode = EasingMode.EaseInOut;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DividerFast.Width = ActualWidth / 2;
            Divider.Width = ActualWidth / 2;
            Animate();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer()
            {
            Interval = new TimeSpan(0, 0, 0, 2, 750)
            };
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Start();
            
        }
        private void Animate()
        {
            DividerFast.Margin = new Thickness(-1 * (ActualWidth + DividerFast.ActualWidth), 0, 2, 100);
            Animations.AnimateMargin(new Thickness(-1 * (ActualWidth), 0, 0, 0), new Thickness(ActualWidth, 0, 0, 0), Divider, 2, 0, easingFunction);
            Animations.AnimateMargin(new Thickness(-1 * (ActualWidth), 0, 0, 0), new Thickness(ActualWidth, 0, 0, 0), DividerFast, 1.2, 1.5, easingFunction);
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Animate();
        }
    }
}
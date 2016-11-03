using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shell;
using System.Windows.Threading;

namespace MaterialWPF
{
    /// <summary>
    /// Interaction logic for TabWindow.xaml
    /// </summary>
    public partial class TabWindow : Window
    {
        public Tab tab;
        public TabBar tabBar;
        private DispatcherTimer dt;
        public TabWindow()
        {
            InitializeComponent();
            Loaded += TabWindow_Loaded;
            WindowChrome wc = new WindowChrome();
            wc.UseAeroCaptionButtons = false;
            wc.CaptionHeight = 40;

            WindowChrome.SetWindowChrome(this, wc);
            TabLayout.tabBar.MouseMove += UIElement_OnMouseMove;
        }

        private async Task Wait(int sec)
        {
            await Task.Delay(sec);
        }

        private async void TabWindow_Loaded(object sender, RoutedEventArgs e)
        {
            actionTitle.Content = tab.Title.Text;
            TabLayout.tabBar.AddTab(tab.Title.Text, tab.AssociatedInstance);
            await Wait(1000);
            dt = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 0, 0, 1)
            };
            dt.Tick += (sender1, args) =>
            {
                tabBar?.GetWindow(this);
            };
            dt.Start();
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void UIElement_OnMouseMove(object sender, MouseEventArgs e)
        {
           
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            dt?.Stop();
            tab = null;
            tabBar = null;
        }
    }
}

using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shell;
using System.Windows.Threading;
using MaterialWPFTest;
using System.Windows.Media.Imaging;

namespace MaterialWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            WindowChrome wc = new WindowChrome();
            wc.UseAeroCaptionButtons = false;
            wc.CaptionHeight = 26;
            WindowChrome.SetWindowChrome(this, wc);
            DispatcherTimer dt = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 0, 0, 1)
            };
            dt.Tick += (sender, args) => TabWindowPass.Window = new TabWindow();
            dt.Start();
            Loaded += MainWindow_Loaded;

            ToolBarItem item_close = new ToolBarItem();
            item_close.IconSource = new BitmapImage(new Uri("pack://application:,,,/MaterialWPFTest;component/Icons/close.png"));
            item_close.Margin = new Thickness(item_close.Margin.Left, item_close.Margin.Top, 0, item_close.Margin.Bottom);
            item_close.IconWidth = 20;
            item_close.IconHeight = 20;
            item_close.Width = 32;
            item_close.Height = 32;

            ToolBarItem item_maximize = new ToolBarItem();
            item_maximize.IconSource = new BitmapImage(new Uri("pack://application:,,,/MaterialWPFTest;component/Icons/maximaze.png"));
            item_maximize.Margin = new Thickness(item_maximize.Margin.Left, item_maximize.Margin.Top, 64, item_maximize.Margin.Bottom);
            item_maximize.IconWidth = 12;
            item_maximize.IconHeight = 12;
            item_maximize.Width = 32;
            item_maximize.Height = 32;

            ToolBarItem item_minimize = new ToolBarItem();
            item_minimize.IconSource = new BitmapImage(new Uri("pack://application:,,,/MaterialWPFTest;component/Icons/minimaze.png"));
            item_minimize.Margin = new Thickness(item_minimize.Margin.Left, item_minimize.Margin.Top, 128, item_minimize.Margin.Bottom);
            item_minimize.IconWidth = 12;
            item_minimize.IconHeight = 12;
            item_minimize.Width = 32;
            item_minimize.Height = 32;

            item_close.PreviewMouseUp += (o, i) =>
            {
                Application.Current.Shutdown();
            };

            item_maximize.PreviewMouseUp += (o, i) =>
            {
                if (this.WindowState == WindowState.Maximized) {
                    this.WindowState = WindowState.Normal;
                } else {
                    this.WindowState = WindowState.Maximized;
                }
            };

            item_minimize.PreviewMouseUp += (o, i) =>
            {
                this.WindowState = WindowState.Minimized;
            };

            ToolBarx.ActionButtonsGridMargin = new Thickness(8, 0, 0, 0);
            ToolBarx.addActionButton(item_close);
            ToolBarx.addActionButton(item_maximize);
            ToolBarx.addActionButton(item_minimize);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            tabLayout.tabBar.AddTab("Selection Controls", new SelectionControlsTab());
            tabLayout.tabBar.AddTab("Buttons", new ButtonsTab());
            tabLayout.tabBar.AddTab("Progress and sliders", new ProgressAndSliders());
            tabLayout.tabBar.AddTab("Fonts and Inputs", new FontsAndInputs());
            tabLayout.tabBar.AddTab("Scroll Viewer", new CustomScrollViewer());

        }
    }
}
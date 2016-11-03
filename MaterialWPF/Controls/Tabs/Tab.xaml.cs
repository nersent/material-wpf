using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Threading;

namespace MaterialWPF
{
    /// <summary>
    /// Interaction logic for Tab.xaml
    /// </summary>
    public abstract class TabWindowPass
    {
        public static dynamic Window;
    }

    public partial class Tab : UserControl
    {
        public UserControl AssociatedInstance;
        TabBar _tabBar;
        public int Index;
        Point _mStart;
        Vector _mStartOffset;
        private Color _rippleColor;
        public Color RippleColor
        {
            get { return _rippleColor; }
            set {
                _rippleColor = value;
                Ripple.Fill = new SolidColorBrush(value);
            }
        }

        public Tab(string text, UserControl uc, TabBar tb, int index)
        {
            InitializeComponent();
            AssociatedInstance = uc;
            Title.Text = text;
            _tabBar = tb;
            Index = index;
            DispatcherTimer dt = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 0, 0, 200)
            };

            dt.Tick += (sender, args) =>
            {

                var parent = this.FindParent<TabBar>();
                if (parent != null)
                {
                    Rect rect = new Rect
                    {
                        Size = new Size(parent.ActualWidth, parent.ActualHeight),
                        Location = new Point(parent.Margin.Left, parent.Margin.Top)
                    };
                    if (!rect.Contains(Mouse.GetPosition(parent)))
                    {
                        parent.CalcSizes(true);
                        foreach (var tab in parent.TabCollection)
                        {
                            tab.Effect = null;
                            tab.Index = parent.TabCollection.IndexOf(tab);
                            Panel.SetZIndex(tab, 2);
                        }
                    }
                }
            };
            dt.Start();
        }

        private int _secondsHeld = 0;
        private bool _locked = true;
        private bool created = false;
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
            CaptureMouse();
            onMouseDown(true);
        }

        private void Title_Loaded(object sender, RoutedEventArgs e)
        {
            if (!created)
            {
                if (AssociatedInstance.Parent == null)
                    this.FindParent<TabLayout>().container.Children.Add(AssociatedInstance);


                RippleColor = this.FindParent<TabLayout>().RippleColor;
                double width = Title.ActualWidth + 64;
                this.Width = width;
                Console.WriteLine("loaded");
                TabBar parent = this.FindParent<TabBar>();

                if (double.IsNaN(this.FindParent<TabLayout>().TabSize))
                {
                    parent.TabCollection.Add(this);
                    if (parent.TabCollection.Count <= 1)
                    {

                        Canvas.SetLeft(this, 0);
                        DoubleAnimation dab = new DoubleAnimation()
                        {
                            From = 0,
                            To = 0,
                            Duration = TimeSpan.FromMilliseconds(0)
                        };
                        this.BeginAnimation(Canvas.LeftProperty, dab);
                    }
                    else
                    {
                        Tab previousTab = parent.TabCollection[parent.TabCollection.IndexOf(this) - 1];
                        double pwidth = previousTab.Title.ActualWidth + 64;
                        Canvas.SetLeft(this, Canvas.GetLeft(previousTab) + pwidth);
                        DoubleAnimation dab = new DoubleAnimation()
                        {
                            From = Canvas.GetLeft(previousTab) + pwidth,
                            To = Canvas.GetLeft(previousTab) + pwidth,
                            Duration = TimeSpan.FromMilliseconds(0)
                        };
                        this.BeginAnimation(Canvas.LeftProperty, dab);
                    }

                }
                else
                {
                    Canvas.SetLeft(this, parent.TabsCount*this.FindParent<TabLayout>().TabSize);
                    DoubleAnimation dab = new DoubleAnimation()
                    {
                        From = parent.TabsCount*this.FindParent<TabLayout>().TabSize,
                        To = parent.TabsCount*this.FindParent<TabLayout>().TabSize,
                        Duration = TimeSpan.FromMilliseconds(0)
                    };
                    this.BeginAnimation(Canvas.LeftProperty, dab);
                    parent.TabsCount += 1;
                    parent.TabCollection.Add(this);
                }
                if (parent.TabCollection.Count > 0)
                {
                    parent.SelectTab(parent.TabCollection[0], true);
                }

                parent.CalcSizes(false);
                created = true;
            }
        }

        private double _oldX = 0;


        private async Task WaitForSeconds(int sec)
        {
            await Task.Delay(sec);
        }
        private async void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {

            TabBar parent = this.FindParent<TabBar>();

            foreach (Tab tab in parent.TabCollection)
            {
                tab.Effect = null;
            }
            parent.CalcSizes(true);
            _secondsHeld = 0;
            _locked = true;
            await WaitForSeconds(200);
            ReleaseMouseCapture();

        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            if (this.FindParent<TabLayout>() != null)
                Animations.AnimateColor(this.FindParent<TabLayout>().TabsBackground,
                    this.FindParent<TabLayout>().TabsHover, bg, 0.2, "Background");
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.FindParent<TabLayout>() != null)
                Animations.AnimateColor(this.FindParent<TabLayout>().TabsHover,
                    this.FindParent<TabLayout>().TabsBackground, bg, 0.2, "Background");

        }

        private void UserControl_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            var parent = this.FindParent<TabBar>();
            Rect rect = new Rect
            {
                Size = new Size(parent.ActualWidth, parent.ActualHeight + 30),
                Location = new Point(parent.Margin.Left, parent.Margin.Top - 15)
            };
            if (e.LeftButton == MouseButtonState.Pressed && !_locked && (this.FindParent<TabLayout>().TabDrag == TabLayout.States.Enabled && !double.IsNaN(this.FindParent<TabLayout>().TabSize)))
            {
                Vector offset = Point.Subtract(e.GetPosition(parent), _mStart);
                Point mousePoint = new Point(_mStartOffset.X + offset.X, _mStartOffset.Y + offset.Y);
                Tab overTab = null;
                overTab = parent.GetTabFromMousePoint(this);
                if (overTab != null)
                {
                    try
                    {
                        var oldTabIndex = overTab.Index;
                        var thisTabIndex = this.Index;
                        overTab.Index = thisTabIndex;
                        this.Index = oldTabIndex;
                        parent.TabCollection[this.Index] = this;
                        parent.TabCollection[overTab.Index] = overTab;
                        parent.CalcSizes(true);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                    }
                }

                    this.BeginAnimation(Canvas.LeftProperty,
                        new DoubleAnimation(Canvas.GetLeft(this), mousePoint.X, TimeSpan.FromSeconds(0)));

               

                foreach (var tab in parent.TabCollection)
                {
                    tab.Effect = null;
                    tab.Index = parent.TabCollection.IndexOf(tab);
                    Panel.SetZIndex(tab, 2);
                }
                this.Effect = new DropShadowEffect()
                {
                    BlurRadius = 12,
                    Direction = -90,
                    Opacity = 0.3,
                    ShadowDepth = 3
                };
                Panel.SetZIndex(this, 6);

                /* Testing purposes
                MainWindow tl1 = this.FindParent<MainWindow>();
                Rectangle rectangle = new Rectangle()
                {
                    Width = parent.ActualWidth,
                    Height = parent.ActualHeight + 10,
                    Margin = new Thickness(parent.Margin.Left, (tl1.TitleBar.ActualHeight + parent.Margin.Top) - 10,0,0),
                    Stroke = new SolidColorBrush(Colors.Blue),
                    StrokeThickness = 2,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                }; 
                tl1.Main.Children.Add(rectangle);
                */

                if (!rect.Contains(e.GetPosition(parent)))
                {
                    if (AssociatedInstance.Parent != null && TabWindowPass.Window.tab == null)
                    {
                        try
                        {
                            Point p = new Point(e.GetPosition(Application.Current.MainWindow).X,
                                e.GetPosition(Application.Current.MainWindow).Y);
                            TabWindowPass.Window.Height = AssociatedInstance.ActualHeight;
                            TabWindowPass.Window.Width = AssociatedInstance.ActualWidth;
                            TabWindowPass.Window.tab = this;
                            TabWindowPass.Window.tabBar = parent;
                            TabWindowPass.Window.Left = Application.Current.MainWindow.PointToScreen(p).X -
                                                         this.ActualWidth;
                            TabWindowPass.Window.Top = Application.Current.MainWindow.PointToScreen(p).Y - 5;
                            
                            foreach (var tab in parent.TabCollection)
                            {
                                tab.ReleaseMouseCapture();
                                tab.Effect = null;
                                tab.bg.Background = new SolidColorBrush(this.FindParent<TabLayout>().TabsBackground);
                            }


                            var tl = this.FindParent<TabLayout>();
                            tl.container.Children.Remove(AssociatedInstance);
                            parent.canvas.Children.Remove(this);
                            parent.TabCollection.Remove(this);
                            TabWindowPass.Window.Show();
                            if (parent.TabCollection.Count != 0)
                                parent.SelectTab(parent.TabCollection[0], true);
                            parent.CalcSizes(true);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.StackTrace);
                        }
                    }

                }
                TabWindowPass.Window?.DragMove();
                _oldX = e.GetPosition(this).X;


            }
        }

        private async void onMouseDown(bool wait)
        {
            _mStart = Mouse.GetPosition(this.FindParent<TabBar>());
            _mStartOffset = new Vector(Canvas.GetLeft(this), Canvas.GetTop(this));
            if (_tabBar.ActualSelect != this)
                _tabBar.SelectTab(this, true);
            var targetWidth = Math.Max(ActualWidth, ActualHeight) * 2;
            Ripple.Width = 0;
            var mousePosition = Mouse.GetPosition(this);
            var startMargin = new Thickness(mousePosition.X, mousePosition.Y, 0, 0);
            Ripple.Margin = startMargin;

            Animations.AnimateFade(0, 0.2, Ripple, 0, 0, null);

            Animations.AnimateRipple(0, targetWidth, Ripple, 0.3, startMargin, new Thickness(mousePosition.X - targetWidth / 2, mousePosition.Y - targetWidth / 2, 0, 0), true, 0.2);
            if (wait)
            {
                while (_secondsHeld != 1)
                {
                    await WaitForSeconds(100);
                    _secondsHeld += 1;
                    _locked = false;
                    _mStart = Mouse.GetPosition(this.FindParent<TabBar>());
                    _mStartOffset = new Vector(Canvas.GetLeft(this), Canvas.GetTop(this));
                }
            }
            else
            {
                _locked = false;
            }
        }

        private void bg_GotMouseCapture(object sender, MouseEventArgs e)
        {
            onMouseDown(false);
        }
    }
}

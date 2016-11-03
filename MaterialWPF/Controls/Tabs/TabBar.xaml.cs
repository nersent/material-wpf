using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace MaterialWPF
{
    /// <summary>
    /// Interaction logic for TabBar.xaml
    /// </summary>
    public partial class TabBar : UserControl
    {
        public List<Tab> TabCollection;
        public int TabsCount;
        private int _tabWidth = 256;
        private int _tabHeight = 48;
        private bool _tabDragLocked = false;
        private bool _selectTabOnCreate = true;

        public Color TabsBackground;
        private DispatcherTimer dt;
        public TabBar()
        {
            InitializeComponent();
            TabCollection = new List<Tab>();
            dt = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 0, 0, 1)
            };
            dt.Tick += Dt_Tick;
            dt.Start();
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            if (ActualSelect != null)
            {
                Divider.BeginAnimation(Canvas.LeftProperty,
                    new DoubleAnimation(Canvas.GetLeft(Divider), Canvas.GetLeft(ActualSelect),
                    TimeSpan.FromMilliseconds(0)));
                Animations.AnimateWidth(Divider.ActualWidth, ActualSelect.ActualWidth, Divider, 0, 0, null);
            }
        }

        public void CalcSizes(bool animation)
        {
            if (!double.IsNaN(this.FindParent<TabLayout>().TabSize))
            {
                double tabWidth = 0;
                int tabs = 0;
                foreach (Tab tab in TabCollection)
                {
                    if (!(ActualWidth/TabsCount >= 256))
                    {
                        tab.Width = ActualWidth/TabsCount;
                        Divider.Width = ActualWidth/TabsCount;
                        tabWidth = ActualWidth/TabsCount;
                    }
                    else
                    {
                        tab.Width = tab.MaxWidth;
                        Divider.Width = tab.MaxWidth;
                        tabWidth = tab.MaxWidth;
                    }
                }

                foreach (Tab t in TabCollection)
                {
                    _tabDragLocked = true;
                    try
                    {

                        DoubleAnimation dab = new DoubleAnimation()
                        {
                            From = Canvas.GetLeft(t),
                            To = tabs*tabWidth
                        };
                        if (animation)
                        {
                            dab.Duration = TimeSpan.FromMilliseconds(200);
                        }
                        else
                        {
                            dab.From = Canvas.GetLeft(t);
                            dab.Duration = TimeSpan.FromMilliseconds(0);
                        }
                        dab.Completed += (o, e) => { _tabDragLocked = false; };
                        t.BeginAnimation(Canvas.LeftProperty, dab);
                        tabs += 1;


                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        private async Task Wait(int sec)
        {
            await Task.Delay(sec);
        }

        private Tab _tab;

        public void GetWindow(dynamic window)
        {
            Rect rectangle = new Rect
            {
                Size = new Size(this.ActualWidth, ActualHeight),
                Location = PointToScreen(new Point(this.Margin.Left, Margin.Top - this.ActualHeight/2))
            };

            if (rectangle.Contains(new Point(window.Left, window.Top)) ||
                rectangle.Contains(new Point(window.Left + window.ActualWidth/2, window.Top)) ||
                rectangle.Contains(new Point(window.Left + window.ActualWidth, window.Top)))
            {
                _tab = window.tab;
                TabCollection.Add(_tab);
                canvas.Children.Add(_tab);
                UserControl uc = _tab.AssociatedInstance;
                uc.FindParent<Grid>().Children.Remove(uc);
                this.FindParent<TabLayout>().container.Children.Add(_tab.AssociatedInstance);
                _tab.Index = TabCollection.Count;
                CalcSizes(false);
                window.Close();
                window.ReleaseMouseCapture();
                SelectTab(_tab, false);
                _tab.CaptureMouse();
            }
        }

        public Tab GetTabFromMousePoint(Tab callingTab)
        {
            Tab theTab = null;
            if (!_tabDragLocked)
            {
                foreach (var ctrl in TabCollection)
                {
                    Rect myRectangle = new Rect
                    {
                        Location = new Point(Canvas.GetLeft(ctrl), Canvas.GetTop(ctrl)),
                        Size = new Size(ctrl.ActualWidth, ctrl.ActualHeight)
                    };
                    if (myRectangle.Contains(Mouse.GetPosition(this)) & ctrl.Equals(callingTab) == false)
                    {
                        theTab = ctrl;
                    }
                }
            }

            return theTab;
        }

        public void AddTab(string text, UserControl uc)
        {
            Tab tab = new Tab(text, uc, this, TabsCount);
            canvas.Children.Add(tab);

            tab.Height = _tabHeight;
            if (!double.IsNaN(this.FindParent<TabLayout>().TabSize))
            {
                tab.Width = this.FindParent<TabLayout>().TabSize;
                tab.MaxWidth = this.FindParent<TabLayout>().TabSize;
            }


            tab.bg.Background = new SolidColorBrush(TabsBackground);
            Canvas.SetTop(tab, 0);
            Panel.SetZIndex(Divider, int.MaxValue);


        }

        private Tab _oldSelection;
        public Tab ActualSelect;

        public void SelectTab(Tab tabSelect, bool moveDivider)
        {
            foreach (var tab in TabCollection)
            {
                if (Equals(tab, tabSelect))
                {
                    ActualSelect = tab;
                    tab.Title.Opacity = 1;

                    if (moveDivider)
                    {
                        MoveDivider(tab);
                    }
                    tab.AssociatedInstance.Visibility = Visibility.Visible;
                    Animations.AnimateFade(0, 1, tab.AssociatedInstance, 0.2, 0, null);
                    _oldSelection = tab;
                }
                else
                {
                    tab.Title.Opacity = 0.7;
                    tab.AssociatedInstance.Visibility = Visibility.Hidden;


                }
            }
        }

        public void MoveDivider(Tab tabSelect)
        {
            foreach (var tab in TabCollection)
            {
                if (Equals(tab, tabSelect))
                {
                    ActualSelect = tab;
                    tab.Title.Opacity = 1;
                    if (_oldSelection == null)
                    {
                        dt.Stop();
                        Divider.BeginAnimation(Canvas.LeftProperty,
                            new DoubleAnimation(0, Canvas.GetLeft(tab), TimeSpan.FromMilliseconds(150)));
                        Animations.AnimateWidth(Divider.ActualWidth, tab.ActualWidth, Divider, 0.15, 0, ()=> dt.Start());
                    }
                    else
                    {
                        dt.Stop();
                        Divider.BeginAnimation(Canvas.LeftProperty,
                            new DoubleAnimation(Canvas.GetLeft(_oldSelection), Canvas.GetLeft(tab),
                                TimeSpan.FromMilliseconds(150)));
                        Animations.AnimateWidth(Divider.ActualWidth, tab.ActualWidth, Divider, 0.15, 0, () => dt.Start());
                    }
                }
            }
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            CalcSizes(false);
        }
    }
}
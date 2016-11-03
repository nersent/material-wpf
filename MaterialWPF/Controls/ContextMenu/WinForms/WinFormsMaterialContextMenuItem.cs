using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MaterialWPF
{
    class WinFormsMaterialContextMenuItem : MenuItem
    {

        WinFormsMaterialContextMenuItem th;
        Border border;
        Grid MainGrid;
        ControlTemplate temp;
        Ellipse rippleElement;
        Label headerContent;
        TextBlock content;
        Grid gridContent;
        Grid iconContent;

        Color defaultBorderColor;
        Color hoverBorderColor;
        Double fadeInBorderTime = 0.3;
        Double fadeOutBorderTime = 0.3;

        System.Windows.Threading.DispatcherTimer showmenu = new System.Windows.Threading.DispatcherTimer();

        bool rippleCenter = false;
        bool ripple = true;

        string headerText = "";

        bool[] caseBool = new bool[5];

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            caseBool[0] = false;
            caseBool[1] = false;

            Style contextmenustyle = FindResource("MaterialContextMenuItem") as Style;

            this.Style = contextmenustyle;

            this.Loaded += WinFormsMaterialContextMenuItem_Loaded;

            this.PreviewMouseLeftButtonDown += WinFormsMaterialContextMenuItem_PreviewMouseLeftButtonDown;
            this.MouseEnter += WinFormsMaterialContextMenuItem_MouseEnter;
            this.MouseLeave += WinFormsMaterialContextMenuItem_MouseLeave;
           
            
        }

        /* LOAD OBJECTS */

        private void WinFormsMaterialContextMenuItem_Loaded(object sender, RoutedEventArgs e)
        {
            switch (caseBool[1])
            {
                case false:
                    WinFormsMaterialContextMenuItem x = (WinFormsMaterialContextMenuItem)sender;
                    th = this;
                    temp = th.Template;
                    MainGrid = (Grid)temp.FindName("MainGrid", th);
                    border = (Border)MainGrid.FindName("Bd") as Border;
                    iconContent = (Grid)MainGrid.FindName("iconContent") as Grid;
                    iconContent.MouseLeftButtonUp += IconContent_MouseLeftButtonUp;

                    gridContent = (Grid)MainGrid.FindName("gridContent") as Grid;
                    headerContent = (Label)gridContent.FindName("headerContent") as Label;
                    content = (TextBlock)gridContent.FindName("content") as TextBlock;

                    headerText = headerContent.Content.ToString();
                    content.Text = headerText;


                    rippleElement = (Ellipse)MainGrid.FindName("Ripple") as Ellipse;

                    defaultBorderColor = colorConverter.convertToColor(border.Background);

                    hoverBorderColor = colorConverter.convertToColor("#b9b9b9");

                    caseBool[1] = true;
                    break;
                case true:
                    caseBool[1] = false;
                    break;
            }
        }

        public void setHeight(double height)
        {
            this.Height = height;
            MainGrid.Height = height;
        }

        public double getHeight()
        {
            return this.ActualHeight;
        }

        public void setPadding(Thickness padding)
        {
            content.Padding = padding;
        }

        public Thickness getPadding()
        {
            return content.Padding;
        }

        public bool repairRipple()
        {
            MainGrid.Width = this.ActualWidth;
            MainGrid.Height = this.ActualHeight;
            return true;
           // Console.WriteLine("width" + this.ActualWidth + " height" + this.ActualHeight);
        }

        bool showwhenclicked = false;
        WinFormsMaterialContextMenu showwhenclickedm;

        public void setIconShow(WinFormsMaterialContextMenu menu, bool t)
        {
            showwhenclicked = t;
            showwhenclickedm = menu;
        }

        double menutimer = 0;

        private void IconContent_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (showwhenclicked)
            {
                showmenu.Interval = new TimeSpan(0, 0, 0, 0, 1);
                showmenu.Tick += Showmenu_Tick;
                showmenu.Start();
            }
        }

        private void Showmenu_Tick(object sender, EventArgs e)
        {
            if (menutimer > 10) {
                showmenu.Stop();
                showwhenclickedm.IsOpen = true;
            } else
            {
                menutimer += 1;
            }
        }

        public void setIconWidth(double width)
        {
            iconContent.Width = width;
        }

        public void setIconHeight(double height)
        {
            iconContent.Height = height;
        }

        public void setIconMargin(Thickness thickness)
        {
            iconContent.Margin = thickness;
        }

        public void setIcon(ImageSource source)
        {
            iconContent.Children.Clear();
            iconContent.Visibility = Visibility.Visible;
            Image img = new Image();
            img.Width = 32;
            img.Height = 32;
            img.HorizontalAlignment = HorizontalAlignment.Center;
            img.VerticalAlignment = VerticalAlignment.Center;
            img.Source = source;

            Thickness borderPadding = content.Padding;

            content.Padding = new Thickness(64, borderPadding.Top, borderPadding.Right, borderPadding.Bottom);
            
            iconContent.Children.Add(img);
        }

        public void setCustomIcon(UIElement element)
        {
            iconContent.Children.Clear();
            iconContent.Visibility = Visibility.Visible;

            Thickness borderPadding = content.Padding;

            content.Padding = new Thickness(64, borderPadding.Top, borderPadding.Right, borderPadding.Bottom);

            iconContent.Children.Add(element);
        }

        /* RIPPLE */
         

        private void WinFormsMaterialContextMenuItem_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            switch (caseBool[0])
            {
                case false:
                    if (ripple) { 
                        if (rippleCenter)
                        {
                            Animations.AnimateFade(0, 0.3, rippleElement, 0, 0, null);
                            rippleElement.Height = 0;
                            rippleElement.Width = 0;
                            Animations.AnimateRipple(0, rippleElement.ActualWidth, rippleElement, 0.3, true, 0.3);
                        } else { 
                            var targetWidth = Math.Max(ActualWidth, ActualHeight) * 2;
                            rippleElement.Width = 0;
                            var mousePosition = (e as MouseButtonEventArgs).GetPosition(this);
                            var startMargin = new Thickness(mousePosition.X, mousePosition.Y, 0, 0);
                            rippleElement.Margin = startMargin;

                            Animations.AnimateFade(0, 0.3, rippleElement, 0.2, 0, null);

                            Animations.AnimateRipple(0, targetWidth, rippleElement, 0.3, startMargin, new Thickness(mousePosition.X - targetWidth / 2, mousePosition.Y - targetWidth / 2, 0, 0), true, 0.3);
           
                        }
                    }
                    caseBool[0] = true;
                    break;
                case true:
                    caseBool[0] = false;
                    break;
            }
        }

        /* SET RIPPLE */
        public void setRipple(bool Ripple)
        {
            ripple = Ripple;
        }
        public void setRippleCenter(bool RippleCenter)
        {
            rippleCenter = RippleCenter;
        }

        /* HOVER */

        //ENTER
        private void WinFormsMaterialContextMenuItem_MouseEnter(object sender, MouseEventArgs e)
        {
            Animations.AnimateColor(defaultBorderColor, hoverBorderColor, border, fadeInBorderTime, "Background");
            Animations.AnimateColor(defaultBorderColor, hoverBorderColor, iconContent, fadeInBorderTime, "Background");
        }
        //LEAVE
        private void WinFormsMaterialContextMenuItem_MouseLeave(object sender, MouseEventArgs e)
        {
            Animations.AnimateColor(hoverBorderColor, defaultBorderColor, border, fadeOutBorderTime, "Background");
            Animations.AnimateColor(hoverBorderColor, defaultBorderColor, iconContent, fadeOutBorderTime, "Background");
        }
    }
}

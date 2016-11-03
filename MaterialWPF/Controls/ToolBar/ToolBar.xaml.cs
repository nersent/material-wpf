using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;

namespace MaterialWPF
{
    /// <summary>
    /// Interaction logic for ToolBar.xaml
    /// </summary>
    public partial class ToolBar : UserControl
    {
        /* NAV ICON */
        public double navIconRippleOpacity = 0.25;
        public double navIconRippleFadeInTime = 0.2;
        public double navIconRippleFadeOutTime = 0.3;

        /* MENU ICON */
        public double menuIconRippleOpacity = 0.25;
        public double menuIconRippleFadeInTime = 0.2;
        public double menuIconRippleFadeOutTime = 0.3;

        public Color BackgroundColor
        {
            get { return (Color)base.GetValue(BackgroundColorProperty); }
            set { base.SetValue(BackgroundColorProperty, value); }
        }
        public static DependencyProperty BackgroundColorProperty =
          DependencyProperty.Register("BackgroundColor", typeof(Color), typeof(ToolBar), null);

        public string Title
        {
            get { return (string)base.GetValue(TitleProperty); }
            set { base.SetValue(TitleProperty, value); }
        }
        public static DependencyProperty TitleProperty =
          DependencyProperty.Register("Title", typeof(string), typeof(ToolBar), null);

        public double TitleFontSize
        {
            get { return (double)base.GetValue(TitleFontSizeProperty); }
            set { base.SetValue(TitleFontSizeProperty, value); }
        }
        public static DependencyProperty TitleFontSizeProperty =
          DependencyProperty.Register("TitleFontSize", typeof(double), typeof(ToolBar), null);

        public Color TitleForeground
        {
            get { return (Color)base.GetValue(TitleForegroundProperty); }
            set { base.SetValue(TitleForegroundProperty, value); }
        }
        public static DependencyProperty TitleForegroundProperty =
          DependencyProperty.Register("TitleForeground", typeof(Color), typeof(ToolBar), null);

        /* NAVICON */

        public ImageSource NavIconImage
        {
            get { return (ImageSource)base.GetValue(NavIconImageProperty); }
            set { base.SetValue(NavIconImageProperty, value); }
        }
        public static DependencyProperty NavIconImageProperty =
          DependencyProperty.Register("NavIconImage", typeof(ImageSource), typeof(ToolBar), null);

     /*   public bool NavIcon
        {
            get { return (bool)base.GetValue(NavIconProperty); }
            set { base.SetValue(NavIconProperty, value); }
        }*/
        public static DependencyProperty NavIconProperty =
          DependencyProperty.Register("NavIcon", typeof(bool), typeof(ToolBar), null);

        public Color NavIconRippleColor
        {
            get { return (Color)base.GetValue(NavIconRippleColorProperty); }
            set { base.SetValue(NavIconRippleColorProperty, value); }
        }
        public static DependencyProperty NavIconRippleColorProperty =
          DependencyProperty.Register("NavIconRippleColor", typeof(Color), typeof(ToolBar), null);

        public double NavIconRippleOpacity
        {
            get { return (double)base.GetValue(NavIconRippleOpacityProperty); }
            set { base.SetValue(NavIconRippleOpacityProperty, value); }
        }
        public static DependencyProperty NavIconRippleOpacityProperty =
          DependencyProperty.Register("NavIconRippleOpacity", typeof(double), typeof(ToolBar), null);

        public double NavIconRippleFadeInTime
        {
            get { return (double)base.GetValue(NavIconRippleFadeInTimeProperty); }
            set { base.SetValue(NavIconRippleFadeInTimeProperty, value); }
        }
        public static DependencyProperty NavIconRippleFadeInTimeProperty =
          DependencyProperty.Register("NavIconRippleFadeInTime", typeof(double), typeof(ToolBar), null);

        public double NavIconRippleFadeOutTime
        {
            get { return (double)base.GetValue(NavIconRippleFadeOutTimeProperty); }
            set { base.SetValue(NavIconRippleFadeOutTimeProperty, value); }
        }

        public static DependencyProperty NavIconRippleFadeOutTimeProperty =
            DependencyProperty.Register("NavIconRippleFadeOutTime", typeof(double), typeof(ToolBar), null);

        public double NavIconGridWidth
        {
            get { return (double)base.GetValue(NavIconGridWidthProperty); }
            set { base.SetValue(NavIconGridWidthProperty, value); }
        }
        public static DependencyProperty NavIconGridWidthProperty =
          DependencyProperty.Register("NavIconGridWidth", typeof(double), typeof(ToolBar), null);

        public double NavIconGridHeight
        {
            get { return (double)base.GetValue(NavIconGridHeightProperty); }
            set { base.SetValue(NavIconGridHeightProperty, value); }
        }
        public static DependencyProperty NavIconGridHeightProperty =
          DependencyProperty.Register("NavIconGridHeight", typeof(double), typeof(ToolBar), null);

        public double NavIconWidth
        {
            get { return (double)base.GetValue(NavIconWidthProperty); }
            set { base.SetValue(NavIconWidthProperty, value); }
        }
        public static DependencyProperty NavIconWidthProperty =
          DependencyProperty.Register("NavIconWidth", typeof(double), typeof(ToolBar), null);

        public double NavIconHeight
        {
            get { return (double)base.GetValue(NavIconHeightProperty); }
            set { base.SetValue(NavIconHeightProperty, value); }
        }
        public static DependencyProperty NavIconHeightProperty =
          DependencyProperty.Register("NavIconHeight", typeof(double), typeof(ToolBar), null);

        /* MENUICON */

      /*  public bool MenuIcon
        {
            get { return (bool)base.GetValue(MenuIconProperty); }
            set { base.SetValue(MenuIconProperty, value); }
        }*/
        public static DependencyProperty MenuIconProperty =
          DependencyProperty.Register("MeuIcon", typeof(bool), typeof(ToolBar), null);

        public ImageSource MenuIconImage
        {
            get { return (ImageSource)base.GetValue(MenuIconImageProperty); }
            set { base.SetValue(MenuIconImageProperty, value); }
        }
        public static DependencyProperty MenuIconImageProperty =
          DependencyProperty.Register("MenuIconImage", typeof(ImageSource), typeof(ToolBar), null);

        public Color MenuIconRippleColor
        {
            get { return (Color)base.GetValue(MenuIconRippleColorProperty); }
            set { base.SetValue(MenuIconRippleColorProperty, value); }
        }
        public static DependencyProperty MenuIconRippleColorProperty =
          DependencyProperty.Register("MenuIconRippleColor", typeof(Color), typeof(ToolBar), null);

        public double MenuIconRippleOpacity
        {
            get { return (double)base.GetValue(MenuIconRippleOpacityProperty); }
            set { base.SetValue(MenuIconRippleOpacityProperty, value); }
        }
        public static DependencyProperty MenuIconRippleOpacityProperty =
          DependencyProperty.Register("MenuIconRippleOpacity", typeof(double), typeof(ToolBar), null);

        public double MenuIconRippleFadeInTime
        {
            get { return (double)base.GetValue(MenuIconRippleFadeInTimeProperty); }
            set { base.SetValue(MenuIconRippleFadeInTimeProperty, value); }
        }
        public static DependencyProperty MenuIconRippleFadeInTimeProperty =
          DependencyProperty.Register("MenuIconRippleFadeInTime", typeof(double), typeof(ToolBar), null);

        public double MenuIconRippleFadeOutTime
        {
            get { return (double)base.GetValue(MenuIconRippleFadeOutTimeProperty); }
            set { base.SetValue(MenuIconRippleFadeOutTimeProperty, value); }
        }
        public static DependencyProperty MenuIconRippleFadeOutTimeProperty =
          DependencyProperty.Register("MenuIconRippleFadeOutTime", typeof(double), typeof(ToolBar), null);

        public double MenuIconGridWidth
        {
            get { return (double)base.GetValue(MenuIconGridWidthProperty); }
            set { base.SetValue(MenuIconGridWidthProperty, value); }
        }
        public static DependencyProperty MenuIconGridWidthProperty =
          DependencyProperty.Register("MenuIconGridWidth", typeof(double), typeof(ToolBar), null);

        public double MenuIconGridHeight
        {
            get { return (double)base.GetValue(MenuIconGridHeightProperty); }
            set { base.SetValue(MenuIconGridHeightProperty, value); }
        }
        public static DependencyProperty MenuIconGridHeightProperty =
          DependencyProperty.Register("MenuIconGridHeight", typeof(double), typeof(ToolBar), null);

        public double MenuIconWidth
        {
            get { return (double)base.GetValue(MenuIconWidthProperty); }
            set { base.SetValue(MenuIconWidthProperty, value); }
        }
        public static DependencyProperty MenuIconWidthProperty =
          DependencyProperty.Register("MenuIconWidth", typeof(double), typeof(ToolBar), null);

        public double MenuIconHeight
        {
            get { return (double)base.GetValue(MenuIconHeightProperty); }
            set { base.SetValue(MenuIconHeightProperty, value); }
        }
        public static DependencyProperty MenuIconHeightProperty =
          DependencyProperty.Register("MenuIconHeight", typeof(double), typeof(ToolBar), null);

        public Thickness ActionButtonsGridMargin
        {
            get { return (Thickness)base.GetValue(ActionButtonsGridMarginProperty); }
            set { base.SetValue(ActionButtonsGridMarginProperty, value); }
        }
        public static DependencyProperty ActionButtonsGridMarginProperty =
          DependencyProperty.Register("ActionButtonsGridMarginHeight", typeof(Thickness), typeof(ToolBar), null);

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == BackgroundColorProperty)
            {
                MainGrid.Background = new SolidColorBrush(BackgroundColor);
            }
            if (e.Property == TitleProperty)
            {
                title.Content = Title;
            }
            if (e.Property == TitleFontSizeProperty)
            {
                title.FontSize = TitleFontSize;
            }
            if (e.Property == TitleForegroundProperty)
            {
               title.Foreground = new SolidColorBrush(TitleForeground);
            }
            /* NAV ICON */
            /*if (e.Property == NavIconProperty)
            {
                navIcon.Visibility = Visibility.Hidden;
            }*/
            if (e.Property == NavIconImageProperty)
            {
                navIconImage.Source = NavIconImage;
            }
            if (e.Property == NavIconRippleColorProperty)
            {
                navIconRipple.Fill = new SolidColorBrush(NavIconRippleColor);
            }
            if (e.Property == NavIconRippleOpacityProperty)
            {
                navIconRippleOpacity = NavIconRippleOpacity;
            }
            if (e.Property == NavIconRippleFadeInTimeProperty)
            {
                navIconRippleFadeInTime = NavIconRippleFadeInTime;
            }
            if (e.Property == NavIconRippleFadeOutTimeProperty)
            {
                navIconRippleFadeOutTime = NavIconRippleFadeOutTime;
            }
            if (e.Property == NavIconGridWidthProperty)
            {
                navIcon.Width = NavIconGridWidth;
            }
            if (e.Property == NavIconGridHeightProperty)
            {
                navIcon.Height = NavIconGridHeight;
            }
            if (e.Property == NavIconWidthProperty)
            {
                navIconImage.Width = NavIconWidth;
            }
            if (e.Property == NavIconHeightProperty)
            {
                navIconImage.Height = NavIconHeight;
            }
            /* MENU ICON */
            /*if (e.Property == MenuIconProperty)
            {
               setMenuIcon(MenuIcon);
            }*/
            if (e.Property == MenuIconImageProperty)
            {
                menuIconImage.Source = MenuIconImage;
            }
            if (e.Property == MenuIconRippleColorProperty)
            {
                menuIconRipple.Fill = new SolidColorBrush(MenuIconRippleColor);
            }
            if (e.Property == MenuIconRippleOpacityProperty)
            {
                menuIconRippleOpacity = MenuIconRippleOpacity;
            }
            if (e.Property == MenuIconRippleFadeInTimeProperty)
            {
                menuIconRippleFadeInTime = MenuIconRippleFadeInTime;
            }
            if (e.Property == MenuIconRippleFadeOutTimeProperty)
            {
                menuIconRippleFadeOutTime = MenuIconRippleFadeOutTime;
            }
            if (e.Property == MenuIconGridWidthProperty)
            {
                menuIcon.Width = MenuIconGridWidth;
            }
            if (e.Property == MenuIconGridHeightProperty)
            {
                menuIcon.Height = MenuIconGridHeight;
            }
            if (e.Property == MenuIconWidthProperty)
            {
                menuIconImage.Width = MenuIconWidth;
            }
            if (e.Property == MenuIconHeightProperty)
            {
                menuIconImage.Height = MenuIconHeight;
            }
            if (e.Property == ActionButtonsGridMarginProperty)
            {
                actionButtons.Margin = ActionButtonsGridMargin;
            }
        }


        Thickness navIconMargin;
        Thickness titleMargin;
        Thickness actionButtonsMargin;
        Thickness menuIconMargin;

        bool ripple = true;

        public ToolBar()
        {
            InitializeComponent();
            titleMargin = title.Margin;
            navIconMargin = navIcon.Margin;
            actionButtonsMargin = actionButtons.Margin;
            menuIconMargin = menuIcon.Margin;
            ActionButtonsGridMargin = actionButtons.Margin;
        }

        public Grid getMenuIcon()
        {
            return menuIcon;
        }

        public Grid getNavIcon()
        {
            return navIcon;
        }

        public void startRipple(Ellipse element, double fadeOpacity, double fadeInTime, double fadeOutTime, double width)
        {
            if (ripple) { 
                Animations.AnimateFade(0,fadeOpacity, element, fadeInTime, 0, null);
                element.Height = 0;
                element.Width = 0;
                Animations.AnimateRipple(0, width, element, fadeInTime, true, fadeOutTime);
            }
        }

        private void navIcon_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           // startRipple(navIconRipple, 0.25, 0.2, 0.3, navIcon.ActualWidth);
           startRipple(navIconRipple, navIconRippleOpacity, navIconRippleFadeInTime, navIconRippleFadeOutTime, navIcon.ActualWidth);
        }

        private void menuIcon_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startRipple(menuIconRipple, menuIconRippleOpacity, menuIconRippleFadeInTime, menuIconRippleFadeOutTime, menuIcon.ActualWidth);
        }
        
        public void setNavIcon(bool visible)
        {
            if (visible) {
                navIcon.Visibility = Visibility.Visible;
                title.Margin = new Thickness(titleMargin.Left, titleMargin.Top, titleMargin.Right, titleMargin.Bottom);
            }
            else {
                navIcon.Visibility = Visibility.Hidden;
                title.Margin = new Thickness(navIconMargin.Left, titleMargin.Top, titleMargin.Right, titleMargin.Bottom);
            }            
        }

        public void setMenuIcon(bool visible)
        {
            if (visible)
            {
                menuIcon.Visibility = Visibility.Visible;
                actionButtons.Margin = new Thickness(actionButtonsMargin.Left, actionButtonsMargin.Top, actionButtonsMargin.Right, actionButtonsMargin.Bottom);
            }
            else
            {
                menuIcon.Visibility = Visibility.Hidden;
                actionButtons.Margin = new Thickness(actionButtonsMargin.Left, actionButtonsMargin.Top, menuIconMargin.Right, actionButtonsMargin.Bottom);
            }
        }

        public void addActionButton(UIElement toolbaritem)
        {
            actionButtons.Children.Add(toolbaritem);
        }
    }
}

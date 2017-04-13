using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaterialWPFTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Ripple_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Ripple.CreateRipple();
        }

        private void Ripple_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MyPopup.PlacementTarget = sender as UIElement;
            MyPopup.Placement = PlacementMode.Bottom;
            MyPopup.AllowsTransparency = true;
            MyPopup.PopupAnimation = PopupAnimation.Slide;
            MyPopup.IsOpen = true;
            Ripple.RemoveRipple();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

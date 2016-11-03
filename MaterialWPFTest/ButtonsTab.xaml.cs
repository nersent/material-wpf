using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaterialWPF
{
    /// <summary>
    /// Interaction logic for ButtonsTab.xaml
    /// </summary>
    public partial class ButtonsTab : UserControl
    {
        public ButtonsTab()
        {
            InitializeComponent();
        }

        private void rb_MouseUp(object sender, MouseButtonEventArgs e)
        {
            rippleDecorator.Visibility = Visibility.Visible;
            rippleDecorator.DoRipple();
            grid.Visibility = Visibility.Visible;
            Animations.AnimateFade(0, 1, grid, 0.2, 0.3, null);
        }

        private void raisedButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            rippleDecorator.Visibility = Visibility.Hidden;
            Animations.AnimateFade(1, 0, grid, 0.2, 0, doafter);

        }

        public void doafter()
        {
            grid.Visibility = Visibility.Hidden;
        }

        private void raisedbutton_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            dialog.Show();
        }

        private void accept_MouseUp(object sender, MouseButtonEventArgs e)
        {
            dialog.Hide();
        }

        private void tooltipbutton_MouseEnter(object sender, MouseEventArgs e)
        {
            tooltip.Show();
        }

        private void tooltipbutton_MouseLeave(object sender, MouseEventArgs e)
        {
            tooltip.Hide();
        }
    }
}
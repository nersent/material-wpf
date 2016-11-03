using System.Windows.Controls;
using System.Windows.Input;

namespace MaterialWPFTest
{
    /// <summary>
    /// Interaction logic for ProgressAndSliders.xaml
    /// </summary>
    public partial class ProgressAndSliders : UserControl
    {
        public ProgressAndSliders()
        {
            InitializeComponent();
        }

        private int x = 50;
        private void raisedButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            progressbar.SetProgressWidth(x);
            x += 50;
        }

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {

        }
    }
}

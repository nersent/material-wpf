using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace MaterialWPF
{
    /// <summary>
    /// Interaction logic for MaterialContextMenuItem.xaml
    /// </summary>
    public partial class MaterialContextMenuItem : UserControl
    {
        public MaterialContextMenuItem(string xd)
        {
            InitializeComponent();
            setText(xd);
        }

        public MaterialContextMenuItem(string xd, Brush x)
        {
            InitializeComponent();
            setText(xd);
            this.Background = x;
        }

        public void setText(string text)
        {
            t.Text = text;
        }
    }
}

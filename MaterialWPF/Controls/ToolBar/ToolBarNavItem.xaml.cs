using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaterialWPF
{
    /// <summary>
    /// Interaction logic for ToolBarNavItem.xaml
    /// </summary>
    public partial class ToolBarNavItem : UserControl
    {
        public ToolBarNavItem()
        {
            InitializeComponent();
        }

        public void animate(bool b)
        {
            if (b)
            {
                Animations.AnimateFade(1,0, line2, 0.3, 0, null);
                //line3.RenderTransform = new RotateTransform(50);
                Animations.AnimateRotate(0, 32, line3, 0.3, 0, null);
            }
        }
    }
}

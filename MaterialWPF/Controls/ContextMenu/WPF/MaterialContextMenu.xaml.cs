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
    /// Interaction logic for MaterialContextMenu.xaml
    /// </summary>
    public partial class MaterialContextMenu : UserControl
    {
        public MaterialContextMenu()
        {
            InitializeComponent();
        }

        public void addItem(MaterialContextMenuItem item)
        {
            item.HorizontalAlignment = HorizontalAlignment.Center;
            item.VerticalAlignment = VerticalAlignment.Top;
            item.Margin = new Thickness(0, getItemsCount() * item.ActualHeight, 0, 0);
            MainGrid.Children.Add(item);
        }

        public int getItemsCount()
        {
            int count = MainGrid.Children.Count;
            return count;
        }
    }
}

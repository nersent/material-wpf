using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MaterialWPF
{
    class WinFormsMaterialContextMenu : ContextMenu
    {
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            Style contextmenustyle = FindResource("MaterialContextMenu") as Style;
            this.Style = contextmenustyle;
        }
    } 
}

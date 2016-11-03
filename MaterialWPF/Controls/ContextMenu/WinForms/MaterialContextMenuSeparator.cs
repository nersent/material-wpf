using System.Windows.Controls;
using System.Windows.Media;

namespace MaterialWPF
{
    class MaterialContextMenuSeparator : Separator
    {
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            this.Width = 364;
            this.Height = 2;
            this.Background = Brushes.Black;
            this.Opacity = 0.1;
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            this.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            this.Margin = new System.Windows.Thickness(-64, 0, 0, 0);
        }

       /* public void setOpacity(double opacity)
        {
            this.Opacity = opacity;
        }

        public void setHeight(double height)
        {
            this.Height = height;
        }

        public void setWidth(double width)
        {
            this.Width = width;
        }
        
        public void setHorizontalAlignment(System.Windows.HorizontalAlignment horizontalaligment)
        {
            this.HorizontalAlignment = horizontalaligment;
        }

        public void setVerticalAlignment(System.Windows.VerticalAlignment verticalaligment)
        {
            this.VerticalAlignment = verticalaligment;
        }

        public void setMargin(System.Windows.Thickness thickness)
        {
            this.Margin = thickness;
        }

        public void setBackgroundColor(Brush brush)
        {
            this.Background = brush;
        }

        public void setBackgroundColor(Color color)
        {
            this.Background = colorConverter.convertToBrush(color);
        }

        public void setBackgroundColor(String hex)
        {
            this.Background = colorConverter.convertToBrush(hex);
        }*/
    }
}

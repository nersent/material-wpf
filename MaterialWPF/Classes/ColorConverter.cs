using System;
using System.Windows.Media;

namespace MaterialWPF
{
    class colorConverter
    {
        public static Color convertToColor(Brush x)
        {
            return (x as SolidColorBrush).Color;
        }
        public static Color convertToColor(String hex)
        {
            return (Color)ColorConverter.ConvertFromString(hex);
        }

        public static Brush convertToBrush(Color x)
        {
            return new SolidColorBrush(x);
        }
        public static Brush convertToBrush(String hex)
        {
            return new SolidColorBrush((Color)ColorConverter.ConvertFromString(hex));
        }
    }
}
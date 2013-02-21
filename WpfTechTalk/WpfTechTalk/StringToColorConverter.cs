using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfTechTalk
{
    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                return ColorFor(((string) value).Length);
            }
            return null;
        }

        private Brush ColorFor(int length)
        {
            switch (length)
            {
                case 1:
                    return new SolidColorBrush(Colors.Red);
                    break;
                case 2: return new SolidColorBrush(Colors.Green);
                    break;
                case 3: return new SolidColorBrush(Colors.Orange);
                    break;
                case 4: return new SolidColorBrush(Colors.BurlyWood);
                    break;
                default: return new SolidColorBrush(Colors.Chartreuse);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
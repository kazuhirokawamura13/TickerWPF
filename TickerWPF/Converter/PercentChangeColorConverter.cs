using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace TickerWPF.Converter
{
    public class PercentChangeColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var state = value.ToString();
            decimal stateNum = System.Convert.ToDecimal(state);

            if (value != null)
            {
                if (stateNum > 0)
                {
                    return new SolidColorBrush(Colors.Green);
                }
                else
                {
                    return new SolidColorBrush(Colors.Red);
                }
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}

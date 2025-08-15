using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MiscWPFControls.Converters
{
    internal class HeadingConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int heading = (int)Math.Floor((double)value);
            double minutes = (((double)value) - heading) * 60;
            double seconds = (((double)minutes) - ((int)minutes)) * 60;
            return $"{heading:000}° {Math.Floor(minutes):00}' {Math.Floor(seconds):00}\"";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

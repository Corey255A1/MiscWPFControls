using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MiscWPFControls.Converters
{
    internal class ScaleConverter : IValueConverter
    {
        public double MaxValue { get; set; }
        public bool IsInverse { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (IsInverse)
            {
                return MaxValue * (1.0 - (double)value);
            }
            return MaxValue * (double)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

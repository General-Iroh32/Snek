using Snek.Graph_Creation.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace Snek.Graph_Creation.Converters
{
    class ZeitenConverter : IValueConverter
    {






        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double result = 0;
            if (value != null)
            {
                List<Zeiten> z = (List<Zeiten>)value;
                foreach (Zeiten current in z)
                {
                    result = result + current.Stunden;
                }

            }

            return result + "";


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

}

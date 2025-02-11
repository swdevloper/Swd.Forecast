using Swd.Forecast.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Swd.Forecast.Gui.Admin.ViewModel
{
    public class WeatherConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            Brush returnColor = Brushes.White;

            MeasuredData measuredData = (MeasuredData)value;

            decimal temperature = 0;

            if (Decimal.TryParse(measuredData.MeasuredValue, out temperature))
            {
                if (temperature >=0 ) 
                    {
                    return Brushes.LightBlue;
                    }
                 else
                    {
                    return Brushes.LightGray;

                    }
            };
            return returnColor; 

        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}

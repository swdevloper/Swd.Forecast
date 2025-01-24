using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Forecast.Helper
{
    public static class DateTimeExtensions
    {


        public static DateTime UnixTimeStampToDateTime(this int unixDateStamp)
        {
            DateTime convertedDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            convertedDateTime = convertedDateTime.AddSeconds(Convert.ToDouble(unixDateStamp)).ToLocalTime();
            return convertedDateTime;
        }
    }
}

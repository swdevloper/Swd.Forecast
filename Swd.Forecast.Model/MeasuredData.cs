using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Forecast.Model
{
    public class MeasuredData : ModelBase
    {
        public int Id { get; set; }
        public string MeasuredValue { get; set; }
        public DateTime MeasuredDateTime { get; set; }

        public TypeOfMeasuredData TypeOfMeasuredData { get; set; }
    }
}

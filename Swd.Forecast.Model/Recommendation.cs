using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Forecast.Model
{
    public class Recommendation : ModelBase
    {
        public int Id { get; set; }
        public string Variable { get; set; }
        public string Headline { get; set; }
        public string Text { get; set; }
        public bool IsActive { get; set; }
        

        public TypeOfRecommendation TypeOfRecommendation { get; set; }
    }
}

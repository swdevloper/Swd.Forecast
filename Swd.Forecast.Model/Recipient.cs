using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Forecast.Model
{
    public class Recipient: ModelBase
    {
        public int Id { get; set; }
        public string Salutation { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Notice { get; set; }
        public bool IsActive { get; set; }
        public string GeoInformation { get; set; }
        public string CommunicationData { get; set; }
    }
}

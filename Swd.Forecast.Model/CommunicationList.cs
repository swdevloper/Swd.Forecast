using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Swd.Forecast.Model
{
    public class CommunicationList : ModelBase
    {
        public int Id { get; set; }
        public string CommunicationType { get; set; }
        public string CommunicationIdentifier { get; set; }
        public string Headline { get; set; }
        public string Text { get; set; }
        public bool IsSent { get; set; }
        public DateTime SentDateTime { get; set; }


        public Recommendation Recommendation { get; set; } //Erzeugt bei der Migration FK automatisch
        public Recipient Recipient { get; set; } //Erzeugt bei der Migration FK automatisch





    }
}

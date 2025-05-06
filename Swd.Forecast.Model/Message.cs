using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Forecast.Model
{
    public class Message
    {

        private int _id;
        private NotificationType _notificationType;
        private string _sender;
        private string _recipients;
        private string _subject;
        private string _body;
        private int _communicationListId;


        public int Id { get { return _id; } set { _id = value; }   }
        public NotificationType NotificationType { get { return _notificationType; } set { _notificationType = value; } }
        public string Sender { get { return _sender; } set { _sender = value; } }
        public string Recipients { get { return _recipients; } set { _recipients = value; } }
        public string Subject { get { return _subject; } set { _subject = value; } }
        public string Body { get { return _body; } set { _body = value; } }
        public int CommunicationListId { get { return _communicationListId; } set { _communicationListId = value; } }
    }
}

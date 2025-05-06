using Swd.Forecast.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Forecast.Business
{
    public class NotificationService
    {


        public NotificationService() { 
        
        }


        public List<Message> GetMessagesToSend()
        {
            List<Message> messages = new List<Message>();

            CommunicationListService service = new CommunicationListService();

            List<CommunicationList> communicationList = service.ReadAllByNotSent().ToList();
            foreach (CommunicationList communicationListItem in communicationList)
            {
                Message message = new Message();
                message.NotificationType = Enum.Parse<NotificationType>(communicationListItem.CommunicationType.ToString());
                message.Recipients = communicationListItem.CommunicationIdentifier;
                message.Subject = communicationListItem.Headline;
                message.Body = communicationListItem.Text;
                //message.CommunicationListId = communicationListItem.Id;
                messages.Add(message);
            }
            return messages;
        }

    }
}

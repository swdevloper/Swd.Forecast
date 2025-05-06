using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swd.Forecast.Model;

namespace Swd.Forecast.Gui.Messenger
{
    public class MessageService : IMessageService
    {
        private readonly SmtpConfig _smtpConfig;
        private readonly ILogger<MessageService> _logger;


        public MessageService(IOptions<SmtpConfig> options, ILogger <MessageService> logger)
        {
            _smtpConfig = options.Value;
            _logger = logger;

        }


        public async Task ProcessMessage(Message message)
        {
            switch (message.NotificationType)
            {
                case NotificationType.EMail:
                    await SendMailNotification(message);
                    return;

                case NotificationType.Sms:
                case NotificationType.Voice:
                case NotificationType.App:
                case NotificationType.Push:
                case NotificationType.WhatsApp:
                    throw new NotImplementedException();    
                    return;
            }
        }

        private async Task SendMailNotification(Message message)
        {
            try
            {
                using (var client = new SmtpClient(_smtpConfig.Hostname))
                {
                    client.Port = _smtpConfig.Port;
                    client.Credentials = new NetworkCredential(_smtpConfig.Username, _smtpConfig.Password);
                    var mailMessage = new MailMessage(_smtpConfig.Sendername, message.Recipients,message.Subject, message.Body);
                    client.Send(mailMessage);
                    _logger.LogDebug(string.Format("{0}: Mail sent to {1}", MethodBase.GetCurrentMethod().Name, message.Recipients));
                    //await client.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }
        }

    }
}

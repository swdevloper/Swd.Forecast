using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Swd.Forecast.Business;
using Swd.Forecast.Model;

namespace Swd.Forecast.Gui.Messenger
{
    internal class Program
    {
        private static string _appConfigFile = "appSettings.json";


        static void Main(string[] args)
        {
            //Serilog per Code konfigurieren
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            

            var host = Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureAppConfiguration((context, config)=>
                {
                    config.AddJsonFile(_appConfigFile, optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    services.Configure<SmtpConfig>(context.Configuration.GetSection("SmtpConfig"));
                    services.AddTransient<IMessageService, MessageService>();
                    services.AddTransient<MessageService>();
                })
                .Build();

            var service = host.Services.GetRequiredService<MessageService>();




            //CommunicationListService communicationListService = new CommunicationListService();

            NotificationService notificationService = new NotificationService();
            List<Message> messageList = notificationService.GetMessagesToSend();
            foreach (var msg in messageList)
            {
                service.ProcessMessage(msg);
                //CommunicationList item = communicationListService.ReadById(msg.CommunicationListId);
                //item.IsSent = true; 
                //item.SentDateTime = DateTime.Now;
                //communicationListService.Update(item);  
            }
        }
    }
}

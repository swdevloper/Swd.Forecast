using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Reflection;

namespace Swd.Forecast.Gui.Retriever
{
    internal class Program
    {
        private static IConfiguration _configuration;
        private static string _appConfigFile = "appSettings.json";


        static void Main(string[] args)
        {
            ReadConfiguration();
            InitLogging(_configuration);
            Log.Information(string.Format("{0}: Application started", MethodBase.GetCurrentMethod().Name));

        }


        private static void ReadConfiguration ()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(_appConfigFile, optional: true, reloadOnChange: true)
                .Build();

        }


        private static void InitLogging(IConfiguration configuration)
        {
            {
                Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(configuration)
                    .CreateLogger();
                Log.Debug(string.Format("{0}: Logging started", MethodBase.GetCurrentMethod().Name));
            }
        }
    }
}

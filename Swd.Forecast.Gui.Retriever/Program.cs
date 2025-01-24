using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Serilog;
using Swd.Forecast.Business;
using Swd.Forecast.Helper;
using Swd.Forecast.Model;
using System.Reflection;

namespace Swd.Forecast.Gui.Retriever
{
    internal class Program
    {
        private static IConfiguration _configuration;
        private static IConfiguration _apiConfiguration;
        
        private static string _appConfigFile = "appSettings.json";


        static async Task Main(string[] args)
        {
            ReadConfiguration();
            InitLogging(_configuration);
            Log.Information(string.Format("{0}: Application started", MethodBase.GetCurrentMethod().Name));

            string apiConfigFile = _configuration.GetValue<string>("ApiConfigurationFile");
            ReadApiConfiguration(apiConfigFile);

            string lat = _apiConfiguration.GetValue<string>("lat"); 
            string lon = _apiConfiguration.GetValue<string>("lon"); 
            string units = _apiConfiguration.GetValue<string>("units");
            string appId = _apiConfiguration.GetValue<string>("appId");
            string apiCallString = _apiConfiguration.GetValue<string>("apiCallString");
            string queryString = string.Format("lat={0}&lon={1}&appid={2}&units={3}", lat, lon, appId, units);


            string content = await GetApiResponseContent(apiCallString, queryString);


            WeatherDataModel weatherData = JsonConvert.DeserializeObject<WeatherDataModel>(content);


            MeasuredData measuredData = new MeasuredData();
            measuredData.MeasuredValue = weatherData.Main.Temp.ToString();
            measuredData.MeasuredDateTime = weatherData.Dt.UnixTimeStampToDateTime();
            

            MeasuredDataService service = new MeasuredDataService();
            service.Add(measuredData);

        }


        private static void ReadConfiguration ()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(_appConfigFile, optional: true, reloadOnChange: true)
                .Build();
        }



        private static void ReadApiConfiguration(string apiConfigFile)
        {
            Log.Debug(string.Format("{0}: Reading api configuration", MethodBase.GetCurrentMethod().Name));

            string apiconfigFilePath = Path.Combine(Directory.GetCurrentDirectory(), "configuration", apiConfigFile);
            try
            {
                _apiConfiguration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(apiconfigFilePath, optional: true, reloadOnChange: true)
                    .Build();
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Format("{0}: Error reading api configuration", MethodBase.GetCurrentMethod().Name));
            }
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


        private static async Task<string> GetApiResponseContent(string apiCallString, string queryString)
        {
            Log.Debug(string.Format("{0}: Getting api response", MethodBase.GetCurrentMethod().Name));
            string content = string.Empty;
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, string.Format("{0}{1}", apiCallString, queryString));

                var response = await client.SendAsync(request);

                Log.Debug(string.Format("{0}: Response code {1}", MethodBase.GetCurrentMethod().Name, response.StatusCode));

                response.EnsureSuccessStatusCode();

                content = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Format("{0}: Error getting api response", MethodBase.GetCurrentMethod().Name));

            }
            return content; 
        }




    }
}

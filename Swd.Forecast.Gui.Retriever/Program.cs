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
            
            //TODO: Konfiguration auslagern
            string lat = _apiConfiguration.GetValue<string>("lat"); 
            string lon = _apiConfiguration.GetValue<string>("lon"); 
            string units = _apiConfiguration.GetValue<string>("units");
            string appId = _apiConfiguration.GetValue<string>("appId");
            string apiCallString = _apiConfiguration.GetValue<string>("apiCallString");
            string queryString = string.Format("lat={0}&lon={1}&appid={2}&units={3}", lat, lon, appId, units);

            //Längere Form des untenstehenden verketteten Aufrufs
            //string content = await ApiHelper.GetApiResponseContent(apiCallString, queryString);
            //AddMeasuredData(GetWeatherDataModelFromContent(content));


             AddMeasuredData(GetWeatherDataModelFromContent(await ApiHelper.GetApiResponseContent(apiCallString, queryString)));
        }



        private static WeatherDataModel GetWeatherDataModelFromContent(string content)
        {
            WeatherDataModel weatherData = new WeatherDataModel();
            Log.Debug(string.Format("{0}: Serializing content", MethodBase.GetCurrentMethod().Name));
            try
            {
                weatherData = JsonConvert.DeserializeObject<WeatherDataModel>(content);
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Format("{0}: Error serializing content", MethodBase.GetCurrentMethod().Name));
            }
            return weatherData;
        }


        private static void AddMeasuredData(WeatherDataModel weatherDataModel)
        {
            try
            {
                Log.Debug(string.Format("{0}: Adding measured data", MethodBase.GetCurrentMethod().Name));


                TypeOfMeasuredDataService typeOfMeasuredDataService = new TypeOfMeasuredDataService();
                List<TypeOfMeasuredData> typeOfMeasuredDatas = typeOfMeasuredDataService.ReadAll().ToList();

                MeasuredDataService service = new MeasuredDataService();

                MeasuredData measuredData = new MeasuredData();
                measuredData.MeasuredValue = weatherDataModel.Main.Temp.ToString();
                measuredData.MeasuredDateTime = weatherDataModel.Dt.UnixTimeStampToDateTime();
                measuredData.TypeOfMeasuredDataId = typeOfMeasuredDatas.Where(d => d.Id == "Temperature").FirstOrDefault().Id;
                service.Add(measuredData);

                measuredData = new MeasuredData();
                measuredData.MeasuredValue = weatherDataModel.Main.Pressure.ToString();
                measuredData.MeasuredDateTime = weatherDataModel.Dt.UnixTimeStampToDateTime();
                measuredData.TypeOfMeasuredDataId = typeOfMeasuredDatas.Where(d => d.Id == "Pressure").FirstOrDefault().Id;
                service.Add(measuredData);


                measuredData = new MeasuredData();
                measuredData.MeasuredValue = weatherDataModel.Main.Humidity.ToString();
                measuredData.MeasuredDateTime = weatherDataModel.Dt.UnixTimeStampToDateTime();
                measuredData.TypeOfMeasuredDataId = typeOfMeasuredDatas.Where(d => d.Id == "Humidity").FirstOrDefault().Id;
                service.Add(measuredData);
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Format("{0}: Error adding measured data", MethodBase.GetCurrentMethod().Name));
            }
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







    }
}

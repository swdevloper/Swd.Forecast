using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Forecast.Helper
{
    public static class ApiHelper
    {

        public static async Task<string> GetApiResponseContent(string apiCallString, string queryString)
        {
            Log.Debug(string.Format("{0}: Getting api response", MethodBase.GetCurrentMethod().Name));
            string content = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Get, string.Format("{0}{1}", apiCallString, queryString)))
                    {
                        using (var response = await client.SendAsync(request))
                        {
                            Log.Debug(string.Format("{0}: Response code {1}", MethodBase.GetCurrentMethod().Name, response.StatusCode));
                            response.EnsureSuccessStatusCode();
                            content = await response.Content.ReadAsStringAsync();
                        };
                    };
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Format("{0}: Error getting api response", MethodBase.GetCurrentMethod().Name));

            }
            return content;
        }

    }
}

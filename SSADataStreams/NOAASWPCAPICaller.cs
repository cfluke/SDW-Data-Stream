using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSADataStreams
{
    internal class NOAASWPCAPICaller
    {
        public async Task<List<string>> CallNOAASWPCAPIAsync()
        {
            try
            {
                //API endpoints that only require an API key
                //The endpoints can return blank if there is no alert/warning
                List<String> APIEndpointsNoOptions = new List<String>
                {
                    "json/boulder_k_index_1m.json",
                    "json/edited_events.json",
                    "json/electron_fluence_forecast.json",
                    "json/enlil_time_series.json",
                    "json/f107_cm_flux.json",
                    "json/ovation_aurora_latest.json",
                    "json/planetary_k_index_1m.json",
                    "json/predicted_f107cm_flux.json",
                    "json/predicted_fredericksburg_a_index.json",
                    "json/predicted_monthly_sunspot_number.json",
                    "json/solar_probabilities.json",
                    "json/solar_regions.json",
                    "json/sunspot_report.json"
                };

                //Call each API endpoint async
                return await CallNOAASWPCAPIEndpointsAsync(APIEndpointsNoOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<String> { ex.ToString() };
            }
        }
        async Task<List<string>> CallNOAASWPCAPIEndpointsAsync(List<String> endpoints)
        {
            List<string> responses = new List<string>();
            foreach (string endpoint in endpoints)
            {
                string fullURL = "https://services.swpc.noaa.gov/" + endpoint;

                //Create an HttpClient instance
                HttpClient httpClient = new HttpClient();

                //Create the HTTP request content
                StringContent content = new StringContent("", Encoding.UTF8, "application/json");

                //Send the POST request
                HttpResponseMessage response = await httpClient.GetAsync(fullURL);

                //Read the response
                string responseJson = await response.Content.ReadAsStringAsync();
                responses.Add(responseJson);
                //List <endpoint> responseJsonDeserialized = JsonConvert.DeserializeObject<List<endpoint>>(responseJson);

                using (StreamWriter writer = new StreamWriter(".\\Data\\NOAA_APICALLS.txt", true))
                {
                    writer.WriteLine(responseJson);
                }
                Console.WriteLine(responseJson);
            }
            return responses;
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSADataStreams
{
    internal class NOAASWPCAPICaller : APICaller
    {
        public NOAASWPCAPICaller(): base("NOAA")
        {

        }
        public override async Task<List<string>> CallAPIAsync()
        {
            try
            {
                //API endpoints that only require an API key
                //The endpoints can return blank if there is no alert/warning
                Dictionary<string, List<string>> endpointSubpageMap = new Dictionary<string, List<string>>();

                List<String> APIEndpointsJSON = new List<String>
                {
                    "boulder_k_index_1m.json",
                    "edited_events.json",
                    "electron_fluence_forecast.json",
                    "enlil_time_series.json",
                    "f107_cm_flux.json",
                    //"ovation_aurora_latest.json",
                    "planetary_k_index_1m.json",
                    "predicted_f107cm_flux.json",
                    "predicted_fredericksburg_a_index.json",
                    "predicted_monthly_sunspot_number.json",
                    "solar_probabilities.json",
                    "solar_regions.json",
                    "sunspot_report.json"
                };


                endpointSubpageMap.Add("json/", APIEndpointsJSON);

                List<string> responseLast = new List<string>();
                //Call each API endpoint async
                foreach (string subpage in endpointSubpageMap.Keys)
                {
                    //Blank string on end as NOAA does not need authentication yet
                    responseLast = await CallAPITextEndpointsAsync("https://services.swpc.noaa.gov/" + subpage, endpointSubpageMap.GetValueOrDefault(subpage), HttpMethod.Get);
                }
                return responseLast;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<String> { ex.ToString() };
            }
        }
    }
}

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
                Dictionary<string, List<string>> endpointTextSubpageMap = new Dictionary<string, List<string>>();
                Dictionary<string, List<string>> endpointImageSubpageMap = new Dictionary<string, List<string>>();

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

                List<String> APIEndpointsJSONSolarCycle = new List<String>
                {
                    "f10-7cm-flux-smoothed.json",
                    "f10-7cm-flux.json",
                    "observed-solar-cycle-indices.json",
                    "predicted-solar-cycle.json",
                    "solar-cycle-25-f10-7cm-flux-predicted-high-low.json",
                    "solar-cycle-25-predicted.json",
                    "solar-cycle-25-ssn-predicted-high-low.json",
                    "sunspots-smoothed.json",
                    "sunspots.json",
                    "swpc_observed_ssn.json"
                };

                List<String> APIEndpointsJSONStereo = new List<String>
                {
                    "stereo_a_1m.json"
                };

                List<String> APIEndpointsJSONRTSW = new List<String>
                {
                    "rtsw_ephemerides_1h.json",
                    "rtsw_mag_1m.json",
                    "rtsw_wind_1m.json"
                };

                List<String> APIEndpointsJSONGeoSpace = new List<String>
                {
                    "geospace_dst_1_hour.json",
                    "geospace_pred_est_kp_1_hour.json",
                    "geospce_pred_est_kp_7_day.json"
                };

                endpointTextSubpageMap.Add("json/", APIEndpointsJSON);
                endpointTextSubpageMap.Add("json/solar-cycle/", APIEndpointsJSONSolarCycle);
                endpointTextSubpageMap.Add("json/stereo/", APIEndpointsJSONStereo);
                endpointTextSubpageMap.Add("json/rtsw/", APIEndpointsJSONRTSW);
                endpointTextSubpageMap.Add("json/geospace/", APIEndpointsJSONGeoSpace);

                List<String> APIEndpointsImageACEEPAM = new List<String>
                {
                    "ace-epam-2-hour.gif",
                    "ace-epam-6-hour.gif",
                    "ace-epam-24-hour.gif",
                    "ace-epam-3-day.gif",
                    "ace-epam-7-day.gif",

                    "ace-epam-e-2-hour.gif",
                    "ace-epam-e-6-hour.gif",
                    "ace-epam-e-24-hour.gif",
                    "ace-epam-e-3-day.gif",
                    "ace-epam-e-7-day.gif",

                    "ace-epam-p-2-hour.gif",
                    "ace-epam-p-6-hour.gif",
                    "ace-epam-p-24-hour.gif",
                    "ace-epam-p-3-day.gif",
                    "ace-epam-p-7-day.gif",
                    "ace-mag-2-hour.gif",
                    "ace-mag-6-hour.gif",
                    "ace-mag-24-hour.gif",
                    "ace-mag-3-day.gif",
                    "ace-mag-7-day.gif"
                };

                endpointImageSubpageMap.Add("/images/", APIEndpointsImageACEEPAM);

                List<string> responseLastText = new List<string>();
                List<Image> responseLastImage = new List<Image>();
                //Call each text API endpoint async
                foreach (string subpage in endpointTextSubpageMap.Keys)
                {
                    //Blank string on end as NOAA does not need authentication yet
                    responseLastText = await CallAPITextEndpointsAsync("https://services.swpc.noaa.gov/" + subpage, endpointTextSubpageMap.GetValueOrDefault(subpage), HttpMethod.Get, "", subpage);
                }
                //Call each image API endpoint async
                foreach (string subpage in endpointImageSubpageMap.Keys)
                {
                    //Blank string on end as NOAA does not need authentication yet
                    responseLastImage = await CallAPIImageEndpointsAsync("https://services.swpc.noaa.gov/" + subpage, endpointImageSubpageMap.GetValueOrDefault(subpage), HttpMethod.Get, "", subpage);
                }
                return responseLastText;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<String> { ex.ToString() };
            }
        }
    }
}

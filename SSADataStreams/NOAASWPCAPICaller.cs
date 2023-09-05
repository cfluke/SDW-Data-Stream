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
                //Dictionary<string, List<string>> endpointTextSubpageMap = new Dictionary<string, List<string>>();
                Dictionary<string, List<string>> endpointImageSubpageMap = new Dictionary<string, List<string>>();

                Dictionary<string, List<string>> endpointTextSubpageMap = ReadEndpointFiles();

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
                    responseLastText = await CallAPITextEndpointsAsync(endpointTextSubpageMap.GetValueOrDefault(subpage), HttpMethod.Get, "", subpage);
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

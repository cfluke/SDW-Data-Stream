using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSADataStreams
{
    internal class SpaceWeatherServiceAPICaller
    {
        public async Task<int> CallSWSAPIAsync()
        {
            try
            {
                //API endpoints that require options
                List<string> APIEndpointsWithOptions = new List<string>
                {
                    "get-a-index",
                    "get-k-index",
                    "get-dst-index",
                };
                //API endpoints that only require an API key
                //The endpoints can return blank if there is no alert/warning
                List<string> APIEndpointsNoOptions = new List<string>
                {
                    "get-mag-alert",
                    "get-mag-warning",
                    "get-aurora-alert",
                    "get-aurora-watch",
                    "get-aurora-outlook"
                };

                string APIKeyOnly = @"{
                ""api_key"": ""710f9362-83c8-4c2e-92fb-2baf5ab8825d""
		        }";

                string optionsReduced = @"{
                ""api_key"": ""710f9362-83c8-4c2e-92fb-2baf5ab8825d"",
                ""options"": {
                    ""location"": ""Australian region""
                }
		        }";
                string optionsFull = @"{
                ""api_key"": ""710f9362-83c8-4c2e-92fb-2baf5ab8825d"",
                ""options"": {
                    ""location"": ""Australian region"",
                    ""start"": ""prop1"",
                    ""end"": ""prop1""
                    }
		        }";

                //Call each API endpoint async
                await CallSWSAPIEndpointsAsync(optionsReduced, APIEndpointsWithOptions);
                await CallSWSAPIEndpointsAsync(APIKeyOnly, APIEndpointsNoOptions);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        async Task<string> CallSWSAPIEndpointsAsync(string JSONOptions, List<string> endpoints)
        {
            List<string> responses = new List<string>();
            foreach (string endpoint in endpoints)
            {
                string fullURL = "https://sws-data.sws.bom.gov.au/api/v1/" + endpoint;

                //Create an HttpClient instance
                HttpClient httpClient = new HttpClient();

                //Create the HTTP request content
                StringContent content = new StringContent(JSONOptions, Encoding.UTF8, "application/json");

                //Send the POST request
                HttpResponseMessage response = await httpClient.PostAsync(fullURL, content);

                //Read the response
                string responseJson = await response.Content.ReadAsStringAsync();

                //Write to file using StreamWriter
                using (StreamWriter writer = new StreamWriter(".\\APICALLS.txt", true))
                {
                    writer.WriteLine(responseJson);
                }
                Console.WriteLine(responseJson);
            }
            return "Complete";
        }
    }
}

using SSADataStreams;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;





List<string> APIEndpoints = new List<string>
{
    "get-a-index",
    "get-k-index",
    "get-dst-index",
    "get-mag-alert",
    "get-mag-warning",
    "get-aurora-alert",
    "get-aurora-watch",
    "get-aurora-outlook"
};

Dictionary<string, string> sampleResponseData = new Dictionary<string, string>
{
    {"get-a-index", "{\"data\": [{\"valid_time\": \"2021-12-12 00:00:00\",\"index\": 3},]"},
    {"get-k-index", "{\r\n    \"data\": [\r\n      {\r\n        \"valid_time\": \"2015-11-30 13:05:00\",\r\n        \"index\": -44\r\n      },\r\n    ]\r\n  }"},
    {"get-dst-index", "{\r\n    \"data\": [\r\n      {\r\n        \"index\": \"6\",\r\n        \"valid_time\": \"2021-11-21 00:05:00\"\r\n      },\r\n      {\r\n        \"index\": \"3\",\r\n        \"valid_time\": \"2021-11-21 00:15:00\"\r\n      },\r\n      {\r\n        \"index\": \"4\",\r\n        \"valid_time\": \"2021-11-21 00:25:00\"\r\n      },\r\n\r\n      ...\r\n\r\n      {\r\n        \"index\": \"-5\",\r\n        \"valid_time\": \"2021-11-21 23:35:00\"\r\n      },\r\n      {\r\n        \"index\": \"-9\",\r\n        \"valid_time\": \"2021-11-21 23:45:00\"\r\n      },\r\n      {\r\n        \"index\": \"-7\",\r\n        \"valid_time\": \"2021-11-21 23:55:00\"\r\n      }\r\n    ]\r\n  }"},
    {"get-mag-alert", "{\r\n    \"data\": [\r\n      {\r\n        \"start_time\": \"2015-02-07 08:45:\",\r\n        \"valid_until\": \"2015-02-07 20:45:00\",\r\n        \"g_scale\": 1,\r\n        \"description\": \"minor\"\r\n      }\r\n    ]\r\n  }"},
    {"get-mag-warning", "{\r\n    \"data\": [\r\n      {\r\n        \"issue_time\": \"2015-03-01 23:18:00\",\r\n        \"start_date\": \"2015-03-02\",\r\n        \"end_date\": \"2015-03-03\",\r\n        \"cause\": \"coronal hole\",\r\n        \"activity\": [\r\n          { \"date\": \"2015-03-02\", \"forecast\": \"Unsettled to minor storm\" },\r\n          { \"date\": \"2015-03-03\", \"forecast\": \"Unsettled to minor storm\" }\r\n        ],\r\n        \"comments\": \"The effect of the high speed solar wind stream from a coronal hole may keep the geomagnetic activity enhanced to unsettled to active levels on 2 and 3 March with the possibility of some minor storm periods on these days.\"\r\n      }\r\n    ]\r\n  }"},
    {"get-aurora-alert", "{\r\n    \"data\": [\r\n      {\r\n        \"start_time\": \"2015-02-07 08:45:\",\r\n        \"valid_until\": \"2015-02-07 20:45:00\",\r\n        \"k_aus\": 6,\r\n        \"lat_band\": \"high\"\r\n        \"description\": \"Geomagnetic storm in progress. Aurora may be observed during local night time hours in good observing conditions at high latitudes.\"\r\n      }\r\n    ]\r\n  }"},
    {"get-aurora-watch", "{\r\n    \"data\": [\r\n      {\r\n        \"issue_time\": \"2015-01-06 23:18:00\",\r\n        \"start_date\": \"2015-01-07\",\r\n        \"end_date\": \"2015-01-08\",\r\n        \"cause\": \"coronal hole\",\r\n        \"k_aus\": 6,\r\n        \"lat_band\": \"high\",\r\n        \"comments\": \"Effects of a coronal hole are expected to impact the Earth within the next 48 hours, possibly resulting in significant geomagnetic activity and visible auroras during local nighttime hours. Aurora alerts will follow if significant geomagnetic activity actually occurs.\"\r\n      }\r\n    ]\r\n  }"},
    {"get-aurora-outlook", "{\r\n    \"data\": [\r\n      {\r\n        \"issue_time\": \"2015-01-12 23:18:00\",\r\n        \"start_date\": \"2015-01-15\",\r\n        \"end_date\": \"2015-01-17\",\r\n        \"cause\": \"coronal mass ejection\",\r\n        \"k_aus\": 7,\r\n        \"lat_band\": \"mid\",\r\n        \"comments\": \"A large active solar region is rotating into a position that is favourable for geoeffective coronal mass ejections (CMEs) and possible auroral activity. There is an increased chance of auroral activity during the period 3-7 days hence. Warnings and/or alerts will follow if a geoeffective CME is observed and/or significant geomagnetic activity actually occurs.\"\r\n      }\r\n    ]\r\n  }"}
};

//Call each API endpoint
foreach (string endpoint in APIEndpoints)
{
    string fullURL = "https://sws-data.sws.bom.gov.au/api/v1/" + endpoint;
    // Set the request data in the form of key-value pairs
    Dictionary<string, string> requestData = new Dictionary<string, string>
    {
        { "api_key", "3f723484-5188-475d-bd35-d969324a4926" }
        // Add more key-value pairs as needed
    };

    // Convert the request data to JSON format
    string jsonRequestBody = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);

    // Create an HttpClient instance
    HttpClient httpClient = new HttpClient();

    // Create the HTTP request content
    StringContent content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

    // Send the POST request
    //HttpResponseMessage response = await httpClient.PostAsync(fullURL, content);

    // Read the response
    //string responseJson = await response.Content.ReadAsStringAsync();

    //Use to access sample data instead of calling API
    string responseJson = sampleResponseData[endpoint];

    // Process the response JSON as needed
    Console.WriteLine(responseJson);
}































/*
// Create an instance of HttpClient
HttpRequestMessage httpClient = new HttpRequestMessage();

// Define the API endpoint and the request URL
string apiUrl = "https://sws-data.sws.bom.gov.au/api/v1/get-a-index";

// Define the request body parameters as a JSON string
string jsonBody = "{ \"api_key\": \"3f723484-5188-475d-bd35-d969324a4926\", \"options\": \"{location\": \"Australian region\"}}";

// Convert the JSON string to a StringContent object
StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

try
{
    httpClient.Properties.Add("Content-Type", "application/json; charset=UTF-8");
    // Send the POST request and get the response
    HttpResponseMessage response = await httpClient. (apiUrl, content);

    // Check if the response is successful
    Console.WriteLine(response.Content.ReadAsStringAsync());
    if (response.IsSuccessStatusCode)
    {
        // Read the response content as a string
        string responseJson = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Response: " + responseJson);
    }
    else
    {
        Console.WriteLine("Status Code: " + response.StatusCode);
    }
}
catch (Exception ex)
{
    // Handle exceptions
    Console.WriteLine("Error: " + ex.Message);
}
finally
{
    // Dispose the HttpClient instance
    httpClient.Dispose();
}

*/


















/*
using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

var repositories = await ProcessRepositoriesAsync(client);

foreach (var repo in repositories)
{
    Console.WriteLine($"Name: {repo.Name}");
    Console.WriteLine($"Homepage: {repo.Homepage}");
    Console.WriteLine($"GitHub: {repo.GitHubHomeUrl}");
    Console.WriteLine($"Description: {repo.Description}");
    Console.WriteLine($"Watchers: {repo.Watchers:#,0}");
    Console.WriteLine($"Last Push: {repo.LastPush}");
    Console.WriteLine();
}

static async Task<List<Repository>> ProcessRepositoriesAsync(HttpClient client)
{
    var body = "{\"api_key\":\"3f723484-5188-475d-bd35-d969324a4926\",\"options\": {\"location\":\"Australian region\"}}";
    HttpContent test = new();
    Http
    await using Stream stream = await client.PostAsync("https://sws-data.sws.bom.gov.au/api/v1/get-a-index", body);
    Console.WriteLine(stream);
    //var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(stream);
    return new();
}*/
using CsvHelper;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Formats.Asn1;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Net.Http;
using SixLabors.ImageSharp;
using System.Collections;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats;

namespace SSADataStreams
{
    internal abstract class APICaller
    {
        private string _APICallerName;

        public string APICallerName { get => _APICallerName; set => _APICallerName = value; }

        protected APICaller(string APICallerName) {
            _APICallerName = APICallerName;
        }
        public async Task<List<string>> CallAPITextEndpointsAsync(List<string> endpoints, HttpMethod httpMethod , string JSONOptions = "", string subFolder = "")
        {
            List<string> responses = new List<string>();
            //Create an HttpClient instance (Created here as HttpClients should be reused)
            HttpClient httpClient = new HttpClient();
            foreach (string endpoint in endpoints)
            {
                string fullURL = endpoint;
                //Log URL
                Console.WriteLine("Pulling data from: " + fullURL);
                //Create the HTTP request content
                StringContent content = new StringContent(JSONOptions, Encoding.UTF8, "application/json");

                //Send the GET/POST request
                HttpResponseMessage response;
                if (httpMethod == HttpMethod.Post)
                {
                    response = await httpClient.PostAsync(fullURL, content);
                } else
                {
                    response = await httpClient.GetAsync(fullURL);
                }
                //Read the response
                string responseJson = await response.Content.ReadAsStringAsync();
                //Check status code
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error occured while contacting " + fullURL + ": " + responseJson);
                    responses.Add("Error occured while contacting " + fullURL + ": " + responseJson);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Successfully pulled data from " + fullURL);
                    responses.Add(responseJson);
                }
                //Reset console colour from red/green
                Console.ResetColor();
                //Write to file using StreamWriter
                if (subFolder != "")
                {
                    subFolder = "\\" + subFolder;
                }
                string fileName = Path.GetFileNameWithoutExtension(endpoint);

                WriteCSVFile(fileName, APICallerName + subFolder, responseJson);
            }
            return responses;
        }

        public async Task<List<Image>> CallAPIImageEndpointsAsync(string baseURL, List<string> endpoints, HttpMethod httpMethod, string JSONOptions = "", string subFolder = "")
        {
            List<Image> responses = new List<Image>();
            //Create an HttpClient instance (Created here as HttpClients should be reused)
            HttpClient httpClient = new HttpClient();
            foreach (string endpoint in endpoints)
            {
                string fullURL = baseURL + endpoint;
                //Log URL
                Console.WriteLine("Pulling data from: " + fullURL);
                //Create the HTTP request content
                StringContent content = new StringContent(JSONOptions, Encoding.UTF8, "application/json");

                //Send the GET/POST request
                HttpResponseMessage response;
                if (httpMethod == HttpMethod.Post)
                {
                    response = await httpClient.PostAsync(fullURL, content);
                }
                else
                {
                    response = await httpClient.GetAsync(fullURL);
                }
                //Read the response stream
                Stream stream = await response.Content.ReadAsStreamAsync();
                byte[] imageData = new byte[stream.Length];
                stream.Read(imageData, 0, (int)stream.Length);
                var image = Image.Load<Rgba32>(imageData);
                //Check status code
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error occured while contacting " + fullURL + ": " + image);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Successfully pulled data from " + fullURL);
                    responses.Add(image);
                }
                //Reset console colour from red/green
                Console.ResetColor();
                //Write to file using StreamWriter
                if (subFolder != "")
                {
                    subFolder = "\\" + subFolder;
                }
                string directoryPath = ".\\Data\\CurrentRun\\" + subFolder + "\\";
                DirectoryInfo directoryInfo = Directory.CreateDirectory(directoryPath);
                //Save image to file
                image.Save(directoryPath + "\\" + endpoint);
            }
            return responses;
        }
        public abstract Task<List<string>> CallAPIAsync();

        public Dictionary<string, List<string>> ReadEndpointFiles()
        {
            string folderPath = ".\\Endpoints\\" + this.APICallerName + "\\";
            Dictionary<string, List<string>> endpointsMap = new Dictionary<string, List<string>>();

            foreach (string file in Directory.EnumerateFiles(folderPath, "*.txt"))
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                Console.WriteLine(fileName);
                //Add all lines of text file to endpoint list
                if (endpointsMap.ContainsKey(fileName))
                {
                    endpointsMap[fileName].AddRange(File.ReadAllLines(file).ToList());
                } else
                {
                    endpointsMap.Add(fileName, File.ReadAllLines(file).ToList());
                }
            }
            return endpointsMap;
        }


        public static void WriteCSVFile(string fileName, string folderName, string jsonContent)
        {
            //Console.WriteLine(jsonContent);
            //NewtonSoft json nuget package
            XmlNode xml = JsonConvert.DeserializeXmlNode("{records:{record:[" + jsonContent + "]}}");
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xml.InnerXml);
            XmlReader xmlReader = new XmlNodeReader(xml);
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(xmlReader);
            //Check if data was returned from API
            DataTable dataTable = new DataTable();
            dataTable = dataSet.Tables[dataSet.Tables.Count - 1];
            //Datatable to CSV
            var lines = new List<string>();
            string[] columnNames = dataTable.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName).
                                              ToArray();
            var header = string.Join(",", columnNames);
            lines.Add(header);
            var valueLines = dataTable.AsEnumerable()
                               .Select(row => string.Join(",", row.ItemArray));
            lines.AddRange(valueLines);
            string directoryPath = ".\\Data\\CurrentRun\\" + folderName + "\\";
            DirectoryInfo directoryInfo = Directory.CreateDirectory(directoryPath);
            File.WriteAllLines(directoryPath + fileName + ".csv", lines);
        }
    }
}

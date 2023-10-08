using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using SSADataStreams;
using System.Net;
using System.Net.Http.Headers;

namespace SSADataStreamsUnitTests
{
    [TestClass]
    public class APICallerTest
    {
        private const string SWSCallerExpectedName = "SpaceWeather";
        private const string NOAACallerExpectedName = "NOAA";
        private const string APICallExpectedResult = "";

        private List<string> testAPIList = new List<string>();

        SpaceWeatherServiceAPICaller SpaceWeatherServiceCaller = new SpaceWeatherServiceAPICaller();
        NOAASWPCAPICaller NOAASWPCCaller = new NOAASWPCAPICaller();
        
        [TestMethod]
        public void TestCallerNames()
        {
            Assert.AreEqual(SWSCallerExpectedName, SpaceWeatherServiceCaller.APICallerName);
            Assert.AreEqual(NOAACallerExpectedName, NOAASWPCCaller.APICallerName);
        }
        [TestMethod]
        public async Task TestAPICallTypeJSON()
        {
            testAPIList.Clear();
            testAPIList.Add("https://services.swpc.noaa.gov/json/boulder_k_index_1m.json");

            string responseType = await NOAASWPCCaller.CallAPIEndpointsAsync(testAPIList, HttpMethod.Get);
            Assert.AreEqual(MediaTypeHeaderValue.Parse("application/json"), MediaTypeHeaderValue.Parse(responseType));
        }
        [TestMethod]
        public async Task TestAPICallTypeGIF()
        {
            testAPIList.Clear();
            testAPIList.Add("https://services.swpc.noaa.gov/images/ace-epam-e-2-hour.gif");

            string responseType = await NOAASWPCCaller.CallAPIEndpointsAsync(testAPIList, HttpMethod.Get);
            Assert.AreEqual(MediaTypeHeaderValue.Parse("image/gif"), MediaTypeHeaderValue.Parse(responseType));
        }
        [TestMethod]
        public async Task TestGIFFileWriting()
        {
            testAPIList.Clear();
            testAPIList.Add("https://services.swpc.noaa.gov/images/ace-epam-e-2-hour.gif");

            string responseType = await NOAASWPCCaller.CallAPIEndpointsAsync(testAPIList, HttpMethod.Get);
            Assert.AreEqual(MediaTypeHeaderValue.Parse("image/gif"), MediaTypeHeaderValue.Parse(responseType));

            string[] files = Directory.GetFiles(".\\Data\\CurrentRun\\NOAA\\");
            foreach(string file in files)
            {
                if(file.Contains(".png"))
                {
                    Assert.IsTrue(file.Contains(".png"));
                }
            }
        }
        [TestMethod]
        public async Task TestJSONFileWriting()
        {
            testAPIList.Clear();
            testAPIList.Add("https://services.swpc.noaa.gov/json/boulder_k_index_1m.json");

            string responseType = await NOAASWPCCaller.CallAPIEndpointsAsync(testAPIList, HttpMethod.Get);
            Assert.AreEqual(MediaTypeHeaderValue.Parse("application/json"), MediaTypeHeaderValue.Parse(responseType));

            string[] files = Directory.GetFiles(".\\Data\\CurrentRun\\NOAA\\");
            foreach (string file in files)
            {
                if (file.Contains(".csv"))
                {
                    Assert.IsTrue(file.Contains(".csv"));
                }
            }
        }
        [TestMethod]
        public async Task TestEndpointFileReading()
        {
            var endpointList = NOAASWPCCaller.ReadEndpointFiles();
            Assert.IsTrue(endpointList.Count > 0);
        }
    }
}
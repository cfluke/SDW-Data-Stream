using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SSADataStreams
{
    internal class HimawariData
    {
        string url = "https://sc-nc-web.nict.go.jp/wsdb_osndisk/shareDirDownload/bDw2maKV?sI=D531106,D531106m,D531107m,TIm,evm&sIt=data_im&";
        string urlJpg = "www.data.jma.go.jp/mscweb/data/himawari/img/aus/aus_tre_0000.jpg";
        private static readonly HttpClient client = new();

        // sDw = Time interval (epoch time)
        // sD = end time (epoch)

        DateTime timeFinish;
        long timePeriodEpochTime, timeFinishEpochTime;
        bool select;

        HimawariData(DateTime time, long period) { 
            this.timeFinish = time;
            var dateTimeWithEpochTimeOffset = new DateTimeOffset(time).ToUniversalTime();
            this.timeFinishEpochTime = dateTimeWithEpochTimeOffset.ToUnixTimeMilliseconds();
            this.timePeriodEpochTime = period;
            this.select = true;
        }

        string createURl() {
            string ret;   //return value
            string sD = timeFinishEpochTime.ToString();
            string sDw = timePeriodEpochTime.ToString();
            string selected = select ? selected = "1" : selected = "0";    //if select is true, selected is 1. else, selected is 0

            string urlOptions = "sD=" + sD + "&sDw=" + sDw + "&selected=" + selected;
            ret = url + urlOptions;
            return ret;
        }
        public async void getPngLinks(string himaUrl) {
            
            new DriverManager().SetUpDriver(new ChromeConfig());

            var driver = new FirefoxDriver();
            //driver.Navigate().GoToUrl("https://sc-nc-web.nict.go.jp/wsdb_osndisk/shareDirDownload/bDw2maKV?lang=en");
            driver.Navigate().GoToUrl(himaUrl);
            driver.Navigate().GoToUrl(himaUrl);

            List<string> imageFiles = new List<string>();

            var searchComplete = driver.FindElement(By.ClassName("ui-progressbar")).GetAttribute("aria-valuenow");
            do
            {
                searchComplete = driver.FindElement(By.ClassName("ui-progressbar")).GetAttribute("aria-valuenow");
            } while (searchComplete != "100");
            
            Console.WriteLine("completed");
            //System.Threading.Thread.Sleep(1000);
            var tableElement = driver.FindElement(By.Id("data_im_table"));
            var tableBody = tableElement.FindElement(By.TagName("tbody"));

            IList<IWebElement> imageResultsRows = tableBody.FindElements(By.TagName("tr"));
            //Console.WriteLine(imageResultsRows.Count);
           // IList<IWebElement> columns;

                foreach (IWebElement element in imageResultsRows)
                {
                    //columns = element.FindElements(By.TagName("td"));
                    imageFiles.Add(element.GetAttribute("data-fname"));
                }

               /* foreach (string name in imageFiles)
                {
                    Console.WriteLine(name);
                }
               */
            Console.WriteLine(imageFiles.Count());

            var downloadButton = driver.FindElement(By.Id("download_btn2"));

                driver.ExecuteAsyncScript("arguments[0].click();", downloadButton);
                
           /* 
        var values = new Dictionary<string, string>
        {
            { "data[FileSearch][is_compress]", "false" },
            { "data[FileSearch][fixedToken]", "82b8751c1881f53a3295583bd9085c95271213a2" },
            {"data[FileSearch][hashUrl]", "bDw2maKV" },
            { "action", "dir_download_dl"},
            { "filelist[0]", "/osn-disk/webuser/wsdb/share_directory/bDw2maKV/png/Pifd/2023/05-03/18/hima920230503183000fd.png"},
            { "dl_path", "/osn-disk/webuser/wsdb/share_directory/bDw2maKV/png/Pifd/2023/05-03/18/hima920230503183000fd.png"}
        };

        var content = new FormUrlEncodedContent(values);
            Console.WriteLine(content.ReadAsStream());
        var response = await client.PostAsync("https://sc-nc-web.nict.go.jp/wsdb_osndisk/fileSearch/download\r\n", content);
        var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);

            */

    }
        public static void Main()
        {
            DateTime targetTime = new DateTime(2023, 5, 10, 12, 00, 00, 000);
            int timeIntervalMinutes = 30;
            long period = 1000 * 60 * timeIntervalMinutes;
            HimawariData himaData = new HimawariData(targetTime, period);
            string url = himaData.createURl();
            //Console.WriteLine(url);
           // url = "https://sc-nc-web.nict.go.jp/wsdb_osndisk/shareDirDownload/bDw2maKV?sI=D531106,D531106m,D531107m,TIm,evm&sIt=data_im&sD=1683916500000&sDw=32400000&selected=1";
            himaData.getPngLinks(url);

        }
    }


    
}

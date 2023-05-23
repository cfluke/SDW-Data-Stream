using SSADataStreams;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

//Create API callers
SpaceWeatherServiceAPICaller SWSCaller = new SpaceWeatherServiceAPICaller();
NOAASWPCAPICaller NOAACaller = new NOAASWPCAPICaller();
//Run API calls and await results
Console.WriteLine(await SWSCaller.CallSWSAPIAsync());
Console.WriteLine(await NOAACaller.CallNOAASWPCAPIAsync());
//Store collected data under today's date
System.IO.File.Move(".\\Data\\SWS.txt", ".\\Data\\SWS" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
System.IO.File.Move(".\\Data\\NOAA_APICALLS.txt", ".\\Data\\NOAA_APICALLS_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
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
Console.WriteLine("Writing data to file: " + "...APICALLS_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
try
{
    System.IO.File.Move(".\\Data\\SWS_APICALLS.txt", ".\\Data\\SWS_APICALLS_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
    System.IO.File.Move(".\\Data\\NOAA_APICALLS.txt", ".\\Data\\NOAA_APICALLS_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
} catch(Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.ToString());
}

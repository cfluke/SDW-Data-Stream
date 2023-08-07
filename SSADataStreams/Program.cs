using SSADataStreams;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

List<APICaller> APICallerList = new List<APICaller>();
//Create API callers
SpaceWeatherServiceAPICaller SpaceWeatherServiceCaller = new SpaceWeatherServiceAPICaller();
NOAASWPCAPICaller NOAASWPCCaller = new NOAASWPCAPICaller();
//Add API callers to list to run through
APICallerList.Add(SpaceWeatherServiceCaller);
APICallerList.Add(NOAASWPCCaller);
//Run through each caller, write response to file
foreach (APICaller APICaller in APICallerList)
{
    //Run API calls and await results
    Console.WriteLine(await APICaller.CallAPIAsync());

    try
    {
        string sourceDirName = ".\\Data\\" + APICaller.APICallerName;
        string destDirName = ".\\Data\\" + APICaller.APICallerName + "_" + DateTime.Now.ToString("yyyyMMdd");
        try
        {
            Directory.Move(sourceDirName, destDirName);
        }
        catch (IOException exp)
        {
            Console.WriteLine(exp.Message);
        }
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.ToString());
    }
}
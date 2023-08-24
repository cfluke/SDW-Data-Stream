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
}
//Move all collected data to new folder with date
try
{
    //Create CurrentRun directory to ensure it exists
    Directory.CreateDirectory(".\\Data\\CurrentRun");
    string sourceDirName = ".\\Data\\CurrentRun";
    string destDirName = ".\\Data\\DataCalls" + "_" + DateTime.Now.ToString("yyyyMMdd");
    //Append number to folder name if already exists
    int folderIndex = 0;
    bool folderMoveFailed = true;
    string destDirNameTemp = destDirName;
    while (folderMoveFailed)
    {
        try
        {
            Directory.Move(sourceDirName, destDirNameTemp);
            folderMoveFailed = false;
        }
        catch (IOException exp)
        {
            //Console.WriteLine(exp.Message);
            folderMoveFailed = true;
            destDirNameTemp = destDirName + "_" + folderIndex;
            folderIndex++;
        }
    }
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Successfully collected data and stored in: " + destDirNameTemp);

}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.ToString());
}
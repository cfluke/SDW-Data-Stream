using SSADataStreams;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;


SpaceWeatherServiceAPICaller SWSCaller = new SpaceWeatherServiceAPICaller();
NOAASWPCAPICaller NOAACaller = new NOAASWPCAPICaller();

//await SWSCaller.CallSWSAPIAsync();
await NOAACaller.CallNOAASWPCAPIAsync();
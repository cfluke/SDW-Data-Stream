using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using TMPro;
using System.Globalization;

public class TimeAPIScript : MonoBehaviour
{
    public TextMeshProUGUI txtDateTime;
    public TextMeshProUGUI txtLabels;
    private const string API_URL = "https://timeapi.io/api/Time/current/coordinate?latitude=-37.82&longitude=145.04";
    private string dtFormat = "dd/MM/yyyy HH:mm:ss.f";
    private string tFormat = @"hh\:mm\:ss\.f";
    private DateTime gregDate = DateTime.MinValue;
    private DateTime utcDate = DateTime.MinValue;
    private float callOffset = 0f;
    private const float LONGITUDE = 145.04f;
    private bool processing = false;
    public class DateTimeData
    {
        public string dateTime;
        public bool dstActive;
    }
    // Start is called before the first frame update
    void Start()
    {
        txtLabels.text = "Local:\nUTC:\nJulian:\nGMST:\nLST:";
    }

    // Update is called once per frame
    void Update()
    {
        if (!processing)
        {
            StartCoroutine(GetTimeRequest());
            processing = true;
        }
        double julian = CalculateJulian(UpdateTime(utcDate));
        txtDateTime.text = string.Format("{0}\n{1}\n{2}\n{3}\n{4}", UpdateTime(gregDate).ToString(dtFormat), UpdateTime(utcDate).ToString(dtFormat), julian.ToString("0000000.00000"), CalculateGMST(julian).ToString(tFormat), CalculateLST(julian).ToString(tFormat));
        
    }

    IEnumerator GetTimeRequest()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(API_URL))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:

                    DateTimeData dateTimeData = JsonUtility.FromJson<DateTimeData>(webRequest.downloadHandler.text);
                    gregDate = ParseDateTime(dateTimeData.dateTime);
                    utcDate = (dateTimeData.dstActive) ? gregDate.Subtract(new TimeSpan(0, 11, 0, 0)) : gregDate.Subtract(new TimeSpan(0, 10, 0, 0));
                    callOffset = Time.realtimeSinceStartup;
                    processing = false;
                    break;
            }
        }
    }

    DateTime ParseDateTime(string datetime)
    {
        //match 0000-00-00
        string date = Regex.Match(datetime, @"^\d{4}-\d{2}-\d{2}").Value;

        //match 00:00:00.000    
        string time = Regex.Match(datetime, @"\d{2}:\d{2}:\d{2}\.\d{3}").Value;
        //string time = Regex.Match(datetime, @"\d{2}:\d{2}:\d{2}").Value;

        string dateTime = string.Format("{0} {1}", date, time);

        return DateTime.ParseExact(dateTime, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.GetCultureInfo("en-AU"));
    }

    public DateTime UpdateTime(DateTime dateTime)
    {
        return dateTime.AddSeconds(Time.realtimeSinceStartup - callOffset);
    }

    public double CalculateJulian(DateTime utc)
    {
        double julian = utc.ToOADate() + 2415018.5;
        return julian;
    }

    TimeSpan CalculateGMST(double julian)
    {
        double gmst = 18.697374558 + 24.06570982441908 * (julian - 2451545);
        gmst = gmst % 24;
        
        double gmstmm = (gmst - (int)gmst) * 60;
        double gmstss = (gmstmm - (int)gmstmm) * 60;
        double gmstff = (gmstss - (int)gmstss) * 1000;
        int gmsthh = (int)gmst;

        return new TimeSpan(0, gmsthh, (int)gmstmm, (int)gmstss, (int)gmstff); 
    }

    TimeSpan CalculateLST(double julian)
    {
        double gmst = 18.697374558 + 24.06570982441908 * (julian - 2451545);
        gmst = gmst % 24;

        double lst = gmst + (LONGITUDE / 15);
        if (lst < 0)
            lst = lst + 24;
        double lstmm = (lst - (int)lst) * 60;
        double lstss = (lstmm - (int)lstmm) * 60;
        double lstff = (lstss - (int)lstss) * 1000;
        int lsthh = (int)lst;

        return new TimeSpan(0, lsthh, (int)lstmm, (int)lstss, (int)lstff);
    }
}

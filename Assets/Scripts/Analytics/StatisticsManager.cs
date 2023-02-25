using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;


public class StatisticsManager
{

    public string database_url = "https://missing-assets-default-rtdb.firebaseio.com/analytics_data.json";

    public void pushDataToAnalyticsDb(AnalyticsData analyticsData) {
        RestClient.Post(database_url, analyticsData);
    }

    public static void buildAnaltyicsDataObjAndPush(string eventName, string eventValue, string eventOutcome){
        AnalyticsData analytics_data = new AnalyticsData();
        
        analytics_data.metricVersion = Config.metricVersion;
        analytics_data.level = 1; //TODO get level by some global value
        analytics_data.timestampLong = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
        analytics_data.eventName = eventName;
        analytics_data.eventValue = eventValue;
        analytics_data.eventOutcome = eventOutcome;

        StatisticsManager statisticsManager = new StatisticsManager();
        statisticsManager.pushDataToAnalyticsDb(analytics_data);
    }

}
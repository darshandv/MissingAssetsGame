using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatisticsManager
{
    // public string database_url =
    //     "https://missing-assets-default-rtdb.firebaseio.com/analytics_data_prod.json";

    // PROD LINK - use this at time of building
    public string database_url =
        "https://missing-assets-default-rtdb.firebaseio.com/analytics_data_prod.json";

    public void pushDataToAnalyticsDb(AnalyticsData analyticsData)
    {
        RestClient.Post(database_url, analyticsData);
    }

    // TODO: A better place to put this
    private static int getLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        int level = Array.IndexOf(Config.levels, scene.name);
        // TODO: How do we handle level = -1
        return level;
    }

    public static void buildAnaltyicsDataObjAndPush(string eventName, string eventValue)
    {
        AnalyticsData analytics_data = new AnalyticsData();

        analytics_data.metricVersion = AnalyticsTracker.metricVersion;
        analytics_data.level = getLevel(); //TODO get level by some global value
        analytics_data.timestampLong = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
        analytics_data.eventName = eventName;
        analytics_data.eventValue = eventValue;

        StatisticsManager statisticsManager = new StatisticsManager();
        statisticsManager.pushDataToAnalyticsDb(analytics_data);
    }
}

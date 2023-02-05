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

    public static void buildAnaltyicsDataObjAndPush() {
        AnalyticsData analytics_data = new AnalyticsData();
        
        analytics_data.enemiesKilledTotalCount = 0;
        analytics_data.level = 1;
        analytics_data.reason = "DieOnSpace";
        analytics_data.remEnergy = "0%";
        analytics_data.timestampLong = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
        analytics_data.type = "termination";
        analytics_data.totalSuccessfulJumpsCount = 0;
        analytics_data.sourceOfDeath = "Enemy";

        StatisticsManager statisticsManager = new StatisticsManager();
        statisticsManager.pushDataToAnalyticsDb(analytics_data);
    }
}

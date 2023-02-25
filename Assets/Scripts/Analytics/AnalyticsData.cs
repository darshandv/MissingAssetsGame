using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyticsData
{
    public int metricVersion; // later will help us to filter based on versions of data collection
    public int level;
    public long timestampLong;
    public string eventName;
    public string eventValue;
}
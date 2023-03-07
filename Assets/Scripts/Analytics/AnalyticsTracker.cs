using System;
using Newtonsoft.Json;
using System.Collections.Generic;

public class Metric3 {
    public int playerBulletHits;
    public int totalPlayerBullets;
}

public class Metric4 {
    public int enemyBulletsHit;
    public int totalEnemyBullets;
}

public class Metric5 {
    public long startTime;
    public long endTime;
}

public class Metric6{
    public float remainingThrust;
    public long remainingHealth;
    public string cause;
}

public class Metric10{
    public long startTime;
    public List<long> pressedTimes;
}

public static class AnalyticsTracker
{
    public static int metricVersion = 1;
    public static int playerBullets = 0; // Total Player bullets fired
    public static int playerBulletsHit = 0; // Player bullets that hit enemy 
    public static int enemiesKilled = 0; 
    public static int enemyBulletsHit = 0; // Enemy bullets that hit player
    public static int totalEnemyBullets = 0; // Total Enemy Bullets fired
    public static bool isOutOfBounds = false;
    public static long health = 0;
    public static float thrust = 0;
    public static int thrustZeroCounter = 0;
    public static int shieldCollected = 0;

    public static long timeStampRecord = 0;
    public static List<long> pressedTimes = new List<long>();

    public static void resetVariables() {
        playerBullets = 0;
        enemiesKilled = 0;
        enemyBulletsHit = 0;
        totalEnemyBullets = 0;
        isOutOfBounds = false;
        playerBulletsHit = 0;
        timeStampRecord = 0;
    }

    public static void sendMetric1(string value){
        if (value.Contains("enemy")){
            StatisticsManager.buildAnaltyicsDataObjAndPush("causeOfDeath","deathByEnemy");
        }
        else if (value.Contains("bounds"))
        {
            StatisticsManager.buildAnaltyicsDataObjAndPush("causeOfDeath","outOfBounds");
        }
        isOutOfBounds = false;
    }

    public static void sendMetric2(){
        StatisticsManager.buildAnaltyicsDataObjAndPush("enemiesKilled",AnalyticsTracker.enemiesKilled.ToString());
        enemiesKilled = 0;
    }

    public static void sendMetric3() {
        Metric3 data = new Metric3();
        data.playerBulletHits = playerBulletsHit;
        data.totalPlayerBullets = playerBullets;

        StatisticsManager.buildAnaltyicsDataObjAndPush("playerFiringAccuracy",JsonConvert.SerializeObject(data));
        // StatisticsManager.buildAnaltyicsDataObjAndPush("playerBulletHits",AnalyticsTracker.playerBulletsHit.ToString());
        // StatisticsManager.buildAnaltyicsDataObjAndPush("totalPlayerBullets",AnalyticsTracker.playerBullets.ToString());
        playerBulletsHit = 0;
        playerBullets = 0;
    }

    public static void sendMetric4 () {
        Metric4 data = new Metric4();
        data.enemyBulletsHit = enemyBulletsHit;
        data.totalEnemyBullets = totalEnemyBullets;

        StatisticsManager.buildAnaltyicsDataObjAndPush("playerBulletAvoidance",JsonConvert.SerializeObject(data));

        // StatisticsManager.buildAnaltyicsDataObjAndPush("enemyBulletsHit",AnalyticsTracker.enemyBulletsHit.ToString());
        // StatisticsManager.buildAnaltyicsDataObjAndPush("totalEnemyBullets",AnalyticsTracker.totalEnemyBullets.ToString());
        enemyBulletsHit = 0;
        totalEnemyBullets = 0;
    }

    public static void sendMetric5 () {
        Metric5 data = new Metric5();
        data.startTime = timeStampRecord;
        data.endTime = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
        StatisticsManager.buildAnaltyicsDataObjAndPush("playerTimeElapsed",JsonConvert.SerializeObject(data));
        // timeStampRecord = 0; Will be reset at metric10
    }

    public static void sendMetric6(string cause) {
        Metric6 data = new Metric6();
        data.remainingHealth = health;
        data.remainingThrust = thrust;
        data.cause = cause;
        StatisticsManager.buildAnaltyicsDataObjAndPush("remainingThrustAndHealth",JsonConvert.SerializeObject(data));
        health = 0;
        thrust = 0;
    }

    public static void sendMetric7() {
        StatisticsManager.buildAnaltyicsDataObjAndPush("levelCompleted","1");
    }

    public static void sendMetric8() {
        StatisticsManager.buildAnaltyicsDataObjAndPush("zeroThrustCounter",thrustZeroCounter.ToString());
        thrustZeroCounter = 0;
    }
    
    public static void sendMetric9() {
        StatisticsManager.buildAnaltyicsDataObjAndPush("shieldsCollected",shieldCollected.ToString());
        shieldCollected = 0;
    }

    public static void sendMetric10() {
        Metric10 data = new Metric10();
        data.startTime = timeStampRecord;
        data.pressedTimes = pressedTimes;
        StatisticsManager.buildAnaltyicsDataObjAndPush("qPresses",JsonConvert.SerializeObject(data));
        timeStampRecord = 0;
        pressedTimes = new List<long>();
    }
}
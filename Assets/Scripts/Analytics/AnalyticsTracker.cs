using System;
using Newtonsoft.Json;

public class Metric3 {
    public int playerBulletHits;
    public int totalPlayerBullets;
}

public class Metric4 {
    public int enemyBulletsHit;
    public int totalEnemyBullets;
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

    public static void resetVariables() {
        playerBullets = 0;
        enemiesKilled = 0;
        enemyBulletsHit = 0;
        totalEnemyBullets = 0;
        isOutOfBounds = false;
        playerBulletsHit = 0;
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

}
public static class AnalyticsTracker
{
    public static int metricVersion = 1;
    public static int playerBullets = 0;
    public static int enemyBullets = 0;
    public static int enemiesKilled = 0;

    public static void resetVariables() {
        metricVersion = 1;
        playerBullets = 0;
        enemyBullets = 0;
        enemiesKilled = 0;
    }
}
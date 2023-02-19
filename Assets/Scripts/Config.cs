public static class Config
{
    public static int  numberofEnemies = 0;
    public static bool isDead = false;
    public static bool shouldEnemiesMove = false;

    // Thrust related variables
    public static float maxThrust = 100f;
    public static float thrustReductionAmount = 2f;
    public static float thrustReductionDelay = 1f; // in seconds
}
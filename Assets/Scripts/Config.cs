public static class Config
{
    public static int  numberofEnemies = 0;
    public static bool isDead = false;
    public static bool shouldEnemiesMove = false;

    // Thrust related variables
    public static bool useThrustControl = false;
    public static float maxThrust = 50f;
    public static float thrustReductionAmount = 2f;
    public static float thrustReductionDelay = 1f; // in seconds 
}
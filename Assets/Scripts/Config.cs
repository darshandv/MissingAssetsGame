public static class Config
{
    public static int numberofEnemies = 0;
    public static bool isDead = false;
    public static bool shouldEnemiesMove = false;

    // Thrust related variables
    public static bool useThrustControl = true;
    public static float maxThrust = 75f;
    public static float thrustReductionAmount = 2f;
    public static float thrustIncrementAmount = thrustReductionAmount / 16;
    public static float thrustReductionDelay = 1f; // in seconds

    public static float maxThrustLevel3 = 20f;
    public static float thrustReductionAmountLevel3 = 5f;
    public static float thrustIncrementAmountLevel3 = 1 / 32;

    //Levels
    public static string[] levels =
    {
        "SampleScene",
        "Level1",
        "Level2",
        "Level3",
        "Level4",
        "Level5",
        "Level6",
        "Level7"
    };
    public static int currentLevel = 3;
}

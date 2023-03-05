public static class Config
{
    public static int numberofEnemies = 0;
    public static bool isDead = false;
    public static bool shouldEnemiesMove = false;

    // Thrust related variables
    public static bool useThrustControl = true;
    public static float maxThrust = 5f;
    public static float thrustReductionAmount = 2f;
    public static float thrustIncrementAmount = 2f;
    public static float thrustReductionDelay = 1f; // in seconds

    public static float maxThrustLevel3 = 20f;
    public static float thrustReductionAmountLevel3 = 5f;
    public static float thrustIncrementAmountLevel3 = 1 / 32;

    //Levels
    public static string[] levels =
    {
        "Scenes/LandingScreen",
        "Scenes/Level1",
        "Scenes/Level2",
        "Scenes/Level3",
        "Scenes/Level4",
        "Scenes/Level5",
        "Scenes/Level6",
        "Scenes/Level7",
        "Scenes/Level8",
        // "Scenes/LandingScreen", // Just for testing purposes
    };
    public static int currentLevel = 1;

    public static int[] levelCollectibles = { 4, 6, 6, 6, 3, 3, 3, 3, 3 };

    public static void ResetAllVariables()
    {
        numberofEnemies = 0;
        isDead = false;
        shouldEnemiesMove = false;
        useThrustControl = true;
        maxThrust = 5f;
        thrustReductionAmount = 2f;
        thrustIncrementAmount = 2f;
        thrustReductionDelay = 1f; // in seconds
        maxThrustLevel3 = 20f;
        thrustReductionAmountLevel3 = 5f;
        thrustIncrementAmountLevel3 = 1 / 32;
    }
}

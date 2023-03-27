public static class Config
{
    public static int numberofEnemies = 0;
    public static bool isDead = false;
    public static bool shouldEnemiesMove = false;
    public static bool isInPlanet = false;

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
        "LandingScreen",
        "Level1",
        "Level2",
        "Level3",
        "Level4",
        "Level5",
        "Level6",
        "Level7",
        // "Level8",
        // "Scenes/LandingScreen", // Just for testing purposes
    };
    public static int currentLevel = 1;

    public static int[] levelCollectibles = { 4, 7, 6, 6, 7, 3, 2, 3, 3 };

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
        isInPlanet = false;
    }
}

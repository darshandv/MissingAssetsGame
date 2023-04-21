public enum MovementType {
    None,
    FixedAxis,
    Follow
}

public static class Config
{
    public static int numberofEnemies = 0;
    public static bool isDead = false;
    public static MovementType movementType = MovementType.None;
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

    public static bool[] bossEnemyDead = { true, true, false, true, true, true, false, true, true, false, true, true, true, false};

    //Levels
    public static string[] levels =
    {
        "LevelTraining1",//1
        "LevelTraining2",//2
        "BossEnemy0",//3
        "Level2",//4
        "Level3",//5
        "Level4",//6
        "BossEnemy1",//7
        "Level5",//8
        "Level6",//9
        "BossEnemy2",//10
        "Level7",//11
        "Level8",//12
        "Level9",//13
        "BossEnemy3",//14

        // "Scenes/LandingScreen", // Just for testing purposes
    };
    public static int currentLevel = 1;

    public static int[] levelCollectibles = { 1, 3, 4, 6, 6, 6, 4, 7, 4, 4, 2, 3, 3, 4, };
    public static int[] bossEnemyLevels = { 2, 6, 9, 13 }; //Give Array index of Level
    public static void ResetAllVariables()
    {
        numberofEnemies = 0;
        isDead = false;
        movementType = MovementType.None;
        useThrustControl = true;
        maxThrust = 5f;
        thrustReductionAmount = 2f;
        thrustIncrementAmount = 2f;
        thrustReductionDelay = 1f; // in seconds
        maxThrustLevel3 = 20f;
        thrustReductionAmountLevel3 = 5f;
        thrustIncrementAmountLevel3 = 1 / 32;
        isInPlanet = false;
        for(int i=0;i< bossEnemyLevels.Length; i++)
        {
            bossEnemyDead[bossEnemyLevels[i]] = false;
        }

    }
}

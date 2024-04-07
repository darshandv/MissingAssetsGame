using System;
using System.Collections.Generic; 

public enum MovementType {
    None,
    FixedAxis,
    Follow
}

public static class Config
{
    // Embedded related variables
    public static bool isUseEmbedded = true;
    public static float maxSensorDistance = 15f;
    public static int numberofEnemies = 0;
    public static bool isDead = false;
    public static MovementType movementType = MovementType.None;
    public static bool isInPlanet = false;

    // Thrust related variables
    public static bool useThrustControl = true;
    public static float maxThrust = 5f;
    public static float thrustReductionAmount = 0.05f; // 2f
    public static float thrustIncrementAmount = 2f;
    public static float thrustReductionDelay = 1f; // in seconds

    public static float maxThrustLevel3 = 20f;
    public static float thrustReductionAmountLevel3 = 1.5f; // 5f;
    public static float thrustIncrementAmountLevel3 = 1 / 32;

    public static bool bossEnemyDead = true;
    // public static int[] maxHealth =  { 50,50,50,50,50,50,50,50,50,50,50,50,50,50 };
    public static Dictionary<string,int> maxHealth =  new Dictionary<string, int>(){
        {"LevelTraining1",50},
        {"LevelTraining2",50},
        {"BossEnemy0",150},
        {"Level2",50},
        {"Level3",50},
        {"Level4",50},
        {"BossEnemy1",50},
        {"Level5",150},
        {"Level6",50},
        {"BossEnemy2",200},
        {"Level7",150},
        {"Level17",50},
        {"Level9",50},
        {"BossEnemy3",50},
        { "MiniBoss", 200}
    };
    //Levels
    public static string[] levels =
    {
        "LevelTraining1",//1
        "LevelTraining2",//2
        "Level6",//3
        "MiniBoss", //4
        "Level2",//5
        "Level3",//6
        "Level4",//7
        "Level9",//8    
        "BossEnemy0",//9
        "Level17",//10
        "Level5",//11
        "Level7",//12
        "BossEnemy3",//13

        // "Scenes/LandingScreen", // Just for testing purposes
    };
    public static int currentLevel = 1;

    public static Dictionary<string, int> levelCollectibles = new Dictionary<string, int>(){
        {"LevelTraining1",1},
        {"LevelTraining2",3},
        {"BossEnemy0",1},
        {"Level2",6},
        {"Level3",6},
        {"Level4",6},
        {"BossEnemy1",4},
        {"Level5",7},
        {"Level6",1},
        {"BossEnemy2",4},
        {"Level7",8},
        {"Level17",4},
        {"Level9",4},
        {"BossEnemy3",1},
        {"MiniBoss", 1 }
    };
    
    // { 1, 3, 4, 6, 6, 6, 4, 7, 4, 4, 2, 3, 3, 4, };
    public static int[] bossEnemyLevels = { 2, 6, 9, 13 }; //Give Array index of Level
    public static void ResetAllVariables()
    {
        numberofEnemies = 0;
        isDead = false;
        movementType = MovementType.None;
        useThrustControl = true;
        maxThrust = 5f;
        thrustReductionAmount = 0.05f; //2f;
        thrustIncrementAmount = 2f;
        thrustReductionDelay = 1f; // in seconds
        maxThrustLevel3 = 20f;
        thrustReductionAmountLevel3 = 0.5f; //5f;
        thrustIncrementAmountLevel3 = 1 / 32;
        isInPlanet = false;
        bossEnemyDead = true;
        // for(int i=0;i< bossEnemyLevels.Length; i++)
        // {
        //     bossEnemyDead[bossEnemyLevels[i]] = false;
        // }

    }
}

public enum MovementType {
    None,
    FixedAxis,
    Follow
}

public static class Config
{
    public static int  numberofEnemies = 0;
    public static bool isDead = false;
    public static MovementType movementType = MovementType.None;

    // Thrust related variables
    public static bool useThrustControl = true;
    public static float maxThrust = 75f;
    public static float thrustReductionAmount = 2f;
    public static float thrustIncrementAmount = thrustReductionAmount/16;
    public static float thrustReductionDelay = 1f; // in seconds 
}
using UnityEngine;

public class GameState
{
    public static bool needRecalculatePigs { get;set; }
    public static bool isLevelCompleted { get; set; }
    public static bool isLevelFailed { get; set; }
    public static int sceneIndex { get; set; }
    public static int triesCount { get; set; }
}

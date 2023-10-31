using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    private static int obstaclesAmount;
    public static int ObstaclesAmount
    {
        get => obstaclesAmount;
        set => obstaclesAmount = value;
    }

    private static int obstaclesBroken;
    public static int ObstaclesBroken
    {
        get => obstaclesBroken;
        set => obstaclesBroken = value;
    }

    private void Start()
    {
        EventManager.BreakableHit.AddListener(IncreaseCount);
        EventManager.LevelRegenerated.AddListener(ResetAmountOfBroken);
    }

    private void IncreaseCount() => obstaclesBroken++;

    private void ResetAmountOfBroken(bool isNew) => obstaclesBroken = 0;
}

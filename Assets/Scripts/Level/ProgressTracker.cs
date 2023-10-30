using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    [SerializeField] private static int obstaclesAmount;
    public static int ObstaclesAmount
    {
        get => obstaclesAmount;
        set => obstaclesAmount = value;
    }

    [SerializeField] private static int obstaclesBroken;
    public static int ObstaclesBroken
    {
        get => obstaclesBroken;
        set => obstaclesBroken = value;
    }

    private void Start()
    {
        EventManager.BreakableHit.AddListener(IncreaseCount);
        EventManager.NextLevelSelected.AddListener(ResetAmountOfBroken);
    }

    private void IncreaseCount() => obstaclesBroken++;

    private void ResetAmountOfBroken() => obstaclesBroken = 0;
}

using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    [SerializeField]
    private GameObject coreCylinder;

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
        EventManager.FloorHit.AddListener(() => SetCoreState(true));

        EventManager.FloorHit.AddListener(() => SetCoreState(false));
    }

    private void IncreaseCount() => obstaclesBroken++;

    private void ResetAmountOfBroken(bool isNew) => obstaclesBroken = 0;

    private void SetCoreState(bool isActive) => coreCylinder.SetActive(isActive);
}

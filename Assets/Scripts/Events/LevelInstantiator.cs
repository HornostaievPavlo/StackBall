using UnityEngine;

public class LevelInstantiator : MonoBehaviour
{
    [SerializeField]
    private CameraSystem cameraSystem;

    [SerializeField]
    private Transform obstaclesParent;

    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private GameObject floorPrefab;

    [SerializeField]
    private GameObject[] obstacles;

    private GameObject[] currentLevelObstacles = new GameObject[4];

    private GameObject currentObstacle;

    private Transform currentBall;

    private Transform currentFloor;

    private int currentLevel = 1;
    public int CurrentLevel { get => currentLevel; }

    private int obstaclesAmountMultiplier = 7;

    private void Start()
    {
        InstantiateLevel(false);

        EventManager.LevelRegenerated.AddListener(InstantiateLevel);
    }

    public void InstantiateLevel(bool isLevelFinished)
    {
        if (isLevelFinished) currentLevel++;

        ClearLevel();

        currentBall = Instantiate(ballPrefab).transform;
        currentFloor = Instantiate(floorPrefab).transform;

        ReassignCameraPoints(currentBall, currentFloor);
        Debug.Log("mutim level");
        SelectObstacleModel();
        InstantiateObstaclesForLevel();
    }

    private void ClearLevel()
    {
        ProgressTracker.ObstaclesAmount = 0;
        if (currentBall != null) DestroyImmediate(currentBall.gameObject);
        if (currentFloor != null) DestroyImmediate(currentFloor.gameObject);
    }

    private void ReassignCameraPoints(Transform newBall, Transform newFloor)
    {
        cameraSystem.CurrentBall = newBall;
        cameraSystem.CurrentFloor = newFloor;
    }

    private void SelectObstacleModel()
    {
        int randomModel = Random.Range(0, 5);

        if (currentLevel > 9) obstaclesAmountMultiplier = 0;

        switch (randomModel)
        {
            case 0:
                for (int i = 0; i < 4; i++)
                    currentLevelObstacles[i] = obstacles[i];
                break;
            case 1:
                for (int i = 0; i < 4; i++)
                    currentLevelObstacles[i] = obstacles[i + 4];
                break;
            case 2:
                for (int i = 0; i < 4; i++)
                    currentLevelObstacles[i] = obstacles[i + 8];
                break;
            case 3:
                for (int i = 0; i < 4; i++)
                    currentLevelObstacles[i] = obstacles[i + 12];
                break;
            case 4:
                for (int i = 0; i < 4; i++)
                    currentLevelObstacles[i] = obstacles[i + 16];
                break;
        }
    }

    private void InstantiateObstaclesForLevel()
    {
        float i;

        for (i = 0; i > -currentLevel - obstaclesAmountMultiplier; i -= 0.5f)
        {
            if (currentLevel <= 20)
                currentObstacle = Instantiate(currentLevelObstacles[Random.Range(0, 2)]);

            if (currentLevel > 20 && currentLevel <= 50)
                currentObstacle = Instantiate(currentLevelObstacles[Random.Range(1, 3)]);

            if (currentLevel > 50 && currentLevel <= 100)
                currentObstacle = Instantiate(currentLevelObstacles[Random.Range(2, 4)]);

            if (currentLevel > 100)
                currentObstacle = Instantiate(currentLevelObstacles[Random.Range(3, 4)]);

            ProgressTracker.ObstaclesAmount++;

            currentObstacle.transform.parent = obstaclesParent;

            float verticalPositionOffset = i - 0.01f;
            currentObstacle.transform.position = new Vector3(0, verticalPositionOffset, 0);

            float rotationOffset = i * 8;
            currentObstacle.transform.eulerAngles = new Vector3(0, rotationOffset, 0);
        }

        float floorPositionOffset = i - 0.01f;
        currentFloor.transform.position = new Vector3(0, floorPositionOffset, 0);
    }
}

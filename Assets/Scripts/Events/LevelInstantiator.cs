using UnityEngine;

public class LevelInstantiator : MonoBehaviour
{
    [SerializeField]
    private Transform obstaclesParent;

    [SerializeField]
    private GameObject floorPrefab;

    [SerializeField]
    private GameObject centerCylinder;

    [SerializeField]
    private GameObject[] obstacles;

    private GameObject[] currentLevelObstacles = new GameObject[4];

    private GameObject currentObstacle;

    public int currentLevel = 0;
    private int obstaclesAmountMultiplier = 7;

    private void Start() => InstantiateLevel();

    public void InstantiateLevel()
    {
        currentLevel++;

        if (currentLevel > 9) obstaclesAmountMultiplier = 0;

        SelectObstacleModel();
        InstantiateObstaclesForLevel();
    }

    private void SelectObstacleModel()
    {
        int randomModel = Random.Range(0, 5);

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

            currentObstacle.transform.parent = obstaclesParent;

            float verticalPositionOffset = i - 0.01f;
            currentObstacle.transform.position = new Vector3(0, verticalPositionOffset, 0);

            float rotationOffset = i * 8;
            currentObstacle.transform.eulerAngles = new Vector3(0, rotationOffset, 0);
        }

        var floor = Instantiate(floorPrefab);

        float floorPositionOffset = i - 0.01f;
        floor.transform.position = new Vector3(0, floorPositionOffset, 0);
    }
}

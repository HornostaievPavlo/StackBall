using UnityEngine;

public class LevelInstantiator : MonoBehaviour
{
    [SerializeField]
    private Transform obstaclesParent;

    [SerializeField]
    private GameObject floorPrefab;

    [SerializeField]
    private GameObject[] obstacles;

    private GameObject[] currentLevelObstacles = new GameObject[4];

    private GameObject currentObstacle;

    public int currentLevel = 1;
    public int addOn = 7;

    private float i = 0;

    private void Start() => InstantiateLevel();

    private void InstantiateLevel()
    {
        if (currentLevel > 9) addOn = 0;

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
        float random = Random.value;

        for (i = 0; i > -currentLevel - addOn; i -= 0.5f)
        {
            if (currentLevel <= 20)
                currentObstacle = Instantiate(currentLevelObstacles[Random.Range(0, 2)]);

            if (currentLevel > 20 && currentLevel <= 50)
                currentObstacle = Instantiate(currentLevelObstacles[Random.Range(1, 3)]);

            if (currentLevel > 50 && currentLevel <= 100)
                currentObstacle = Instantiate(currentLevelObstacles[Random.Range(2, 4)]);

            if (currentLevel > 100)
                currentObstacle = Instantiate(currentLevelObstacles[Random.Range(3, 4)]);

            currentObstacle.transform.position = new Vector3(0, i - 0.01f, 0);
            currentObstacle.transform.eulerAngles = new Vector3(0, i * 8, 0);

            currentObstacle.transform.parent = obstaclesParent;

            if (Mathf.Abs(i) >= currentLevel * 0.3f && Mathf.Abs(i) <= currentLevel * 0.6f)
            {
                currentObstacle.transform.eulerAngles = new Vector3(0, i * 8, 0);
                currentObstacle.transform.eulerAngles += Vector3.up * 180f;
            }
            else if (Mathf.Abs(i) >= currentLevel * 0.8f)
            {
                currentObstacle.transform.eulerAngles = new Vector3(0, i * 8, 0);

                if (random > 0.75f)
                {
                    currentObstacle.transform.eulerAngles += Vector3.up * 180f;
                }
            }
        }

        var floor = Instantiate(floorPrefab);
        floor.transform.position = new Vector3(0, i - 0.01f, 0);
    }
}

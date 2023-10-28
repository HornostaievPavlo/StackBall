using UnityEngine;

public class LevelInstantiator : MonoBehaviour
{
    public GameObject[] obstacles;

    [HideInInspector] 
    public GameObject[] currentLevelObstacles = new GameObject[4];

    public GameObject floorPrefab;

    private GameObject temp1;
    private GameObject temp2;

    public int level = 1;
    public int addOn = 7;

    private float i = 0;

    private void Start() => InstantiateLevel();

    private void InstantiateLevel()
    {
        if (level > 9) addOn = 0;

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
        for (i = 0; i > -level - addOn; i -= 0.5f)
        {
            if (level <= 20)
                temp1 = Instantiate(currentLevelObstacles[Random.Range(0, 2)]);

            if (level > 20 && level <= 50)
                temp1 = Instantiate(currentLevelObstacles[Random.Range(1, 3)]);

            if (level > 50 && level <= 100)
                temp1 = Instantiate(currentLevelObstacles[Random.Range(2, 4)]);

            if (level > 100)
                temp1 = Instantiate(currentLevelObstacles[Random.Range(3, 4)]);

            temp1.transform.position = new Vector3(0, i - 0.01f, 0);
            temp1.transform.eulerAngles = new Vector3(0, i * 8, 0);
        }

        temp2 = Instantiate(floorPrefab);
        temp2.transform.position = new Vector3(0, i - 0.01f, 0);
    }
}

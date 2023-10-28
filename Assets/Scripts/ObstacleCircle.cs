using System.Collections;
using UnityEngine;

public class ObstacleCircle : MonoBehaviour
{
    [SerializeField]
    private Obstacle[] obstacles = null;

    public void ShatterWholeObstacle()
    {
        if (transform.parent != null)
            transform.parent = null;

        foreach (var obstacle in obstacles)
        {
            obstacle.Shatter();
        }

        StartCoroutine(DestroyParts());
    }

    private IEnumerator DestroyParts()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}

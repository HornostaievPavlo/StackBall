using System.Collections;
using UnityEngine;

public class ObstacleCircle : MonoBehaviour
{
    [SerializeField]
    private Obstacle[] obstacles = null;

    public void ShatterWholeCircle()
    {
        if (transform.parent != null)
            transform.parent = null;

        foreach (var obstacle in obstacles)
        {
            obstacle.ShatterPart();
        }

        StartCoroutine(DestroyParts());
    }

    private IEnumerator DestroyParts()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}

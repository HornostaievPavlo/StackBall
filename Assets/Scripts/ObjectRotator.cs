using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;

    private void Update() => RotateObstacle();

    private void RotateObstacle()
    {
        Vector3 direction = new Vector3(0, rotationSpeed * Time.deltaTime, 0);
        transform.Rotate(direction);
    }
}

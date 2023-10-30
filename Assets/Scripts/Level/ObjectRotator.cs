using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;

    private void Start()
    {
        EventManager.UnbreakableHit.AddListener(StopRotation);
        EventManager.LevelRegenerated.AddListener(RestoreSpeed);
    }

    private void Update() => RotateObstacle();

    private void RotateObstacle()
    {
        Vector3 direction = new Vector3(0, rotationSpeed * Time.deltaTime, 0);
        transform.Rotate(direction);
    }

    private void StopRotation() => rotationSpeed = 0;

    private void RestoreSpeed(bool isWon) => rotationSpeed = 100f;
}

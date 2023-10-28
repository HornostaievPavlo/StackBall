using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField]
    private Transform ball;

    private Transform floor;

    private Vector3 offset;

    private void Update() => FollowBall();

    private void FollowBall()
    {
        if (floor == null)
            floor = GameObject.Find("Floor(Clone)").GetComponent<Transform>();

        float offsetOnFloor = floor.position.y + 4f;

        if (transform.position.y > ball.position.y &&
            transform.position.y > offsetOnFloor)
        {
            offset = new Vector3(transform.position.x, ball.position.y, transform.position.z);
        }

        float forwardOffset = -5f;
        transform.position = new Vector3(transform.position.x, offset.y, forwardOffset);
    }
}

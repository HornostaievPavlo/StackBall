using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    private Transform ball;
    public Transform CurrentBall { set => ball = value; }

    private Transform floor;
    public Transform CurrentFloor { set => floor = value; }

    private Vector3 offset;

    private void Update()
    {
        FollowBall(ball, floor);
    }

    private void FollowBall(Transform ball, Transform floor)
    {
        float offsetOnFloor = floor.position.y + 4f;

        if (transform.position.y > ball.position.y &&
            transform.position.y > offsetOnFloor ||
            transform.position.y < (ball.position.y - 5f))
        {
            offset = new Vector3(transform.position.x, ball.position.y, transform.position.z);
        }

        float forwardOffset = -5f;
        transform.position = new Vector3(transform.position.x, offset.y, forwardOffset);
    }
}

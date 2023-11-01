using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    private Ball ball;
    private Transform ballTransform;
    public Transform CurrentBall
    {
        set
        {
            ball = value.gameObject.GetComponent<Ball>();
            ballTransform = value;
        }
    }

    private Transform floor;
    public Transform CurrentFloor { set => floor = value; }

    private Vector3 startPosition = new Vector3(0, 0, -5f);

    private bool isFollowingNeeded = false;

    private void Update()
    {
        CheckBallState();

        if (isFollowingNeeded)
            FollowBall(ballTransform, floor);
    }

    private void FollowBall(Transform ball, Transform floor)
    {
        float offsetOnFloor = floor.position.y + 4f;
        float lerpSpeed = 20f;

        Vector3 targetPosition = new Vector3(transform.position.x, ball.position.y, transform.position.z);

        if (transform.position.y < offsetOnFloor)
            return;

        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);
    }

    private void CheckBallState() => isFollowingNeeded = ball.IsSmashing;

    public void ResetPosition() => transform.position = startPosition;
}

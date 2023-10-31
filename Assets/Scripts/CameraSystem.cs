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
        CheckBallState();

        if (isFollowingNeeded)
            FollowBall(ball, floor);
    }

    //private void FollowBall(Transform ball, Transform floor)
    //{
    //    float offsetOnFloor = floor.position.y + 4f;

    //    if (transform.position.y > ball.position.y &&
    //        transform.position.y > offsetOnFloor ||
    //        transform.position.y < (ball.position.y - 5f))
    //    {
    //        offset = new Vector3(transform.position.x, ball.position.y, transform.position.z);
    //    }

    //    float forwardOffset = -5f;
    //    transform.position = new Vector3(transform.position.x, offset.y, forwardOffset);
    //}


    private Vector3 startPosition = new Vector3(0, 0, -5f);

    public bool isFollowingNeeded = false;

    private void FollowBall(Transform ball, Transform floor)
    {
        //float offsetOnFloor = floor.position.y + 4f;

        Vector3 targetPosition =
            new Vector3(transform.position.x, ball.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, 10f * Time.deltaTime);
    }

    private void CheckBallState()
    {
        if (ball != null)
        {
            isFollowingNeeded = ball.GetComponent<Ball>().IsSmashing;
        }
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
    }
}

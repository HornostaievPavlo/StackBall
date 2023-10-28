using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] private Transform ball;
    private Transform floor;

    private Vector3 offset;

    void Update()
    {
        FollowBall();
    }

    private void FollowBall()
    {
        if (floor == null)
            floor = GameObject.Find("Floor(Clone)").GetComponent<Transform>();

        if (transform.position.y > ball.position.y &&
           transform.position.y > floor.position.y + 4f)
        {
            offset = new Vector3(transform.position.x, ball.position.y, transform.position.z);
        }

        transform.position = new Vector3(transform.position.x, offset.y, -5f);
    }
}

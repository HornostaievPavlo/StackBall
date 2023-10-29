using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;

    private bool isSmashing;

    public UnityEvent BallJumpedOnSurface = new UnityEvent();
    public UnityEvent BreakableSurfaceHit = new UnityEvent();
    public UnityEvent UnBreakableSurfaceHit = new UnityEvent();
    public UnityEvent FloorHit = new UnityEvent();

    private void Awake() => rb = GetComponent<Rigidbody>();

    private void Update() => ProcessInput();

    private void FixedUpdate() => ControlVelocity();

    private void OnCollisionEnter(Collision collision)
    {
        if (isSmashing)
        {
            var hitSurfaceType = collision.gameObject.GetComponent<Surface>().surfaceType;

            switch (hitSurfaceType)
            {
                case SurfaceType.Breakable:
                    BreakableSurfaceHit.Invoke();

                    var circle = collision.transform.parent.GetComponent<ObstacleCircle>();
                    circle.ShatterWholeCircle();
                    break;

                case SurfaceType.Unbreakable:
                    UnBreakableSurfaceHit.Invoke();

                    rb.isKinematic = true;
                    break;

                case SurfaceType.Floor:
                    FloorHit.Invoke();
                    break;
            }
        }
        else
        {
            BallJumpedOnSurface.Invoke();

            float verticalVelocity = 50f * Time.deltaTime * 5f;
            rb.velocity = new Vector3(0, verticalVelocity, 0);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        var hitSurfaceType = collision.gameObject.GetComponent<Surface>().surfaceType;

        if (hitSurfaceType == SurfaceType.Floor)
        {
            float oppositeVerticalVelocity = 50f * Time.deltaTime * 5f;
            rb.velocity = new Vector3(0, oppositeVerticalVelocity, 0);
        }
    }

    private void ProcessInput()
    {
        if (Input.GetMouseButtonDown(0)) isSmashing = true;
        if (Input.GetMouseButtonUp(0)) isSmashing = false;
    }

    private void ControlVelocity()
    {
        float velocityMaxValue = 5f;

        if (Input.GetMouseButton(0))
        {
            isSmashing = true;

            float verticalVelocity = -100f * Time.fixedDeltaTime * 7f;
            rb.velocity = new Vector3(0, verticalVelocity, 0);
        }
        if (rb.velocity.y > velocityMaxValue)
        {
            Vector3 currentVelocity = rb.velocity;
            currentVelocity = new Vector3(currentVelocity.x, velocityMaxValue, currentVelocity.z);
        }
    }
}

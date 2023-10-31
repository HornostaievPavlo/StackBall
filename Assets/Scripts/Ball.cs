using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private GameObject splashPrefab;

    private Rigidbody rb;

    private bool isSmashing;
    public bool IsSmashing { get => isSmashing; }

    private void Awake() => rb = GetComponent<Rigidbody>();

    private void Update() => ProcessInput();

    private void FixedUpdate() => ControlVelocity();

    private void OnCollisionEnter(Collision collision)
    {
        var hitSurfaceType = collision.gameObject.GetComponent<Surface>().surfaceType;

        if (isSmashing)
            SmashSurface(hitSurfaceType, collision.transform);
        else
            JumpOnSurface(hitSurfaceType, collision.transform);
    }

    private void SmashSurface(SurfaceType surfaceType, Transform collision)
    {
        switch (surfaceType)
        {
            case SurfaceType.Breakable:
                EventManager.HitBreakableSurface();
                var circle = collision.transform.parent.GetComponent<ObstacleCircle>();
                circle.ShatterWholeCircle();
                break;

            case SurfaceType.Unbreakable:
                EventManager.HitUnbreakableSurface();
                rb.isKinematic = true;
                break;

            case SurfaceType.Floor:
                EventManager.HitFloor();
                rb.isKinematic = true;
                break;
        }
    }

    private void JumpOnSurface(SurfaceType surfaceType, Transform collision)
    {
        if (surfaceType == SurfaceType.Floor)
        {
            EventManager.HitFloor();
            rb.isKinematic = true;
            return;
        }

        EventManager.JumpOnSurface();

        var splash = Instantiate(splashPrefab, collision.transform);

        float verticalOffsetFromBall = transform.position.y - 0.22f;
        splash.transform.position = new Vector3(transform.position.x, verticalOffsetFromBall, transform.position.z);

        float verticalVelocityValue = 50f * Time.deltaTime * 5f;
        rb.velocity = new Vector3(0, verticalVelocityValue, 0);
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

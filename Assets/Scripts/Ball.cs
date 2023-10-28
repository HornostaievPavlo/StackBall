using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;

    public bool isSmashing;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ProcessInput();
    }

    private void FixedUpdate()
    {
        ControlVelocity();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isSmashing)
        {
            var hitSurfaceType = collision.gameObject.GetComponent<Surface>().surfaceType;
            Debug.Log(hitSurfaceType.ToString());

            switch (hitSurfaceType)
            {
                case SurfaceType.Breakable:
                    var circle = collision.transform.parent.GetComponent<ObstacleCircle>();
                    circle.ShatterWholeCircle();
                    break;

                case SurfaceType.Unbreakable:
                    break;

                case SurfaceType.Floor:
                    break;
            }
        }
        else
        {
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

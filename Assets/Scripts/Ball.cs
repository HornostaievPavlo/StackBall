using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;

    private float currentTime;

    private bool isSmashing;
    private bool isInvincible;

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
        if (!isSmashing)
        {
            float verticalVelocity = 50f * Time.deltaTime * 5f;
            rb.velocity = new Vector3(0, verticalVelocity, 0);
        }
        else // redo
        {
            if (isInvincible)
            {
                if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "plane")
                {
                    var stack = collision.transform.parent.GetComponent<ObstacleCircle>();
                    stack.ShatterWholeObstacle();
                }
            }
            else
            {
                if (collision.gameObject.tag == "enemy")
                {
                    var stack = collision.transform.parent.GetComponent<ObstacleCircle>();
                    stack.ShatterWholeObstacle();
                }
                if (collision.gameObject.tag == "plane")
                {
                    Debug.Log("Hit hard part");
                }
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!isSmashing || collision.gameObject.tag == "Finish") // update
        {
            float oppositeVerticalVelocity = 50f * Time.deltaTime * 5f;
            rb.velocity = new Vector3(0, oppositeVerticalVelocity, 0);
        }
    }

    private void ProcessInput()
    {
        if (Input.GetMouseButtonDown(0)) isSmashing = true;
        if (Input.GetMouseButtonUp(0)) isSmashing = false;

        if (isInvincible)
            currentTime -= Time.deltaTime * 0.35f;
        else
        {
            if (isSmashing)
                currentTime += Time.deltaTime * 0.8f;
            else
                currentTime -= Time.deltaTime * 0.5f;
        }

        if (currentTime >= 1)
        {
            currentTime = 1;
            isInvincible = true;
        }
        else if (currentTime <= 0)
        {
            currentTime = 0;
            isInvincible = false;
        }

        Debug.Log(isInvincible);
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

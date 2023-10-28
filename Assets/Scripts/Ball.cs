using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;

    private bool isFalling;

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

    private void ProcessInput()
    {
        if (Input.GetMouseButtonDown(0)) isFalling = true;
        if (Input.GetMouseButtonUp(0)) isFalling = false;
    }

    private void ControlVelocity()
    {
        Vector3 currentVelocity = rb.velocity;
        float velocityMaxValue = 5f;

        if (Input.GetMouseButton(0))
        {
            isFalling = true;

            float verticalMovementFactor = -100f * Time.fixedDeltaTime * 7f;
            currentVelocity = new Vector3(0, verticalMovementFactor, 0);
        }
        if (currentVelocity.y > velocityMaxValue)
        {
            currentVelocity = new Vector3(currentVelocity.x, velocityMaxValue, currentVelocity.z);
        }
    }
}

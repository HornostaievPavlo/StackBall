using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody rb;
    private MeshRenderer meshRenderer;
    private Collider meshCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<Collider>();
    }

    public void ShatterPart()
    {
        rb.isKinematic = false;
        meshCollider.enabled = false;

        float parentXPos = transform.parent.position.x;
        float thisXPos = meshRenderer.bounds.center.x;

        Vector3 subDirection = parentXPos - thisXPos < 0 ? Vector3.right : Vector3.left;
        Vector3 forceDirection = (Vector3.up * 1.5f + subDirection).normalized;

        float forceMultiplier = Random.Range(20, 35);
        Vector3 force = forceDirection * forceMultiplier;
        Vector3 forcePosition = transform.parent.position;

        rb.AddForceAtPosition(force, forcePosition, ForceMode.Impulse);

        float torqueMultiplier = Random.Range(110, 180);
        Vector3 torque = Vector3.left * torqueMultiplier;

        rb.AddTorque(torque);

        rb.velocity = Vector3.down;
    }
}

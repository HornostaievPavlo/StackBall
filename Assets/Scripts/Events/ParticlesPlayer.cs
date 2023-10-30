using UnityEngine;

public class ParticlesPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform ball;

    [SerializeField]
    private ParticleSystem explosionParticle;

    [SerializeField]
    private ParticleSystem floorHitParticle;

    private void Start()
    {
        EventManager.UnbreakableHit.AddListener(PlayExplosion);
        EventManager.FloorHit.AddListener(PlayFloorHitParticle);
    }

    private void PlayExplosion()
    {
        Vector3 position = ball.position;
        Instantiate(explosionParticle.gameObject, position, Quaternion.identity);

        ball.gameObject.SetActive(false);
    }

    private void PlayFloorHitParticle() => Instantiate(floorHitParticle.gameObject);
}

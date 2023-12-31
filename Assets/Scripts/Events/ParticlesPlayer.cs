using UnityEngine;

public class ParticlesPlayer : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem explosionParticle;

    [SerializeField]
    private ParticleSystem floorHitParticle;

    private Transform ball;

    private void Start()
    {
        EventManager.UnbreakableHit.AddListener(PlayExplosion);
        EventManager.FloorHit.AddListener(PlayFloorHitParticle);

        EventManager.LevelRegenerated.AddListener(RemoveParticles);
    }

    private void PlayExplosion()
    {
        ball = FindObjectOfType<Ball>().transform;

        Vector3 position = ball.position;
        Instantiate(explosionParticle.gameObject, position, Quaternion.identity);

        ball.gameObject.SetActive(false);
    }

    private void PlayFloorHitParticle() => Instantiate(floorHitParticle.gameObject);

    private void RemoveParticles(bool isNew)
    {
        var playingParticles = FindObjectOfType<ParticleSystem>();
        if (playingParticles != null) DestroyImmediate(playingParticles.gameObject);
    }
}

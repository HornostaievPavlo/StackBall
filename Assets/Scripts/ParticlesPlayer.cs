using UnityEngine;

public class ParticlesPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform ball;

    [SerializeField]
    private ParticleSystem floorHitParticle;  

    private void Start()
    {
        //ball.BreakableSurfaceHit.AddListener();
        //ball.UnbreakableSurfaceHit.AddListener();
        EventManager.FloorHit.AddListener(PlayFloorHitClip);
    }

    //private void PlayBreakableHitClip() => audioSource.PlayOneShot(breakableHitClip);
    //private void PlayUnbreakableHitClip() => audioSource.PlayOneShot(unbreakableHitClip);
    private void PlayFloorHitClip() => Instantiate(floorHitParticle.gameObject);

    
}

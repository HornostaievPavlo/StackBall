using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]
    private Ball ball;

    [SerializeField]
    private AudioClip defaultJumpClip;

    [SerializeField]
    private AudioClip breakableHitClip;

    [SerializeField]
    private AudioClip unbreakableHitClip;

    [SerializeField]
    private AudioClip floorHitClip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        ball.BallJumpedOnSurface.AddListener(PlayDefaultJumpClip);
        ball.BreakableSurfaceHit.AddListener(PlayBreakableHitClip);
        ball.UnBreakableSurfaceHit.AddListener(PlayUnbreakableHitClip);
        ball.FloorHit.AddListener(PlayFloorHitClip);
    }

    private void PlayDefaultJumpClip() => audioSource.PlayOneShot(defaultJumpClip);
    private void PlayBreakableHitClip() => audioSource.PlayOneShot(breakableHitClip);
    private void PlayUnbreakableHitClip() => audioSource.PlayOneShot(unbreakableHitClip);
    private void PlayFloorHitClip() => audioSource.PlayOneShot(floorHitClip);
}

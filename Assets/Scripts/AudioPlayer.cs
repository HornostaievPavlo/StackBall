using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
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

        EventManager.BallJumpedOnSurface.AddListener(PlayDefaultJumpClip);
        EventManager.BreakableSurfaceHit.AddListener(PlayBreakableHitClip);
        EventManager.UnbreakableSurfaceHit.AddListener(PlayUnbreakableHitClip);
        EventManager.FloorHit.AddListener(PlayFloorHitClip);
    }

    private void PlayDefaultJumpClip() => audioSource.PlayOneShot(defaultJumpClip);
    private void PlayBreakableHitClip() => audioSource.PlayOneShot(breakableHitClip);
    private void PlayUnbreakableHitClip() => audioSource.PlayOneShot(unbreakableHitClip);
    private void PlayFloorHitClip() => audioSource.PlayOneShot(floorHitClip);
}

using UnityEngine.Events;

public static class EventManager
{
    public static UnityEvent BallJumpedOnSurface = new UnityEvent();
    public static UnityEvent BreakableSurfaceHit = new UnityEvent();
    public static UnityEvent UnbreakableSurfaceHit = new UnityEvent();
    public static UnityEvent FloorHit = new UnityEvent();

    public static void JumpOnSurface() => BallJumpedOnSurface.Invoke();
    public static void HitBreakableSurface() => BreakableSurfaceHit.Invoke();
    public static void HitUnbreakableSurface() => UnbreakableSurfaceHit.Invoke();
    public static void HitFloor() => FloorHit.Invoke();
    //public static void JumpOnSurface() => BallJumpedOnSurface.Invoke();
    //public static void JumpOnSurface() => BallJumpedOnSurface.Invoke();
}

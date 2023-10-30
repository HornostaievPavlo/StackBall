using UnityEngine.Events;

public static class EventManager
{
    public static UnityEvent BallJumped = new UnityEvent();
    public static UnityEvent BreakableHit = new UnityEvent();
    public static UnityEvent UnbreakableHit = new UnityEvent();
    public static UnityEvent FloorHit = new UnityEvent();

    public static UnityEvent<int> NextLevelSelected = new UnityEvent<int>();

    public static void JumpOnSurface() => BallJumped.Invoke();
    public static void HitBreakableSurface() => BreakableHit.Invoke();
    public static void HitUnbreakableSurface() => UnbreakableHit.Invoke();
    public static void HitFloor() => FloorHit.Invoke();

    public static void CreateLevel(int number) => NextLevelSelected.Invoke(number);
}

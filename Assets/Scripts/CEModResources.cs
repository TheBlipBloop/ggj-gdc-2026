using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

[CreateAssetMenu(fileName = "CEModResources", menuName = "Scriptable Objects/CEModResources")]
public class CEModResources : CardEffect
{
    public int GuestsDelta;
    public int MoodDelta;
    public int SacrificesDelta;

    public override void Apply(GameState gameState)
    {
        int realDelta = TryChangeClammped(ref gameState.guests, GuestsDelta, 0, 10000);
        if (realDelta != 0)
        {
            Events.OnGuestsChanged.Invoke(realDelta);
        }

        Debug.Log(realDelta);

        // TODO : Get real numbers from these from design group
        realDelta = TryChangeClammped(ref gameState.mood, MoodDelta, -10, 4);
        if (realDelta != 0)
        {
            Events.OnMoodChanged.Invoke(realDelta);
        }

        realDelta = TryChangeClammped(ref gameState.sacrifices, SacrificesDelta, 0, 100000);
        if (realDelta != 0)
        {
            Events.OnSacrificesChanged.Invoke(realDelta);
        }
    }

    // ret @delta
    private int TryChangeClammped(ref int target, int delta, int min, int max)
    {
        int prev = target;
        target = Mathf.Clamp(target + delta, min, max);
        return target - prev;
    }
}

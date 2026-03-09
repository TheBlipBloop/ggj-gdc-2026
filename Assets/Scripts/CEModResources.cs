using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

[CreateAssetMenu(fileName = "CEModResources", menuName = "Scriptable Objects/CEModResources")]
public class CEModResources : CardEffect
{
    public int GuestsDelta; // if killing, adds to sacrifice automatically. Ask B.
    public int MoodDelta;
    public int SacrificesDelta;

    public override void Apply(GameState gameState)
    {
        int realGuestDelta = TryChangeClammped(ref gameState.guests, GuestsDelta, 0, 10000);
        if (realGuestDelta != 0)
        {
            Events.OnGuestsChanged.Invoke(realGuestDelta);

            // bad code 
            if (realGuestDelta < 0)
            {
                int guh = TryChangeClammped(ref gameState.sacrifices, -realGuestDelta, 0, 100000);
                if (guh != 0)
                {
                    Events.OnSacrificesChanged.Invoke(guh);
                }
            }
        }

        int realMoodDelta = TryChangeClammped(ref gameState.mood, MoodDelta, Game.instance.MinMood, Game.instance.MaxMood);
        if (realMoodDelta != 0)
        {
            Events.OnMoodChanged.Invoke(realMoodDelta);
        }

        int realSacrificeDelta = TryChangeClammped(ref gameState.sacrifices, SacrificesDelta, 0, 100000);
        if (realSacrificeDelta != 0)
        {
            Events.OnSacrificesChanged.Invoke(realSacrificeDelta);
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

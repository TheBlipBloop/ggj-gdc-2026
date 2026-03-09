using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

[CreateAssetMenu(fileName = "CardEffectSlaughter", menuName = "Scriptable Objects/CardEffectSlaughter")]
public class CardEffectSlaughter : CardEffect
{
    // Kills up to this many guests and adds to the sacrfice pool.
    public int maxToKill = 1;

    public int moodDelta = -2;

    public override void Apply(GameState gameState)
    {
        int realGuestDelta = TryChangeClammped(ref gameState.guests, -maxToKill, 0, 10000);
        if (realGuestDelta != 0)
        {
            gameState.guests += realGuestDelta;
            Events.OnGuestsChanged.Invoke(realGuestDelta);
            // gameState.ChangeGuests(realGuestDelta);
        }

        gameState.ChangeSacrifices(realGuestDelta);
        gameState.ChangeMood(moodDelta);
    }

    // ret @delta
    private int TryChangeClammped(ref int target, int delta, int min, int max)
    {
        int prev = target;
        target = Mathf.Clamp(target + delta, min, max);
        return target - prev;
    }
}

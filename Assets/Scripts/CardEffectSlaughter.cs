using UnityEngine;

[CreateAssetMenu(fileName = "CardEffectSlaughter", menuName = "Scriptable Objects/CardEffectSlaughter")]
public class CardEffectSlaughter : CardEffect
{
    // Kills up to this many guests and adds to the sacrfice pool.
    public int maxToKill = 1;

    public int moodDelta = -2;


    public override void Apply(GameState gameState)
    {
        gameState.KillGuests(maxToKill);
        gameState.ChangeMood(moodDelta);
    }
}

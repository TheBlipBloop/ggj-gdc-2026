using UnityEngine;

[CreateAssetMenu(fileName = "CERedraw", menuName = "Scriptable Objects/CERedraw")]
public class CERedraw : CardEffect
{
    public int GuestsDelta;
    public int MoodDelta;
    public int SacrificesDelta;

    public override void Apply(GameState gameState)
    {
        Game.ReplaceHand();
        gameState.ChangeGuests(GuestsDelta, false);
        gameState.ChangeMood(MoodDelta);
        gameState.ChangeSacrifices(SacrificesDelta);
    }
}

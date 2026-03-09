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
        // no killing
        gameState.ChangeGuests(GuestsDelta, false);
        gameState.ChangeMood(MoodDelta);
        gameState.ChangeSacrifices(SacrificesDelta);
    }
}

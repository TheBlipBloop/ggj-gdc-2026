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
        gameState.ChangeGuests(GuestsDelta);
        gameState.ChangeMood(MoodDelta);
        gameState.ChangeSacrifices(SacrificesDelta);
    }
}

using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "CEModResources", menuName = "Scriptable Objects/CEModResources")]
public class CEModResources : CardEffect
{
    public int GuestsDelta;
    public int MoodDelta;
    public int SacrificesDelta;

    public override GameState Apply(GameState gameState)
    {
        var newState = gameState.Clone();
        newState.guests += GuestsDelta;
        newState.mood += MoodDelta;
        newState.sacrifices += SacrificesDelta;

        return newState;
    }
}

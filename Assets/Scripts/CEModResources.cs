using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "CEModResources", menuName = "Scriptable Objects/CEModResources")]
public class CEModResources : CardEffect
{
    public int GuestsDelta;
    public int MoodDelta;
    public int SacrificesDelta;

    public override void Apply(GameState gameState)
    {
        
        gameState.guests += GuestsDelta;
        gameState.mood += MoodDelta;
        gameState.sacrifices += SacrificesDelta;
    }
}

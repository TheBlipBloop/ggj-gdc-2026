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

        if(GuestsDelta != 0)
        {
            Events.OnGuestsChanged.Invoke(GuestsDelta);
        }

        gameState.mood += MoodDelta;
        if(MoodDelta != 0)
        {
            Events.OnMoodChanged.Invoke(MoodDelta);
        }

        gameState.sacrifices += SacrificesDelta;
        if(SacrificesDelta != 0)
        {
            Events.OnSacrificesChanged.Invoke(SacrificesDelta);
        }
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "CERedraw", menuName = "Scriptable Objects/CERedraw")]
public class CERedraw : CardEffect
{
    public override void Apply(GameState gameState)
    {
        Game.ReplaceHand();
    }
}

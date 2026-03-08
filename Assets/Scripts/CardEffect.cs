
using UnityEngine;

public abstract class CardEffect : ScriptableObject
{
    public abstract GameState Apply(GameState gameState);
}

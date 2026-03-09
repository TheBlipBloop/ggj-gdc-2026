using UnityEngine;

public enum GamePhase
{
    Prep = 0,
    Party = 1,
    Slaughter = 2
}

public class GameState
{
    public int mood;
    public int guests;
    public int sacrifices;

    public int turnNumber;
    public GamePhase phase;

    public bool CanPlayCard(Card query)
    {
        // TODO

        return true;
    }
}

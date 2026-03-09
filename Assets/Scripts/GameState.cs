using UnityEngine;

public enum GamePhase
{
    Prep,
    Party,
    Slaughter
}

public class GameState
{
    public int mood;
    public int guests;
    public int sacrifices;

    public int turnNumber;
    public GamePhase phase;
}

using UnityEngine;

public class GameState
{
    public int mood;
    public int guests;
    public int sacrifices;

    public GameState Clone()
    {
        return new GameState
        {
            mood = this.mood,
            guests = this.guests,
            sacrifices = this.sacrifices
        };
    }
}

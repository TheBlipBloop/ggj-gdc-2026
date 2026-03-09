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

    public void ChangeMood(int delta)
    {
        int realMoodDelta = TryChangeClammped(ref mood, delta, Game.instance.MinMood, Game.instance.MaxMood);
        if (realMoodDelta != 0)
        {
            Events.OnMoodChanged.Invoke(realMoodDelta);
        }
    }

    public void ChangeGuests(int delta)
    {
        int realGuestDelta = TryChangeClammped(ref guests, delta, 0, 10000);
        if (realGuestDelta != 0)
        {
            Events.OnGuestsChanged.Invoke(realGuestDelta);
        }
    }

    public void ChangeSacrifices(int delta)
    {
        int realSacrificeDelta = TryChangeClammped(ref sacrifices, delta, 0, 100000);
        if (realSacrificeDelta != 0)
        {
            Events.OnSacrificesChanged.Invoke(realSacrificeDelta);
        }
    }

    private int TryChangeClammped(ref int target, int delta, int min, int max)
    {
        int prev = target;
        target = Mathf.Clamp(target + delta, min, max);
        return target - prev;
    }
}

using UnityEngine.Events;

public static class Events
{
    public static UnityEvent<int> OnMoodChanged = new UnityEvent<int>();
    public static UnityEvent<int> OnGuestsChanged = new UnityEvent<int>();
    public static UnityEvent<int> OnGuestsAdded = new UnityEvent<int>();
    public static UnityEvent<int> OnSacrificesChanged = new UnityEvent<int>();

    // num of killed
    public static UnityEvent<int> OnGuestKilled = new UnityEvent<int>();

    public static UnityEvent<int> OnGuestLeaves = new UnityEvent<int>();

    public static UnityEvent<Card> OnCardDrawn = new UnityEvent<Card>();
    public static UnityEvent<Card> OnCardPlayed = new UnityEvent<Card>();
    public static UnityEvent<Card> OnCardDiscarded = new UnityEvent<Card>();
    public static UnityEvent<int> OnTurnEnded = new UnityEvent<int>();
    public static UnityEvent<GamePhase> OnPhaseEnded = new UnityEvent<GamePhase>();
    public static UnityEvent<GamePhase> OnPhaseStarted = new UnityEvent<GamePhase>();
}

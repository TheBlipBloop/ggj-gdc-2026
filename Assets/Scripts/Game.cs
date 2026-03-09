using System.Diagnostics.Tracing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

// God class from hell.
// Static doer
public class Game : MonoBehaviour
{
    public static Game instance;

    public static int handSizePrep = 3;
    public static int handSizeParty = 5;
    public static int handSizeSlaughter = 3;
    public static int prepTurns = 1;
    public static int partyTurns = 9;

    [Header("Data")]

    [SerializeField]
    protected DeckInfo deck;
    
    [SerializeField]
    protected MoodThresholds moodThresholds;
    public int GuestDelta => moodThresholds.GetGuestDelta(gameState.mood);
    public int MinMood => moodThresholds.thresholds[0].threshold;
    public int MaxMood => moodThresholds.thresholds[moodThresholds.thresholds.Length - 1].threshold;

    [SerializeField]
    protected GameObject cardPrefab;

    [Header("Game")]

    [SerializeField]
    protected Hand hand;

    [SerializeField]
    public UnityEvent<CardInfo> onCardPlayedListener;

    public GameState gameState = new GameState();

    public static Card InstantiateCard(CardInfo cardInfo, Transform parent)
    {
        GameObject newInstance = Instantiate(instance.cardPrefab);
        newInstance.transform.SetParent(parent);

        Card cardInstance = newInstance.GetComponent<Card>();
        cardInstance.Bind(cardInfo);

        return cardInstance;
    }


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartGame();
    }

    public static void StartGame()
    {
        instance.gameState = new GameState();
        DrawCards(handSizePrep);
    }

    public static void DrawCards(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var newCard = DrawCard();
            Events.OnCardDrawn.Invoke(newCard);
        }
    }

    public static Card DrawCard()
    {
        var newCardInfo = instance.deck.DrawCard();
        var newCard = instance.hand.AddCard(newCardInfo);
        return newCard;
    }

    public static bool PlayCard(Card card)
    {
        if (!instance.gameState.CanPlayCard(card))
        {
            return false;
        }

        instance.hand.PlayCard(card);
        card.card.Apply(instance.gameState);
        Events.OnCardPlayed.Invoke(card);

        EndTurn();

        return true;
    }

    public static void ReplaceHand()
    {
        int cardCount = instance.hand.CardCount;
        ReplaceHand(cardCount);
    }

    public static void ReplaceHand(int newCount)
    {
        DiscardHand();
        DrawCards(newCount);
    }

    public static void DiscardHand()
    {
        instance.hand.DiscardHand();
    }

    private static void DiscardCard(Card target)
    {
        instance.hand.DiscardCard(target);
        Events.OnCardDiscarded.Invoke(target);
    }

    public static void EndTurn()
    {

        instance.gameState.turnNumber++;
        instance.gameState.ChangeGuests(instance.GuestDelta);

        if(instance.gameState.phase == GamePhase.Prep && instance.gameState.turnNumber > prepTurns)
        {
            EndPhase();
        }
        else if(instance.gameState.phase == GamePhase.Party && instance.gameState.turnNumber > partyTurns)
        {
            EndPhase();
        }
        else
        {
            DrawCard();    
        }
    }

    public static void EndPhase()
    {
        if (instance.gameState.phase == GamePhase.Prep)
        {
            Events.OnPhaseEnded.Invoke(instance.gameState.phase);
            DiscardHand();
            instance.gameState.phase++;
            instance.gameState.turnNumber = 0;
            Events.OnPhaseStarted.Invoke(instance.gameState.phase);
            DrawCards(handSizeParty);
        }
        else if (instance.gameState.phase == GamePhase.Party)
        {
            Events.OnPhaseEnded.Invoke(instance.gameState.phase);
            DiscardHand();
            instance.gameState.phase++;
            instance.gameState.turnNumber = 0;
            Events.OnPhaseStarted.Invoke(instance.gameState.phase);
            DrawCards(handSizeSlaughter);
        }
        if (instance.gameState.phase == GamePhase.Slaughter)
        {
            Events.OnPhaseEnded.Invoke(instance.gameState.phase);
            EndGame();
        }
    }

    public static void EndGame()
    {
        //TO DO
    }

    public static int GetGuestCount()
    {
        return instance.gameState.guests;
    }

}

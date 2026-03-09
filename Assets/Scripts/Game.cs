using System.Diagnostics.Tracing;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

[System.Serializable]
public class PhaseDeck
{
    public GamePhase phase;
    public DeckInfo deck;
}

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
    protected PhaseDeck[] phaseDecks;
    [SerializeField] protected Transform playPosition;
    
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

    public static DeckInfo GetDeckForPhase(GamePhase phase)
    {
        foreach (var phaseDeck in instance.phaseDecks)
        {
            if (phaseDeck.phase == phase)
            {
                return phaseDeck.deck;
            }
        }

        return null;
    }

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
        var newCardInfo = GetDeckForPhase(instance.gameState.phase).DrawCard();
        var newCard = instance.hand.AddCard(newCardInfo);
        return newCard;
    }

    public static bool PlayCard(Card card)
    {
        if (!instance.gameState.CanPlayCard(card))
        {
            return false;
        }

        card.transform.DOMove(instance.playPosition.position, 0.5f).OnComplete(() =>
        {
            ResolveCard(card);
        });

        return true;
    }

    public static void ResolveCard(Card card)
    {
        instance.hand.PlayCard(card);
        card.card.Apply(instance.gameState);
        Events.OnCardPlayed.Invoke(card);

        EndTurn();
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

        if(instance.gameState.phase == GamePhase.Prep && instance.gameState.turnNumber >= prepTurns)
        {
            EndPhase();
        }
        else if(instance.gameState.phase == GamePhase.Party && instance.gameState.turnNumber >= partyTurns)
        {
            EndPhase();
        }
        else if(instance.gameState.phase == GamePhase.Slaughter && instance.gameState.guests <= 0)
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
        else if (instance.gameState.phase == GamePhase.Slaughter)
        {
            Events.OnPhaseEnded.Invoke(instance.gameState.phase);
            EndGame();
        }
    }

    public static void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static int GetGuestCount()
    {
        Debug.Log("Game Over, Score: " + instance.gameState.sacrifices);
        return instance.gameState.guests;
    }

}

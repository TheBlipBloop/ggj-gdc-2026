using System.Diagnostics.Tracing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

// God class from hell.
// Static doer
public class Game : MonoBehaviour
{
    public static Game instance;
    
    public static int handSizePrep = 3;
    public static int handSizeParty = 5;
    public static int handSizeSlaughter = 3;

    [Header("Data")]

    [SerializeField]
    protected DeckInfo deck;

    [SerializeField]
    protected GameObject cardPrefab;

    [Header("Game")]

    [SerializeField]
    protected Hand hand;

    [SerializeField]
    public UnityEvent<CardInfo> onCardPlayedListener;

    private GameState gameState = new GameState();

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

    public static void PlayCard(Card card)
    {
        instance.hand.PlayCard(card);
        Events.OnCardPlayed.Invoke(card);
        EndTurn();
    }

    public static void ReplaceHand()
    {
        int cardCount = instance.hand.CardCount;
        DiscardHand();
        DrawCards(cardCount);
    }

    public static void DiscardHand()
    {
        // TO DO
    }

    private static void DiscardCard(int index)
    {
        // TO DO
        // Also make sure to invoke the OnCardDiscarded event
    }

    public static void EndTurn()
    {
        instance.gameState.turnNumber++;
        DrawCard();
    }

    public static void EndPhase()
    {
        if (instance.gameState.phase == GamePhase.Prep)
        {
            Events.OnPhaseEnded.Invoke(instance.gameState.phase);
            DiscardHand();
            instance.gameState.phase++;
            Events.OnPhaseStarted.Invoke(instance.gameState.phase);
            DrawCards(handSizeParty);
        }
        else if (instance.gameState.phase == GamePhase.Party)
        {
            Events.OnPhaseEnded.Invoke(instance.gameState.phase);
            DiscardHand();
            instance.gameState.phase++;
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
}

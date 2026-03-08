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

    // Update is called once per frame
    void Update()
    {

    }

    public static void DrawCards(int count)
    {
        for (int i = 0; i < count; i++)
        {
            DrawCard();
        }
    }

    public static void DrawCard()
    {
        var newCard = instance.deck.DrawCard();
        instance.hand.AddCard(newCard);
    }
}

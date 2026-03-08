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
    protected Deck deck;

    [SerializeField]
    protected GameObject cardPrefab;

    [Header("Game")]

    [SerializeField]
    protected Hand hand;

    [SerializeField]
    protected UnityEvent<Card> onCardPlayedListener;

    public static CardInstance InstantiateCard(Card cardInfo, Transform parent)
    {
        GameObject newInstance = Instantiate(instance.cardPrefab);
        newInstance.transform.SetParent(parent);

        CardInstance cardInstance = newInstance.GetComponent<CardInstance>();
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

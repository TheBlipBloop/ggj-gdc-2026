using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    protected List<Card> cards = new List<Card>();

    public int CardCount => cards.Count;

    [SerializeField]
    protected Transform cardHoldler;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cards.Clear();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public Card AddCard(CardInfo card)
    {
        Card newCard = Game.InstantiateCard(card, cardHoldler);
        cards.Add(newCard);
        return newCard;
    }

    public void PlayCard(Card card)
    {

    }

    public void HoverCard()
    {


    }
}

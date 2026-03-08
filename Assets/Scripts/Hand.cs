using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    protected List<Card> cards = new List<Card>();

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

    public void AddCard(CardInfo card)
    {
        Card newCard = Game.InstantiateCard(card, cardHoldler);
        cards.Add(newCard);
    }

    public void PlayCard()
    {

    }

    public void HoverCard()
    {


    }
}

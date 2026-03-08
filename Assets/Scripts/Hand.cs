using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    protected int handSize = 5;

    protected List<CardInstance> cards = new List<CardInstance>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cards.Clear();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddCard(Card card)
    {
        CardInstance newCard = Game.InstantiateCard(card, transform);
        cards.Add(newCard);
    }

    public void PlayCard()
    {

    }

    public void HoverCard()
    {


    }
}

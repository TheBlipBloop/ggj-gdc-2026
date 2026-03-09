using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    protected List<Card> cards = new List<Card>();

    public int CardCount => cards.Count;

    [SerializeField]
    protected Transform cardHoldler;

    [SerializeField]
    protected AnimationCurve _cardGap;

    [SerializeField]
    protected AnimationCurve _cardRadialSpread;

    [SerializeField]
    protected float cardSmoothSpeed = 1.5f;

    private float cardCountSmoothed = 0;

    private int selectedCardIndex = -1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // cards.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            if (i == selectedCardIndex)
            {
                cards[i].UpdateHovered();
            }
            else
            {
                cards[i].UpdateUnhovered();
            }

            SetCardPosition(i, cardCountSmoothed);


        }


        // guh
        float center = cards.Count / 2f;
        float distance = selectedCardIndex - center;


        // transform.eulerAngles = Vector3.forward * distance * -20f;

        cardCountSmoothed = Mathf.MoveTowards(cardCountSmoothed, cards.Count, Time.deltaTime * cardSmoothSpeed);

        if (Input.GetKeyDown(KeyCode.Mouse0) && selectedCardIndex >= 0 && selectedCardIndex < cards.Count)
        {
            Game.PlayCard(cards[selectedCardIndex]);
        }
    }

    protected void SetCardPosition(float cardIndex, float cardCount)
    {
        var card = cards[(int)cardIndex];

        float gap = _cardGap.Evaluate(cardCount);
        float radialGap = _cardRadialSpread.Evaluate(cardCount);
        float center = cardCount / 2f;
        float centeredOffset = cardIndex - center;

        // card.transform.eulerAngles = Vector3.forward * (radialGap * -centeredOffset);
        card.transform.localPosition = Vector3.right * (gap * centeredOffset) + card.GetPositionOffset();
        card.transform.localEulerAngles = -Vector3.forward * (radialGap * centeredOffset);
        // card.transform.position += card.transform.up * 0.1f;


        // distance to selected
        if (selectedCardIndex >= 0)
        {
            float distance = cardIndex - selectedCardIndex;

            if (distance > 0 && cardIndex != selectedCardIndex)
            {
                card.transform.localPosition += Vector3.right;
            }
            else
            {
                card.transform.localPosition -= Vector3.right;
            }
        }
    }

    public Card AddCard(CardInfo card)
    {
        Card newCard = Game.InstantiateCard(card, cardHoldler);
        cards.Add(newCard);

        int newCardIndex = cards.Count - 1;

        newCard.onStartHover.AddListener(() => HoverCard(newCard));
        newCard.onStopHover.AddListener(() => UnhoverCard(newCard));

        return newCard;
    }

    public void PlayCard(Card card)
    {
        DiscardCard(card);
        ResetSelection();
    }

    public void HoverCard(Card card)
    {
        selectedCardIndex = GetCardIndex(card);
    }

    public void UnhoverCard(Card card)
    {
        ResetSelection();
    }

    protected Card GetCard(int index)
    {
        return cards[index];
    }

    protected int GetCardIndex(Card query)
    {
        return cards.IndexOf(query);
    }

    public void DiscardHand()
    {
        int count = cards.Count;
        for (int i = 0; i < count; i++)
        {
            DiscardCard(0);
        }
    }

    public Card DiscardCard(int index)
    {
        var targetCard = cards[index];
        DiscardCard(targetCard);
        return targetCard;
    }

    public void DiscardCard(Card targetCard)
    {
        Destroy(targetCard.gameObject);
        cards.Remove(targetCard);

        ResetSelection();
    }

    void ResetSelection()
    {
        selectedCardIndex = -1;
    }
}

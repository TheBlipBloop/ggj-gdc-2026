using UnityEngine;

[CreateAssetMenu(fileName = "Deck", menuName = "Scriptable Objects/Deck")]
public class DeckInfo : ScriptableObject
{
    [System.Serializable]
    public class CardEntry
    {
        [SerializeField]
        public CardInfo card = null;

        [SerializeField]
        public float weight = 1f;
    }

    [SerializeField]
    public CardEntry[] CardEntries;

    [SerializeField]
    protected int CardCount = 100;

    /// <summary>
    /// Randomly picks a card with respect to weighted probabilities, etc
    /// </summary>
    /// <returns></returns>
    public CardInfo DrawCard()
    {
        // TODO : Weights
        int index = Random.Range(0, CardEntries.Length);
        return CardEntries[index].card;
    }
}

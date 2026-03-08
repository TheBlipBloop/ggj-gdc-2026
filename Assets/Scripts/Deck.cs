using UnityEngine;

[CreateAssetMenu(fileName = "Deck", menuName = "Scriptable Objects/Deck")]
public class Deck : ScriptableObject
{
    [System.Serializable]
    public class CardEntry
    {
        [SerializeField]
        public Card card = null;

        [SerializeField]
        public float weight = 1f;
    }

    [SerializeField]
    protected CardEntry[] CardEntries;

    [SerializeField]
    protected int CardCount = 100;

    /// <summary>
    /// Randomly picks a card with respect to weighted probabilities, etc
    /// </summary>
    /// <returns></returns>
    public Card DrawCard()
    {
        // TODO : Weights
        int index = Random.Range(0, CardEntries.Length);
        return CardEntries[index].card;
    }


}

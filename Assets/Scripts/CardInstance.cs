using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardInstance : MonoBehaviour
{
    [SerializeField]
    protected Card card = null;

    [SerializeField]
    protected RawImage front;

    [SerializeField]
    protected RawImage back;

    [SerializeField]
    protected TMP_Text titleText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bind(Card newCard)
    {
        card = newCard;
        front.texture = card.FrontTexture;
        back.texture = card.BackTexture;
        titleText.text = card.name; 
    }
}
